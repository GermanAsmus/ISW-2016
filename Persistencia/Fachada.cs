using System;
using System.Collections.Generic;

namespace Persistencia
{
    class FachadaPersistencia
    {
        /// <summary>
        /// Crea la Campaña en la base de datos
        /// </summary>
        /// <param name="pCampaña">Campaña a crear</param>
        /// <returns>Tipo de dato entero que representa el código en la base de datos de la campaña</returns>
        public int CrearCampaña(Campaña pCampaña)
        {
            FachadaCRUDCampaña fachadaCampaña = new FachadaCRUDCampaña();
            return fachadaCampaña.Create(pCampaña);
        }

        /// <summary>
        /// Actualiza la Campaña de la base de datos
        /// </summary>
        /// <param name="pCampaña">Campaña con los datos nuevos a actualizar</param>
        public void ActualizarCampaña(Campaña pCampaña)
        {
            FachadaCRUDCampaña fachadaCampaña = new FachadaCRUDCampaña();
            fachadaCampaña.Update(pCampaña);
        }

        /// <summary>
        /// Elimina una campaña de la base de datos
        /// </summary>
        /// <param name="pCampaña">Campaña a eliminar</param>
        public void EliminarCampaña(Campaña pCampaña)
        {
            FachadaCRUDCampaña fachadaCampaña = new FachadaCRUDCampaña();
            fachadaCampaña.Delete(fachadaCampaña.GetByCodigo(pCampaña.Codigo));
        }
        
        /// <summary>
        /// Devuelve las campañas que cumplen con los filtros
        /// </summary>
        /// <param name="argumentosFiltrado">Argumentos de filtro de las campañas</param>
        /// <returns>Tipo de dato Lista de Campañas que representan aquellas que cumplen con el filtro dado</returns>
        public List<Campaña> ObtenerCampañas(Dictionary<Type, object> argumentosFiltrado = null)
        {
            FachadaCRUDCampaña fachadaCampaña = new FachadaCRUDCampaña();
            return fachadaCampaña.GetAll(argumentosFiltrado);
        }

        /// <summary>
        /// Devuelve la campaña cuyo código es el suministrado
        /// </summary>
        /// <param name="pCodigoCamapaña">Código de la campaña a obtener</param>
        /// <returns>Tipo de dato Campaña que representa la buscada</returns>
        public Campaña ObtenerCampaña(int pCodigoCamapaña)
        {
            FachadaCRUDCampaña fachadaCampaña = new FachadaCRUDCampaña();
            return (fachadaCampaña.GetByCodigo(pCodigoCamapaña));
        }

        /// <summary>
        /// Crea el Banner en la base de datos
        /// </summary>
        /// <param name="pBanner">Banner a crear</param>
        /// <returns>Tipo de dato entero que representa el código en la base de datos del banner</returns>
        public int CrearBanner(Banner pBanner)
        {
            if (pBanner.Fuente.GetType() == typeof(FuenteTextoFijo))
            {
                pBanner.Fuente.Codigo = this.CrearFuente(pBanner.Fuente);
                pBanner.Fuente_Codigo = pBanner.Fuente.Codigo;
            }
            FachadaCRUDBanner fachadaBanner = new FachadaCRUDBanner();
            return fachadaBanner.Create(pBanner);
        }

        /// <summary>
        /// Actualiza el Banner de la base de datos
        /// </summary>
        /// <param name="pBanner">Banner con los datos nuevos a actualizar</param>
        public void ActualizarBanner(Banner pBanner)
        {
            if(pBanner.Fuente.GetType() == typeof(FuenteTextoFijo))
            {
                FachadaCRUDFuente fachadaFuente = new FachadaCRUDFuente();
                if (fachadaFuente.GetByCodigo(pBanner.Fuente_Codigo) == null)
                {
                    pBanner.Fuente_Codigo = fachadaFuente.Create(pBanner.Fuente);
                    pBanner.Fuente.Codigo = pBanner.Fuente_Codigo;
                }
                else
                {
                    this.ActualizarFuente(pBanner.Fuente);
                }
            }
            FachadaCRUDBanner fachadaBanner = new FachadaCRUDBanner();
            fachadaBanner.Update(pBanner);
        }

