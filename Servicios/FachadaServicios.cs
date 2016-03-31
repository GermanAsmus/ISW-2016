using Persistencia;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio;
using System.Runtime.CompilerServices;
using log4net;
using System.Threading;

[assembly: InternalsVisibleTo("UI")]

namespace Servicios
{
    /// <summary>
    /// Clase responsable de la Comunicación entre las diversas partes de la Aplicación: Dominio, UI, Persistencia.
    /// </summary>
    class FachadaServicios
    {
        public static ILog ObtenerLogger()
        {
            return Logging.Logger;
        }

        #region Banner
        /// <summary>
        /// Agrega el Banner a la base de datos y al Dominio
        /// </summary>
        /// <param name="pBanner">Banner a agregar</param>
        public static void AgregarBanner(Dominio.Banner pBanner)
        {
            Persistencia.Fachada fachada = IoCContainerLocator.GetType<Persistencia.Fachada>();
            pBanner.Codigo = fachada.CrearBanner(AutoMapper.Map<Dominio.Banner, Persistencia.Banner>(pBanner));
            IoCContainerLocator.GetType<Dominio.Fachada>().Agregar(pBanner);
        }

        /// <summary>
        /// Modifica el Banner en la base de datos y en el Dominio
        /// </summary>
        /// <param name="pBanner">Banner a modificar</param>
        public static void ModificarBanner(Dominio.Banner pBanner)
        {
            Persistencia.Fachada fachada = IoCContainerLocator.GetType<Persistencia.Fachada>();
            fachada.ActualizarBanner(AutoMapper.Map<Dominio.Banner, Persistencia.Banner>(pBanner));
            IoCContainerLocator.GetType<Dominio.Fachada>().Modificar(pBanner);
        }

        /// <summary>
        /// Elimina el Banner en la base de datos y en el Dominio
        /// </summary>
        /// <param name="pBanner">Banner a eliminar</param>
        public static void EliminarBanner(Dominio.Banner pBanner)
        {
            Persistencia.Fachada fachada = IoCContainerLocator.GetType<Persistencia.Fachada>();
            fachada.EliminarBanner(AutoMapper.Map<Dominio.Banner, Persistencia.Banner>(pBanner));
            IoCContainerLocator.GetType<Dominio.Fachada>().Eliminar(pBanner);
        }

        /// <summary>
        /// Obtiene todos los Banners que cumplen con un determinado filtro
        /// </summary>
        /// <param name="argumentosFiltrado">Argumentos para filtrar Banners</param>
        /// <returns>Tipo de dato Lista que representa los Banners filtrados</returns>
        public static List<Dominio.Banner> ObtenerBanners(Dictionary<Type, object> argumentosFiltrado = null)
        {
            Persistencia.Fachada fachada = IoCContainerLocator.GetType<Persistencia.Fachada>();
            Type tipoDeFiltrado = typeof(Dominio.RangoFecha);
            if (argumentosFiltrado != null)
            {
                if (argumentosFiltrado.ContainsKey(typeof(Dominio.RangoFecha)))
                {
                    argumentosFiltrado.Add(typeof(Persistencia.RangoFecha),
                                            AutoMapper.Map<Dominio.RangoFecha, Persistencia.RangoFecha>
                                            ((Dominio.RangoFecha)argumentosFiltrado[typeof(Dominio.RangoFecha)]));
                    argumentosFiltrado.Remove(typeof(Dominio.RangoFecha));
                }
                if (argumentosFiltrado.ContainsKey(typeof(Dominio.Fuente)))
                {
                    argumentosFiltrado.Add(typeof(Persistencia.Fuente),
                                            (AutoMapper.Map<Dominio.Fuente, Persistencia.Fuente>
                                            ((Dominio.Fuente)argumentosFiltrado[typeof(Dominio.Fuente)])).GetType());
                    argumentosFiltrado.Remove(typeof(Dominio.Fuente));
                }
            }
            return (AutoMapper.Map<List<Persistencia.Banner>, List<Dominio.Banner>>(fachada.ObtenerBanners(argumentosFiltrado)));
        }

