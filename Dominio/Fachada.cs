using System;
using System.Collections.Generic;

namespace Dominio
{
    class Fachada
    {
        private Banner iBannerNulo;
        private Campaña iCampañaNula;
        private SortedList<int, Banner> iListaBannersActual;
        private SortedList<int, Banner> iListaBannersProxima;
        private SortedList<int, int> iListaCampañaActual;
        private SortedList<int, int> iListaCampañaProxima;
        private bool iActualizarListaBanner = false;
        private bool iActualizarListaCampaña = false;

        /// <summary>
        /// Constructor de la fachada
        /// </summary>
        public Fachada()
        {
            //BANNER NULO
            FuenteTextoFijo pTextoFijo = new FuenteTextoFijo() { Valor = "Publicite Aquí" };
            this.iBannerNulo = new Banner()
            {
                Codigo = -1,
                InstanciaFuente = pTextoFijo
            };
            //CAMPAÑA NULA
            List<Imagen> lImagenesNula = new List<Imagen>();
            Imagen imagenNula = new Imagen();
            imagenNula.Picture = Properties.Resources.sinCampaña;
            imagenNula.Tiempo = 60;
            lImagenesNula.Add(imagenNula);
            this.iCampañaNula = new Campaña { Codigo = CodigoCampañaNula(), Nombre = "", ListaImagenes = lImagenesNula };

            this.iListaBannersActual = new SortedList<int, Banner>();
            this.iListaBannersProxima = new SortedList<int, Banner>();
            this.iListaCampañaActual = new SortedList<int, int>();
            this.iListaCampañaProxima = new SortedList<int, int>();
            this.InicializarListaBanner();
            this.InicializarListaCampaña();
        }

        /// <summary>
        /// Inicializa la lista de Banners con Banners nulos
        /// </summary>
        private void InicializarListaBanner()
        {
            this.iListaBannersProxima = new SortedList<int, Banner>();
            int totalMinutosDia = (int)(new TimeSpan(23, 59, 00)).TotalMinutes;
            for (int i = 0; i <= totalMinutosDia; i++)
            {
                this.iListaBannersProxima[i] = this.iBannerNulo;
            }
            this.iActualizarListaBanner = false;
        }

        /// <summary>
        /// Inicializa la lista de Campaña con Campañas nulas
        /// </summary>
        private void InicializarListaCampaña()
        {
            this.iListaCampañaProxima = new SortedList<int, int>();
            int totalMinutosDia = (int)(new TimeSpan(23, 59, 00)).TotalMinutes;
            for (int i = 0; i <= totalMinutosDia; i++)
            {
                this.iListaCampañaProxima[i] = CodigoCampañaNula();
            }
            this.iActualizarListaCampaña = false;
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
            //Lista Actual
            foreach (int pIndice in pBanner.ListaDeIndices(DateTime.Now.Date))
            {
                this.iListaBannersActual[pIndice] = pBanner;
            }
            //Lista Próxima
            foreach (int pIndice in pBanner.ListaDeIndices(DateTime.Now.AddDays(1).Date))
            {
                this.iListaBannersProxima[pIndice] = pBanner;
            }
        }

        /// <summary>
        /// Agrega un Banner en la lista suministrada
        /// </summary>
        /// <param name="pBanner">Banner a agregar</param>
        /// <param name="pListaBanners">Lista de Banners en la cual agregar</param>
        private void Agregar(Banner pBanner, SortedList<int, Banner> pListaBanners)
        {
            foreach (int pIndice in pBanner.ListaDeIndices(DateTime.Now.Date))
            {
                pListaBanners[pIndice] = pBanner;
            }
        }

        /// <summary>
        /// Agrega una Campaña en la lista de la Fachada
        /// </summary>
        /// <param name="pBanner">Campaña a agregar</param>
        public void Agregar(Campaña pCampaña)
        {
            //Lista Actual
            foreach (int pIndice in pCampaña.ListaDeIndices(DateTime.Now.Date))
            {
                this.iListaCampañaActual[pIndice] = pCampaña.Codigo;
            }
            //Lista Próxima
            foreach (int pIndice in pCampaña.ListaDeIndices(DateTime.Now.AddDays(1).Date))
            {
                this.iListaCampañaProxima[pIndice] = pCampaña.Codigo;
            }
        }

