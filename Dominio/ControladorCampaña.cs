using Persistencia;
using System;
using System.Collections.Generic;

namespace Dominio
{
    class ControladorCampaña
    {
        #region Atributos
        private static Campaña CampañaNula;
        private static SortedList<int, int> ListaCampañaActual;
        private static SortedList<int, int> ListaCampañaProxima;
        private static bool ActualizarListaCampaña = false;
        #endregion

        #region Inicializar
        /// <summary>
        /// Inicializa los atributos de la Logica Compaña
        /// </summary>
        internal static void Inicializar()
        {
            //CAMPAÑA NULA
            List<Imagen> lImagenesNula = new List<Imagen>();
            Imagen imagenNula = new Imagen();
            imagenNula.Picture = Properties.Resources.sinCampaña;
            imagenNula.Tiempo = 60;
            lImagenesNula.Add(imagenNula);
            CampañaNula = new Campaña { Codigo = CodigoCampañaNula(), Nombre = "", ListaImagenes = lImagenesNula };
            ListaCampañaActual = new SortedList<int, int>();
            ListaCampañaProxima = new SortedList<int, int>();
            InicializarListaCampaña();
        }

        /// <summary>
        /// Inicializa la lista de Campaña con Campañas nulas
        /// </summary>
        internal static void InicializarListaCampaña()
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
        private static void Cargar(List<Campaña> listaCampañas)
        {
            foreach (Campaña pCampaña in listaCampañas)
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
        internal static void CargaInicial()
        {
            CambiarListas();
        }

        /// <summary>
        /// Carga las Campañas del día de la fecha en la Fachada
        /// </summary>
        /// <param name="pFecha">Fecha Actual de Carga</param>
        internal static void CargarEnMemoria(DateTime pFecha)
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
        internal static void Agregar(Campaña pCampaña)
        {
            Persistencia.FachadaPersistencia fachada = IoCContainerLocator.GetType<Persistencia.FachadaPersistencia>();
            pCampaña.Codigo = fachada.CrearCampaña(AutoMapper.Map<Dominio.Campaña, Persistencia.Campaña>(pCampaña));
            AgregarLocal(pCampaña);
        }

        /// <summary>
        /// Agrega una Campaña en la lista Caché local
        /// </summary>
        /// <param name="pCampaña">Campaña a agregar</param>
        private static void AgregarLocal(Campaña pCampaña)
        {
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
        internal static void Modificar(Campaña pCampaña)
        {
            Persistencia.FachadaPersistencia fachada = IoCContainerLocator.GetType<Persistencia.FachadaPersistencia>();
            fachada.ActualizarCampaña(AutoMapper.Map<Dominio.Campaña, Persistencia.Campaña>(pCampaña));
            EliminarLocal(pCampaña);
            AgregarLocal(pCampaña);
        }

        /// <summary>
        /// Elimina una Campaña de la lista de la lógica
        /// </summary>
        /// <param name="pBanner">Campaña a eliminar</param>
        internal static void Eliminar(Campaña pCampaña)
        {
            Persistencia.FachadaPersistencia fachada = IoCContainerLocator.GetType<Persistencia.FachadaPersistencia>();
            fachada.EliminarCampaña(AutoMapper.Map<Dominio.Campaña, Persistencia.Campaña>(pCampaña));
            EliminarLocal(pCampaña);
        }

        /// <summary>
        /// Elimina la Campaña de la Lista Caché local
        /// </summary>
        /// <param name="pCampaña">Campaña a eliminar localmente</param>
        private static void EliminarLocal(Campaña pCampaña)
        {
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
        internal static List<Campaña> ObtenerCampañas(Dictionary<Type, object> argumentosFiltrado = null)
        {
            Persistencia.FachadaPersistencia fachada = IoCContainerLocator.GetType<Persistencia.FachadaPersistencia>();
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
            return (AutoMapper.Map<List<Persistencia.Campaña>, List<Campaña>>(fachada.ObtenerCampañas(argumentosFiltrado)));
        }

        /// <summary>
        /// Obtiene la campaña correspondiente con respecto a la fecha y a la hora
        /// </summary>
        /// <returns>Tipo de dato Campaña que representa la campaña Siguiente a mostrar</returns>
        internal static Campaña ObtenerSiguiente()
        {
            Campaña campañaResultado;
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
                campañaResultado = ObtenerCampañaPorCodigo(codigoCampañaResultado);
            }
            if (ActualizarListaCampaña)
            {
                CargarEnMemoria(DateTime.Today.AddDays(1).Date);
            }
            return campañaResultado;
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
            argumentos.Add(typeof(Dominio.RangoFecha), pRangoFecha);
            List<Campaña> pListaCampaña = ObtenerCampañas(argumentos);
            List<RangoHorario> listaResultado = new List<RangoHorario>();
            foreach (Campaña pCampaña in pListaCampaña)
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

        /// <summary>
        /// Obtiene la campaña que se corresponde con el código
        /// </summary>
        /// <param name="pCodigoCampaña">Codigo de campaña de la imagen a buscar</param>
        /// <returns>Campaña cuyo código es el suminitrado</returns>
        internal static Campaña ObtenerCampañaPorCodigo(int pCodigoCampaña)
        {
            return AutoMapper.Map<Persistencia.Campaña,Campaña>
                        (IoCContainerLocator.GetType<Persistencia.FachadaPersistencia>().ObtenerCampaña(pCodigoCampaña));
        }
    }
}
