using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Servicios;

namespace UI
{
    public partial class Form_FuenteTextoFijo : Form
    {
        #region Variables
        /// <summary>
        /// Texto Fijo a modificar
        /// </summary>
        private FuenteTextoFijo iFuenteTextoFijo;
        #endregion

        #region Región: Inicialización y Carga
        /// <summary>
        /// Constructor de la ventana de Texto Fijo
        /// </summary>
        /// <param name="pFuente">Fuente de Texto Fijo a modificar</param>
        internal Form_FuenteTextoFijo(FuenteTextoFijo pFuente = null)
        {
            InitializeComponent();
            bool auxiliar = pFuente != null;
            if (auxiliar)
            {
                this.textBox_ValorTextoFijo.Text = pFuente.Valor;
                this.iFuenteTextoFijo = pFuente;
            }
            else
            {
                this.iFuenteTextoFijo = new FuenteTextoFijo() { Codigo = 0, Valor = "" };
            }
            this.button_Aceptar.Enabled = auxiliar;
            this.CampoCompleto(this.pictureBox_ComprobacionValorTF, auxiliar);
        }
        #endregion

        #region Región: Eventos Comunes
        /// <summary>
        /// Evento que surge al hacer clic en el botón Volver
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void button_Volver_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea perder todos los cambios?", "Atención",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Evento que surge al hacer clic en el botón Aceptar
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void button_Aceptar_Click(object sender, EventArgs e)
        {
            this.iFuenteTextoFijo.Valor = this.textBox_ValorTextoFijo.Text;
            ((Form_Configuracion_Banner)this.Owner).ActualizarFuente(this.iFuenteTextoFijo);
            this.Close();
        }

        /// <summary>
        /// Evento que surge al salir del TextoBox Valor del Texto Fijo
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void textBox_ValorTextoFijo_Leave(object sender, EventArgs e)
        {
            this.textBox_ValorTextoFijo.Text = this.textBox_ValorTextoFijo.Text.TrimStart(' ').TrimEnd(' ');
            this.CampoCompleto(this.pictureBox_ComprobacionValorTF, this.textBox_ValorTextoFijo.Text != "");
            this.ActivarAceptar();
            this.button_Aceptar.Focus();
        }

        /// <summary>
        /// Evento que surge al ingresar entradas de teclas al textoBox Valor de Texto Fijo
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void textBox_ValorTextoFijo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Región: Métodos Extra Comunes
        /// <summary>
        /// Activa el botón Aceptar si todos los Campos están llenos
        /// </summary>
        private void ActivarAceptar()
        {
            this.button_Aceptar.Enabled = this.textBox_ValorTextoFijo.Text != "";
        }

        /// <summary>
        /// Determina el ícono que representa el estado del campo
        /// </summary>
        /// <param name="pPictureBox">Form que contiene la imagen</param>
        /// <param name="value">Valor booleano que representa si está o no completo el campo correspondiente</param>
        private void CampoCompleto(PictureBox pPictureBox, bool value)
        {
            int anchoComun = pPictureBox.Width;
            int altoComun = pPictureBox.Height;
            if (value)
            {
                pPictureBox.Image = ImagenServices.CambiarTamañoImagen(Properties.Resources.greenTick, anchoComun, altoComun);

            }
            else
            {
                pPictureBox.Image = ImagenServices.CambiarTamañoImagen(SystemIcons.Exclamation.ToBitmap(), anchoComun, altoComun);
            }
        }
        #endregion
    }
}
