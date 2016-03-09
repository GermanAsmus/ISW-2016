using Persistencia;
using System;
using System.Collections.Generic;
using Modelo;
using System.Text;

namespace Servicios
{
    /// <summary>
    /// Clase responsable de la Comunicación entre las diversas partes de la Aplicación: Modelo, UI, Persistencia.
    /// </summary>
    public class Fachada
    {
        #region Banner
        /// <summary>
        /// Agrega el Banner a la base de datos y al Modelo si corresponde
        /// </summary>
        /// <param name="pBanner">Banner a agregar</param>
        public static void Agregar(UI.Tipos.Banner pBanner)
        {
            FachadaCRUDBanner fachadaBanner = IoCContainerLocator.GetType<FachadaCRUDBanner>();
            pBanner.Codigo = fachadaBanner.Create(AutoMapper.Map<UI.Tipos.Banner, Persistencia.Banner>(pBanner));
            if (Fachada.DiaEnCurso(pBanner.ListaRangosFecha))
            {
                IoCContainerLocator.GetType<Modelo.Fachada>().Agregar(AutoMapper.Map<UI.Tipos.Banner, Modelo.Banner>(pBanner));
            }
        }

        /// <summary>
        /// Modifica el Banner en la base de datos y en el Modelo si corresponde
        /// </summary>
        /// <param name="pBanner">Banner a modificar</param>
        public static void Modificar(UI.Tipos.Banner pBanner)
        {
            FachadaCRUDBanner fachadaBanner = IoCContainerLocator.GetType<FachadaCRUDBanner>();
            fachadaBanner.Update(AutoMapper.Map<UI.Tipos.Banner, Persistencia.Banner>(pBanner));
            if (DiaEnCurso(pBanner.ListaRangosFecha))
            {
                IoCContainerLocator.GetType<Modelo.Fachada>().Modificar(AutoMapper.Map<UI.Tipos.Banner, Modelo.Banner>(pBanner));
            }
        }

        /// <summary>
        /// Elimina el Banner en la base de datos y en el Modelo si corresponde
        /// </summary>
        /// <param name="pBanner">Banner a eliminar</param>
        public static void Eliminar(UI.Tipos.Banner pBanner)
        {
            FachadaCRUDBanner fachadaBanner = IoCContainerLocator.GetType<FachadaCRUDBanner>();
            fachadaBanner.Delete(AutoMapper.Map<UI.Tipos.Banner, Persistencia.Banner>(pBanner));
            if (DiaEnCurso(pBanner.ListaRangosFecha))
            {
                IoCContainerLocator.GetType<Modelo.Fachada>().Eliminar(AutoMapper.Map<UI.Tipos.Banner, Modelo.Banner>(pBanner));
            }
        }

        /// <summary>
        /// Obtiene la cadena de RSS a partir de la WebURL
        /// </summary>
        /// <param name="pWebURL">URL a partir de la cual obtener el RSS</param>
        /// <returns>Tipo de dato string que representa el contenido del RSS</returns>
        public static string OperacionesRSS(string pWebURL)
        {
            Uri pURL = WebServices.ObtenerURLVálida(pWebURL);
            IRssReader mRssReader = IoCContainerLocator.GetType<IRssReader>();
            IEnumerable<RssItem> mItmes = mRssReader.Read(pURL);
            StringBuilder resultado = new StringBuilder("");
            foreach(RssItem pItem in mItmes)
            {
                resultado.Append(pItem.Title + " // ");
            }
            return resultado.ToString();
        }

        /// <summary>
        /// Obtiene todos los Banners de la base de datos
        /// </summary>
        /// <returns>Tipo de dato Lista de los Banners que están en la base de datos (TODOS)</returns>
        public static List<UI.Tipos.Banner> ObtenerBanners()
        {
            FachadaCRUDBanner fachadaBanner = new FachadaCRUDBanner();
            return (AutoMapper.Map<List<Persistencia.Banner>, List<UI.Tipos.Banner>>(fachadaBanner.GetAll()));
        }

        /// <summary>
        /// Obtiene todos los Banners que cumplen con un determinado filtro
        /// </summary>
        /// <param name="argumentosFiltrado">Argumentos para filtrar Banners</param>
        /// <returns>Tipo de dato Lista que representa los Banners filtrados</returns>
        public static List<UI.Tipos.Banner> ObtenerBanners(Dictionary<string, object> argumentosFiltrado)
        {
            FachadaCRUDBanner fachadaBanner = new FachadaCRUDBanner();
            if (argumentosFiltrado.ContainsKey("Rango Fecha"))
            {
                argumentosFiltrado["Rango Fecha"] = AutoMapper.Map<UI.Tipos.RangoFecha, Persistencia.RangoFecha>
                                                                                        ((UI.Tipos.RangoFecha)argumentosFiltrado["Rango Fecha"]);
            }
            return (AutoMapper.Map<List<Persistencia.Banner>, List<UI.Tipos.Banner>>(fachadaBanner.GetAll(argumentosFiltrado)));
        }