        /// <summary>
        /// Obtiene los Rangos Horarios Ocupados para un cierto Rango de Fechas
        /// </summary>
        /// <param name="pRangoFecha">Rango de Fechas</param>
        /// <returns>Tipo de dato Lista de Rangos Horarios que representa los rangos horarios ocupados</returns>
        public static List<Dominio.RangoHorario> RangosHorariosOcupadosBanner(Dominio.RangoFecha pRangoFecha)
        {
            Dictionary<Type, object> argumentos = new Dictionary<Type, object>();
            argumentos.Add(typeof(string), "");
            argumentos.Add(typeof(Dominio.RangoFecha), pRangoFecha);
            List<Dominio.RangoFecha> listaRangosFecha = new List<Dominio.RangoFecha>();
            foreach (Dominio.Banner pBanner in ObtenerBanners(argumentos))
            {
                listaRangosFecha.AddRange(pBanner.ListaRangosFecha);
            }
            return ListaRangosHorariosRH(listaRangosFecha);
        }
        #endregion

        #region Campaña
        /// <summary>
        /// Agrega la Campaña a la base de datos
        /// </summary>
        /// <param name="pCampaña">Campaña a agregar</param>
        public static void AgregarCampaña(Dominio.Campaña pCampaña)
        {
            Persistencia.Fachada fachada = IoCContainerLocator.GetType<Persistencia.Fachada>();
            pCampaña.Codigo = fachada.CrearCampaña(AutoMapper.Map<Dominio.Campaña, Persistencia.Campaña>(pCampaña));
            IoCContainerLocator.GetType<Dominio.Fachada>().Agregar(pCampaña);
            GC.Collect();
        }

        /// <summary>
        /// Modifica la Campaña en la base de datos y en el Dominio
        /// </summary>
        /// <param name="pCampaña">Campaña a modificar</param>
        public static void ModificarCampaña(Dominio.Campaña pCampaña)
        {
            Persistencia.Fachada fachada = IoCContainerLocator.GetType<Persistencia.Fachada>();
            fachada.ActualizarCampaña(AutoMapper.Map<Dominio.Campaña, Persistencia.Campaña>(pCampaña));
            IoCContainerLocator.GetType<Dominio.Fachada>().Modificar(pCampaña);
        }

        /// <summary>
        /// Elimina la Campaña en la base de datos y en el Dominio
        /// </summary>
        /// <param name="pCampaña">Campaña a eliminar</param>
        public static void EliminarCampaña(Dominio.Campaña pCampaña)
        {
            Persistencia.Fachada fachada = IoCContainerLocator.GetType<Persistencia.Fachada>();
            fachada.EliminarCampaña(AutoMapper.Map<Dominio.Campaña, Persistencia.Campaña>(pCampaña));
            IoCContainerLocator.GetType<Dominio.Fachada>().Eliminar(pCampaña);
        }

        /// <summary>
        /// Obtiene todos las Campañas que cumplen con un determinado filtro
        /// </summary>
        /// <param name="argumentosFiltrado">Argumentos para filtrar Campañas</param>
        /// <returns>Tipo de dato Lista que representa las Campañas filtradas</returns>
        public static List<Dominio.Campaña> ObtenerCampañas(Dictionary<Type, object> argumentosFiltrado = null)
        {
            Persistencia.Fachada fachada = IoCContainerLocator.GetType<Persistencia.Fachada>();
            if (argumentosFiltrado != null)
            {
                if (argumentosFiltrado.ContainsKey(typeof(Dominio.RangoFecha)))
                { 
                    argumentosFiltrado.Add(typeof(Persistencia.RangoFecha),
                                            AutoMapper.Map<Dominio.RangoFecha, Persistencia.RangoFecha>
                                            ((Dominio.RangoFecha)argumentosFiltrado[typeof(Dominio.RangoFecha)]));
                    argumentosFiltrado.Remove(typeof(Dominio.RangoFecha));
                }
            }
            return (AutoMapper.Map<List<Persistencia.Campaña>, List<Dominio.Campaña>>(fachada.ObtenerCampañas(argumentosFiltrado)));
        }

        /// <summary>
        /// Obtiene las imágenes de la campaña
        /// </summary>
        /// <param name="pCodigoCamapaña">Código de la Campaña</param>
        /// <returns>Tipo de dato Lista de Imágenes que representa la lista de imágenes de la campaña</returns>
        public static List<Dominio.Imagen> ObtenerImagenesCampaña(int pCodigoCampaña)
        {
            return AutoMapper.Map<List<Persistencia.Imagen>, List<Dominio.Imagen>>
                        (IoCContainerLocator.GetType<Persistencia.Fachada>().ObtenerImagenesCampaña(pCodigoCampaña));
        }