        /// <summary>
        /// Agrega un Campaña en la lista suministrada
        /// </summary>
        /// <param name="pBanner">Campaña a agregar</param>
        /// <param name="listaBanners">Lista de Campañas en la cual agregar</param>
        private void Agregar(Campaña pCampaña, SortedList<int, int> pListaCampañas)
        {
            //Lista Actual
            foreach (int pIndice in pCampaña.ListaDeIndices(DateTime.Now.Date))
            {
                pListaCampañas[pIndice] = pCampaña.Codigo;
            }
        }

        /// <summary>
        /// Elimina un Banner de la lista de la Fachada
        /// </summary>
        /// <param name="pBanner">Banner a eliminar</param>
        public void Eliminar(Banner pBanner)
        {
            //Lista Actual
            foreach (int pIndice in pBanner.ListaDeIndices(DateTime.Now.Date))
            {
                this.iListaBannersActual[pIndice] = this.iBannerNulo;
            }
            //Lista Próxima
            foreach (int pIndice in pBanner.ListaDeIndices(DateTime.Now.AddDays(1).Date))
            {
                this.iListaBannersProxima[pIndice] = this.iBannerNulo;
            }
        }

        /// <summary>
        /// Elimina una Campaña de la lista de la Fachada
        /// </summary>
        /// <param name="pBanner">Campaña a eliminar</param>
        public void Eliminar(Campaña pCampaña)
        {
            for (int i = 0; i < this.iListaCampañaActual.Count; i++)
            {
                if(this.iListaCampañaActual[i] == pCampaña.Codigo)
                {
                    this.iListaCampañaActual[i] = CodigoCampañaNula();
                }
                if (this.iListaCampañaProxima[i] == pCampaña.Codigo)
                {
                    this.iListaCampañaActual[i] = CodigoCampañaNula();
                }
            }
        }

        /// <summary>
        /// Modifica un Banner de la lista de la Fachada
        /// </summary>
        /// <param name="pBanner">Banner a modificar</param>
        public void Modificar(Banner pBanner)
        {
            this.Eliminar(this.BuscarBanner(pBanner));
            this.Agregar(pBanner);
        }

