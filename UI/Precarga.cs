using System;
using System.ComponentModel;
using System.Windows.Forms;
using Servicios;

namespace UI
{
    public partial class Precarga : Form
    {
        /// <summary>
        /// Constructor de la ventana
        /// </summary>
        public Precarga()
        {
            InitializeComponent();
;        }

        /// <summary>
        /// Evento que surge cuando la ventana se empieza a cargar
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void Precarga_Load(object sender, EventArgs e)
        {
            // Start the BackgroundWorker.
            backgroundWorker_CargaDeDatos.RunWorkerAsync();
            this.timer_Barra.Enabled = true;
            //Se lanzarían backgroundWorker de cada uno de los elementos a cargar de la DB
        }

        /// <summary>
        /// Evento que surge cuando el proceso en segundo plano de carga datos empieza a trabajar
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_CargaDeDatos_DoWork(object sender, DoWorkEventArgs e)
        {
            Servicios.FachadaServicios.CargarCampañasEnMemoria(DateTime.Today);
            Servicios.FachadaServicios.CargarBannersEnMemoria(DateTime.Today);
            Servicios.FachadaServicios.CargaInicial();
        }

        /// <summary>
        /// Evento que surge cuando el proceso en segundo plano de carga datos reporta progreso
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_CargaDeDatos_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar to the BackgroundWorker progress.
            progressBar1.Value = e.ProgressPercentage;
            // Set the text.
            this.Text = e.ProgressPercentage.ToString();
        }

        /// <summary>
        /// Evento que surge cuando el proceso en segundo plano de carga datos termina de ralizar la operación
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_CargaDeDatos_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer_Barra.Interval = 50;
            // Connect the Tick event of the timer to its event handler.
            timer_Barra.Tick += new EventHandler(IncreaseProgressBar);
        }

        /// <summary>
        /// Evento que surge cuando el timer de la barra hace un tick
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void timer_Barra_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Increment(1);
        }

        /// <summary>
        /// Evento que surge cuando la barra de progreso se incrementa
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void IncreaseProgressBar(object sender, EventArgs e)
        {
            // Increment the value of the ProgressBar a value of one each time.
            progressBar1.Increment(1);

            if (progressBar1.Value == 100)
            {
                timer_Barra.Enabled = false;
                Principal form_Principal = new Principal();
                this.Hide();
                form_Principal.ShowDialog();
                this.Close();
            }
        }
    }
}