        /// <summary>
        /// Obtiene los Rangos Horarios Ocupados para un cierto Rango de Fechas
        /// </summary>
        /// <param name="pRangoFecha">Rango de Fechas</param>
        /// <returns>Tipo de dato Lista de Rangos Horarios que representa los rangos horarios ocupados</returns>
        public static List<Dominio.RangoHorario> RangosHorariosOcupadosCampaña(Dominio.RangoFecha pRangoFecha)
        {
            Dictionary<Type, object> argumentos = new Dictionary<Type, object>();
            argumentos.Add(typeof(string), "");
            argumentos.Add(typeof(Dominio.RangoFecha), pRangoFecha);
            List<Dominio.RangoFecha> listaRangosFecha = new List<Dominio.RangoFecha>();
            foreach (Dominio.Campaña pCampaña in ObtenerCampañas(argumentos))
            {
                listaRangosFecha.AddRange(pCampaña.ListaRangosFecha);
            }
            return ListaRangosHorariosRH(listaRangosFecha);
        }
        #endregion

        #region Fuente
        /// <summary>
        /// Agrega la Fuente a la base de datos y al Dominio si corresponde
        /// </summary>
        /// <param name="pFuente">Fuente a agregar</param>
        public static void AgregarFuente(Dominio.Fuente pFuente)
        {
            Persistencia.Fachada fachada = IoCContainerLocator.GetType<Persistencia.Fachada>();
            pFuente.Codigo = fachada.CrearFuente(AutoMapper.Map<Dominio.Fuente, Persistencia.Fuente>(pFuente));
            GC.Collect();
        }

        /// <summary>
        /// Modifica la Fuente en la base de datos
        /// </summary>
        /// <param name="pFuente">Fuente a modificar</param>
        public static void ModificarFuente(Dominio.Fuente pFuente)
        {
            Persistencia.Fachada fachada = IoCContainerLocator.GetType<Persistencia.Fachada>();
            fachada.ActualizarFuente(AutoMapper.Map<Dominio.Fuente, Persistencia.Fuente>(pFuente));
        }

        /// <summary>
        /// Elimina la Fuente en la base de datos y en el Dominio
        /// </summary>
        /// <param name="pFuente">Campaña a eliminar</param>
        public static void EliminarFuente(Dominio.Fuente pFuente)
        {
            Persistencia.Fachada fachada = IoCContainerLocator.GetType<Persistencia.Fachada>();
            fachada.EliminarFuente(AutoMapper.Map<Dominio.Fuente, Persistencia.Fuente>(pFuente));
        }

        /// <summary>
        /// Obtiene todos las Fuentes que cumplen con un determinado filtro
        /// </summary>
        /// <param name="argumentosFiltrado">Argumentos para filtrar Fuente</param>
        /// <returns>Tipo de dato Lista que representa las Fuentes filtradas</returns>
        public static List<Dominio.Fuente> ObtenerFuentes(Dominio.Fuente argumentoFiltro = null)
        {
            Persistencia.Fachada fachada = IoCContainerLocator.GetType<Persistencia.Fachada>();
            return (AutoMapper.Map<List<Persistencia.Fuente>, List<Dominio.Fuente>>
                            (fachada.ObtenerFuentes(AutoMapper.Map<Dominio.Fuente,Persistencia.Fuente>(argumentoFiltro))));
        }
        #endregion

        /// <summary>
        /// Obtiene los rangos horarios de una lista de rangos de fecha (concatena)
        /// </summary>
        /// <param name="listaRangosFecha">Lista de Rangos de Fecha</param>
        /// <returns>Tipo de dato Lista de Rangos Horarios que representa los rangos horarios que poseen los de fecha</returns>
        private static List<Dominio.RangoHorario> ListaRangosHorariosRH(List<Dominio.RangoFecha> listaRangosFecha)
        {
            List<Dominio.RangoHorario> listaRangoHorarios = new List<Dominio.RangoHorario>();
            foreach (Dominio.RangoFecha pRangoFecha in listaRangosFecha)
            {
                listaRangoHorarios.AddRange(pRangoFecha.ListaRangosHorario);
            }
            return listaRangoHorarios;
        }

        /// <summary>
        /// Obtiene el banner correspondiente con respecto a la fecha y a la hora
        /// </summary>
        /// <param name="pHoraActual">Hora Actual</param>
        /// <param name="pFechaActual">Fecha Actual</param>
        /// <returns>Tipo de dato Banner que representa el Banner Siguiente a mostrar</returns>
        public static Dominio.Banner ObtenerBannerSiguiente()
        {
            Dominio.Banner bannerSiguiente = IoCContainerLocator.GetType<Dominio.Fachada>().ObtenerBannerSiguiente();
            if (IoCContainerLocator.GetType<Dominio.Fachada>().NecesitaActualizarListas())
            {
                DateTime DiaMañana = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day + 1);
                CargarBannersEnMemoria(DiaMañana);
            }

