using System;
using System.Collections.Generic;

using System.Threading;

namespace Dominio
{
    class ControladorBanner
    {
        #region Atributos
        private static Banner BannerNulo;
        private static SortedList<int, Banner> ListaBannersActual;
        private static SortedList<int, Banner> ListaBannersProxima;
        private static bool ActualizarListaBanner = false;
        #endregion

        #region Inicializar
        /// <summary>
        /// Inicializa los atributos de la Logica Banner
        /// </summary>
        public static void Inicializar()
        {
            FuenteTextoFijo pTextoFijo = new FuenteTextoFijo() { Valor = "Publicite Aquí" };
            BannerNulo = new Banner()
            {
                Codigo = -1,
                InstanciaFuente = pTextoFijo
            };
            ListaBannersActual = new SortedList<int, Banner>();
            ListaBannersProxima = new SortedList<int, Banner>();
            InicializarListaBanner();
        }

        /// <summary>
        /// Inicializa la lista de Banners con Banners nulos
        /// </summary>
        private static void InicializarListaBanner()
        {
            ListaBannersProxima = new SortedList<int, Banner>();
            int totalMinutosDia = (int)(new TimeSpan(23, 59, 00)).TotalMinutes;
            for (int i = 0; i <= totalMinutosDia; i++)
            {
                ListaBannersProxima[i] = BannerNulo;
            }
            ActualizarListaBanner = false;
        }
        #endregion

        #region Carga
        /// <summary>
        /// Carga la lista de Banners en la lógica
        /// </summary>
        /// <param name="listaBanners">Lista de Banners a cargar</param>
        private static void Cargar(List<Banner> listaBanners)
        {
            foreach (Banner pBanner in listaBanners)
            {
                foreach (int pIndice in pBanner.ListaDeIndices(DateTime.Now.Date))
                {
                    ListaBannersProxima[pIndice] = pBanner;
                }
            }
        }

        /// <summary>
        /// Carga las Listas inicialmente, efectuando el correspondiente cambio de proximo a actual
        /// </summary>
        internal static void CargaInicial()
        {
            CambiarListas();
        }

        /// <summary>
        /// Carga los Banners del día en la Fachada
        /// </summary>
        /// <param name="pFecha">Fecha Actual de Carga</param>
        internal static void CargarEnMemoria(DateTime pFecha)
        {
            //Argumentos de filtrado de Banner
            Dictionary<Type, object> argumentosBanner = new Dictionary<Type, object>();
            argumentosBanner.Add(typeof(string), "");
            Dominio.RangoFecha pRF = new Dominio.RangoFecha() { FechaInicio = pFecha, FechaFin = pFecha };
            argumentosBanner.Add(typeof(Dominio.RangoFecha), pRF);
            Cargar(ObtenerBanners(argumentosBanner));
        }

        /// <summary>
        /// Cambia las listas de Banners
        /// </summary>
        private static void CambiarListas()
        {
            SortedList<int, Banner> listaAuxBanner = ListaBannersProxima;
            InicializarListaBanner();
            ListaBannersActual = listaAuxBanner;
        }
        #endregion

        /// <summary>
        /// Agrega un Banner en la lista de la lógica
        /// </summary>
        /// <param name="pBanner">Banner a agregar</param>
        internal static void Agregar(Banner pBanner)
        {
            Persistencia.FachadaPersistencia fachada = IoCContainerLocator.GetType<Persistencia.FachadaPersistencia>();
            pBanner.Codigo = fachada.CrearBanner(AutoMapper.Map<Banner, Persistencia.Banner>(pBanner));
            AgregarLocal(pBanner);
        }

        /// <summary>
        /// Agrega un Banner en la lista Caché local
        /// </summary>
        /// <param name="pBanner">Banner a agregar</param>
        private static void AgregarLocal(Banner pBanner)
        {
            //Lista Actual
            foreach (int pIndice in pBanner.ListaDeIndices(DateTime.Now.Date))
            {
                ListaBannersActual[pIndice] = pBanner;
            }
            //Lista Próxima
            foreach (int pIndice in pBanner.ListaDeIndices(DateTime.Now.AddDays(1).Date))
            {
                ListaBannersProxima[pIndice] = pBanner;
            }
        }

        /// <summary>
        /// Modifica un Banner de la lista de la lógica
        /// </summary>
        /// <param name="pBanner">Banner a modificar</param>
        internal static void Modificar(Banner pBanner)
        {
            Persistencia.FachadaPersistencia fachada = IoCContainerLocator.GetType<Persistencia.FachadaPersistencia>();
            fachada.ActualizarBanner(AutoMapper.Map<Dominio.Banner, Persistencia.Banner>(pBanner));
            EliminarLocal(BuscarBanner(pBanner));
            AgregarLocal(pBanner);
        }

        /// <summary>
        /// Elimina un Banner de la lista de la lógica
        /// </summary>
        /// <param name="pBanner">Banner a eliminar</param>
        internal static void Eliminar(Banner pBanner)
        {
            Persistencia.FachadaPersistencia fachada = IoCContainerLocator.GetType<Persistencia.FachadaPersistencia>();
            fachada.EliminarBanner(AutoMapper.Map<Dominio.Banner, Persistencia.Banner>(pBanner));
            EliminarLocal(pBanner);
        }

        /// <summary>
        /// Elimina el Banner de la Lista Caché local
        /// </summary>
        /// <param name="pBanner">Banner a eliminar localmente</param>
        internal static void EliminarLocal(Banner pBanner)
        {
            //Lista Actual
            foreach (int pIndice in pBanner.ListaDeIndices(DateTime.Now.Date))
            {
                ListaBannersActual[pIndice] = BannerNulo;
            }
            //Lista Próxima
            foreach (int pIndice in pBanner.ListaDeIndices(DateTime.Now.AddDays(1).Date))
            {
                ListaBannersProxima[pIndice] = BannerNulo;
            }
        }

