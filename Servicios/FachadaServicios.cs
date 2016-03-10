using Persistencia;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UI")]

namespace Servicios
{
    /// <summary>
    /// Clase responsable de la Comunicación entre las diversas partes de la Aplicación: Modelo, UI, Persistencia.
    /// </summary>
    class FachadaServicios
    {
        #region Banner
        /// <summary>
        /// Agrega el Banner a la base de datos y al Modelo si corresponde
        /// </summary>
        /// <param name="pBanner">Banner a agregar</param>
        public static void Agregar(Dominio.Banner pBanner)
        {
            FachadaCRUDBanner fachadaBanner = IoCContainerLocator.GetType<FachadaCRUDBanner>();
            pBanner.Codigo = fachadaBanner.Create(AutoMapper.Map<Dominio.Banner, Persistencia.Banner>(pBanner));
            if (FachadaServicios.DiaEnCurso(pBanner.ListaRangosFecha))
            {
                IoCContainerLocator.GetType<Dominio.Fachada>().Agregar(pBanner);
            }
        }

        /// <summary>
        /// Modifica el Banner en la base de datos y en el Modelo si corresponde
        /// </summary>
        /// <param name="pBanner">Banner a modificar</param>
        public static void Modificar(Dominio.Banner pBanner)
        {
            FachadaCRUDBanner fachadaBanner = IoCContainerLocator.GetType<FachadaCRUDBanner>();
            fachadaBanner.Update(AutoMapper.Map<Dominio.Banner, Persistencia.Banner>(pBanner));
            if (DiaEnCurso(pBanner.ListaRangosFecha))
            {
                IoCContainerLocator.GetType<Dominio.Fachada>().Modificar(pBanner);
            }
        }

        /// <summary>
        /// Elimina el Banner en la base de datos y en el Modelo si corresponde
        /// </summary>
        /// <param name="pBanner">Banner a eliminar</param>
        public static void Eliminar(Dominio.Banner pBanner)
        {
            FachadaCRUDBanner fachadaBanner = IoCContainerLocator.GetType<FachadaCRUDBanner>();
            fachadaBanner.Delete(AutoMapper.Map<Dominio.Banner, Persistencia.Banner>(pBanner));
            if (DiaEnCurso(pBanner.ListaRangosFecha))
            {
                IoCContainerLocator.GetType<Dominio.Fachada>().Eliminar(pBanner);
            }
        }

        
        /// <summary>
        /// Obtiene la cadena de RSS a partir de la WebURL
        /// </summary>
        /// <param name="pWebURL">URL a partir de la cual obtener el RSS</param>
        /// <returns>Tipo de dato string que representa el contenido del RSS</returns>
        /*
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
        }*/
        



        /// <summary>
        /// Obtiene todos los Banners de la base de datos
        /// </summary>
        /// <returns>Tipo de dato Lista de los Banners que están en la base de datos (TODOS)</returns>
        public static List<Dominio.Banner> ObtenerBanners()
        {
            FachadaCRUDBanner fachadaBanner = new FachadaCRUDBanner();
            return (AutoMapper.Map<List<Persistencia.Banner>, List<Dominio.Banner>>(fachadaBanner.GetAll()));
        }

        /// <summary>
        /// Obtiene todos los Banners que cumplen con un determinado filtro
        /// </summary>
        /// <param name="argumentosFiltrado">Argumentos para filtrar Banners</param>
        /// <returns>Tipo de dato Lista que representa los Banners filtrados</returns>
        public static List<Dominio.Banner> ObtenerBanners(Dictionary<string, object> argumentosFiltrado)
        {
            FachadaCRUDBanner fachadaBanner = new FachadaCRUDBanner();
            if (argumentosFiltrado.ContainsKey("Rango Fecha"))
            {
                argumentosFiltrado["Rango Fecha"] = AutoMapper.Map<Dominio.RangoFecha, Persistencia.RangoFecha>
                                                                                        ((Dominio.RangoFecha)argumentosFiltrado["Rango Fecha"]);
            }
            return (AutoMapper.Map<List<Persistencia.Banner>, List<Dominio.Banner>>(fachadaBanner.GetAll(argumentosFiltrado)));
        }

