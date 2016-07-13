using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System;
using System.Threading;

//Hace que sea visible para el Testing, los Servicios y UI
[assembly: InternalsVisibleTo("Testings")]
[assembly: InternalsVisibleTo("UI")]

namespace Dominio
{
    class ControladorBanner : IEquatable<ControladorBanner>
    {
        #region Instanica
        private int iCodigo;
        private string iNombre;
        private IFuente iFuente;
        private List<RangoFecha> iListaRangosFecha;

        /// <summary>
        /// Constructor del Banner
        /// </summary>
        public ControladorBanner()
        {
            this.iListaRangosFecha = new List<RangoFecha>();
        }

        /// <summary>
        /// Get/Set del código del Banner
        /// </summary>
        public int Codigo
        {
            get { return this.iCodigo; }
            set { this.iCodigo = value; }
        }

        /// <summary>
        /// Get/Set del nombre del Banner
        /// </summary>
        public string Nombre
        {
            get { return this.iNombre; }
            set { this.iNombre = value; }
        }

        /// <summary>
        /// Get del Texto del Banner
        /// </summary>
        public string Texto
        {
            get { return this.iFuente.Texto(); }

        }

        /// <summary>
        /// Get/Set de la Fuente del Banner
        /// </summary>
        public IFuente InstanciaFuente
        {
            get { return this.iFuente; }
            set { this.iFuente = value; }
        }

        /// <summary>
        /// Get/Set de la Lista de Rangos de Fechas
        /// </summary>
        public List<RangoFecha> ListaRangosFecha
        {
            get { return this.iListaRangosFecha; }
            set { this.iListaRangosFecha = value; }
        }

        /// <summary>
        /// Compara dos intancias de Banner
        /// </summary>
        /// <param name="other">Otro Banner a comparar</param>
        /// <returns>Tipo de dato booleano que representa si dos instancias de Banner son diferentes</returns>
        public bool Equals(ControladorBanner other)
        {
            return this.Codigo == other.Codigo;
        }

        /// <summary>
        /// Devuelve los rangos Horarios ocupados por el Banner
        /// </summary>
        /// <returns>Tipo de dato Lista de Rangos Horarios que representan aquellos ocupados por el Banner</returns>
        public List<RangoHorario> ObtenerRangosHorariosOcupados()
        {
            List<RangoHorario> listaResultado = new List<RangoHorario>();
            foreach (RangoFecha pRangoFecha in this.iListaRangosFecha)
            {
                listaResultado.AddRange(pRangoFecha.ListaRangosHorario);
            }
            return listaResultado;
        }

        /// <summary>
        /// Devuelve los Rangos Horarios de los Rangos de Fecha que contienen la fecha suministrada
        /// </summary>
        /// <param name="pFecha">Fecha a contener</param>
        /// <returns>Tipo de dato Lista de Rangos Horarios que pertenencen a los Rangos de fecha que contienen la fecha suministrada</returns>
        private List<RangoHorario> RangosHorariosDeFecha(DateTime pFecha)
        {
            List<RangoHorario> listaRangosHorarios = new List<RangoHorario>();
            foreach(RangoFecha pRangoFecha in this.ListaRangosFecha)
            {
                if (pRangoFecha.RangoContieneFecha(pFecha))
                {
                    listaRangosHorarios.AddRange(pRangoFecha.ListaRangosHorario);
                }
            }
            return listaRangosHorarios;
        }

        /// <summary>
        /// Devuelve los Rangos Horarios de los Rangos de Fecha que contienen la fecha suministrada
        /// </summary>
        /// <param name="pFecha">Fecha a contener</param>
        /// <returns>Tipo de dato Lista de Rangos Horarios que pertenencen a los Rangos de fecha que contienen la fecha suministrada</returns>
        public List<int> ListaDeIndices(DateTime pFecha)
        {
            List<int> listaResultado = new List<int>();
            List<RangoHorario> listaRangosHorarios = this.RangosHorariosDeFecha(pFecha);
            foreach (RangoHorario pRangoHorario in listaRangosHorarios)
            {
                for (int i = pRangoHorario.CodigoInicio; i < pRangoHorario.CodigoFin; i++)
                {
                    listaResultado.Add(i);
                }
            }
            return listaResultado;
        }
        #endregion

        #region Logica
        #region Atributos
        private static ControladorBanner BannerNulo;
        private static SortedList<int, ControladorBanner> ListaBannersActual;
        private static SortedList<int, ControladorBanner> ListaBannersProxima;
        private static bool ActualizarListaBanner = false;
        #endregion

        #region Inicializar
        /// <summary>
        /// Inicializa los atributos de la Logica Banner
        /// </summary>
        public static void Inicializar()
        {
            FuenteTextoFijo pTextoFijo = new FuenteTextoFijo() { Valor = "Publicite Aquí" };
            BannerNulo = new ControladorBanner()
            {
                Codigo = -1,
                InstanciaFuente = pTextoFijo
            };
            ListaBannersActual = new SortedList<int, ControladorBanner>();
            ListaBannersProxima = new SortedList<int, ControladorBanner>();
            InicializarListaBanner();
        }

