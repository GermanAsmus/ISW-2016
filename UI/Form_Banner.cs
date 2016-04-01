using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Dominio;
using Servicios;
using System.Text.RegularExpressions;
using System.Drawing;

namespace UI
{
    public partial class Form_Banner : Form
    {
        #region Variables
        /// <summary>
        /// Delegado del banner
        /// </summary>
        /// <param name="banner"></param>
        internal delegate void delegado(Banner banner);
        /// <summary>
        /// Delegado para agregar un banner
        /// </summary>
        private delegado agregar = new delegado(Servicios.FachadaServicios.AgregarBanner);
        /// <summary>
        /// Delegado para modificar un banner
        /// </summary>
        private delegado modificar = new delegado(Servicios.FachadaServicios.ModificarBanner);
        /// <summary>
        /// Cantidad de campañas que están siendo guardadas
        /// </summary>
        private int iGuardandoCantidad;
        #endregion

        #region Región: Inicialización y Carga
        /// <summary>
        /// Constructor de la ventana
        /// </summary>
        public Form_Banner()
        {
            InitializeComponent();
            this.ConfiguracionInicialForms();
            this.ConfiguracionInicialDataGridView();
            this.ActualizarDGV(this.ArgumentosHoy());
            this.iGuardandoCantidad = 0;
        }