        /// <summary>
        /// Obtiene los Rangos Horarios Ocupados para un cierto Rango de Fechas
        /// </summary>
        /// <param name="pRangoFecha">Rango de Fechas</param>
        /// <returns>Tipo de dato Lista de Rangos Horarios que representa los rangos horarios ocupados</returns>
        public static List<UI.Tipos.RangoHorario> RangosHorariosOcupadosBanner(UI.Tipos.RangoFecha pRangoFecha)
        {
            Dictionary<string, object> argumentos = new Dictionary<string, object>();
            argumentos.Add("Nombre", "");
            argumentos.Add("URL", "");
            argumentos.Add("Texto", "");
            argumentos.Add("Rango Fecha", pRangoFecha);
            List<UI.Tipos.RangoFecha> listaRangosFecha = new List<UI.Tipos.RangoFecha>();
            FachadaCRUDBanner fachada = new FachadaCRUDBanner();
            foreach (UI.Tipos.Banner pBanner in ObtenerBanners(argumentos))
            {
                listaRangosFecha.AddRange(pBanner.ListaRangosFecha);
            }
            return ListaRangosHorariosRH(listaRangosFecha);
        }
        #endregion

        #region Campaña
        /// <summary>
        /// Agrega la Campaña a la base de datos y al Modelo si corresponde
        /// </summary>
        /// <param name="pCampaña">Campaña a agregar</param>
        public static void Agregar(UI.Tipos.Campaña pCampaña)
        {
            FachadaCRUDCampaña fachadaCampaña = IoCContainerLocator.GetType<FachadaCRUDCampaña>();
            pCampaña.Codigo = fachadaCampaña.Create(AutoMapper.Map<UI.Tipos.Campaña, Persistencia.Campaña>(pCampaña));
            if (DiaEnCurso(pCampaña.ListaRangosFecha))
            {
                IoCContainerLocator.GetType<Modelo.Fachada>().Agregar(AutoMapper.Map<UI.Tipos.Campaña, Modelo.Campaña>(pCampaña));
            }
            GC.Collect();
        }

        /// <summary>
        /// Modifica la Campaña en la base de datos y en el Modelo si corresponde
        /// </summary>
        /// <param name="pCampaña">Campaña a modificar</param>
        public static void Modificar(UI.Tipos.Campaña pCampaña)
        {
            FachadaCRUDCampaña fachadaCampaña = IoCContainerLocator.GetType<FachadaCRUDCampaña>();
            fachadaCampaña.Update(AutoMapper.Map<UI.Tipos.Campaña, Persistencia.Campaña>(pCampaña));
            if (DiaEnCurso(pCampaña.ListaRangosFecha))
            {
                IoCContainerLocator.GetType<Modelo.Fachada>().Modificar(AutoMapper.Map<UI.Tipos.Campaña, Modelo.Campaña>(pCampaña));
            }
        }

        /// <summary>
        /// Elimina la Campaña en la base de datos y en el Modelo si corresponde
        /// </summary>
        /// <param name="pCampaña">Campaña a eliminar</param>
        public static void Eliminar(UI.Tipos.Campaña pCampaña)
        {
            FachadaCRUDCampaña fachadaCampaña = IoCContainerLocator.GetType<FachadaCRUDCampaña>();
            fachadaCampaña.Delete(AutoMapper.Map<UI.Tipos.Campaña, Persistencia.Campaña>(pCampaña));
            if (DiaEnCurso(pCampaña.ListaRangosFecha))
            {
                IoCContainerLocator.GetType<Modelo.Fachada>().Eliminar(AutoMapper.Map<UI.Tipos.Campaña, Modelo.Campaña>(pCampaña));
            }
        }

        /// <summary>
        /// Obtiene las imágenes de la campaña
        /// </summary>
        /// <param name="pCodigoCamapaña">Código de la Campaña</param>
        /// <returns>Tipo de dato Lista de Imágenes que representa la lista de imágenes de la campaña</returns>
        public static List<UI.Tipos.Imagen> ObtenerImagenesCampaña(int pCodigoCamapaña)
        {
            FachadaCRUDCampaña fachadaCampaña = IoCContainerLocator.GetType<FachadaCRUDCampaña>();
            return AutoMapper.Map<List<Persistencia.Imagen>, List<UI.Tipos.Imagen>>
                            (fachadaCampaña.GetByCodigo(pCodigoCamapaña).Imagenes);
        }

