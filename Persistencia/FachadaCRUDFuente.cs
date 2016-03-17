using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;

namespace Persistencia
{
    class FachadaCRUDFuente
    {
        /// <summary>
        /// Constructor del CRUDFacade
        /// </summary>
        public FachadaCRUDFuente()
        {

        }

        /// <summary>
        /// Crea una Fuente en la base de datos
        /// </summary>
        /// <param name="pFuente">Fuente a almacenar en la base de datos</param>
        /// <returns>Tipo de dato entero que representa el código de la Fuente agregado</returns>
        public virtual int Create(Fuente pFuente)
        {
            using (UnitOfWork pUnitOfWork = new UnitOfWork())
            {
                pUnitOfWork.FuenteRepository.Insert(pFuente);
                pUnitOfWork.Save();
                return pFuente.Codigo;
            }
        }

        /// <summary>
        /// Actualiza una Fuente de la base de datos
        /// </summary>
        /// <param name="pFuente">Fuente a actualizar de la base de datos</param>
        public virtual void Update(Fuente pFuente)
        {
            using (UnitOfWork pUnitOfWork = new UnitOfWork())
            {
                pUnitOfWork.FuenteRepository.Update(pFuente);
                pUnitOfWork.Save();
            }
        }

        /// <summary>
        /// Elimina una Fuente de la base de datos
        /// </summary>
        /// <param name="pFuente">Fuente a eliminar</param>
        public virtual void Delete(Fuente pFuente)
        {
            using (UnitOfWork pUnitOfWork = new UnitOfWork())
            {
                this.EliminarBannersAsociados(pFuente);
                pUnitOfWork.FuenteRepository.Delete(pFuente);
                pUnitOfWork.Save();
            }
        }

        /// <summary>
        /// Elmina los Banners Asociados con la Fuente dada por parámetro
        /// </summary>
        /// <param name="pFuente">Fuente suministrada por parámetro</param>
        private void EliminarBannersAsociados(Fuente pFuente)
        {
            using(UnitOfWork pUnitOfWork = new UnitOfWork())
            {
                int codigoFuente = pFuente.Codigo;
                IQueryable<Banner> result = from banner in pUnitOfWork.BannerRepository.Queryable.Include("Fuente")
                                            where banner.Fuente_Codigo == codigoFuente
                                            select banner;
                FachadaCRUDBanner fachadaBanner = new FachadaCRUDBanner();
                foreach (Banner pBanner in result)
                {
                    fachadaBanner.Delete(fachadaBanner.GetByCodigo(pBanner.Codigo));
                }
                pUnitOfWork.Save();
            }
        }

        /// <summary>
        /// Obtiene todas las fuentes de la base de datos
        /// </summary>
        /// <returns>Tipo de dato Lista que representa las Fuentes almacenadas en la base de datos</returns>
        public virtual List<Fuente> GetAll()
        {
            using (UnitOfWork pUnitOfWork = new UnitOfWork())
            {
                return pUnitOfWork.FuenteRepository.GetAll();
            }
        }

        /// <summary>
        /// Obtiene todas las fuentes de la base de datos
        /// </summary>
        /// <param name="fuenteTipo">Tipo de fuente para filtrar</param>
        /// <returns>Tipo de dato Lista que representa las Fuentes almacenadas en la base de datos</returns>
        public virtual List<Fuente> GetAll(Type fuenteTipo)
        {
            using (UnitOfWork pUnitOfWork = new UnitOfWork())
            {
                IQueryable<Fuente> result = from Fuente in pUnitOfWork.FuenteRepository.Queryable
                                            select Fuente;
                return result.ToList().FindAll(fuente => fuente.GetType() == fuenteTipo as Type);
            }
        }

        /// <summary>
        /// Obtiene una instancia de Fuente
        /// </summary>
        /// <param name="pFuenteCodigo">Código de la Fuente que se desea obtener</param>
        /// <returns>Tipo de dato Fuente que representa la buscada por código y Tipo</returns>
        public virtual Fuente GetByCodigo(int pFuenteCodigo)
        {
            using (UnitOfWork pUnitOfWork = new UnitOfWork())
            {
                return (Fuente) pUnitOfWork.FuenteRepository.GetByCodigo(pFuenteCodigo);
            }
        }
    }
}