        /// <summary>
        /// Obtiene todos los Banners que cumplen con un determinado filtro
        /// </summary>
        /// <param name="argumentosFiltrado">Argumentos para filtrar Banners</param>
        /// <returns>Tipo de dato Lista que representa los Banners filtrados</returns>
        internal static List<Banner> ObtenerBanners(Dictionary<Type, object> argumentosFiltrado = null)
        {
            Persistencia.FachadaPersistencia fachada = IoCContainerLocator.GetType<Persistencia.FachadaPersistencia>();
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
                if (argumentosFiltrado.ContainsKey(typeof(Dominio.IFuente)))
                {
                    argumentosFiltrado.Add(typeof(Persistencia.Fuente),
                                            (AutoMapper.Map<Dominio.IFuente, Persistencia.Fuente>
                                            ((Dominio.IFuente)argumentosFiltrado[typeof(Dominio.IFuente)])).GetType());
                    argumentosFiltrado.Remove(typeof(Dominio.IFuente));
                }
            }
            return (AutoMapper.Map<List<Persistencia.Banner>, List<Dominio.Banner>>(fachada.ObtenerBanners(argumentosFiltrado)));
        }

        /// <summary>
        /// Obtiene los Rangos Horarios Ocupados para un cierto Rango de Fechas
        /// </summary>
        /// <param name="pRangoFecha">Rango de Fechas</param>
        /// <returns>Tipo de dato Lista de Rangos Horarios que representa los rangos horarios ocupados</returns>
        internal static List<RangoHorario> RangosHorariosOcupados(RangoFecha pRangoFecha)
        {
            Dictionary<Type, object> argumentos = new Dictionary<Type, object>();
            argumentos.Add(typeof(string), "");
            argumentos.Add(typeof(RangoFecha), pRangoFecha);
            List<Banner> pListaBanners = ObtenerBanners(argumentos);
            List<RangoHorario> listaResultado = new List<RangoHorario>();
            foreach (Banner pBanner in pListaBanners)
            {
                listaResultado.AddRange(pBanner.ObtenerRangosHorariosOcupados());
            }
            return listaResultado;
        }

        /// <summary>
        /// Obtiene el banner correspondiente con respecto a la fecha y a la hora
        /// </summary>
        /// <param name="pHoraActual">Hora Actual</param>
        /// <param name="pFechaActual">Fecha Actual</param>
        /// <returns>Tipo de dato Banner que representa el Banner Siguiente a mostrar</returns>
        internal static Banner ObtenerSiguiente()
        {
            Banner bannerResultado;
            DateTime fechaActual = DateTime.Now;
            int horaInicio = (int)(new TimeSpan(fechaActual.Hour, fechaActual.Minute, 0).TotalMinutes) + 1;
            if (horaInicio > 1380)
            {
                ActualizarListaBanner = true;
            }
            if (horaInicio == 1439) //Serían las 23:59
            {
                CambiarListas();
                horaInicio = 0;
            }
            bannerResultado = ListaBannersActual.Values[horaInicio];
            if (ActualizarListaBanner)
            {
                CargarEnMemoria(DateTime.Today.AddDays(1).Date);
            }
            if (DateTime.Now.Minute % 60 == 0)
            {
                ThreadStart delegadoPS = new ThreadStart(ControladorFuente.Actualizar);
                Thread hiloSecundario = new Thread(delegadoPS);
                hiloSecundario.Start();
            }
            return bannerResultado;
        }

        /// <summary>
        /// Actualiza las Fuentes RSS y las devuelve actualizardas
        /// </summary>
        /// <returns>Tipo de dato Lista de Fuentes RSS qeu representa las del día de hoy actualizadas</returns>
        internal static List<IFuente> ActualizarFuentes()
        {
            List<IFuente> resultado = new List<IFuente>();
            foreach (Banner pBanners in ListaBannersActual.Values)
            {
                IFuente pFuente = pBanners.InstanciaFuente;
                if (pFuente.Actualizable())
                {
                    pFuente.Actualizar();
                    resultado.Add(pFuente);
                }
            }
            return resultado;
        }

        /// <summary>
        /// Obtiene el Banner de la lista que se corresponde con el suministrado
        /// </summary>
        /// <param name="pBanner">Banner suministrado</param>
        /// <returns>Tipo de dato Banner que representa aquel almacenado</returns>
        private static Banner BuscarBanner(Banner pBanner)
        {
            int i = 0;
            Banner resultado = BannerNulo;
            i = ListaBannersActual.IndexOfValue(pBanner);
            if (i != -1)
            {
                resultado = ListaBannersActual.Values[i];
            }
            else if (i == -1)
            {
                i = ListaBannersProxima.IndexOfValue(pBanner);
                if (i != -1)
                {
                    resultado = ListaBannersProxima.Values[i];
                }
            }
            return resultado;
        }

        /// <summary>
        /// Obtiene el Banner que se corresponde con el código
        /// </summary>
        /// <param name="pCodigoBanner">Codigo de Banner de la imagen a buscar</param>
        /// <returns>Banner cuyo código es el suminitrado</returns>
        internal static Banner ObtenerBannerPorCodigo(int pCodigoBanner)
        {
            return AutoMapper.Map<Persistencia.Banner, Banner>
                        (IoCContainerLocator.GetType<Persistencia.FachadaPersistencia>().ObtenerBanner(pCodigoBanner));
        }
    }
}
