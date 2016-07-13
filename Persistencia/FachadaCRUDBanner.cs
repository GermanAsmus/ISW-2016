using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;

//Hace que sea visible para el Testing y los Servicios
[assembly: InternalsVisibleTo("Testings")]
[assembly: InternalsVisibleTo("Dominio")]
[assembly: InternalsVisibleTo("Servicios")]

namespace Persistencia
{
    class FachadaCRUDBanner
    {
        /// <summary>
        /// Constructor del CRUDFacade
        /// </summary>
        public FachadaCRUDBanner()
        {

        }

        /// <summary>
        /// Crea una Banner en la base de datos
        /// </summary>
        /// <param name="pBanner">Banner a almacenar en la base de datos</param>
        /// <returns>Tipo de dato entero que representa el código del banner agregado</returns>
        public virtual int Create(Banner pBanner)
        {
            using (UnitOfWork pUnitOfWork = new UnitOfWork())
            {
                pBanner.Fuente = null;
                pUnitOfWork.BannerRepository.Insert(pBanner);
                pUnitOfWork.Save();
                return pBanner.Codigo;
            }
        }

        /// <summary>
        /// Actualiza un Banner de la base de datos
        /// </summary>
        /// <param name="pBanner">Banner a actualizar de la base de datos</param>
        public virtual void Update(Banner pBanner)
        {
            using (UnitOfWork pUnitOfWork = new UnitOfWork())
            {
                Banner databaseBanner = this.GetByCodigo(pBanner.Codigo);
                pUnitOfWork.BannerRepository.Update(databaseBanner);
                pUnitOfWork.BannerRepository.ChangeValues(databaseBanner, pBanner);
                //Rangos Fecha
                List<RangoFecha> rangosFechaEliminados = ExtesionLista.GetDeleted<RangoFecha>(databaseBanner.RangosFecha, pBanner.RangosFecha);
                List<RangoFecha> rangosFechaModificados = ExtesionLista.GetModified<RangoFecha>(databaseBanner.RangosFecha, pBanner.RangosFecha);
                List<RangoFecha> rangosFechaAInsertar = ExtesionLista.GetNew<RangoFecha>(databaseBanner.RangosFecha, pBanner.RangosFecha);
                foreach (RangoFecha pRangoFecha in rangosFechaEliminados)
                {
                    pRangoFecha.Principal = null;
                    pUnitOfWork.RangoFechaRepository.DeleteWithRelated(pRangoFecha);
                }
                foreach (RangoFecha pRangoFecha in rangosFechaAInsertar)
                {
                    pRangoFecha.Principal = null;
                    pUnitOfWork.RangoFechaRepository.Insert(pRangoFecha);
                }
                foreach (RangoFecha pRangoFecha in rangosFechaModificados)
                {
                    //Actualizar Rango Fecha
                    RangoFecha rangoFechaOriginal = databaseBanner.RangosFecha.Find(x => x.Equals(pRangoFecha));
                    pUnitOfWork.RangoFechaRepository.ChangeValues(rangoFechaOriginal, pRangoFecha);
                    //Rangos Horarios
                    List<RangoHorario> rangosHorariosAInsertar = pRangoFecha.RangosHorario;
                    for (int i = rangoFechaOriginal.RangosHorario.Count - 1; i >= 0; i--) 
                    {
                        pUnitOfWork.RangoHorarioRepository.Delete(rangoFechaOriginal.RangosHorario[i]);
                    }
                    foreach (RangoHorario pRangoHorario in rangosHorariosAInsertar)
                    {
                        pRangoHorario.RangoFecha = null;
                        pUnitOfWork.RangoHorarioRepository.Insert(pRangoHorario);
                    }
                }
                pUnitOfWork.Save();
            }
        }

        /// <summary>
        /// Elimina un Banner de la base de datos
        /// </summary>
        /// <param name="pBanner">Banner a eliminar</param>
        public virtual void Delete(Banner pBanner)
        {
            using (UnitOfWork pUnitOfWork = new UnitOfWork())
            {
                pUnitOfWork.BannerRepository.DeleteWithRelated(pBanner);
                pUnitOfWork.Save();
            }
        }

