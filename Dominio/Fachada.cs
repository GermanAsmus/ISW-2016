using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace Dominio
{
    class Fachada
    {
        DateTime iFechaActual;
        SortedList<RangoHorario, Banner> iListaBannersActual;
        SortedList<RangoHorario, Banner> iListaBannersProxima;
        SortedList<RangoHorario,int> iListaCampañaActual;
        SortedList<RangoHorario, int> iListaCampañaProxima;

        /// <summary>
        /// Constructor de la fachada
        /// </summary>
        public Fachada()
        {
            this.iListaBannersActual = new SortedList<RangoHorario, Banner>(new ComparadorRangosHorarios());
            this.iListaBannersProxima = new SortedList<RangoHorario, Banner>(new ComparadorRangosHorarios());
            this.iListaCampañaActual = new SortedList<RangoHorario, int>(new ComparadorRangosHorarios());
            this.iListaCampañaProxima = new SortedList<RangoHorario, int>(new ComparadorRangosHorarios());
            this.iFechaActual = DateTime.Today.Date;
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
                            this.iListaBannersActual[pRangoHorario] = pBanner;
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
        private void Agregar(Banner pBanner, SortedList<RangoHorario, Banner> listaBanners)
        {
            foreach (RangoFecha pRangoFecha in pBanner.ListaRangosFecha)
            {
                if (this.RangoFechaActual(pRangoFecha))
                {
                    foreach (RangoHorario pRangoHorario in pRangoFecha.ListaRangosHorario)
                    {
                        listaBanners[pRangoHorario] = pBanner;
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
            foreach(RangoFecha pRangoFecha in pCampaña.ListaRangosFecha)
            {
                if (this.RangoFechaActual(pRangoFecha))
                {
                    foreach(RangoHorario pRangoHorario in pRangoFecha.ListaRangosHorario)
                    {
                        if (DateTime.Now.TimeOfDay.Add(new TimeSpan(0, 1, 1)).CompareTo(pRangoHorario.HoraInicio) <= 0)
                        {
                            this.iListaCampañaActual[pRangoHorario] = pCampaña.Codigo;
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
        private void Agregar(Campaña pCampaña, SortedList<RangoHorario, int> iListaCampañas)
        {
            foreach (RangoFecha pRangoFecha in pCampaña.ListaRangosFecha)
            {
                if (this.RangoFechaActual(pRangoFecha))
                {
                    foreach (RangoHorario pRangoHorario in pRangoFecha.ListaRangosHorario)
                    {
                        iListaCampañas[pRangoHorario] = pCampaña.Codigo;
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
                        this.iListaBannersActual.Remove(pRangoHorario);
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
                        this.iListaBannersActual.Remove(pRangoHorario);
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
            int indice = this.iListaBannersActual.IndexOfValue(pBanner);
            while (indice != -1)
            {
                this.iListaBannersActual.RemoveAt(indice);
                indice = this.iListaBannersActual.IndexOfValue(pBanner);
            }
            this.Agregar(pBanner);
        }

        /// <summary>
        /// Modifica una Campaña de la lista de la Fachada
        /// </summary>
        /// <param name="pBanner">Banner a modificar</param>
        public void Modificar(Campaña pCampaña)
        {
            int indice = this.iListaCampañaActual.IndexOfValue(pCampaña.Codigo);
            while (indice != -1)
            {
                this.iListaCampañaActual.RemoveAt(indice);
                indice = this.iListaCampañaActual.IndexOfValue(pCampaña.Codigo);
            }
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
        public Banner ObtenerBannerSiguiente(TimeSpan horaInicio, DateTime fechaActual)
        {
            if(fechaActual.Date.CompareTo(this.iFechaActual) < 0)
            {
                this.CambiarListas();
                this.EstablecerFecha(fechaActual);
            }
            Banner bannerResultado;
            int indice = 0;
            if((indice == this.iListaBannersActual.Count) || 
                Math.Abs((horaInicio.Subtract(this.iListaBannersActual.Keys[indice].HoraInicio)).TotalSeconds) > 60)
            {
                bannerResultado = BannerNulo();
            }
            else
            {
                bannerResultado = this.iListaBannersActual.Values[indice];
                this.Eliminar(bannerResultado);
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
            TimeSpan horaInicio = new TimeSpan(fechaActual.Hour, fechaActual.Minute, fechaActual.Second);
            if (fechaActual.Date.CompareTo(this.iFechaActual) < 0)
            {
                this.CambiarListas();
                this.EstablecerFecha(fechaActual);
            }
            int campañaResultado;
            int indice = 0;
            if ((indice == this.iListaCampañaActual.Count) || 
                Math.Abs((horaInicio.Subtract(this.iListaCampañaActual.Keys[indice].HoraInicio)).TotalSeconds) > 60)
            {
                campañaResultado = -1;
            }
            else
            {
                campañaResultado = this.iListaCampañaActual.Values[indice];
                this.iListaCampañaActual.RemoveAt(indice);
            }
            return campañaResultado;
        }

        /// <summary>
        /// Cambia las listas de Banners y Campañas
        /// </summary>
        public void CambiarListas()
        {
            this.iListaBannersActual = this.iListaBannersProxima;
            this.iListaBannersProxima = new SortedList<RangoHorario, Banner>();
            this.iListaCampañaActual = this.iListaCampañaProxima;
            this.iListaCampañaProxima = new SortedList<RangoHorario, int>();
        }

        /// <summary>
        /// Devuleve la duración en segundos del banner siguiente
        /// </summary>
        /// <param name="horaInicio">Hora de inicio a verificar la Campaña siguiente</param>
        /// <returns>Tipo de dato Entero que representa la duración del banner siguiente</returns>
        public int ObtenerDuracionBannerSiguiente(TimeSpan horaInicio)
        {
            int duracionResultado = 0;
            int indice = 0;
            if ((indice == this.iListaBannersActual.Count) ||
                Math.Abs((horaInicio.Subtract(this.iListaBannersActual.Keys[indice].HoraInicio)).TotalSeconds) > 60)
            {
                duracionResultado = 60;
            }
            else
            {
                RangoHorario rangoActual = this.iListaBannersActual.Keys[indice];
                duracionResultado = ((rangoActual.HoraFin.Hours - rangoActual.HoraInicio.Hours) * 60 + (rangoActual.HoraFin.Minutes - rangoActual.HoraInicio.Minutes)) * 60;
            }
            return duracionResultado;
        }

        /// <summary>
        /// Devuleve la duración en segundos del banner siguiente
        /// </summary>
        /// <param name="horaInicio">Hora de inicio a verificar la Campaña siguiente</param>
        /// <returns>Tipo de dato Entero que representa la duración del banner siguiente</returns>
        public int ObtenerDuracionCampañaSiguiente()
        {
            DateTime fechaActual = DateTime.Now;
            TimeSpan horaInicio= new TimeSpan(fechaActual.Hour, fechaActual.Minute, fechaActual.Second);
            int duracionResultado = 0;
            int indice = 0;
            if ((indice == this.iListaCampañaActual.Count)||
                Math.Abs((horaInicio.Subtract(this.iListaCampañaActual.Keys[indice].HoraInicio)).TotalSeconds) > 60)
            {
                duracionResultado = 60;
            }
            else
            {
                RangoHorario rangoActual = this.iListaCampañaActual.Keys[indice];
                duracionResultado = ((rangoActual.HoraFin.Hours - rangoActual.HoraInicio.Hours) * 60 + (rangoActual.HoraFin.Minutes - rangoActual.HoraInicio.Minutes)) * 60;
            }
            return duracionResultado;
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
        public static Dominio.Banner BannerNulo()
            {
                TextoFijo pTextoFijo = new TextoFijo("");
                return new Dominio.Banner()
                {
                    Codigo = -1,
                    InstanciaTexto = pTextoFijo
                };
            }

            /// <summary>
            /// Comprueba si el banner es nulo o no.
            /// </summary>
            /// <returns>Devuelve verdadero si es nulo el Banner</returns>
            public static bool EsBannerNulo(Banner pBanner)
            {
                bool resultado=false;
                if(pBanner.Codigo==-1)
                {
                    resultado = true;
                }
                return resultado;
            }



        /// <summary>
        /// Devuelve una Campaña que es la Nula (código -1)
        /// </summary>
        /// <returns>tipo de dato Campaña que representa la Campaña de código -1</returns>
        public static Dominio.Campaña CampañaNula()
        {
            Campaña campañaNula = new Campaña() { Codigo = -1,Nombre="" };
            Imagen imagenNula = new Imagen();
            imagenNula.Picture = Properties.Resources.sinCampaña;
            imagenNula.Tiempo = 60;
            campañaNula.ListaImagenes.Add(imagenNula);
            return campañaNula;
        }


        /// <summary>
        /// Comprueba si la Campaña es nula o no.
        /// </summary>
        /// <returns>Devuelve verdadero si es nulo la Campaña</returns>
        public static bool EsCampañaNula(Campaña pCampaña)
        {
            bool resultado = false;
            if (pCampaña.Codigo == -1)
            {
                resultado = true;
            }
            return resultado;
        }
    }
}
