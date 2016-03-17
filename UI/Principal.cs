using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Principal : Form
    {
        /// <summary>
        /// Constructor de la ventana
        /// </summary>
        public Principal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento que surge al hacer clic sobre el menú Salir
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento que surge al hacer clic sobre el menú Banner
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void bannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Banner bannerConfiguracion = new Form_Banner();
            bannerConfiguracion.Owner = this;
            bannerConfiguracion.ShowDialog();
        }

        /// <summary>
        /// Evento que surge al hacer clic sobre el menú Campaña
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void campañaPublicitariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Campaña camapañaConfiguracion = new Form_Campaña();
            camapañaConfiguracion.Owner = this;
            camapañaConfiguracion.ShowDialog();
        }

        /// <summary>
        /// Evento que surge al hacer clic sobre el menú de Vista
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void vistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vista ventanaVista = new Vista();
            ventanaVista.ShowDialog();
        }

        /// <summary>
        /// Evento que surge al hacer clic sobre el menú de Fuentes RSS
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void fuentesRSSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_FuentesRSS fuenteAdministracion = new Form_FuentesRSS();
            fuenteAdministracion.Owner = this;
            fuenteAdministracion.ShowDialog();
        }
    }
}
