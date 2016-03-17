using System;
using System.Collections.Generic;
using System.ComponentModel;
using Servicios;
using System.Windows.Forms;
using Dominio;

namespace UI
{
    public partial class Form_FuentesRSS : Form
    {
        List<FuenteRSS> iListaFuenteRSSAgregar;
        List<FuenteRSS> iListaFuenteRSSModificar;
        List<FuenteRSS> iListaFuenteRSSEliminar;
        List<FuenteRSS> iListaFuenteRSS;

        /// <summary>
        /// Constructor de la ventana
        /// </summary>
        /// <param name="pListaFuenteRSS">Lista de Fuentes RSS existentes</param>
        internal Form_FuentesRSS()
        {
            InitializeComponent();
            this.iListaFuenteRSS = new List<FuenteRSS>();
            this.iListaFuenteRSSModificar = new List<FuenteRSS>();
            this.iListaFuenteRSSEliminar = new List<FuenteRSS>();
            this.iListaFuenteRSSAgregar = new List<FuenteRSS>();
            this.AcceptButton = this.button_Aceptar;
            this.CancelButton = this.button_Volver;
        }

        /// <summary>
        /// Evento que surge cuando se hace clic en el botón Modificar
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void button_Modificar_Click(object sender, EventArgs e)
        {
            FuenteRSS pFuente = this.FuenteSeleccionada();
            if (!this.iListaFuenteRSSAgregar.Contains(pFuente))
            {
                this.iListaFuenteRSSModificar.Add(pFuente);
            }
            this.ActualizarDGV();
        }

        /// <summary>
        /// Evento que surge cuando se hace clic en el botón Eliminar
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void button_Eliminar_Click(object sender, EventArgs e)
        {
            FuenteRSS pFuente = this.FuenteSeleccionada();
            if (!this.iListaFuenteRSSAgregar.Contains(pFuente))
            {
                this.iListaFuenteRSSEliminar.Add(pFuente);
            }
            this.iListaFuenteRSS.Remove(pFuente);
            this.ActualizarDGV();
        }

        /// <summary>
        /// Evento que surge cuando se hace clic en el botón Agregar
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void button_Agregar_Click(object sender, EventArgs e)
        {
            FuenteRSS nuevaFuente = new FuenteRSS()
            {
                Codigo = 0,
                Valor = "",
                Descripcion = this.textBox_Descripcion.Text,
                URL = this.textBox_URL.Text
            };
            this.iListaFuenteRSSAgregar.Add(nuevaFuente);
            this.iListaFuenteRSS.Add(nuevaFuente);
            this.ActualizarDGV();
        }

        /// <summary>
        /// Evento que surge cuando se hace clic en el botón Aceptar
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void button_Aceptar_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Evento que surge cuando se hace clic en el botón Volver
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void button_Volver_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea perder todos los cambios?\nSe perderán modificaciones, eliminaciones y nuevas Fuentes", "Atención",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if(result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Devuelve la Fuente Seleccionada
        /// </summary>
        /// <returns>Tipo de dato FuenteRSS que representa la fuente seleccionada</returns>
        private FuenteRSS FuenteSeleccionada()
        {
            return (FuenteRSS)this.dataGridView.CurrentRow.DataBoundItem;
        }

        /// <summary>
        /// Actualiza el DataGridView
        /// </summary>
        private void ActualizarDGV()
        {
            this.dataGridView.DataSource = typeof(List<FuenteRSS>);
            this.dataGridView.DataSource = this.iListaFuenteRSS;
            //(this.dataGridView.BindingContext [this.dataGridView_Fecha.DataSource] as CurrencyManager).Refresh();
            this.dataGridView.Update();
            this.dataGridView.Refresh();
        }

        /// <summary>
        /// Evento que surge cuando cambia la selección de la fila
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            bool auxiliar = this.dataGridView.RowCount > 0;
            this.button_Modificar.Enabled = auxiliar;
            this.button_Eliminar.Enabled = auxiliar;
        }

        /// <summary>
        /// Evento que surge cuando el Proceso en segundo plano empieza trabajar para guardar/modificar y actualizar Fuentes
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_Fuentes_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        /// <summary>
        /// Evento que surge cuando el Proceso en segundo plano termina de trabajar para actualizar y guardar Fuentes
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_Fuentes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        /// <summary>
        /// Evento que surge cuando el Proceso en segundo plano obtiene las fuentes RSS
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_ObtenerRSS_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        /// <summary>
        /// Evento que surge cuando el Proceso en segundo plano termina de trabajar de obtener las fuentes RSS
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_ObtenerRSS_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
