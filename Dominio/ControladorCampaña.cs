using Persistencia;
using System;
using System.Collections.Generic;

namespace Dominio
{
    class ControladorCampaña : IEquatable<ControladorCampaña>
    {
        #region Instancia
        private int iCodigo;
        private int iInteravaloTiempo;
        private string iNombre;
        private List<RangoFecha> iListaRangosFecha;
        private List<Imagen> iListaImagenes;

        /// <summary>
        /// Constructor de la Campaña
        /// </summary>
        public ControladorCampaña()
        {
            this.iListaRangosFecha = new List<RangoFecha>();
            this.iListaImagenes = new List<Imagen>();
        }

        /// <summary>
        /// Get/Set del código de la campaña
        /// </summary>
        public int Codigo
        {
            get { return this.iCodigo; }
            set { this.iCodigo = value; }
        }

        /// <summary>
        /// Get/Set del intervalo de tiempo  de la campaña
        /// </summary>
        public int IntervaloTiempo
        {
            get { return this.iInteravaloTiempo; }
            set { this.iInteravaloTiempo = value; }
        }

        /// <summary>
        /// Get/Set del nombre de la campaña
        /// </summary>
        public string Nombre
        {
            get { return this.iNombre; }
            set { this.iNombre = value; }
        }

        /// <summary>
        /// Get/Set de la lista de Rangos de Fecha
        /// </summary>
        public List<RangoFecha> ListaRangosFecha
        {
            get { return this.iListaRangosFecha; }
            set { this.iListaRangosFecha = value; }
        }

        /// <summary>
        /// Get/Set de la lista de imágenes de la campaña
        /// </summary>
        public List<Imagen> ListaImagenes
        {
            get { return this.iListaImagenes; }
            set { this.iListaImagenes = value; }
        }
        
        /// <summary>
        /// Determina si dos campañas son iguales
        /// </summary>
        /// <param name="other">Otra campaña a comparar</param>
        /// <returns>Tipo de dato booleano que representa si dos campañas son iguales</returns>
        public bool Equals(ControladorCampaña other)
        {
            return this.Codigo == other.Codigo;
        }