        /// <summary>
        /// Inicializa la lista de Banners con Banners nulos
        /// </summary>
        private static void InicializarListaBanner()
        {
            ListaBannersProxima = new SortedList<int, ControladorBanner>();
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
        public static void Cargar(List<ControladorBanner> listaBanners)
        {
            foreach (ControladorBanner pBanner in listaBanners)
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
        public static void CargaInicial()
        {
            CambiarListas();
        }

        /// <summary>
        /// Carga los Banners del día en la Fachada
        /// </summary>
        /// <param name="pFecha">Fecha Actual de Carga</param>
        public static void CargarEnMemoria(DateTime pFecha)
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
            SortedList<int, ControladorBanner> listaAuxBanner = ListaBannersProxima;
            InicializarListaBanner();
            ListaBannersActual = listaAuxBanner;
        }
        #endregion

        /// <summary>
        /// Agrega un Banner en la lista de la lógica
        /// </summary>
        /// <param name="pBanner">Banner a agregar</param>
        public static void Agregar(ControladorBanner pBanner)
        {
            Persistencia.Fachada fachada = IoCContainerLocator.GetType<Persistencia.Fachada>();
            pBanner.Codigo = fachada.CrearBanner(AutoMapper.Map<ControladorBanner, Persistencia.Banner>(pBanner));
            AgregarLocal(pBanner);
        }

        /// <summary>
        /// Agrega un Banner en la lista Caché local
        /// </summary>
        /// <param name="pBanner">Banner a agregar</param>
        private static void AgregarLocal(ControladorBanner pBanner)
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
        public static void Modificar(ControladorBanner pBanner)
        {
            Persistencia.Fachada fachada = IoCContainerLocator.GetType<Persistencia.Fachada>();
            fachada.ActualizarBanner(AutoMapper.Map<Dominio.ControladorBanner, Persistencia.Banner>(pBanner));
            EliminarLocal(BuscarBanner(pBanner));
            AgregarLocal(pBanner);
        }

        /// <summary>
        /// Elimina un Banner de la lista de la lógica
        /// </summary>
        /// <param name="pBanner">Banner a eliminar</param>
        public static void Eliminar(ControladorBanner pBanner)
        {
            Persistencia.Fachada fachada = IoCContainerLocator.GetType<Persistencia.Fachada>();
            fachada.EliminarBanner(AutoMapper.Map<Dominio.ControladorBanner, Persistencia.Banner>(pBanner));
            EliminarLocal(pBanner);
        }

        /// <summary>
        /// Elimina el Banner de la Lista Caché local
        /// </summary>
        /// <param name="pBanner">Banner a eliminar localmente</param>
        private static void EliminarLocal(ControladorBanner pBanner)
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
        public static List<ControladorBanner> ObtenerBanners(Dictionary<Type, object> argumentosFiltrado = null)
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
                if (argumentosFiltrado.ContainsKey(typeof(Dominio.IFuente)))
                {
                    argumentosFiltrado.Add(typeof(Persistencia.Fuente),
                                            (AutoMapper.Map<Dominio.IFuente, Persistencia.Fuente>
                                            ((Dominio.IFuente)argumentosFiltrado[typeof(Dominio.IFuente)])).GetType());
                    argumentosFiltrado.Remove(typeof(Dominio.IFuente));
                }
            }
            return (AutoMapper.Map<List<Persistencia.Banner>, List<Dominio.ControladorBanner>>(fachada.ObtenerBanners(argumentosFiltrado)));
        }

        /// <summary>
        /// Obtiene los Rangos Horarios Ocupados para un cierto Rango de Fechas
        /// </summary>
        /// <param name="pRangoFecha">Rango de Fechas</param>
        /// <returns>Tipo de dato Lista de Rangos Horarios que representa los rangos horarios ocupados</returns>
        public static List<RangoHorario> RangosHorariosOcupados(RangoFecha pRangoFecha)
        {
            Dictionary<Type, object> argumentos = new Dictionary<Type, object>();
            argumentos.Add(typeof(string), "");
            argumentos.Add(typeof(RangoFecha), pRangoFecha);
            List<ControladorBanner> pListaBanners = ObtenerBanners(argumentos);
            List<RangoHorario> listaResultado = new List<RangoHorario>();
            foreach (ControladorBanner pBanner in pListaBanners)
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
        public static ControladorBanner ObtenerSiguiente()
        {
            ControladorBanner bannerResultado;
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
            foreach (ControladorBanner pBanners in ListaBannersActual.Values)
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
        private static ControladorBanner BuscarBanner(ControladorBanner pBanner)
        {
            int i = 0;
            ControladorBanner resultado = BannerNulo;
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
        #endregion
    }
}
