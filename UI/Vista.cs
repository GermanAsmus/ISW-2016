using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Servicios;
using System.IO;
using Dominio;

namespace UI
{
    public partial class Vista : Form
    {
        #region Variables
        Banner iBannerActual;
        Banner iBannerProximo;
        Campaña iCampañaActual;
        Campaña iCampañaProxima;
        IEnumerator<Imagen> enumeradorImagenes;

        #endregion

        #region Inicialización y Carga
        /// <summary>
        /// Constructor de la ventana Vista
        /// </summary>
        public Vista()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.tableLayoutPanel_Vista.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            this.ConfigurarTimers();
            this.ConfigurarBannerCampaña();
        }

        /// <summary>
        /// Configura los Timers
        /// </summary>
        public void ConfigurarTimers()
        {
            this.timer_TextoDeslizante.Interval = 100;
            this.timer_TextoDeslizante.Enabled = true;
            this.timer_ImagenesCampaña.Interval = 1000;
            this.timer_ImagenesCampaña.Enabled = true;
            this.backgroundWorker_InicializarTimers.RunWorkerAsync();
        }

        /// <summary>
        /// Configura Primer Banner y Campaña
        /// </summary>
        public void ConfigurarBannerCampaña()
        {
            ///BANNER
            this.iBannerActual=FachadaServicios.ObtenerBannerSiguiente();
            this.label_TextoBanner.Text = iBannerActual.Texto;
            this.iBannerProximo = FachadaServicios.ObtenerBannerSiguiente();

            ///CAMPAÑA
            this.iCampañaActual=FachadaServicios.ObtenerCampañaSiguiente();
            this.enumeradorImagenes = this.iCampañaActual.ListaImagenes.GetEnumerator();
            this.pictureBox_Campaña.Image = this.ImagenCampañaCorrespondiente(iCampañaActual);
            this.iCampañaProxima = FachadaServicios.ObtenerCampañaSiguiente();
        }

        #endregion

        #region Muestra del Banner

        /// <summary>
        /// Evento que surge cuando el timer del texto Deslizante hace un tick
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void timer_TextoDeslizante_Tick(object sender, EventArgs e)
        {
            this.label_TextoBanner.Left -= 3;
            if (this.label_TextoBanner.Left + this.label_TextoBanner.Width < this.Left)
            {
                this.label_TextoBanner.Left = this.Width + this.Location.X;
            }
        }

        /// <summary>
        /// Evento que surge cuando el proceso de chequeo de Banners comienza a ejecutarse
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_ChequeoBanner_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = FachadaServicios.ObtenerBannerSiguiente();
        }

        /// <summary>
        /// Evento que surge cuando el proceso de chequeo de Banners termina de ejecutarse
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_ChequeoBanner_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            this.iBannerProximo = (Banner)e.Result;
        }


        /// <summary>
        /// Cambia el valor de Label para que muestre el Banner Actual
        /// </summary>
        public void ActualizarBanner()
        {
            this.label_TextoBanner.Left = Screen.FromControl(this).Bounds.Width;
            this.label_TextoBanner.Text = this.iBannerActual.Texto;
        }
        #endregion

        #region Muestra de la Campaña

        /// <summary>
        /// Devuelve la imagen de la campaña correspondiente
        /// </summary>
        /// <param name="pCampaña"></param>
        /// <returns></returns>
        private Image ImagenCampañaCorrespondiente(Campaña pCampaña)
        {
            Image imagen;
            if(this.enumeradorImagenes.MoveNext())
            {
                imagen=this.enumeradorImagenes.Current.Picture;
                this.timer_ImagenesCampaña.Interval = this.enumeradorImagenes.Current.Tiempo*1000;
            }
            else
            {
                this.enumeradorImagenes.Reset();
                this.enumeradorImagenes.MoveNext();
                this.timer_ImagenesCampaña.Interval = this.enumeradorImagenes.Current.Tiempo*1000;
                imagen = this.enumeradorImagenes.Current.Picture;
                
            }
            return imagen;
        }

        /// <summary>
        /// Evento que surge cuando el timer de las imágenes de Campañas hace un tick
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void timer_ImagenesCampaña_Tick(object sender, EventArgs e)
        {
            this.pictureBox_Campaña.Image = this.ImagenCampañaCorrespondiente(iCampañaActual);
        }

        /// <summary>
        /// Evento que surge cuando el proceso de chequeo de Campaña comienza a ejecutarse
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_ChequeoCampaña_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = FachadaServicios.ObtenerCampañaSiguiente();
        }

        /// <summary>
        /// Evento que surge cuando el proceso de chequeo de Campaña termina de ejecutarse
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_ChequeoCampaña_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.iCampañaProxima = (Campaña)e.Result;
        }

        /// <summary>
        /// Cambia el valor del PictureBox y el Timer para que muestre la Campaña Actual
        /// </summary>
        public void ActualizarCampaña()
        {
            this.enumeradorImagenes = this.iCampañaActual.ListaImagenes.GetEnumerator();
            this.pictureBox_Campaña.Image = this.ImagenCampañaCorrespondiente(iCampañaActual);
        }
        #endregion


        #region Eventos Comunes
        /// <summary>
        /// Evento que surge cuando el proceso de inicialización de Timers comienza a ejecutarse
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_InicializarTimers_DoWork(object sender, DoWorkEventArgs e)
        {
            int ahora = DateTime.Now.Second;
            while (ahora != 15)
            {
                ahora = DateTime.Now.Second;
            }
            this.backgroundWorker_InicializarTimers.ReportProgress(0);
            ahora = DateTime.Now.Second;
            while (ahora != 59)
            {
                ahora = DateTime.Now.Second;
            }
            this.backgroundWorker_InicializarTimers.ReportProgress(1);
        }

        /// <summary>
        /// Evento que surge cuando el proceso de inicialización de Timers reporta progreso
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_InicializarTimers_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                //60 segundos = 1 minuto
                this.timer_Chequeo.Interval = 60 * 1000;
                this.timer_Chequeo.Enabled = true;
            }
            else
            {
                //60 segundos = 1 minuto
                this.timer_Cambio.Interval = 60 * 1000;
                this.timer_Cambio.Enabled = true;
            }
        }

        /// <summary>
        /// Evento que surge cuando el timer del Chequeo hace un tick
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void timer_Chequeo_Tick(object sender, EventArgs e)
        {
            backgroundWorker_ChequeoBanner.RunWorkerAsync();
            backgroundWorker_ChequeoCampaña.RunWorkerAsync();
        }

        /// <summary>
        /// Evento que surge cuando el timer del cambio hace un tick
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void timer_Cambio_Tick(object sender, EventArgs e)
        {
            if(!iBannerActual.Equals(iBannerProximo))
            {
                iBannerActual = iBannerProximo;
                this.ActualizarBanner();
            }

            if (!iCampañaActual.Equals(iCampañaProxima))
            {
                iCampañaActual = iCampañaProxima;
                this.ActualizarCampaña();
            }
        }

        /// <summary>
        /// Evento que surge cuando la ventana se cierra
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void Vista_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.timer_Cambio.Enabled = false;
            this.timer_Chequeo.Enabled = false;
            this.timer_ImagenesCampaña.Enabled = false;
            this.timer_TextoDeslizante.Enabled = false;
        }


        /// <summary>
        /// Evento que surge cuando el proceso de RSS comienza a ejecutarse
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_RSS_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        #endregion


    }
}
