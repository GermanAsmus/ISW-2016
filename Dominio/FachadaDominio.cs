using System;
using System.Collections.Generic;

namespace Dominio
{
    class FachadaDominio
    {
        #region Inicializar
        /// <summary>
        /// Inicializa el Controlador banner y el de campaña
        /// </summary>
        public static void Inicializar()
        {
            ControladorBanner.Inicializar();
            ControladorCampaña.Inicializar();
        }
        #endregion

        #region Cargar
        /// <summary>
        /// Carga la lista de Banners en la lógica
        /// </summary>
        /// <param name="fecha">Fecha de los banners a cargar a cargar</param>
        /// <param name="cargaInicial">Booleano que determina si es la carga inicial o no</param>
        public static void CargarBanners(DateTime fecha, bool cargaInicial = false)
        {
            ControladorBanner.CargarEnMemoria(fecha);
            if (cargaInicial)
            {
                ControladorBanner.CargaInicial();
            }
        }

        /// <summary>
        /// Carga la lista de Campañas en la lógica
        /// </summary>
        /// <param name="fecha">Fecha de las campañas a cargar a cargar</param>
        /// <param name="cargaInicial">Booleano que determina si es la carga inicial o no</param>
        public static void CargarCampañas(DateTime fecha, bool cargaInicial = false)
        {
            ControladorCampaña.CargarEnMemoria(fecha);
            if (cargaInicial)
            {
                ControladorCampaña.CargaInicial();
            }
        }
        #endregion

        #region Agregar
        /// <summary>
        /// Agrega un Banner en la lista de la lógica
        /// </summary>
        /// <param name="pBanner">Banner a agregar</param>
        public static void AgregarBanner(Banner pBanner)
        {
            ControladorBanner.Agregar(pBanner);
        }

        /// <summary>
        /// Agrega una Campaña en la lista de la lógica
        /// </summary>
        /// <param name="pBanner">Campaña a agregar</param>
        public static void AgregarCampaña(Campaña pCampaña)
        {
            ControladorCampaña.Agregar(pCampaña);
        }
        #endregion

        #region Modificar
        /// <summary>
        /// Modifica un Banner de la lista de la lógica
        /// </summary>
        /// <param name="pBanner">Banner a modificar</param>
        public static void ModificarBanner(Banner pBanner)
        {
            ControladorBanner.Modificar(pBanner);
        }

        /// <summary>
        /// Modifica una Campaña de la lista de la lógica
        /// </summary>
        /// <param name="pBanner">Banner a modificar</param>
        public static void ModificarCampaña(Campaña pCampaña)
        {
            ControladorCampaña.Modificar(pCampaña);
        }
        #endregion

        #region Eliminar
        /// <summary>
        /// Elimina un Banner de la lista de la lógica
        /// </summary>
        /// <param name="pBanner">Banner a eliminar</param>
        public static void EliminarBanner(Banner pBanner)
        {
            ControladorBanner.Eliminar(pBanner);
        }

        /// <summary>
        /// Elimina una Campaña de la lista de la lógica
        /// </summary>
        /// <param name="pBanner">Campaña a eliminar</param>
        public static void EliminarCampaña(Campaña pCampaña)
        {
            ControladorCampaña.Eliminar(pCampaña);
        }
        #endregion

        #region Obtener Banner
        /// <summary>
        /// Obtiene todos los Banners que cumplen con un determinado filtro
        /// </summary>
        /// <param name="argumentosFiltrado">Argumentos para filtrar Banners</param>
        /// <returns>Tipo de dato Lista que representa los Banners filtrados</returns>
        public static List<Banner> ObtenerBanners(Dictionary<Type, object> argumentosFiltrado = null)
        {
            return ControladorBanner.ObtenerBanners(argumentosFiltrado);
        }

        /// <summary>
        /// Obtiene el banner correspondiente con respecto a la fecha y a la hora
        /// </summary>
        /// <param name="pHoraActual">Hora Actual</param>
        /// <param name="pFechaActual">Fecha Actual</param>
        /// <returns>Tipo de dato Banner que representa el Banner Siguiente a mostrar</returns>
        public static Banner ObtenerBannerSiguiente()
        {
            return ControladorBanner.ObtenerSiguiente();
        }

        /// <summary>
        /// Obtiene el Banner que se corresponde con el código
        /// </summary>
        /// <param name="pCodigoBanner">Codigo de Banner de la imagen a buscar</param>
        /// <returns>Banner cuyo código es el suminitrado</returns>
        public static Banner ObtenerBannerPorCodigo(int pCodigoCampaña)
        {
            return ControladorBanner.ObtenerBannerPorCodigo(pCodigoCampaña);
        }

        //public static 
        #endregion

        #region Obtener Campaña
        /// <summary>
        /// Obtiene todos las Campañas que cumplen con un determinado filtro
        /// </summary>
        /// <param name="argumentosFiltrado">Argumentos para filtrar Campañas</param>
        /// <returns>Tipo de dato Lista que representa las Campañas filtradas</returns>
        public static List<Campaña> ObtenerCampañas(Dictionary<Type, object> argumentosFiltrado = null)
        {
            return ControladorCampaña.ObtenerCampañas(argumentosFiltrado);
        }

        /// <summary>
        /// Obtiene la campaña correspondiente con respecto a la fecha y a la hora
        /// </summary>
        /// <returns>Tipo de dato Campaña que representa la campaña Siguiente a mostrar</returns>
        public static Campaña ObtenerCampañaSiguiente()
        {
            return ControladorCampaña.ObtenerSiguiente();
        }

        /// <summary>
        /// Obtiene la campaña que se corresponde con el código
        /// </summary>
        /// <param name="pCodigoCampaña">Codigo de campaña de la imagen a buscar</param>
        /// <returns>Campaña cuyo código es el suminitrado</returns>
        public static Campaña ObtenerCampañaPorCodigo(int pCodigoCampaña)
        {
            return ControladorCampaña.ObtenerCampañaPorCodigo(pCodigoCampaña);
        }
        #endregion

        #region Obtener Fuente
        /// <summary>
        /// Obtiene la Fuente que se corresponde con el código
        /// </summary>
        /// <param name="pCodigoFuente">Codigo de Fuente de la imagen a buscar</param>
        /// <returns>Fuente cuyo código es el suminitrado</returns>
        public static IFuente ObtenerFuentePorCodigo(int pCodigoFuente)
        {
            return ControladorFuente.ObtenerFuentePorCodigo(pCodigoFuente);
        }
        #endregion

        #region Rangos Horarios Ocupados
        /// <summary>
        /// Obtiene los Rangos Horarios Ocupados para un cierto Rango de Fechas
        /// </summary>
        /// <param name="pRangoFecha">Rango de Fechas</param>
        /// <returns>Tipo de dato Lista de Rangos Horarios que representa los rangos horarios ocupados</returns>
        public static List<RangoHorario> RangosHorariosOcupadosBanner(RangoFecha pRangoFecha)
        {
            return ControladorBanner.RangosHorariosOcupados(pRangoFecha);
        }

        /// <summary>
        /// Obtiene los Rangos Horarios Ocupados para un cierto Rango de Fechas
        /// </summary>
        /// <param name="pRangoFecha">Rango de Fechas</param>
        /// <returns>Tipo de dato Lista de Rangos Horarios que representa los rangos horarios ocupados</returns>
        public static List<RangoHorario> RangosHorariosOcupadosCampaña(RangoFecha pRangoFecha)
        {
            return ControladorCampaña.RangosHorariosOcupados(pRangoFecha);
        }
        #endregion
    }
}