            if(DateTime.Now.Minute % 60 == 0)
            {
                ThreadStart delegadoPS = new ThreadStart(ActualizarFuentesRSS);
                Thread hiloSecundario = new Thread(delegadoPS);
                hiloSecundario.Start();
            }
            return bannerSiguiente;
        }

        /// <summary>
        /// Obtiene la campaña correspondiente con respecto a la fecha y a la hora
        /// </summary>
        /// <returns>Tipo de dato Campaña que representa la campaña Siguiente a mostrar</returns>
        public static Dominio.Campaña ObtenerCampañaSiguiente()
        {
            int codigoCampaña = IoCContainerLocator.GetType<Dominio.Fachada>().ObtenerCampañaSiguiente();
            Dominio.Campaña campañaSiguiente;
            if (IoCContainerLocator.GetType<Dominio.Fachada>().NecesitaActualizarListas())
            {
                DateTime DiaMañana = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day + 1);
                CargarCampañasEnMemoria(DiaMañana);
            }
            if (Dominio.Fachada.EsCampañaNula(codigoCampaña))
            {
                campañaSiguiente = Dominio.Fachada.CampañaNula();
            }
            else
            {
                FachadaCRUDCampaña fachadaCampaña = IoCContainerLocator.GetType<FachadaCRUDCampaña>();
                campañaSiguiente = AutoMapper.Map<Persistencia.Campaña, Dominio.Campaña>(fachadaCampaña.GetByCodigo(codigoCampaña));
                campañaSiguiente.ListaImagenes = ObtenerImagenesCampaña(campañaSiguiente.Codigo);
            }
            return campañaSiguiente;
        }

        /// <summary>
        /// Carga los Banners del día en la Fachada
        /// </summary>
        /// <param name="pFecha">Fecha Actual de Carga</param>
        public static void CargarBannersEnMemoria(DateTime pFecha)
        {
            //Argumentos de filtrado de Banner
            Dictionary<Type, object> argumentosBanner = new Dictionary<Type, object>();
            argumentosBanner.Add(typeof(string), "");
            Dominio.RangoFecha pRF = new Dominio.RangoFecha() { FechaInicio = pFecha, FechaFin = pFecha };
            argumentosBanner.Add(typeof(Dominio.RangoFecha), pRF);
            IoCContainerLocator.GetType<Dominio.Fachada>().Cargar(ObtenerBanners(argumentosBanner));
        }


        /// <summary>
        /// Carga las Campañas del día en la Fachada
        /// </summary>
        /// <param name="pFecha">Fecha Actual de Carga</param>
        public static void CargarCampañasEnMemoria(DateTime pFecha)
        {
            Dominio.RangoFecha pRF = new Dominio.RangoFecha() { FechaInicio = pFecha, FechaFin = pFecha };
            //Argumentos de filtrado de Campaña
            Dictionary<Type, object> argumentosCampaña = new Dictionary<Type, object>();
            argumentosCampaña.Add(typeof(string), "");
            argumentosCampaña.Add(typeof(Dominio.RangoFecha), pRF);
            IoCContainerLocator.GetType<Dominio.Fachada>().Cargar(ObtenerCampañas(argumentosCampaña));
        }

        /// <summary>
        /// Carga las Listas inicialmentes
        /// </summary>
        public static void CargaInicial()
        {
            IoCContainerLocator.GetType<Dominio.Fachada>().CambiarListaBanners();
            IoCContainerLocator.GetType<Dominio.Fachada>().CambiarListaCampañas();
        }

        /// <summary>
        /// Actualiza las fuentes RSS
        /// </summary>
        private static void ActualizarFuentesRSS()
        {
            Persistencia.Fachada fachada = IoCContainerLocator.GetType<Persistencia.Fachada>();
            SortedList<int, Dominio.Banner> listaBanners = IoCContainerLocator.GetType<Dominio.Fachada>().ListaBannersActual;
            foreach (Dominio.Banner pBanners in listaBanners.Values)
            {
                Dominio.Fuente pFuente = pBanners.InstanciaFuente;
                pFuente.Texto();
                fachada.ActualizarFuente(AutoMapper.Map<Dominio.Fuente, Persistencia.Fuente>(pFuente));
            }

        }
    }
}