        /// <summary>
        /// Obtiene todas las Campañas de la base de datos
        /// </summary>
        /// <returns>Tipo de dato Lista de las Campañas que están en la base de datos (TODAS)</returns>
        public static List<UI.Tipos.Campaña> ObtenerCampañas()
        {
            FachadaCRUDCampaña fachadaCampaña = new FachadaCRUDCampaña();
            return (AutoMapper.Map<List<Persistencia.Campaña>, List<UI.Tipos.Campaña>>(fachadaCampaña.GetAll()));
        }

        /// <summary>
        /// Obtiene todos las Campañas que cumplen con un determinado filtro
        /// </summary>
        /// <param name="argumentosFiltrado">Argumentos para filtrar Campañas</param>
        /// <returns>Tipo de dato Lista que representa las Campañas filtradas</returns>
        public static List<UI.Tipos.Campaña> ObtenerCampañas(Dictionary<string, object> argumentosFiltrado)
        {
            FachadaCRUDCampaña fachadaCampaña = new FachadaCRUDCampaña();
            if(argumentosFiltrado.ContainsKey("Rango Fecha"))
            {
                argumentosFiltrado["Rango Fecha"] = AutoMapper.Map<UI.Tipos.RangoFecha, Persistencia.RangoFecha>
                                                                                        ((UI.Tipos.RangoFecha)argumentosFiltrado["Rango Fecha"]);
            }
            return (AutoMapper.Map<List<Persistencia.Campaña>, List<UI.Tipos.Campaña>>(fachadaCampaña.GetAll(argumentosFiltrado)));
        }

        /// <summary>
        /// Obtiene los Rangos Horarios Ocupados para un cierto Rango de Fechas
        /// </summary>
        /// <param name="pRangoFecha">Rango de Fechas</param>
        /// <returns>Tipo de dato Lista de Rangos Horarios que representa los rangos horarios ocupados</returns>
        public static List<UI.Tipos.RangoHorario> RangosHorariosOcupadosCampaña(UI.Tipos.RangoFecha pRangoFecha)
        {
            Dictionary<string, object> argumentos = new Dictionary<string, object>();
            argumentos.Add("Nombre", "");
            argumentos.Add("Rango Fecha", pRangoFecha);
            List<UI.Tipos.RangoFecha> listaRangosFecha = new List<UI.Tipos.RangoFecha>();
            FachadaCRUDCampaña fachada = new FachadaCRUDCampaña();
            foreach (UI.Tipos.Campaña pCampaña in ObtenerCampañas(argumentos))
            {
                listaRangosFecha.AddRange(pCampaña.ListaRangosFecha);
            }
            return ListaRangosHorariosRH(listaRangosFecha);
        }
        #endregion
        #region Métodos Comunes

        #endregion

        /// <summary>
        /// Obtiene los rangos horarios de una lista de rangos de fecha (concatena)
        /// </summary>
        /// <param name="listaRangosFecha">Lista de Rangos de Fecha</param>
        /// <returns>Tipo de dato Lista de Rangos Horarios que representa los rangos horarios que poseen los de fecha</returns>
        private static List<UI.Tipos.RangoHorario> ListaRangosHorariosRH(List<UI.Tipos.RangoFecha> listaRangosFecha)
        {
            List<UI.Tipos.RangoHorario> listaRangoHorarios = new List<UI.Tipos.RangoHorario>();
            foreach (UI.Tipos.RangoFecha pRangoFecha in listaRangosFecha)
            {
                listaRangoHorarios.AddRange(pRangoFecha.ListaRangosHorario);
            }
            return listaRangoHorarios;
        }

        /// <summary>
        /// Determina si la lista de Rangos de Fecha posee una fecha actual
        /// </summary>
        /// <param name="pListaRangosFecha">Lista de Rangos de Fecha a verificar si existe Rango de Fecha del día en curso</param>
        /// <returns>Tipo de dato booleano que representa si existe Rango de Fecha del día en curso</returns>
        private static bool DiaEnCurso(List<UI.Tipos.RangoFecha> pListaRangosFecha)
        {
            DateTime fechaHoy = DateTime.Today.Date;
            IEnumerator<UI.Tipos.RangoFecha> enumerador = pListaRangosFecha.GetEnumerator();
            bool auxiliar = false;
            while (enumerador.MoveNext() && !auxiliar)
            {
                auxiliar = (fechaHoy.CompareTo(enumerador.Current.FechaInicio) >= 0) && 
                           (fechaHoy.CompareTo(enumerador.Current.FechaFin) <= 0);
            }
            return auxiliar;
        }