        /// <summary>
        /// Obtiene los Rangos Horarios Ocupados para un cierto Rango de Fechas
        /// </summary>
        /// <param name="pRangoFecha">Rango de Fechas</param>
        /// <returns>Tipo de dato Lista de Rangos Horarios que representa los rangos horarios ocupados</returns>
        public static List<Dominio.RangoHorario> RangosHorariosOcupadosBanner(Dominio.RangoFecha pRangoFecha)
        {
            Dictionary<string, object> argumentos = new Dictionary<string, object>();
            argumentos.Add("Nombre", "");
            argumentos.Add("URL", "");
            argumentos.Add("Texto", "");
            argumentos.Add("Rango Fecha", pRangoFecha);
            List<Dominio.RangoFecha> listaRangosFecha = new List<Dominio.RangoFecha>();
            FachadaCRUDBanner fachada = new FachadaCRUDBanner();
            foreach (Dominio.Banner pBanner in ObtenerBanners(argumentos))
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
        public static void Agregar(Dominio.Campaña pCampaña)
        {
            FachadaCRUDCampaña fachadaCampaña = IoCContainerLocator.GetType<FachadaCRUDCampaña>();
            pCampaña.Codigo = fachadaCampaña.Create(AutoMapper.Map<Dominio.Campaña, Persistencia.Campaña>(pCampaña));
            if (DiaEnCurso(pCampaña.ListaRangosFecha))
            {
                IoCContainerLocator.GetType<Dominio.Fachada>().Agregar(pCampaña);
            }
            GC.Collect();
        }

        /// <summary>
        /// Modifica la Campaña en la base de datos y en el Modelo si corresponde
        /// </summary>
        /// <param name="pCampaña">Campaña a modificar</param>
        public static void Modificar(Dominio.Campaña pCampaña)
        {
            FachadaCRUDCampaña fachadaCampaña = IoCContainerLocator.GetType<FachadaCRUDCampaña>();
            fachadaCampaña.Update(AutoMapper.Map<Dominio.Campaña, Persistencia.Campaña>(pCampaña));
            if (DiaEnCurso(pCampaña.ListaRangosFecha))
            {
                IoCContainerLocator.GetType<Dominio.Fachada>().Modificar(pCampaña);
            }
        }

        /// <summary>
        /// Elimina la Campaña en la base de datos y en el Modelo si corresponde
        /// </summary>
        /// <param name="pCampaña">Campaña a eliminar</param>
        public static void Eliminar(Dominio.Campaña pCampaña)
        {
            FachadaCRUDCampaña fachadaCampaña = IoCContainerLocator.GetType<FachadaCRUDCampaña>();
            fachadaCampaña.Delete(AutoMapper.Map<Dominio.Campaña, Persistencia.Campaña>(pCampaña));
            if (DiaEnCurso(pCampaña.ListaRangosFecha))
            {
                IoCContainerLocator.GetType<Dominio.Fachada>().Eliminar(pCampaña);
            }
        }

        /// <summary>
        /// Obtiene las imágenes de la campaña
        /// </summary>
        /// <param name="pCodigoCamapaña">Código de la Campaña</param>
        /// <returns>Tipo de dato Lista de Imágenes que representa la lista de imágenes de la campaña</returns>
        public static List<Dominio.Imagen> ObtenerImagenesCampaña(int pCodigoCamapaña)
        {
            FachadaCRUDCampaña fachadaCampaña = IoCContainerLocator.GetType<FachadaCRUDCampaña>();
            return AutoMapper.Map<List<Persistencia.Imagen>, List<Dominio.Imagen>>
                            (fachadaCampaña.GetByCodigo(pCodigoCamapaña).Imagenes);
        }

        /// <summary>
        /// Obtiene todas las Campañas de la base de datos
        /// </summary>
        /// <returns>Tipo de dato Lista de las Campañas que están en la base de datos (TODAS)</returns>
        public static List<Dominio.Campaña> ObtenerCampañas()
        {
            FachadaCRUDCampaña fachadaCampaña = new FachadaCRUDCampaña();
            return (AutoMapper.Map<List<Persistencia.Campaña>, List<Dominio.Campaña>>(fachadaCampaña.GetAll()));
        }

        /// <summary>
        /// Obtiene todos las Campañas que cumplen con un determinado filtro
        /// </summary>
        /// <param name="argumentosFiltrado">Argumentos para filtrar Campañas</param>
        /// <returns>Tipo de dato Lista que representa las Campañas filtradas</returns>
        public static List<Dominio.Campaña> ObtenerCampañas(Dictionary<string, object> argumentosFiltrado)
        {
            FachadaCRUDCampaña fachadaCampaña = new FachadaCRUDCampaña();
            if(argumentosFiltrado.ContainsKey("Rango Fecha"))
            {
                argumentosFiltrado["Rango Fecha"] = AutoMapper.Map<Dominio.RangoFecha, Persistencia.RangoFecha>
                                                                                        ((Dominio.RangoFecha)argumentosFiltrado["Rango Fecha"]);
            }
            return (AutoMapper.Map<List<Persistencia.Campaña>, List<Dominio.Campaña>>(fachadaCampaña.GetAll(argumentosFiltrado)));
        }

        /// <summary>
        /// Obtiene los Rangos Horarios Ocupados para un cierto Rango de Fechas
        /// </summary>
        /// <param name="pRangoFecha">Rango de Fechas</param>
        /// <returns>Tipo de dato Lista de Rangos Horarios que representa los rangos horarios ocupados</returns>
        public static List<Dominio.RangoHorario> RangosHorariosOcupadosCampaña(Dominio.RangoFecha pRangoFecha)
        {
            Dictionary<string, object> argumentos = new Dictionary<string, object>();
            argumentos.Add("Nombre", "");
            argumentos.Add("Rango Fecha", pRangoFecha);
            List<Dominio.RangoFecha> listaRangosFecha = new List<Dominio.RangoFecha>();
            FachadaCRUDCampaña fachada = new FachadaCRUDCampaña();
            foreach (Dominio.Campaña pCampaña in ObtenerCampañas(argumentos))
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
        /// Determina si la lista de Rangos de Fecha posee una fecha actual
        /// </summary>
        /// <param name="pListaRangosFecha">Lista de Rangos de Fecha a verificar si existe Rango de Fecha del día en curso</param>
        /// <returns>Tipo de dato booleano que representa si existe Rango de Fecha del día en curso</returns>
        private static bool DiaEnCurso(List<Dominio.RangoFecha> pListaRangosFecha)
        {
            DateTime fechaHoy = DateTime.Today.Date;
            IEnumerator<Dominio.RangoFecha> enumerador = pListaRangosFecha.GetEnumerator();
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
        public static Dominio.Banner ObtenerBannerCorrespondiente()
        {
            DateTime fechaActual = DateTime.Now;
            TimeSpan horaActual = new TimeSpan(fechaActual.Hour, fechaActual.Minute, fechaActual.Second);
            return IoCContainerLocator.GetType<Dominio.Fachada>().ObtenerBannerSiguiente(horaActual, fechaActual);
        }

        /// <summary>
        /// Obtiene la campaña correspondiente con respecto a la fecha y a la hora
        /// </summary>
        /// <returns>Tipo de dato Campaña que representa la campaña Siguiente a mostrar</returns>
        public static Dominio.Campaña ObtenerCampañaCorrespondiente()
        {
            FachadaCRUDCampaña fachadaCampaña = IoCContainerLocator.GetType<FachadaCRUDCampaña>();
            int codigoCampaña = IoCContainerLocator.GetType<Dominio.Fachada>().ObtenerCampañaSiguiente();
            Dominio.Campaña campañaSiguiente;
            if (codigoCampaña == -1)
            {
                campañaSiguiente = new Dominio.Campaña() { Codigo = codigoCampaña };
            }
            else
            {
                campañaSiguiente = AutoMapper.Map<Persistencia.Campaña, Dominio.Campaña>(fachadaCampaña.GetByCodigo(codigoCampaña));
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
            Dominio.RangoFecha pRF = new Dominio.RangoFecha() { FechaInicio = pFecha, FechaFin = pFecha };
            argumentosBanner.Add("Rango Fecha", pRF);
            //Argumentos de filtrado de Campaña
            Dictionary<string, object> argumentosCampaña = new Dictionary<string, object>();
            argumentosCampaña.Add("Nombre", "");
            argumentosCampaña.Add("Rango Fecha", pRF);
            Dominio.Fachada fachada = IoCContainerLocator.GetType<Dominio.Fachada>();
            fachada.EstablecerFecha(pFecha.Date);
            fachada.Cargar(ObtenerCampañas(argumentosCampaña));
            fachada.Cargar(ObtenerBanners(argumentosBanner));
        }

        /// <summary>
        /// Obtiene la duración del Banner próximo
        /// </summary>        
        /// <param name="pHoraActual">Hora Actual</param>
        /// <returns>Tipo de dato entero que reprsenta la duración del banner próximo</returns>
        public static int DuracionBannerSiguiente()
        {
            DateTime fechaActual = DateTime.Now;
            TimeSpan horaActual = new TimeSpan(fechaActual.Hour, fechaActual.Minute, fechaActual.Second);
            return IoCContainerLocator.GetType<Dominio.Fachada>().ObtenerDuracionBannerSiguiente(horaActual);
        }

        /// <summary>
        /// Obtiene la duración de la Campaña próxima
        /// </summary>
        /// <param name="pHoraActual">Hora Actual</param>
        /// <returns>Tipo de dato entero que reprsenta la duración de la Campaña próxima</returns>
        public static int DuracionCampañaSiguiente()
        {
            return IoCContainerLocator.GetType<Dominio.Fachada>().ObtenerDuracionCampañaSiguiente();
        }

        /// <summary>
        /// Carga las Listas inicialmentes
        /// </summary>
        public static void CargaInicial()
        {
            IoCContainerLocator.GetType<Dominio.Fachada>().CambiarListas();
        }

        /// <summary>
        /// Devuelve un Banner Nulo
        /// </summary>
        /// <returns>Tipo banner que representa el banner nulo</returns>
        public static Dominio.Banner BannerNulo()
        {
            return FachadaServicios.BannerNulo();
        }

        /// <summary>
        /// Comprueba si un Banner es nulo o no
        /// </summary>
        /// <returns>Verdadero si el Banner es nulo</returns>
        public static bool EsBannerNulo(Dominio.Banner pBanner)
        {
            return FachadaServicios.EsBannerNulo(pBanner);
        }
    }
}