        /// <summary>
        /// Devuelve los rangos Horarios ocupados por la campaña
        /// </summary>
        /// <returns>Tipo de dato Lista de Rangos Horarios que representan aquellos ocupados por la campaña</returns>
        public List<RangoHorario> ObtenerRangosHorariosOcupados()
        {
            List<RangoHorario> listaResultado = new List<RangoHorario>();
            foreach(RangoFecha pRangoFecha in this.iListaRangosFecha)
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
            foreach (RangoFecha pRangoFecha in this.ListaRangosFecha)
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
        private static ControladorCampaña CampañaNula;
        private static SortedList<int, int> ListaCampañaActual;
        private static SortedList<int, int> ListaCampañaProxima;
        private static bool ActualizarListaCampaña = false;
        #endregion

        #region Inicializar
        /// <summary>
        /// Inicializa los atributos de la Logica Compaña
        /// </summary>
        public static void Inicializar()
        {
            //CAMPAÑA NULA
            List<Imagen> lImagenesNula = new List<Imagen>();
            Imagen imagenNula = new Imagen();
            imagenNula.Picture = Properties.Resources.sinCampaña;
            imagenNula.Tiempo = 60;
            lImagenesNula.Add(imagenNula);
            CampañaNula = new ControladorCampaña { Codigo = CodigoCampañaNula(), Nombre = "", ListaImagenes = lImagenesNula };
            ListaCampañaActual = new SortedList<int, int>();
            ListaCampañaProxima = new SortedList<int, int>();
            InicializarListaCampaña();
        }

        /// <summary>
        /// Inicializa la lista de Campaña con Campañas nulas
        /// </summary>
        private static void InicializarListaCampaña()
        {
            ListaCampañaProxima = new SortedList<int, int>();
            int totalMinutosDia = (int)(new TimeSpan(23, 59, 00)).TotalMinutes;
            for (int i = 0; i <= totalMinutosDia; i++)
            {
                ListaCampañaProxima[i] = CodigoCampañaNula();
            }
            ActualizarListaCampaña = false;
        }
        #endregion

        #region Carga
        /// <summary>
        /// Carga la lista de Campañas en la lógica
        /// </summary>
        /// <param name="listaCampañas">Lista de Campañas a cargar</param>
        public static void Cargar(List<ControladorCampaña> listaCampañas)
        {
            foreach (ControladorCampaña pCampaña in listaCampañas)
            {
                foreach (int pIndice in pCampaña.ListaDeIndices(DateTime.Now.Date))
                {
                    ListaCampañaProxima[pIndice] = pCampaña.Codigo;
                }
            }
        }

        /// <summary>
        /// Carga las Listas inicialmentes
        /// </summary>
        public static void CargaInicial()
        {
            CambiarListas();
        }

        /// <summary>
        /// Carga las Campañas del día de la fecha en la Fachada
        /// </summary>
        /// <param name="pFecha">Fecha Actual de Carga</param>
        public static void CargarEnMemoria(DateTime pFecha)
        {
            RangoFecha pRF = new RangoFecha() { FechaInicio = pFecha, FechaFin = pFecha };
            //Argumentos de filtrado de Campaña
            Dictionary<Type, object> argumentosCampaña = new Dictionary<Type, object>();
            argumentosCampaña.Add(typeof(string), "");
            argumentosCampaña.Add(typeof(RangoFecha), pRF);
            Cargar(ObtenerCampañas(argumentosCampaña));
        }

        /// <summary>
        /// Cambia las listas de Campañas
        /// </summary>
        private static void CambiarListas()
        {
            SortedList<int, int> listaAuxCampaña = new SortedList<int, int>(ListaCampañaProxima);
            InicializarListaCampaña();
            ListaCampañaActual = listaAuxCampaña;
        }
        #endregion  

        /// <summary>
        /// Agrega una Campaña en la lista de la lógica
        /// </summary>
        /// <param name="pBanner">Campaña a agregar</param>
        public static void Agregar(ControladorCampaña pCampaña)
        {
            Persistencia.Fachada fachada = IoCContainerLocator.GetType<Persistencia.Fachada>();
            pCampaña.Codigo = fachada.CrearCampaña(AutoMapper.Map<Dominio.ControladorCampaña, Persistencia.Campaña>(pCampaña));
            //Lista Actual
            foreach (int pIndice in pCampaña.ListaDeIndices(DateTime.Now.Date))
            {
                ListaCampañaActual[pIndice] = pCampaña.Codigo;
            }
            //Lista Próxima
            foreach (int pIndice in pCampaña.ListaDeIndices(DateTime.Now.AddDays(1).Date))
            {
                ListaCampañaProxima[pIndice] = pCampaña.Codigo;
            }
            GC.Collect();
        }

        /// <summary>
        /// Modifica una Campaña de la lista de la lógica
        /// </summary>
        /// <param name="pBanner">Banner a modificar</param>
        public static void Modificar(ControladorCampaña pCampaña)
        {
            Persistencia.Fachada fachada = IoCContainerLocator.GetType<Persistencia.Fachada>();
            fachada.ActualizarCampaña(AutoMapper.Map<Dominio.ControladorCampaña, Persistencia.Campaña>(pCampaña));
            Eliminar(pCampaña);
            Agregar(pCampaña);
        }

        /// <summary>
        /// Elimina una Campaña de la lista de la lógica
        /// </summary>
        /// <param name="pBanner">Campaña a eliminar</param>
        public static void Eliminar(ControladorCampaña pCampaña)
        {
            Persistencia.Fachada fachada = IoCContainerLocator.GetType<Persistencia.Fachada>();
            fachada.EliminarCampaña(AutoMapper.Map<Dominio.ControladorCampaña, Persistencia.Campaña>(pCampaña));
            for (int i = 0; i < ListaCampañaActual.Count; i++)
            {
                if (ListaCampañaActual[i] == pCampaña.Codigo)
                {
                    ListaCampañaActual[i] = CodigoCampañaNula();
                }
                if (ListaCampañaProxima[i] == pCampaña.Codigo)
                {
                    ListaCampañaActual[i] = CodigoCampañaNula();
                }
            }
        }

        /// <summary>
        /// Obtiene todos las Campañas que cumplen con un determinado filtro
        /// </summary>
        /// <param name="argumentosFiltrado">Argumentos para filtrar Campañas</param>
        /// <returns>Tipo de dato Lista que representa las Campañas filtradas</returns>
        public static List<Dominio.ControladorCampaña> ObtenerCampañas(Dictionary<Type, object> argumentosFiltrado = null)
        {
            Persistencia.Fachada fachada = IoCContainerLocator.GetType<Persistencia.Fachada>();
            if (argumentosFiltrado != null)
            {
                if (argumentosFiltrado.ContainsKey(typeof(RangoFecha)))
                {
                    argumentosFiltrado.Add(typeof(Persistencia.RangoFecha),
                                            AutoMapper.Map<RangoFecha, Persistencia.RangoFecha>
                                            ((RangoFecha)argumentosFiltrado[typeof(RangoFecha)]));
                    argumentosFiltrado.Remove(typeof(RangoFecha));
                }
            }
            return (AutoMapper.Map<List<Persistencia.Campaña>, List<ControladorCampaña>>(fachada.ObtenerCampañas(argumentosFiltrado)));
        }

        /// <summary>
        /// Obtiene la campaña correspondiente con respecto a la fecha y a la hora
        /// </summary>
        /// <returns>Tipo de dato Campaña que representa la campaña Siguiente a mostrar</returns>
        public static ControladorCampaña ObtenerSiguiente()
        {
            ControladorCampaña campañaResultado;
            DateTime fechaActual = DateTime.Now;
            int horaInicio = (int)(new TimeSpan(fechaActual.Hour, fechaActual.Minute, 0).TotalMinutes) + 1;
            if (horaInicio > 1380)
            {
                ActualizarListaCampaña = true;
            }
            if (horaInicio == 1439) //Serían las 23:59
            {
                CambiarListas();
                horaInicio = 0;
            }
            int codigoCampañaResultado = ListaCampañaActual.Values[horaInicio];
            if (CodigoCampañaNula() == codigoCampañaResultado)
            {
                campañaResultado = CampañaNula;
            }
            else
            {
                FachadaCRUDCampaña fachadaCampaña = IoCContainerLocator.GetType<FachadaCRUDCampaña>();
                campañaResultado = AutoMapper.Map<Persistencia.Campaña, ControladorCampaña>(fachadaCampaña.GetByCodigo(codigoCampañaResultado));
                campañaResultado.ListaImagenes = ObtenerImagenesCampaña(codigoCampañaResultado);
            }
            if (ActualizarListaCampaña)
            {
                CargarEnMemoria(DateTime.Today.AddDays(1).Date);
            }
            return campañaResultado;
        }

        /// <summary>
        /// Obtiene las imágenes correspondientes a una campaña
        /// </summary>
        /// <param name="codigoCampaña">Codigo de campaña de la imagen a buscar</param>
        /// <returns>Lista de imágenes de la campaña</returns>
        public static List<Imagen> ObtenerImagenesCampaña(int codigoCampaña)
        {
            return AutoMapper.Map<List<Persistencia.Imagen>, List<Dominio.Imagen>>
                        (IoCContainerLocator.GetType<Persistencia.Fachada>().ObtenerImagenesCampaña(codigoCampaña));
        }
        
        /// <summary>
        /// Obtiene los Rangos Horarios Ocupados para un cierto Rango de Fechas
        /// </summary>
        /// <param name="pRangoFecha">Rango de Fechas</param>
        /// <returns>Tipo de dato Lista de Rangos Horarios que representa los rangos horarios ocupados</returns>
        public static List<Dominio.RangoHorario> RangosHorariosOcupados(Dominio.RangoFecha pRangoFecha)
        {
            Dictionary<Type, object> argumentos = new Dictionary<Type, object>();
            argumentos.Add(typeof(string), "");
            argumentos.Add(typeof(Dominio.RangoFecha), pRangoFecha);
            List<ControladorCampaña> pListaCampaña = ObtenerCampañas(argumentos);
            List<RangoHorario> listaResultado = new List<RangoHorario>();
            foreach (ControladorCampaña pCampaña in pListaCampaña)
            {
                listaResultado.AddRange(pCampaña.ObtenerRangosHorariosOcupados());
            }
            return listaResultado;
        }

        /// <summary>
        /// Devuelve el codigo de una Campaña nula (código -1)
        /// </summary>
        /// <returns>tipo de dato Campaña que representa la Campaña de código -1</returns>
        private static int CodigoCampañaNula()
        {
            return -1;
        }
        #endregion
    }
}