        /// <summary>
        /// Obtiene el Banner de la lista que se corresponde con el suministrado
        /// </summary>
        /// <param name="pBanner">Banner suministrado</param>
        /// <returns>Tipo de dato Banner que representa aquel almacenado</returns>
        private Banner BuscarBanner(Banner pBanner)
        {
            int i = 0;
            Banner resultado = this.iBannerNulo;
            i = this.iListaBannersActual.IndexOfValue(pBanner);
            if(i != -1)
            {
                resultado = this.iListaBannersActual.Values[i];
            }
            else if(i == -1)
            {
                i = this.iListaBannersProxima.IndexOfValue(pBanner);
                if (i != -1)
                {
                    resultado = this.iListaBannersProxima.Values[i];
                }
            }
            return resultado;
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
        /// Obtiene el Banner siguiente
        /// </summary>
        /// <param name="horaInicio">Hora de inicio a verificar el Banner siguiente</param>
        /// <param name="fechaActual">Fecha Actual en la que se pide el Banner</param>
        /// <returns>Tipo de dato Banner que representa el Banner siguiente</returns>
        public Banner ObtenerBannerSiguiente()
        {
            Banner bannerResultado;
            DateTime fechaActual = DateTime.Now;
            int horaInicio = (int)(new TimeSpan(fechaActual.Hour, fechaActual.Minute, 0).TotalMinutes) + 1;
            if (horaInicio > 1380)
            {
                this.iActualizarListaBanner = true;
            }

            if (horaInicio == 1439) //Serían las 23:59
            {
                this.CambiarListaBanners();
                horaInicio = 0;
            }
            bannerResultado = this.iListaBannersActual.Values[horaInicio];
            return bannerResultado;
        }

        /// <summary>
        /// Obtiene la Campaña siguiente
        /// </summary>
        /// <returns>Tipo de dato Campaña que representa la Campaña siguiente</returns>
        public Campaña ObtenerCampañaSiguiente()
        {
            DateTime fechaActual = DateTime.Now;
            int horaInicio = (int)(new TimeSpan(fechaActual.Hour, fechaActual.Minute, 0).TotalMinutes) + 1;
            if (horaInicio > 1380)
            {
                this.iActualizarListaCampaña = true;
            }

            if (horaInicio == 1439) //Serían las 23:59
            {
                this.CambiarListaCampañas();
                horaInicio = 0;
            }
            int campañaResultado = this.iListaCampañaActual.Values[horaInicio];
            Campaña resultado = new Campaña() { Codigo = campañaResultado };
            if (EsCampañaNula(resultado))
            {
                resultado = this.iCampañaNula;
            }
            return resultado;
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
            SortedList<int, int> listaAuxCampaña = new SortedList<int, int>(this.iListaCampañaProxima);
            this.InicializarListaCampaña();
            this.iListaCampañaActual = listaAuxCampaña;
        }

        /// <summary>
        /// Si se desea saber si hay que actualizar las listas o no.
        /// </summary>
        /// <returns>tipo booleano, verdadero en caso de que se necesite</returns>
        public bool NecesitaActualizarListas()
        {
            return (this.iActualizarListaCampaña || this.iActualizarListaBanner);
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
        /// Comprueba si la Campaña es nula o no
        /// </summary>
        /// <param name="pCampaña">Campaña a copmrobar</param>
        /// <returns>Valor bool que indica si es nula o no la Campaña</returns>
        public static bool EsCampañaNula(Campaña pCampaña)
        {
            return pCampaña.Codigo == -1;
        }

        /// <summary>
        /// Obtiene todos los Rangos Horarios ocupados por las Banners dadas
        /// </summary>
        /// <param name="pListaBanners">Lista de Banners</param>
        /// <returns>Tipo de dato Lista de Rangos Horario que representan los ocupados por los Banners</returns>
        public static List<RangoHorario> RangosHorariosOcupadosBanner(List<Banner> pListaBanners)
        {
            List<RangoHorario> listaResultado = new List<RangoHorario>();
            foreach (Banner pBanner in pListaBanners)
            {
                listaResultado.AddRange(pBanner.ObtenerRangosHorariosOcupados());
            }
            return listaResultado;
        }

        /// <summary>
        /// Obtiene todos los Rangos Horarios ocupados por las Campañas dadas
        /// </summary>
        /// <param name="pListaCampaña">Lista de Campañas</param>
        /// <returns>Tipo de dato Lista de Rangos Horario que representan los ocupados por las Campañas</returns>
        public static List<RangoHorario> RangoHorariosOcupadosCampaña(List<Campaña> pListaCampaña)
        {
            List<RangoHorario> listaResultado = new List<RangoHorario>();
            foreach (Campaña pCampaña in pListaCampaña)
            {
                listaResultado.AddRange(pCampaña.ObtenerRangosHorariosOcupados());
            }
            return listaResultado;
        }
        
        /// <summary>
        /// Actualiza las Fuentes RSS y las devuelve actualizardas
        /// </summary>
        /// <returns>Tipo de dato Lista de Fuentes RSS qeu representa las del día de hoy actualizadas</returns>
        public List<IFuente> ActualizarFuentes()
        {
            List<IFuente> resultado = new List<IFuente>();
            foreach (Banner pBanners in this.iListaBannersActual.Values)
            {
                IFuente pFuente = pBanners.InstanciaFuente;
                if (pFuente.Actualizable())
                {
                    pFuente.Texto();
                    resultado.Add(pFuente);
                }
            }
            return resultado;
        }
    }
}