        /// <summary>
        /// Elimina un banner de la base de datos
        /// </summary>
        /// <param name="pBanner">Banner a eliminar</param>
        public void EliminarBanner(Banner pBanner)
        {
            Fuente pFuente = pBanner.Fuente;
            FachadaCRUDBanner fachadaBanner = new FachadaCRUDBanner();
            fachadaBanner.Delete(pBanner);
            if (pFuente.GetType() == typeof(FuenteTextoFijo))
            {
                this.EliminarFuente(pFuente);
            }
        }

        /// <summary>
        /// Devuelve los Banners que cumplen con los filtros
        /// </summary>
        /// <param name="argumentosFiltrado">Argumentos de filtro del banner</param>
        /// <returns>Tipo de dato Lista de Banners que representan aquellos que cumplen con el filtro dado</returns>
        public List<Banner> ObtenerBanners(Dictionary<Type, object> argumentosFiltrado = null)
        {
            FachadaCRUDBanner fachadaBanner = new FachadaCRUDBanner();
            return fachadaBanner.GetAll(argumentosFiltrado);
        }

        /// <summary>
        /// Devuelve el banner cuyo código es el suministrado
        /// </summary>
        /// <param name="pCodigoBanner">Código del Banner a obtener</param>
        /// <returns>Tipo de dato Banner que representa el buscado</returns>
        public Banner ObtenerBanner(int pCodigoBanner)
        {
            FachadaCRUDBanner fachadaBanner = new FachadaCRUDBanner();
            return (fachadaBanner.GetByCodigo(pCodigoBanner));
        }

        /// <summary>
        /// Crea la Fuente en la base de datos
        /// </summary>
        /// <param name="pFuente">Fuente a crear</param>
        /// <returns>Tipo de dato entero que representa el código en la base de datos de la Fuente</returns>
        public int CrearFuente(Fuente pFuente)
        {
            FachadaCRUDFuente fachadaFuente = new FachadaCRUDFuente();
            return fachadaFuente.Create(pFuente);
        }

        /// <summary>
        /// Actualiza la Fuente de la base de datos
        /// </summary>
        /// <param name="pFuente">Fuente con los datos nuevos a actualizar</param>
        public void ActualizarFuente(Fuente pFuente)
        {
            FachadaCRUDFuente fachadaFuente = new FachadaCRUDFuente();
            fachadaFuente.Update(pFuente);
        }

        /// <summary>
        /// Elimina una Fuente de la base de datos
        /// </summary>
        /// <param name="pFuente">Fuente a eliminar</param>
        public void EliminarFuente(Fuente pFuente)
        {
            FachadaCRUDFuente fachadaFuente = new FachadaCRUDFuente();
            fachadaFuente.Delete(pFuente);
        }

        /// <summary>
        /// Devuelve las Fuentes que cumplen con los filtros
        /// </summary>
        /// <param name="pFuente">Argumentos de filtro de la fuente</param>
        /// <returns>Tipo de dato Lista de Fuentes que representan aquellas que cumplen con el filtro dado</returns>
        public List<Fuente> ObtenerFuentes(Fuente pFuente = null)
        {
            Type filtro;
            if(pFuente == null)
            {
                filtro = null;
            }
            else
            {
                filtro = pFuente.GetType();
            }
            FachadaCRUDFuente fachadaFuente = new FachadaCRUDFuente();
            return fachadaFuente.GetAll(filtro);
        }

        /// <summary>
        /// Devuelve la fuente cuyo código es el suministrado
        /// </summary>
        /// <param name="pCodigoFuente">Código de la fuente a obtener</param>
        /// <returns>Tipo de dato Fuente que representa la buscada</returns>
        public Fuente ObtenerFuente(int pCodigoFuente)
        {
            FachadaCRUDFuente fachadaFuente = new FachadaCRUDFuente();
            return (fachadaFuente.GetByCodigo(pCodigoFuente));
        }
    }
}