        /// <summary>
        /// Configura los DataGridView para que muestren las columnas correspondientes
        /// </summary>
        private void ConfiguracionInicialDataGridView()
        {
            // Inicializar DataGridView
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.AutoSize = false;
            // Inicializar y agregar columna de textBox
            DataGridViewColumn column = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Nombre",
                Name = "Nombre"
            };
            this.dataGridView.Columns.Add(column);
            // Inicializar y agregar columna de textBox
            column = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "TipoDeFuente",
                Name = "Tipo de Fuente"
            };
            this.dataGridView.Columns.Add(column);
        }

        /// <summary>
        /// Configura los forms inicialmente
        /// </summary>
        private void ConfiguracionInicialForms()
        {
            this.label_Operacion.Visible = false;
            this.groupBox_Filtro.Visible = false;
            this.textBox_Nombre.Enabled = false;
            this.radioButton_RSS.Enabled = false;
            this.radioButton_Texto.Enabled = false;
            this.dateTimePicker_FechaDesde.Enabled = false;
            this.dateTimePicker_FechaHasta.Enabled = false;
            this.label_Desde.Enabled = false;
            this.label_Hasta.Enabled = false;
            //PictureBoxes
            this.CampoCompleto(pictureBox_Tipo, true);
            this.pictureBox_Nombre.Visible = false;
            this.pictureBox_Tipo.Visible = false;
            this.pictureBox_Desde.Visible = false;
            this.pictureBox_Hasta.Visible = false;
        }
        #endregion

        #region Región: Eventos Comunes
        /// <summary>
        /// Evento que surge al al hacer clic sobre el botón Cancelar
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void button_Agregar_Click(object sender, EventArgs e)
        {
            Form_Configuracion_Banner formConfigBanner = new Form_Configuracion_Banner(agregar);
            formConfigBanner.Owner = this;
            formConfigBanner.Text = "Nuevo Banner";
            this.Hide();
            formConfigBanner.ShowDialog();
        }

        /// <summary>
        /// Evento que surge al hacer clic en el botón Modificar
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void button_Modificar_Click(object sender, EventArgs e)
        {
            Form_Configuracion_Banner formConfigBanner = new Form_Configuracion_Banner(modificar, this.ElementoSeleccionado());
            formConfigBanner.Owner = this;
            formConfigBanner.Text = "Modificar Banner";
            this.Hide();
            formConfigBanner.ShowDialog();
        }

        /// <summary>
        /// Evento que surge al hacer clic sobre el botón Eliminar
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void button_Eliminar_Click(object sender, EventArgs e)
        {
            if (this.backgroundWorker_Eliminar.IsBusy)
            {
                MessageBox.Show("Operación de eliminación en proceso, aguarde un instante");
            }
            else
            {
                if (this.dataGridView.RowCount <= 1)
                {
                    this.button_Modificar.Enabled = false;
                    this.button_Eliminar.Enabled = false;
                    this.button_Mostrar.Enabled = false;
                }
                this.backgroundWorker_Eliminar.RunWorkerAsync(this.ElementoSeleccionado());
            }
        }

        /// <summary>
        /// Evento que surge cuando se hace clic sobre el botón regresar
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void button_Regresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento que surge al hacer clic sobre el botón de Filtro
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void button_Mostrar_Click(object sender, EventArgs e)
        {
            if (!this.groupBox_Filtro.Visible)
            {
                this.groupBox_Filtro.Visible = true;
                this.button_Mostrar.Text = "&Ocultar Filtros";
            }
            else
            {
                this.groupBox_Filtro.Visible = false;
                this.button_Mostrar.Text = "M&ostrar Filtros";
            }
        }

        /// <summary>
        /// Evento que surge al hacer clic sobre el botón de Búsqueda
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void button_Busqueda_Click(object sender, EventArgs e)
        {
            if (this.backgroundWorker_Obtener.IsBusy)
            {
                this.backgroundWorker_Obtener.CancelAsync();
            }
            Dictionary<Type, object> argumentos = this.ArgumentosSelccionados();
            this.ActualizarDGV(argumentos);
        }

        /// <summary>
        /// Evento que surge al al hacer clic sobre el botón Cancelar
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView.RowCount > 0)
            {
                this.button_Eliminar.Enabled = true;
                this.button_Modificar.Enabled = true;
            }
        }

        /// <summary>
        /// Evento que surge al checkear el CheckBox Nombre
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void checkBox_Nombre_CheckedChanged(object sender, EventArgs e)
        {
            bool aux = this.checkBox_Nombre.Checked;
            this.textBox_Nombre.Enabled = aux;
            this.pictureBox_Nombre.Visible = aux;
            this.CampoCompleto(this.pictureBox_Nombre, this.textBox_Nombre.Text != "");
            this.ActivarBuscar();
        }

        /// <summary>
        /// Evento que surge al checkear el CheckBox Tipo
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void checkBox_Tipo_CheckedChanged(object sender, EventArgs e)
        {
            bool aux = this.checkBox_Tipo.Checked;
            this.radioButton_RSS.Enabled = aux;
            this.radioButton_Texto.Enabled = aux;
            this.pictureBox_Tipo.Visible = aux;
            this.ActivarBuscar();
        }

        /// <summary>
        /// Evento que surge al checkear el CheckBox Rango Fecha
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void checkBox_RangoFechas_CheckedChanged(object sender, EventArgs e)
        {
            bool aux = this.checkBox_RangoFechas.Checked;
            this.dateTimePicker_FechaDesde.Enabled = aux;
            this.dateTimePicker_FechaHasta.Enabled = aux;
            this.label_Desde.Enabled = aux;
            this.label_Hasta.Enabled = aux;
            this.pictureBox_Desde.Visible = aux;
            this.pictureBox_Hasta.Visible = aux;
            this.CampoCompleto(this.pictureBox_Desde, true);
            int auxiliarValor = this.dateTimePicker_FechaHasta.Value.Date.CompareTo(this.dateTimePicker_FechaDesde.Value.Date);
            this.CampoCompleto(pictureBox_Hasta, auxiliarValor >= 0);
            this.ActivarBuscar();
        }

        /// <summary>
        /// Evento que surge al ingresar entradas de teclas al Nombre
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void textBox_Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsSeparator(e.KeyChar)
                && !char.IsSymbol(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }
       
        /// <summary>
        /// Evento que surge al salir del textBox Nombre
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void textBox_Nombre_Leave(object sender, EventArgs e)
        {
            this.textBox_Nombre.Text = this.textBox_Nombre.Text.TrimStart(' ').TrimEnd(' ');
            bool resultado = Regex.IsMatch(this.textBox_Nombre.Text, @"^[a-zA-ZáíéóúÑñ0-9\s\p{P}]+$");
            this.CampoCompleto(this.pictureBox_Nombre, resultado);
            if (!resultado)
            {
                this.textBox_Nombre.Text = "";
            }
            this.ActivarBuscar();
        }

        /// <summary>
        /// Evento que surge cuando el valor de un DateTimePicker cambia
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            this.dateTimePicker_FechaDesde.Value = this.dateTimePicker_FechaDesde.Value.Date;
            this.dateTimePicker_FechaHasta.Value = this.dateTimePicker_FechaHasta.Value.Date;
            bool resultado = (this.dateTimePicker_FechaDesde.Value.CompareTo(this.dateTimePicker_FechaHasta.Value) <= 0);
            this.CampoCompleto(this.pictureBox_Hasta, resultado);
            if (!resultado)
            {
                MessageBox.Show("La fecha de fin (Hasta) debe ser mayor o igual a la fecha de inicio (Desde)");
                this.dateTimePicker_FechaHasta.Value = this.dateTimePicker_FechaDesde.Value;
            }
            this.ActivarBuscar();
        }
        #endregion

        #region Región: Métodos Extra Comunes
        /// <summary>
        /// Actualiza la lista
        /// </summary>
        private void ActualizarFuente(List<Banner> fuenteBanners)
        {
            this.dataGridView.DataSource = typeof(List<Banner>);
            this.dataGridView.DataSource = fuenteBanners;
            this.ReDibujarDGV();
        }

        /// <summary>
        /// Actualiza la vista del DGV, redibujando
        /// </summary>
        private void ReDibujarDGV()
        {
            (this.dataGridView.BindingContext[this.dataGridView.DataSource] as CurrencyManager).Refresh();
            this.dataGridView.Update();
            this.dataGridView.Refresh();
        }

        /// <summary>
        /// Devuelve el elemento seleccionado
        /// </summary>
        /// <returns>Tipo de dato Banner que representa el Banner seleccionado</returns>
        private Banner ElementoSeleccionado()
        {
            return (Banner)this.dataGridView.CurrentRow.DataBoundItem;
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
                pPictureBox.Image = ImagenServices.CambiarTamañoImagen(SystemIcons.Error.ToBitmap(), anchoComun, altoComun);
            }
        }

        /// <summary>
        /// Activa el botón búsqueda si los campos de los filtros han sido activados
        /// </summary>
        private void ActivarBuscar()
        {
            bool resultado = true;
            if (this.checkBox_Nombre.Checked)
            {
                resultado = this.textBox_Nombre.Text != "";
            }
            this.button_Busqueda.Enabled = resultado;
        }

        /// <summary>
        /// Devuelve los argumentos corresponientes para obtener los objetos del día de hoy
        /// </summary>
        /// <returns>Tipo de dato Dictionary que representa los argumentos para filtrar</returns>
        private Dictionary<Type, object> ArgumentosHoy()
        {
            Dictionary<Type, object> argumentos = new Dictionary<Type, object>();
            argumentos.Add(typeof(string),"");
            RangoFecha pRangoFecha = new RangoFecha()
            {
                FechaInicio = this.dateTimePicker_FechaDesde.Value,
                FechaFin = this.dateTimePicker_FechaHasta.Value
            };
            argumentos.Add(pRangoFecha.GetType(), pRangoFecha);
            return argumentos;
        }

        /// <summary>
        /// Realiza una actualización del DGV
        /// </summary>
        /// <param name="argumentos">Arguementos para filtrar los elementos a mostrar</param>
        private void ActualizarDGV(Dictionary<Type, object> argumentos)
        {
            this.LabelActualizar();
            this.backgroundWorker_Obtener.RunWorkerAsync(argumentos);
        }

        /// <summary>
        /// Actualiza el texto del label que dice que la acción que se está realizando es una Actualización
        /// </summary>
        private void LabelActualizar()
        {
            this.label_Operacion.Visible = true;
            this.label_Operacion.Text = "Actualizando datos a mostrar";
        }

        /// <summary>
        /// Actualiza el texto del label que dice que acción se está realizando
        /// </summary>
        private void LabelGuardar()
        {
            if (this.iGuardandoCantidad > 0)
            {
                this.label_Operacion.Visible = true;
                this.label_Operacion.Text = "Guardando Campañas (" + this.iGuardandoCantidad.ToString() + ")";
            }
            else
            {
                this.label_Operacion.Visible = false;
            }
        }

        /// <summary>
        /// Traduce los argumentos seleccionados del GroupBox filtro a un diccionario
        /// </summary>
        /// <returns>Arguementos para filtrar los Elementos a mostrar</returns>
        private Dictionary<Type,Object> ArgumentosSelccionados()
        {
            Dictionary<Type, object> argumentos = new Dictionary<Type, object>();
            string nombre = "";
            if (this.checkBox_Nombre.Checked)
            {
                nombre = this.textBox_Nombre.Text;
            }
            argumentos.Add(nombre.GetType(), nombre);
            if (this.checkBox_Tipo.Checked)
            {
                IFuente fuenteTipo;
                if (this.radioButton_RSS.Checked)
                {
                    fuenteTipo = new FuenteRSS();
                }
                else
                {
                    fuenteTipo = new FuenteTextoFijo();
                }
                argumentos.Add(typeof(IFuente), fuenteTipo);
            }
            if (this.checkBox_RangoFechas.Checked)
            {
                RangoFecha pRangoFecha = new RangoFecha()
                {
                    FechaInicio = this.dateTimePicker_FechaDesde.Value,
                    FechaFin = this.dateTimePicker_FechaHasta.Value
                };
                argumentos.Add(pRangoFecha.GetType(), pRangoFecha);
            }
            return argumentos;
        }
        #endregion

        #region Región: Procesos segundo Plano
        /// <summary>
        /// Evento que surge cuando el Proceso en segundo plano empieza trabajar para obtener los banners
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_Obtener_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            object resultado;
            Dictionary<Type, object> argumentos = (Dictionary<Type, object>)e.Argument;
            if (argumentos.Count == 0)
            {
                resultado = Servicios.FachadaServicios.ObtenerBanners();
            }
            else
            {
                resultado = Servicios.FachadaServicios.ObtenerBanners(argumentos);
            }
            e.Result = resultado;
        }

        /// <summary>
        /// Evento que surge cuando el Proceso en segundo plano termina de obtener los banners
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_Obtener_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if ((e.Error == null) && (!e.Cancelled))
            {
                List<Banner> resultado = (List<Banner>)e.Result;
                this.ActualizarFuente(resultado);
            }
            this.label_Operacion.Visible = false;
        }

        /// <summary>
        /// Evento que surge cuando el Proceso en segundo plano termina eliminar el banner
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_Eliminar_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = e.Argument;
            Servicios.FachadaServicios.EliminarBanner((Banner) e.Argument);
        }

        /// <summary>
        /// Evento que surge cuando el Proceso en segundo plano termina de eliminar el banner
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_Eliminar_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Banner auxBanner = (Banner)e.Result;
                MessageBox.Show("Ha ocurrido un problema mientras se intentaba eliminar el banner\n" +
                                "\t- Nombre: " + auxBanner.Nombre + "\n" +
                                "Problema:" + e.Error.Message +
                                "Intente Eliminarlo nuevamente");
            }
            else
            {
                ((List<Banner>)this.dataGridView.DataSource).Remove((Banner)e.Result);
                this.ReDibujarDGV();
            }
        }
        #endregion

        #region Método Accesibles
        /// <summary>
        /// Método que se lanza cuando la ventana de Configuración del Banner se cierra
        /// </summary>
        internal void HijoCerrandose()
        {
            this.Show();
        }

        /// <summary>
        /// Hace que la ventana muestre label de que se están guardando banners
        /// </summary>
        /// <param name="value">Valor para sumar o restar cantidad de banners guardados</param>
        internal void Guardando(bool value)
        {
            if (value)
            {
                this.iGuardandoCantidad++;
            }
            else
            {
                this.iGuardandoCantidad--;
            }
            this.LabelGuardar();
        }

        /// <summary>
        /// Actualiza el DGV a partir del Hijo
        /// </summary>
        public void ActualizarDesdeHijo()
        {
            if (this.backgroundWorker_Obtener.IsBusy)
            {
                this.backgroundWorker_Obtener.CancelAsync();
            }
            Dictionary<Type, object> argumentos;
            if (!this.groupBox_Filtro.Visible)
            {
                argumentos = this.ArgumentosHoy();
            }
            else
            {
                argumentos = this.ArgumentosSelccionados();
            }
            this.ActualizarDGV(argumentos);
        }
        #endregion
    }
}