        /// <summary>
        /// Obtiene el banner correspondiente con respecto a la fecha y a la hora
        /// </summary>
        /// <param name="pHoraActual">Hora Actual</param>
        /// <param name="pFechaActual">Fecha Actual</param>
        /// <returns>Tipo de dato Banner que representa el Banner Siguiente a mostrar</returns>
        public static UI.Tipos.Banner ObtenerBannerCorrespondiente(TimeSpan pHoraActual, DateTime pFechaActual)
        {
            Modelo.Banner bannerSiguiente = IoCContainerLocator.GetType<Modelo.Fachada>().ObtenerBannerSiguiente(pHoraActual, pFechaActual);
            return AutoMapper.Map<Modelo.Banner, UI.Tipos.Banner>(bannerSiguiente);
        }

        /// <summary>
        /// Obtiene la campaña correspondiente con respecto a la fecha y a la hora
        /// </summary>
        /// <param name="pHoraActual">Hora Actual</param>
        /// <param name="pFechaActual">Fecha Actual</param>
        /// <returns>Tipo de dato Campaña que representa la campaña Siguiente a mostrar</returns>
        public static UI.Tipos.Campaña ObtenerCampañaCorrespondiente(TimeSpan pHoraActual, DateTime pFechaActual)
        {
            FachadaCRUDCampaña fachadaCampaña = IoCContainerLocator.GetType<FachadaCRUDCampaña>();
            int codigoCampaña = IoCContainerLocator.GetType<Modelo.Fachada>().ObtenerCampañaSiguiente(pHoraActual, pFechaActual);
            UI.Tipos.Campaña campañaSiguiente;
            if (codigoCampaña == -1)
            {
                campañaSiguiente = new UI.Tipos.Campaña() { Codigo = codigoCampaña };
            }
            else
            {
                campañaSiguiente = AutoMapper.Map<Persistencia.Campaña,UI.Tipos.Campaña>(fachadaCampaña.GetByCodigo(codigoCampaña));
            }
            return campañaSiguiente;
        }

        /// <summary>
        /// Carga los Datos (Banner y Campaña) del día en la Fachada
        /// </summary>
        /// <param name="pFecha">Fecha Actual de Carga</param>
        public static void CargarDatosEnMemoria(DateTime pFecha)
        {
            //Argumentos de filtrado de Banner
            Dictionary<string, object> argumentosBanner = new Dictionary<string, object>();
            argumentosBanner.Add("Nombre", "");
            argumentosBanner.Add("URL", "");
            argumentosBanner.Add("Texto", "");
            UI.Tipos.RangoFecha pRF = new UI.Tipos.RangoFecha() { FechaInicio = pFecha, FechaFin = pFecha };
            argumentosBanner.Add("Rango Fecha", pRF);
            //Argumentos de filtrado de Campaña
            Dictionary<string, object> argumentosCampaña = new Dictionary<string, object>();
            argumentosCampaña.Add("Nombre", "");
            argumentosCampaña.Add("Rango Fecha", pRF);
            Modelo.Fachada fachada = IoCContainerLocator.GetType<Modelo.Fachada>();
            fachada.EstablecerFecha(pFecha.Date);
            fachada.Cargar(AutoMapper.Map<List<UI.Tipos.Campaña>, List<Modelo.Campaña>>(ObtenerCampañas(argumentosCampaña)));
            fachada.Cargar(AutoMapper.Map<List<UI.Tipos.Banner>, List<Modelo.Banner>>(ObtenerBanners(argumentosBanner)));
        }

        /// <summary>
        /// Obtiene la duración del Banner próximo
        /// </summary>        
        /// <param name="pHoraActual">Hora Actual</param>
        /// <returns>Tipo de dato entero que reprsenta la duración del banner próximo</returns>
        public static int DuracionBannerSiguiente(TimeSpan pHoraActual)
        {
            return IoCContainerLocator.GetType<Modelo.Fachada>().ObtenerDuracionBannerSiguiente(pHoraActual);
        }

        /// <summary>
        /// Obtiene la duración de la Campaña próxima
        /// </summary>
        /// <param name="pHoraActual">Hora Actual</param>
        /// <returns>Tipo de dato entero que reprsenta la duración de la Campaña próxima</returns>
        public static int DuracionCampañaSiguiente(TimeSpan pHoraActual)
        {
            return IoCContainerLocator.GetType<Modelo.Fachada>().ObtenerDuracionCampañaSiguiente(pHoraActual);
        }

        /// <summary>
        /// Carga las Listas inicialmentes
        /// </summary>
        public static void CargaInicial()
        {
            IoCContainerLocator.GetType<Modelo.Fachada>().CambiarListas();
        }    
    }
}
