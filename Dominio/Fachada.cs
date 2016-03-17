using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace Dominio
{
    class Fachada
    {
        DateTime iFechaActual;
        SortedList<int, Banner> iListaBannersActual;
        SortedList<int, Banner> iListaBannersProxima;
        SortedList<int, int> iListaCampañaActual;
        SortedList<int, int> iListaCampañaProxima;
        bool iActualizarListaBanners=false;
        bool iActualizarListaCampaña=false;

        /// <summary>
        /// Constructor de la fachada
        /// </summary>
        public Fachada()
        {
            this.iListaBannersActual = new SortedList<int, Banner>();
            this.iListaBannersProxima = new SortedList<int, Banner>();
            this.iListaCampañaActual = new SortedList<int, int>();
            this.iListaCampañaProxima = new SortedList<int, int>();
            this.iFechaActual = DateTime.Today.Date;
            this.InicializarListaBanner();
            this.InicializarListaCampaña();
        }

        /// <summary>
        /// Inicializa la lista de Banners con Banners nulos
        /// </summary>
        private void InicializarListaBanner()
        {
            int totalMinutosDia = (int)(new TimeSpan(23, 59, 00)).TotalMinutes;
            for (int i = 0; i <= totalMinutosDia; i++)
            {
                iListaBannersActual[i] = BannerNulo();
                iListaBannersProxima[i] = BannerNulo();
            }
            this.iActualizarListaBanners = false;
        }

        /// <summary>
        /// Inicializa la lista de Campaña con Campañas nulas
        /// </summary>
        private void InicializarListaCampaña()
        {
            int totalMinutosDia = (int)(new TimeSpan(23, 59, 00)).TotalMinutes;
            for (int i = 0; i <= totalMinutosDia; i++)
            {
                iListaCampañaActual[i] = CodigoCampañaNula();
                iListaCampañaActual[i] = CodigoCampañaNula();
            }
            this.iActualizarListaCampaña = false;
        }


        /// <summary>
        /// Establece la fecha actual de la Fachada
        /// </summary>
        /// <param name="fechaActual">Fecha Actual a establecer</param>
        public void EstablecerFecha(DateTime fechaActual)
        {
            this.iFechaActual = fechaActual.Date;
        }

        /// <summary>
        /// Carga la lista de Banners en la fachada
        /// </summary>
        /// <param name="listaBanners">Lista de Banners a cargar</param>
        public void Cargar(List<Banner> listaBanners)
        {
            this.InicializarListaBanner();
            this.InicializarListaCampaña();
            foreach (Banner pBanner in listaBanners)
            {
                this.Agregar(pBanner, this.iListaBannersProxima);
            }
        }

        /// <summary>
        /// Carga la lsita de Campaña en la fachada
        /// </summary>
        /// <param name="listaCampañas">Lista de Campañas a cargar</param>
        public void Cargar(List<Campaña> listaCampañas)
        {
            foreach (Campaña pCampaña in listaCampañas)
            {
                this.Agregar(pCampaña, this.iListaCampañaProxima);
            }
        }

        /// <summary>
        /// Agrega un Banner en la lista de la Fachada
        /// </summary>
        /// <param name="pBanner">Banner a agregar</param>
        public void Agregar(Banner pBanner)
        {
            foreach (RangoFecha pRangoFecha in pBanner.ListaRangosFecha)
            {
                if (this.RangoFechaActual(pRangoFecha))
                {
                    foreach (RangoHorario pRangoHorario in pRangoFecha.ListaRangosHorario)
                    {
                        if (DateTime.Now.TimeOfDay.Add(new TimeSpan(0, 1, 1)).CompareTo(pRangoHorario.HoraInicio) <= 0)
                        {
                            int minutoInicio = (int)pRangoHorario.HoraInicio.TotalMinutes;
                            int minutoFin = (int)pRangoHorario.HoraFin.TotalMinutes;
                            for (int i = minutoInicio; i <= minutoFin; i++)
                            {
                                this.iListaBannersActual[i] = pBanner;
                            }                            
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Agrega un Banner en la lista suministrada
        /// </summary>
        /// <param name="pBanner">Banner a agregar</param>
        /// <param name="listaBanners">Lista de Banners en la cual agregar</param>
        private void Agregar(Banner pBanner, SortedList<int, Banner> listaBanners)
        {
            foreach (RangoFecha pRangoFecha in pBanner.ListaRangosFecha)
            {
                if (this.RangoFechaActual(pRangoFecha))
                {
                    foreach (RangoHorario pRangoHorario in pRangoFecha.ListaRangosHorario)
                    {
                        int minutoInicio = (int)pRangoHorario.HoraInicio.TotalMinutes;
                        int minutoFin = (int)pRangoHorario.HoraFin.TotalMinutes;
                        for (int i=minutoInicio;i<=minutoFin;i++)
                        {
                            listaBanners[i] = pBanner;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Agrega una Campaña en la lista de la Fachada
        /// </summary>
        /// <param name="pBanner">Campaña a agregar</param>
        public void Agregar(Campaña pCampaña)
        {
            foreach (RangoFecha pRangoFecha in pCampaña.ListaRangosFecha)
            {
                if (this.RangoFechaActual(pRangoFecha))
                {
                    foreach (RangoHorario pRangoHorario in pRangoFecha.ListaRangosHorario)
                    {
                        if (DateTime.Now.TimeOfDay.Add(new TimeSpan(0, 1, 1)).CompareTo(pRangoHorario.HoraInicio) <= 0)
                        {
                            int minutoInicio = (int)pRangoHorario.HoraInicio.TotalMinutes;
                            int minutoFin = (int)pRangoHorario.HoraFin.TotalMinutes;
                            for (int i = minutoInicio; i <= minutoFin; i++)
                            {
                                this.iListaCampañaActual[i] = pCampaña.Codigo;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Agrega un Campaña en la lista suministrada
        /// </summary>
        /// <param name="pBanner">Campaña a agregar</param>
        /// <param name="listaBanners">Lista de Campañas en la cual agregar</param>
        private void Agregar(Campaña pCampaña, SortedList<int, int> iListaCampañas)
        {
            foreach (RangoFecha pRangoFecha in pCampaña.ListaRangosFecha)
            {
                if (this.RangoFechaActual(pRangoFecha))
                {
                    foreach (RangoHorario pRangoHorario in pRangoFecha.ListaRangosHorario)
                    {
                        int minutoInicio = (int)pRangoHorario.HoraInicio.TotalMinutes;
                        int minutoFin = (int)pRangoHorario.HoraFin.TotalMinutes;
                        for (int i = minutoInicio; i <= minutoFin; i++)
                        {
                            iListaCampañas[i] = pCampaña.Codigo;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Elimina un Banner de la lista de la Fachada
        /// </summary>
        /// <param name="pBanner">Banner a eliminar</param>
        public void Eliminar(Banner pBanner)
        {
            foreach (RangoFecha pRangoFecha in pBanner.ListaRangosFecha)
            {
                if (this.RangoFechaActual(pRangoFecha))
                {
                    foreach (RangoHorario pRangoHorario in pRangoFecha.ListaRangosHorario)
                    {
                        int minutoInicio = (int)pRangoHorario.HoraInicio.TotalMinutes;
                        int minutoFin = (int)pRangoHorario.HoraFin.TotalMinutes;
                        for (int i = minutoInicio; i <= minutoFin; i++)
                        {
                            this.iListaBannersActual[i]=BannerNulo();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Elimina una Campaña de la lista de la Fachada
        /// </summary>
        /// <param name="pBanner">Campaña a eliminar</param>
        public void Eliminar(Campaña pCampaña)
        {
            foreach (RangoFecha pRangoFecha in pCampaña.ListaRangosFecha)
            {
                if (this.RangoFechaActual(pRangoFecha))
                {
                    foreach (RangoHorario pRangoHorario in pRangoFecha.ListaRangosHorario)
                    {                    
                        int minutoInicio = (int)pRangoHorario.HoraInicio.TotalMinutes;
                        int minutoFin = (int)pRangoHorario.HoraFin.TotalMinutes;
                        for (int i = minutoInicio; i <= minutoFin; i++)
                        {
                            this.iListaCampañaActual[i] = CodigoCampañaNula();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Modifica un Banner de la lista de la Fachada
        /// </summary>
        /// <param name="pBanner">Banner a modificar</param>
        public void Modificar(Banner pBanner)
        {
            this.Eliminar(pBanner);
            this.Agregar(pBanner);
        }

        /// <summary>
        /// Modifica una Campaña de la lista de la Fachada
        /// </summary>
        /// <param name="pBanner">Banner a modificar</param>
        public void Modificar(Campaña pCampaña)
        {
            this.Eliminar(pCampaña);
            this.Agregar(pCampaña);
        }

        /// <summary>
        /// Determina si un Rango de Fecha está dentro del actual
        /// </summary>
        /// <param name="pRangoFecha">Rango Fecha a verificar</param>
        /// <returns>Tipo de dato booleano que representa si un Rango de Fecha es actual</returns>
        private bool RangoFechaActual(RangoFecha pRangoFecha)
        {
            DateTime hoy = DateTime.Today.Date;
            return (pRangoFecha.FechaInicio.CompareTo(hoy) <= 0 && pRangoFecha.FechaFin.CompareTo(hoy) >= 0);
        }

        /// <summary>
        /// Obtiene el Banner siguiente
        /// </summary>
        /// <param name="horaInicio">Hora de inicio a verificar el Banner siguiente</param>
        /// <param name="fechaActual">Fecha Actual en la que se pide el Banner</param>
        /// <returns>Tipo de dato Banner que representa el Banner siguiente</returns>
        public Banner ObtenerBannerSiguiente()
        {
            Banner bannerResultado;
            DateTime fechaActual = DateTime.Now;
            int horaInicio = (int)(new TimeSpan(fechaActual.Hour, fechaActual.Minute, fechaActual.Second)).TotalMinutes + 1;
            bannerResultado = this.iListaBannersActual.Values[horaInicio];
            if(horaInicio==1439)//Serían las 23:59
            {
                this.CambiarListaBanners();
                this.iActualizarListaBanners = true;
            }
            return bannerResultado;
        }

        /// <summary>
        /// Obtiene la Campaña siguiente
        /// </summary>
        /// <returns>Tipo de dato Campaña que representa la Campaña siguiente</returns>
        public int ObtenerCampañaSiguiente()
        {
            DateTime fechaActual = DateTime.Now;
            int horaInicio = (int)(new TimeSpan(fechaActual.Hour, fechaActual.Minute, fechaActual.Second).TotalMinutes)+1;
            if (horaInicio == 1439)//Serían a las 23:59
            {
                this.CambiarListaCampañas();
                this.iActualizarListaCampaña = true;
            }
            int campañaResultado = this.iListaCampañaActual.Values[horaInicio];
            return campañaResultado;
        }

        /// <summary>
        /// Cambia las listas de Banners
        /// </summary>
        public void CambiarListaBanners()
        {
            SortedList<int, Banner> listaAuxBanner = this.iListaBannersProxima;
            this.InicializarListaBanner();
            this.iListaBannersActual = listaAuxBanner;
        }

        /// <summary>
        /// Cambia las listas de Campañas
        /// </summary>
        public void CambiarListaCampañas()
        {
            SortedList<int, int> listaAuxCampaña = this.iListaCampañaProxima;
            this.InicializarListaCampaña();
            this.iListaCampañaActual = listaAuxCampaña;
        }

        /// <summary>
        /// Si se desea saber si hay que actualizar las listas o no.
        /// </summary>
        /// <returns>tipo booleano, verdadero en caso de que se necesite</returns>
        public bool NecesitaActualizarListas()
        {
            return (iActualizarListaBanners && iActualizarListaCampaña);
        }


        /// <summary>
        /// Clase responsable de comparar dos RangosHorarios
        /// </summary>
        private class ComparadorRangosHorarios : IComparer<RangoHorario>
        {
            /// <summary>
            /// Compara dos Rangos Horarios
            /// </summary>
            /// <param name="x">Rango Horario original</param>
            /// <param name="y">Rango Horario a comparar</param>
            /// <returns>Tipo de dato int que representa -1 si x menor a y, 0 si x igual a y, 1 si x mayor a y</y></returns>
            public int Compare(RangoHorario x, RangoHorario y)
            {
                return (x.HoraInicio.CompareTo(y.HoraInicio));
            }
        }


        /// <summary>
        /// Devuelve un Banner que es el Nulo (código -1)
        /// </summary>
        /// <returns>tipo de dato Banner que representa el Banner de código -1</returns>
        private static Dominio.Banner BannerNulo()
        {
            FuenteTextoFijo pTextoFijo = new FuenteTextoFijo("");
            return new Dominio.Banner()
            {
                Codigo = -1,
                InstanciaTexto = pTextoFijo
            };
        }



        /// <summary>
        /// Devuelve el codigo de una Campaña nula (código -1)
        /// </summary>
        /// <returns>tipo de dato Campaña que representa la Campaña de código -1</returns>
        public static int CodigoCampañaNula()
        {
            return -1;
        }

        /// <summary>
        /// Devuelve una campaña nula (código -1)
        /// </summary>
        /// <returns>tipo de dato Campaña que representa la Campaña de código -1</returns>
        public static Campaña CampañaNula()
        {
            List<Imagen> lImagenesNula = new List<Imagen>();
            Imagen imagenNula = new Imagen();
            imagenNula.Picture = Properties.Resources.sinCampaña;
            imagenNula.Tiempo = 60;
            lImagenesNula.Add(imagenNula);
            return new Campaña { Codigo = CodigoCampañaNula(), Nombre = "", ListaImagenes = lImagenesNula };
        }

        /// <summary>
        /// Comprueba si la Campaña es nula o no.
        /// </summary>
        /// <returns>Devuelve verdadero si es nulo la Campaña</returns>
        public static bool EsCampañaNula(int pCampaña)
        {
            bool resultado = false;
            if (pCampaña == -1)
            {
                resultado = true;
            }
            return resultado;
        }
    }
}
