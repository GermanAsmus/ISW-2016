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
        public static List<Dominio.Banner> ObtenerBanners(Dictionary<Type, object> argumentosFiltrado)
        {
            FachadaCRUDBanner fachadaBanner = new FachadaCRUDBanner();
            Type tipoDeFiltrado = typeof(Dominio.RangoFecha);
            if (argumentosFiltrado.ContainsKey(tipoDeFiltrado))
            {
                argumentosFiltrado[tipoDeFiltrado] = AutoMapper.Map<Dominio.RangoFecha, Persistencia.RangoFecha>
                                                                                        ((Dominio.RangoFecha)argumentosFiltrado[tipoDeFiltrado]);
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
            Dictionary<Type, object> argumentos = new Dictionary<Type, object>();
            argumentos.Add(typeof(string), "");
            argumentos.Add(typeof(Dominio.FuenteRSS), "");
            argumentos.Add(typeof(Dominio.FuenteTextoFijo), "");
            argumentos.Add(typeof(Dominio.RangoFecha), pRangoFecha);
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
        public static List<Dominio.Imagen> ObtenerImagenesCampaña(int pCodigoCampaña)
        {
                return AutoMapper.Map<List<Persistencia.Imagen>, List<Dominio.Imagen>>
                            (IoCContainerLocator.GetType<Persistencia.Fachada>().ObtenerImagenesCampaña(pCodigoCampaña));
        }

        /// <summary>
        /// Obtiene todas las Campañas de la base de datos
        /// </summary>
        /// <returns>Tipo de dato Lista de las Campañas que están en la base de datos (TODAS)</returns>
        public static List<Dominio.Campaña> ObtenerCampañas()
        {
            Persistencia.Fachada fachadaPersistencia = new Persistencia.Fachada();
            return (AutoMapper.Map<List<Persistencia.Campaña>,List<Dominio.Campaña>>(fachadaPersistencia.ObtenerCampañas()));
        }


        /// <summary>
        /// Obtiene todos las Campañas que cumplen con un determinado filtro
        /// </summary>
        /// <param name="argumentosFiltrado">Argumentos para filtrar Campañas</param>
        /// <returns>Tipo de dato Lista que representa las Campañas filtradas</returns>
        public static List<Dominio.Campaña> ObtenerCampañas(Dictionary<Type, object> argumentosFiltrado)
        {
            FachadaCRUDCampaña fachadaCampaña = new FachadaCRUDCampaña();
            if(argumentosFiltrado.ContainsKey(typeof(Dominio.RangoFecha)))
            {
                argumentosFiltrado[typeof(Dominio.RangoFecha)] = AutoMapper.Map<Dominio.RangoFecha, Persistencia.RangoFecha>
                                                                                        ((Dominio.RangoFecha)argumentosFiltrado[typeof(Dominio.RangoFecha)]);
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
            Dictionary<Type, object> argumentos = new Dictionary<Type, object>();
            argumentos.Add(typeof(string), "");
            argumentos.Add(typeof(Dominio.RangoFecha), pRangoFecha);
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
        public static Dominio.Banner ObtenerBannerSiguiente()
        {
            Dominio.Banner bannerSiguiente = IoCContainerLocator.GetType<Dominio.Fachada>().ObtenerBannerSiguiente();
            if (IoCContainerLocator.GetType<Dominio.Fachada>().NecesitaActualizarListas())
            {
                DateTime DiaMañana = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                CargarDatosEnMemoria(DiaMañana);
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
            if(IoCContainerLocator.GetType<Dominio.Fachada>().NecesitaActualizarListas())
            {
                DateTime DiaMañana = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                CargarDatosEnMemoria(DiaMañana);
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
            Dictionary<Type, object> argumentosBanner = new Dictionary<Type, object>();
            argumentosBanner.Add(typeof(string), "");
            argumentosBanner.Add(typeof(Dominio.FuenteRSS), "");
            argumentosBanner.Add(typeof(Dominio.FuenteTextoFijo), "");
            Dominio.RangoFecha pRF = new Dominio.RangoFecha() { FechaInicio = pFecha, FechaFin = pFecha };
            argumentosBanner.Add(typeof(Dominio.RangoFecha), pRF);
            //Argumentos de filtrado de Campaña
            Dictionary<Type, object> argumentosCampaña = new Dictionary<Type, object>();
            argumentosCampaña.Add(typeof(string), "");
            argumentosCampaña.Add(typeof(Dominio.RangoFecha), pRF);
            Dominio.Fachada fachada = IoCContainerLocator.GetType<Dominio.Fachada>();
            fachada.EstablecerFecha(pFecha.Date);
            fachada.Cargar(ObtenerCampañas(argumentosCampaña));
            fachada.Cargar(ObtenerBanners(argumentosBanner));
        }

        /// <summary>
        /// Carga las Listas inicialmentes
        /// </summary>
        public static void CargaInicial()
        {
            IoCContainerLocator.GetType<Dominio.Fachada>().CambiarListaBanners();
            IoCContainerLocator.GetType<Dominio.Fachada>().CambiarListaCampañas();
        }
    }
}