        /// <summary>
        /// Obtiene una instancia de Banner
        /// </summary>
        /// <param name="pBannerCodigo">Código del Banner que se desea obtener</param>
        /// <returns>Tipo de dato Banner que representa el buscado por código</returns>
        public virtual Banner GetByCodigo(int pBannerCodigo)
        {
            using (UnitOfWork pUnitOfWork = new UnitOfWork())
            {
                Banner banner = pUnitOfWork.BannerRepository.GetByCodigo(pBannerCodigo);
                foreach (RangoFecha rangoFecha in banner.RangosFecha)
                {
                    RangoFecha auxiliarRangoFecha = pUnitOfWork.RangoFechaRepository.GetByCodigo(rangoFecha.Codigo);
                    rangoFecha.RangosHorario = auxiliarRangoFecha.RangosHorario;
                    rangoFecha.Principal = auxiliarRangoFecha.Principal;
                }
                return banner;
            }
        }
        
        /// <summary>
        /// Obtiene todos los Banners de la base de datos
        /// </summary>
        /// <returns>Tipo de dato Lista que representa los Banners almacenados en la base de dato</returns>
        public virtual List<Banner> GetAll()
        {
            using (UnitOfWork pUnitOfWork = new UnitOfWork())
            {
                List<Banner> listaBanners = pUnitOfWork.BannerRepository.GetAll();
                foreach (Banner banner in listaBanners)
                {
                    pUnitOfWork.BannerRepository.Queryable.Include("RangosFecha").ToList();
                    foreach (RangoFecha rangoFecha in banner.RangosFecha)
                    {
                        pUnitOfWork.RangoFechaRepository.Queryable.Include("RangosHorario").ToList();
                    }
                    pUnitOfWork.BannerRepository.Queryable.Include("Fuente");
                }
                return listaBanners;
            }
        }

        /// <summary>
        /// Obtiene todos los Banner de la base de datos que cumplen con el filtro
        /// </summary>
        /// <param name="argumentosFiltrado">Argumentos para filtrar banners</param>
        /// <returns>Tipo de dato Lista de Banners a filtrar</returns>
        public virtual List<Banner> GetAll(Dictionary<Type, object> argumentosFiltrado)
        {
            using (UnitOfWork pUnitOfWork = new UnitOfWork())
            {
                //usar tipos simple(no objetos)  porque tirar error si se usan objetos
                string nombre = (string)argumentosFiltrado[typeof(string)];
                IQueryable<Banner> result = from banner in pUnitOfWork.BannerRepository.Queryable.Include("RangosFecha").Include("Fuente")
                                            where banner.Nombre.Contains(nombre)
                                            select banner;
                List<Banner> resultado = new List<Banner>();
                //FILTRAR FECHA
                if (argumentosFiltrado.ContainsKey(typeof(RangoFecha)))
                {
                    RangoFecha pRF = (RangoFecha)argumentosFiltrado[typeof(RangoFecha)];
                    DateTime fechaI = pRF.FechaInicio.Date;
                    DateTime fechaF = pRF.FechaFin.Date;
                    foreach (var banner in result)
                    {
                        IQueryable<RangoFecha> rangoFecha = banner.RangosFecha.AsQueryable<RangoFecha>();
                        var auxiliar = from rf in rangoFecha
                                       where ((rf.FechaInicio.CompareTo(fechaI) <= 0 && rf.FechaFin.CompareTo(fechaI) >= 0) ||
                                               ((rf.FechaInicio.CompareTo(fechaF) <= 0 && rf.FechaFin.CompareTo(fechaF) >= 0)) ||
                                               (rf.FechaInicio.CompareTo(fechaI) >= 0 && rf.FechaFin.CompareTo(fechaF) <= 0))
                                       select rf;
                        if (auxiliar.ToList().Count != 0)
                        {
                            resultado.Add(banner);
                        }
                    }
                }
                else
                {
                    resultado = result.ToList();
                }
                //FILTRAR FUENTES
                if (argumentosFiltrado.ContainsKey(typeof(Fuente)))
                {
                    Type pTipofuente = (Type) argumentosFiltrado[typeof(Fuente)];
                    for (int i = resultado.Count - 1; i >= 0; i--)
                    {
                        if(!(resultado[i].Fuente.GetType() == pTipofuente))
                        {
                            resultado.RemoveAt(i);
                        }
                    }
                }
                foreach (Banner banner in resultado)
                {
                    foreach (RangoFecha rangoFecha in banner.RangosFecha)
                    {
                        pUnitOfWork.RangoFechaRepository.Queryable.Include("RangosHorario").ToList();
                    }
                }
                return resultado;
            }
        }
    }
}