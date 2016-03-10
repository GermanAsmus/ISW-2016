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
        int iDuracionCampañaActual;
        int iDuracionCampañaProxima;
        int iDuracionBannerProximo;
        int iDuracionBannerActual;
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
            this.ConfigurarBannerCampaña();        }

        /// <summary>
        /// Configura los Timers
        /// </summary>
        public void ConfigurarTimers()
        {
            this.timer_TextoDeslizante.Interval = 100;
            this.timer_TextoDeslizante.Enabled = true;
            this.timer_ImagenesCampaña.Interval = 1000;
            this.timer_ImagenesCampaña.Enabled = true;
            this.iDuracionBannerActual = 0;
            this.iDuracionCampañaActual = 0;
            this.backgroundWorker_InicializarTimers.RunWorkerAsync();
        }

        /// <summary>
        /// Configura Primer Banner y Camapaña
        /// </summary>
        public void ConfigurarBannerCampaña()
        {
            //BANNER
            this.iBannerProximo = BannerNulo();
            this.iDuracionBannerActual = Servicios.FachadaServicios.DuracionBannerSiguiente();
            this.iBannerActual = Servicios.FachadaServicios.ObtenerBannerCorrespondiente();
            this.ActualizarBanner();
            //CAMPAÑA
            this.iCampañaProxima = CampañaNula();
            this.iDuracionCampañaActual = Servicios.FachadaServicios.DuracionCampañaSiguiente();
            this.iCampañaActual = Servicios.FachadaServicios.ObtenerCampañaCorrespondiente();
            this.ActualizarCampaña();
        }

        #endregion

        #region Muestra del Banner
        /// <summary>
        /// Genera el Banner Nulo 
        /// </summary>
        /// <returns>Tipo de dato Banner que representa el Banner Nulo</returns>
        private static Banner BannerNulo()
        {
            return FachadaServicios.BannerNulo();
        }

        /// <summary>
        /// Devuelve el texto del banner correspondiente, ya sea el RSS o el Texto
        /// </summary>
        /// <returns>Devuelve una cadena con el texto correspondiente</returns>
        private string TextoBannerActual()
        {
            string cadena = this.iBannerActual.Texto;
            return cadena;
        }

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
            this.backgroundWorker_ChequeoBanner.ReportProgress(0, Servicios.FachadaServicios.DuracionBannerSiguiente());
            e.Result = Servicios.FachadaServicios.ObtenerBannerCorrespondiente();
        }

        /// <summary>
        /// Evento que surge cuando el proceso de chequeo de Banners termina de ejecutarse
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_ChequeoBanner_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            this.iBannerProximo = (Banner)e.Result;
            this.backgroundWorker_CargarDiaSiguiente.RunWorkerAsync(this.iBannerProximo);
            //this.label_TextoBanner.Text = TextoBannerCorrespondiente(iBannerActual);
        }

        /// <summary>
        /// Evento que surge cuando el proceso de chequeo de Banners reporta el progreso
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_ChequeoBanner_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.iDuracionBannerProximo = (int)e.UserState;
        }

        /// <summary>
        /// Cambia el valor de Label para que muestre el Banner Actual
        /// </summary>
        public void ActualizarBanner()
        {
            this.label_TextoBanner.Left = Screen.FromControl(this).Bounds.Width;
            this.label_TextoBanner.Text = this.TextoBannerActual();
            if(this.iBannerActual.Codigo == -1)
            {
                this.iDuracionBannerActual = 0;
            }
        }
        #endregion

        #region Muestra de la Campaña
        /// <summary>
        /// Campaña nula
        /// </summary>
        /// <returns></returns>
        private static Campaña CampañaNula()
        {
            Campaña campañaNula = new Campaña() { Codigo = -1 };
            Imagen imagenNula = new Imagen();
            imagenNula.Picture = Properties.Resources.sinCampaña;
            imagenNula.Tiempo = 60;
            campañaNula.ListaImagenes.Add(imagenNula);
            return campañaNula;
        }

        /// <summary>
        /// Devuelve la imagen de la campaña correspondiente
        /// </summary>
        /// <param name="pCampaña"></param>
        /// <returns></returns>
        private Image ImagenCampañaCorrespondiente(Campaña pCampaña)
        {
            Image imagen;
            if (pCampaña.Codigo == -1)
            {
                this.iCampañaActual = CampañaNula();
                this.enumeradorImagenes = this.iCampañaActual.ListaImagenes.GetEnumerator();
            }
            if (enumeradorImagenes.MoveNext())
            {
                imagen = this.enumeradorImagenes.Current.Picture;
                this.timer_ImagenesCampaña.Interval = this.enumeradorImagenes.Current.Tiempo * 1000;
            }
            else
            {
                this.enumeradorImagenes.Reset();
                this.enumeradorImagenes.MoveNext();
                imagen = this.enumeradorImagenes.Current.Picture;
                this.timer_ImagenesCampaña.Interval = this.enumeradorImagenes.Current.Tiempo * 1000;
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
            DateTime fechaActual = (DateTime)e.Argument;
            TimeSpan horaActual = new TimeSpan(fechaActual.Hour, fechaActual.Minute, fechaActual.Second);
            this.backgroundWorker_ChequeoCampaña.ReportProgress(0, Servicios.FachadaServicios.DuracionCampañaSiguiente(horaActual));
            e.Result = Servicios.FachadaServicios.ObtenerCampañaCorrespondiente(horaActual, fechaActual);
        }

        /// <summary>
        /// Evento que surge cuando el proceso de chequeo de Campaña termina de ejecutarse
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_ChequeoCampaña_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.iCampañaProxima = (Campaña)e.Result;
            //this.enumeradorImagenes = this.iCampañaActual.ListaImagenes.GetEnumerator();
            //this.pictureBox_Campaña.Image = this.ImagenCampañaCorrespondiente(this.iCampañaActual);
        }

        /// <summary>
        /// Evento que surge cuando el proceso de chequeo de Campaña reporta progreso
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_ChequeoCampaña_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.iDuracionCampañaProxima = (int)e.UserState;
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

        #region Muestra de la Información Adicional
        /// <summary>
        /// Muestra la información Adicional
        /// </summary>
        /// <param name="pInformacionAdicional">Infomración Adicional a mostrar</param>
        private void MostrarInformaciónAdicional()
        {
            /*
            string auxiliar="";
            foreach (string xPath in pInformacionAdicional.NodosXML)
            {
                 auxiliar = auxiliar +" "+ Path.GetFileName(xPath);
                
            }
            GroupBox groupBox = new GroupBox();
            groupBox.Text = pInformacionAdicional.Nombre;
            groupBox.ForeColor = Color.White;
            groupBox.Anchor= (AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left);
            groupBox.AutoSize = true;
            FlowLayoutPanel panelFlow = new FlowLayoutPanel();
            groupBox.Controls.Add(panelFlow);
            panelFlow.AutoSize = true;
            panelFlow.Anchor = (AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom);
            Label labelNodo = new Label() { Text = auxiliar, Anchor = (AnchorStyles.Top | AnchorStyles.Left) };
            labelNodo.AutoSize = true;
            panelFlow.Controls.Add(labelNodo);
            this.flowLayoutPanel_InformacionAdicional.Controls.Add(groupBox);
            */
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
            DateTime fechaActual = DateTime.Now;
            if((fechaActual.Hour == 23))
            {
                if(fechaActual.Minute == 59)
                {
                    fechaActual = new DateTime(fechaActual.Year, fechaActual.Month, fechaActual.Day + 1, 0, 0, 0);
                }
                else if (fechaActual.Minute == 30)
                {
                    this.backgroundWorker_CargarDiaSiguiente.RunWorkerAsync(fechaActual.AddDays(1));
                }
            }
            if (this.iDuracionBannerActual <= 60)
            {
                this.backgroundWorker_ChequeoBanner.RunWorkerAsync(fechaActual);
            }
            if (this.iDuracionCampañaActual <= 60)
            {
                this.backgroundWorker_ChequeoCampaña.RunWorkerAsync(fechaActual);
            }
        }

        /// <summary>
        /// Evento que surge cuando el timer del cambio hace un tick
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void timer_Cambio_Tick(object sender, EventArgs e)
        {
            this.iDuracionCampañaActual -= 60;
            this.iDuracionBannerActual -= 60;
            //Último minuto que corre el Banner
            if (this.iDuracionBannerActual < 60)
            {
                this.iBannerActual = this.iBannerProximo;
                this.iDuracionBannerActual = this.iDuracionBannerProximo;
                this.iDuracionBannerProximo = 0;
                this.iBannerProximo = BannerNulo();
                this.ActualizarBanner();
            }
            if (this.iDuracionCampañaActual < 60)
            {
                this.iCampañaActual = this.iCampañaProxima;
                this.iDuracionCampañaActual = this.iDuracionCampañaProxima;
                this.iDuracionCampañaProxima = 0;
                this.iCampañaProxima = CampañaNula();
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
        /// Evento que surge cuando el proceso en segundo plano carga los Banners y campañas dia siguiente
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_CargarDiaSiguiente_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime fechaCarga = (DateTime)e.Argument;
            Servicios.FachadaServicios.CargarDatosEnMemoria(fechaCarga);
        }

        /// <summary>
        /// Evento que surge cuando el proceso de RSS comienza a ejecutarse
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_RSS_DoWork(object sender, DoWorkEventArgs e)
        {
            Banner pBanner = (Banner)e.Argument;
            try
            {
                //string resultado = Servicios.Fachada.OperacionesRSS(pBanner.URL);
                
            }
            catch (Exception) { }
        }
        #endregion


    }
}
