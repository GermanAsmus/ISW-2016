using System;
using System.Windows.Forms;
using Servicios;
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Dominio;

namespace UI
{
    public partial class Form_Configuracion_Campaña : Form
    {
        #region Variables
        /// <summary>
        /// Campaña sobre la cual trabajar
        /// </summary>
        private Campaña iCampaña;
        /// <summary>
        /// Cantidad de Rangos Fecha agregados
        /// </summary>
        private int iCantRangosFecha;
        /// <summary>
        /// Determina si los rangos fecha están completos
        /// </summary>
        private bool iRangosFechaCompletos;
        /// <summary>
        /// Variable booleana que determina cuando cerrar la ventana de forma permanente o cuando preguntar para guardar
        /// </summary>
        private bool iCerrarCodigo;
        /// <summary>
        /// Variable booleana que determina si se activa o no el handler del SelectionChanged Event
        /// Para ello verifica que la fila actual no sea la última sino el CurrentRow del SelectionChange lanza excepción
        /// </summary>
        private bool iSCEActive;
        /// <summary>
        /// Variable que determina que hace la ventana
        /// </summary>
        private Form_Campaña.delegado iFuncionVentana;
        /// <summary>
        /// Índice que determina la imagen actual de la lista que posee la campaña, se utiliza junto con los toolStripContainers y demás
        /// </summary>
        private int iIndiceImagenActual;
        /// <summary>
        /// Lista de Picture Boxes de Miniatura
        /// </summary>
        private List<PictureBox> iListaPictureBoxMiniatura;
        /// <summary>
        /// Lista de TextBoxes de Miniatura
        /// </summary>
        private List<TextBox> iListaTextBoxesMiniatura;
        /// <summary>
        /// Lista de ToolStripContainers de Miniatura
        /// </summary>
        private List<ToolStripContainer> iListaToolStripContainerMiniatura;
        /// <summary>
        /// Enumerador para poder previsualizar las imágenes
        /// </summary>
        private IEnumerator<Imagen> enumeradorImagenes;
        #endregion

        #region Región: Inicialización y Carga
        /// <summary>
        /// Constructor de la ventana
        /// </summary>
        /// <param name="funcionVentana">Función que realizará la ventana a la hora de presionar boton Aceptar</param>
        /// <param name="pCampaña">Campaña sobre la cual trabajar, sino es nulo</param>
        public Form_Configuracion_Campaña(Form_Campaña.delegado funcionVentana, Campaña pCampaña = null)
        {
            InitializeComponent();
            this.ConfiguracionInicialDataGridView();
            bool auxiliar = pCampaña != null;
            if (auxiliar)
            {
                this.iCampaña = pCampaña;
                this.textBox_Nombre.Text = this.iCampaña.Nombre;
                this.textBox_IntervaloTiempo.Text = this.iCampaña.IntervaloTiempo.ToString();
                this.tabControl.TabPages[2].Text += " [cargando...]";
                this.backgroundWorker_CargarImagenes.RunWorkerAsync(this.iCampaña.Codigo);
                this.DesHabilitarTab(this.tabControl.TabPages[2], false);
                this.textBox_IntervaloTiempo.Text = this.iCampaña.IntervaloTiempo.ToString();
            }
            else
            {
                this.ChangeEnableGroupBoxHorario(false);
                this.button_EliminarFecha.Enabled = false;
                this.iCampaña = new Campaña();
            }
            this.iIndiceImagenActual = 0;
            this.ConfigInicialForms();
            this.Configuracion(auxiliar);
            this.iFuncionVentana = funcionVentana;
            this.ActualizarListaFechas();
            this.textBox_Nombre.Focus();
            this.ConfigurarPestañaImagenes();
        }

        /// <summary>
        /// Configura forms de la ventana en el inicio
        /// </summary>
        private void ConfigInicialForms()
        {
            this.iCerrarCodigo = false;
            this.button_Aceptar.Enabled = false;
            this.CancelButton = this.button_Cancelar;
            this.AcceptButton = this.button_Aceptar;
            this.iCantRangosFecha = this.iCampaña.ListaRangosFecha.Count;
            this.iSCEActive = true;
            //File Dialog Imagenes
            this.openFileDialog_Imagenes.RestoreDirectory = true;
            this.openFileDialog_Imagenes.Multiselect = true;
            this.openFileDialog_Imagenes.Filter = "Imagen (*.bmp;*.jpg;*.gif;*.png;*.tiff)|*.bmp;*.jpg;*.gif;*.png;*.tiff";
            this.openFileDialog_Imagenes.FilterIndex = 0;
            this.openFileDialog_Imagenes.DefaultExt = "jpg";
            this.openFileDialog_Imagenes.Title = "Seleccionar Imagen";
            //Lista Picture Box
            this.iListaPictureBoxMiniatura = new List<PictureBox>();
            this.iListaPictureBoxMiniatura.Add(this.pictureBox_ImMin1);
            this.iListaPictureBoxMiniatura.Add(this.pictureBox_ImMin2);
            this.iListaPictureBoxMiniatura.Add(this.pictureBox_ImMin3);
            this.iListaPictureBoxMiniatura.Add(this.pictureBox_ImMin4);
            //Lista Text Box
            this.iListaTextBoxesMiniatura = new List<TextBox>();
            this.iListaTextBoxesMiniatura.Add(this.textBox_ImMin1);
            this.iListaTextBoxesMiniatura.Add(this.textBox_ImMin2);
            this.iListaTextBoxesMiniatura.Add(this.textBox_ImMin3);
            this.iListaTextBoxesMiniatura.Add(this.textBox_ImMin4);
            //Lista ToolStripContainers
            this.iListaToolStripContainerMiniatura = new List<ToolStripContainer>();
            this.iListaToolStripContainerMiniatura.Add(this.toolStripContainer_ImMin1);
            this.iListaToolStripContainerMiniatura.Add(this.toolStripContainer_ImMin2);
            this.iListaToolStripContainerMiniatura.Add(this.toolStripContainer_ImMin3);
            this.iListaToolStripContainerMiniatura.Add(this.toolStripContainer_ImMin4);
        }

        /// <summary>
        /// Configura variables de la ventana y la imagen inicial de los parte inferior del form
        /// </summary>
        /// <param name="value">Valor a configurar</param>
        private void Configuracion(bool value)
        {
            this.iRangosFechaCompletos = value;
            this.CampoCompleto(this.pictureBox_ComprobacionNombre, value);
            this.CampoCompleto(this.pictureBox_ComprobacionIntervaloTiempo, value);
            this.CampoCompleto(this.pictureBox_ComprobacionRF, value);
            this.CampoCompleto(this.pictureBox_ComprobacionRH, value);
            this.CampoCompleto(this.pictureBox_ComprobacionImagenes, value);
            this.CampoCompleto(this.pictureBox_ComprobacionTiempoIm, value);
            this.button_Atras.Image = ImagenServices.CambiarTamañoImagen(Properties.Resources.Atrás, this.button_Atras.Size.Width, this.button_Atras.Size.Height);
            this.button_Siguiente.Image = ImagenServices.CambiarTamañoImagen(Properties.Resources.Siguiente, this.button_Siguiente.Size.Width, this.button_Siguiente.Size.Height);
            this.button_AgregarHora.Image = ImagenServices.CambiarTamañoImagen(Properties.Resources.Modificar, this.button_AgregarHora.Size.Width, this.button_AgregarHora.Size.Height);
        }
        #endregion

        #region Región: Eventos Comunes
        /// <summary>
        /// Evento que surge al hacer clic sobre el botón Cancelar
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento que surge al hacer clic sobre el botón Aceptar
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void button_Aceptar_Click(object sender, EventArgs e)
        {
            this.iCampaña.Nombre = this.textBox_Nombre.Text;
            this.iCampaña.IntervaloTiempo = Convert.ToInt16(this.textBox_IntervaloTiempo.Text);
            this.backgroundWorker_BotonAceptar.RunWorkerAsync(this.iCampaña);
            this.Hide();
            ((Form_Campaña)this.Owner).EnEspera(false);
            ((Form_Campaña)this.Owner).HijoCerrandose();
        }

        /// <summary>
        /// Evento que surge antes de que la ventana se cierre
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void Form_ConfiguracionCampaña_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((!this.iCerrarCodigo) && (e.CloseReason == CloseReason.UserClosing))
            {
                DialogResult result = MessageBox.Show("¿Está seguro que desea regresar sin guardar? Se perderán los datos", "Atención",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    ((Form_Campaña)this.Owner).HijoCerrandose();
                }
                else
                {
                    //Cancela el evento de cerrar la ventana
                    e.Cancel = true;
                }
            }
            else
            {
                ((Form_Campaña)this.Owner).HijoCerrandose();
            }
        }

        /// <summary>
        /// Evento que surge al presionar tecla en el textBox Tiempo Intervalo o en el de las Imágenes
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void textBox_Numerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
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
            bool valorFinal = (this.textBox_Nombre.Text != "") && (this.textBox_IntervaloTiempo.Text != "0") &&
                              (this.iCampaña.ListaRangosFecha.Count > 0) && this.iRangosFechaCompletos &&
                              this.TiemposImagenesCompletos();
            //No es necesari comprobar (this.iCampaña.ListaImagenes.Count > 0) por que lo hace el TiempoImagenesCompleto
            this.button_Aceptar.Enabled = valorFinal;
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

        /// <summary>
        /// Habilita o Deshabilita todos los elementos que están en una pestaña
        /// </summary>
        /// <param name="pestaña">Pestaña a habilitar o deshabilitar</param>
        /// <param name="habilitacion">Valor de habilitación o deshabilitación</param>
        private void DesHabilitarTab(TabPage pestaña, bool habilitacion)
        {
            foreach (Control ctl in pestaña.Controls)
            {
                ctl.Enabled = habilitacion;
            }
        }
        #endregion

        #region Región: Pestaña Configuración Básica
        #region Eventos
        /// <summary>
        /// Evento que surge al ingresar entradas de teclas al Nombre
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void textBox_Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar) && !char.IsSymbol(e.KeyChar))
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
            bool resultado = Regex.IsMatch(this.textBox_Nombre.Text, @"^[a-zA-Záíéóú\s\p{P}]+$");
            this.CampoCompleto(this.pictureBox_ComprobacionNombre, resultado);
            if (!resultado)
            {
                this.textBox_Nombre.Text = "";
            }
            this.ActivarAceptar();

        }

        /// <summary>
        /// Evento que surge al salir del textBox Tiempo Intervalo
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void textBox_IntervaloTiempo_Leave(object sender, EventArgs e)
        {
            bool resultado = this.textBox_IntervaloTiempo.Text == "" || Convert.ToInt16(this.textBox_IntervaloTiempo.Text) == 0;
            if (resultado)
            {
                this.textBox_IntervaloTiempo.Text = "0";
            }
            this.CampoCompleto(this.pictureBox_ComprobacionIntervaloTiempo, !resultado);
            this.ActivarAceptar();
        }

        /// <summary>
        /// Evento que surge cuando se cambia el checked del checkBoxPrevisualización
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void checkBox_Previsualizacion_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_Previsualizacion.Checked)
            {
                bool intTiempoCompleto = this.textBox_IntervaloTiempo.Text != "0";
                bool cantImagenesCompletas = this.iCampaña.ListaImagenes.Count > 0;
                bool tiemposImagenesCompletos = this.TiemposImagenesCompletos();
                if (!(intTiempoCompleto && cantImagenesCompletas && tiemposImagenesCompletos))
                {
                    this.groupBox_CamposACompletar.Visible = true;
                    this.linkLabel_Imágenes.Visible = !cantImagenesCompletas;
                    this.linkLabel_IntervaloTiempo.Visible = !intTiempoCompleto;
                    this.linkLabel_TiemposImágenes.Visible = !tiemposImagenesCompletos;
                }
                else
                {
                    this.enumeradorImagenes = this.iCampaña.ListaImagenes.GetEnumerator();
                    this.Previsualizacion();
                }
            }
            else
            {
                this.groupBox_CamposACompletar.Visible = false;
                this.pictureBox_Previsualización.Image = null;
                this.timer_ImagenesCampaña.Enabled = false;
            }
        }

        /// <summary>
        /// Evento que surge al hacer click en el link de Intervalo de Tiempo
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void linkLabel_IntervaloTiempo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.textBox_IntervaloTiempo.Focus();
        }

        /// <summary>
        /// Evento que surge al hacer click en el link de Imágenes o Tiempos de Imágenes
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void linkLabel_PestañaImágenes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.tabControl.SelectedIndex = 2;
        }

        /// <summary>
        /// Evento que surge al salir de la Pestaña Configuración Básica
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void tabPage_ConfiguracionBasica_Leave(object sender, EventArgs e)
        {
            this.checkBox_Previsualizacion.Checked = false;
            this.pictureBox_Previsualización.Image = null;
            this.timer_ImagenesCampaña.Interval = 1000;
            this.timer_ImagenesCampaña.Enabled = false;
        }

        /// <summary>
        /// Evento que surge cada vez que el timer hace tick (pasa 1 segundo)
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void timer_ImagenesCampaña_Tick(object sender, EventArgs e)
        {
            if (enumeradorImagenes.MoveNext())
            {
                this.pictureBox_Previsualización.Image = this.enumeradorImagenes.Current.Picture;
                this.timer_ImagenesCampaña.Interval = this.enumeradorImagenes.Current.Tiempo * 1000;
            }
            else
            {
                this.enumeradorImagenes.Reset();
                this.pictureBox_Previsualización.Image = null;
                this.timer_ImagenesCampaña.Interval = 1000;
                //Imagen de Fin
            }
        }
        #endregion

        #region Métodos Extra
        /// <summary>
        /// Método que se encarga de activar el Timer y resetear el enumerador
        /// </summary>
        private void Previsualizacion()
        {
            this.pictureBox_Previsualización.Image = null;
            this.enumeradorImagenes.Reset();
            this.timer_ImagenesCampaña.Interval = 1000;
            this.timer_ImagenesCampaña.Enabled = true;
        }
        #endregion
        #endregion

        #region Región: Pestaña Rango Horario
        #region Eventos
        /// <summary>
        /// Evento que surge al seleccionar un Rango Fecha
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void dataGridView_Fecha_SelectionChanged(object sender, EventArgs e)
        {
            if (this.iSCEActive)
            {
                this.ActualizarListaHorarios(this.RangoFechaSeleccionado());
            }
        }

        /// <summary>
        /// Evento que surge al hacer clic sobre el botón de Agregar del groupBox Rango de Fechas
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void button_AgregarFecha_Click(object sender, EventArgs e)
        {
            DateTime auxFechaI = this.dateTimePicker_RangoFechaDesde.Value.Date;
            DateTime auxFechaF = this.dateTimePicker_RangoFechaHasta.Value.Date;
            int resultadoC = auxFechaI.CompareTo(auxFechaF);
            if ((resultadoC <= 0) && (this.VerificarRangoFecha(auxFechaI, auxFechaF)))
            {
                this.iSCEActive = true;
                this.iCantRangosFecha += 1;
                RangoFecha auxRangoFecha = new RangoFecha()
                {
                    FechaInicio = auxFechaI,
                    FechaFin = auxFechaF,
                    Codigo = this.iCantRangosFecha
                };
                this.iCampaña.ListaRangosFecha.Add(auxRangoFecha);
                this.button_EliminarFecha.Enabled = true;
                this.ChangeEnableGroupBoxHorario(true);
                this.ActualizarListaFechas();
                this.MarcarFilasIncompletas();
                this.CampoCompleto(this.pictureBox_ComprobacionRF, true);
                this.CampoCompleto(this.pictureBox_ComprobacionRH, this.iRangosFechaCompletos);
            }
            else
            {
                string mensaje;
                if (resultadoC > 0)
                {
                    mensaje = "La fecha de fin (Hasta) debe ser mayor o igual a la fecha de inicio (Desde)";
                }
                else
                {
                    mensaje = "El rango de fechas ya existe";
                }
                MessageBox.Show(mensaje);
            }
        }

        /// <summary>
        /// Evento que surge al hacer clic sobre el botón de Eliminar del groupBox Rango de Fechas
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void button_EliminarFecha_Click(object sender, EventArgs e)
        {
            RangoFecha auxRangoFecha = this.RangoFechaSeleccionado();
            this.iSCEActive = !(this.dataGridView_Fecha.CurrentRow.Index + 1 == this.dataGridView_Fecha.RowCount);
            this.iCampaña.ListaRangosFecha.Remove(auxRangoFecha);
            this.ActualizarListaFechas();
            this.ActivarAceptar();
            this.button_AgregarFecha.Enabled = true;
            bool aux = this.iCampaña.ListaRangosFecha.Count > 0;
            this.ChangeEnableGroupBoxHorario(aux);
            this.button_EliminarFecha.Enabled = aux;
            this.MarcarFilasIncompletas();
            //Sólo se ejecuta luego de que se elimina la última fila, luego de actualizar el DGV Fecha y así actualiza el Rango horario con el 
            //primero, sino tira error. Alternativa: sacar el EventHandler del SelectionChanged de DGV fecha cuando se elimina la última fila;
            if (!this.iSCEActive && (this.dataGridView_Fecha.RowCount > 0))
            {
                this.ActualizarListaHorarios(this.RangoFechaSeleccionado());
            }
            this.iSCEActive = true;
            this.CampoCompleto(this.pictureBox_ComprobacionRF, this.iCampaña.ListaRangosFecha.Count > 0);
            this.CampoCompleto(this.pictureBox_ComprobacionRH, this.iRangosFechaCompletos);
        }

        /// <summary>
        /// Evento que surge al hacer clic sobre el botón de Agregar del groupBox Rango Horario
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void button_AgregarHora_Click(object sender, EventArgs e)
        {
            this.button_AgregarFecha.Enabled = true;
            Form_SeleccionRangoHorario seleccionHorarios =
                                    new Form_SeleccionRangoHorario(this.RangoFechaSeleccionado(), this.ListaRangosHorariosRF(), false);
            seleccionHorarios.Owner = this;
            seleccionHorarios.ShowDialog();
        }

        /// <summary>
        /// Evento que surge al hacer clic sobre el botón de Eliminar del groupBox Rango Horario
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void button_EliminarHora_Click(object sender, EventArgs e)
        {
            RangoHorario rangoHorario = this.RangoHorarioSeleccionado();
            RangoFecha auxRangoFecha = this.RangoFechaSeleccionado();
            auxRangoFecha.ListaRangosHorario.Remove(rangoHorario);
            this.ActualizarListaHorarios(auxRangoFecha);
            int cantidadRangosHor = auxRangoFecha.ListaRangosHorario.Count;
            this.button_AgregarFecha.Enabled = cantidadRangosHor > 0;
            this.MarcarFilasIncompletas();
            this.ActivarAceptar();
            this.CampoCompleto(this.pictureBox_ComprobacionRH, this.iRangosFechaCompletos);
        }
        #endregion

        #region Métodos Extra
        /// <summary>
        /// Configura los DataGridView para que muestren las columnas correspondientes
        /// </summary>
        private void ConfiguracionInicialDataGridView()
        {
            //CONFIGURACIÓN DataGridView FECHA
            this.dataGridView_Fecha.AutoGenerateColumns = false;
            this.dataGridView_Fecha.AutoSize = false;
            // Ininicializa la columna de la 'Fecha Inicio'
            DataGridViewColumn column = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "FechaInicio",
                Name = "Fecha de inicio",
                ValueType = typeof(DateTime)
            };
            this.dataGridView_Fecha.Columns.Add(column);
            // Ininicializa la columna de la 'Fecha Fin'
            column = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "FechaFin",
                Name = "Fecha Fin",
                ValueType = typeof(DateTime)
            };
            this.dataGridView_Fecha.Columns.Add(column);
            // Ininicializa la columna del 'Codigo' (No Visible)
            column = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Codigo",
                Name = "Codigo",
                Visible = false,
                ValueType = typeof(int),
            };
            this.dataGridView_Fecha.Columns.Add(column);

            //CONFIGURACIÓN DataGridView HORARIO
            this.dataGridView_Hora.AutoGenerateColumns = false;
            this.dataGridView_Hora.AutoSize = false;
            // Ininicializa la columna de la 'Hora Inicio'
            column = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "HoraInicio",
                Name = "Hora de inicio",
                ValueType = typeof(TimeSpan)
            };
            this.dataGridView_Hora.Columns.Add(column);
            // Ininicializa la columna de la 'Hora Fin'
            column = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "HoraFin",
                Name = "Hora Finalización",
                ValueType = typeof(TimeSpan)
            };
            this.dataGridView_Hora.Columns.Add(column);
        }

        /// <summary>
        /// Cambia la Habilitación todos los forms contenidos dentro de un groupBox 
        /// </summary>
        /// <param name="value">Valor a cambiar la habilitación</param>
        private void ChangeEnableGroupBoxHorario(bool value)
        {
            this.groupBox_RangoHorario.Enabled = value;
        }

        /// <summary>
        /// Devuleve el rango de fecha seleccionado
        /// </summary>
        /// <returns>Tipo de dato UI.Tipos.RangoFecha que representa el rango de Fecha que ha sido seleccionado del DataGridView </returns>
        private RangoFecha RangoFechaSeleccionado()
        {
            return (RangoFecha)this.dataGridView_Fecha.CurrentRow.DataBoundItem;
        }

        /// <summary>
        /// Devuleve el rango de horario seleccionado
        /// </summary>
        /// <returns>Tipo de dato UI.Tipos.RangoHorario que representa el rango horario que ha sido seleccionado del DataGridView</returns>
        private RangoHorario RangoHorarioSeleccionado()
        {
            return (RangoHorario)this.dataGridView_Hora.CurrentRow.DataBoundItem;
        }

        /// <summary>
        /// Actualiza el dataGridView de Fechas
        /// </summary>
        private void ActualizarListaFechas()
        {
            this.dataGridView_Fecha.DataSource = typeof(List<RangoFecha>);
            this.dataGridView_Fecha.DataSource = this.iCampaña.ListaRangosFecha;
            (this.dataGridView_Fecha.BindingContext[this.dataGridView_Fecha.DataSource] as CurrencyManager).Refresh();
            this.dataGridView_Fecha.Update();
            this.dataGridView_Fecha.Refresh();
        }

        /// <summary>
        /// Actualiza la lista de Rangos Horarios
        /// </summary>
        /// <param name="pRangoFechaSeleccionado">Rango de Fecha seleccionado para ver sus Rangos Horarios</param>
        private void ActualizarListaHorarios(RangoFecha pRangoFechaSeleccionado)
        {
            this.dataGridView_Hora.DataSource = typeof(List<RangoHorario>);
            this.dataGridView_Hora.DataSource = pRangoFechaSeleccionado.ListaRangosHorario;
            (this.dataGridView_Hora.BindingContext[this.dataGridView_Hora.DataSource] as CurrencyManager).Refresh();
            this.dataGridView_Hora.Refresh();
            this.dataGridView_Hora.Update();
        }

        /// <summary>
        /// Cambia color de fondo de los rangos de fecha a los que les falta agregar Rangos Horarios
        /// </summary>
        private void MarcarFilasIncompletas()
        {
            this.iRangosFechaCompletos = this.dataGridView_Fecha.RowCount > 0;
            foreach (DataGridViewRow fila in this.dataGridView_Fecha.Rows)
            {
                RangoFecha rangoFecha = (RangoFecha)fila.DataBoundItem;
                if (rangoFecha.ListaRangosHorario.Count > 0)
                {
                    fila.DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    fila.DefaultCellStyle.BackColor = Color.Red;
                    this.iRangosFechaCompletos = false;
                }
            }
        }

        /// <summary>
        /// Verifica que no haya dos rangos de fecha con igual Fecha de Inicio y Fecha de Fin
        /// </summary>
        /// <param name="pFechaInicio">Fecha de Inicio del nuevo Rango Fecha a crear</param>
        /// <param name="pFechaFin">Fecha de Fin del nuevo Rango Fecha a crear</param>
        /// <returns>Tipo de dato booleano que representa si se puede crear el RF o no</returns>
        private bool VerificarRangoFecha(DateTime pFechaInicio, DateTime pFechaFin)
        {
            int indice = this.iCampaña.ListaRangosFecha.FindIndex(pRangoFecha =>
                    (pRangoFecha.FechaInicio.CompareTo(pFechaInicio) == 0) && (pRangoFecha.FechaFin.CompareTo(pFechaFin) == 0));
            return (indice == -1);
        }

        /// <summary>
        /// Actualiza la lista de Rangos Horarios a partir de los Seleccionados)
        /// </summary>
        /// <param name="pListaRangoHorario">Lista de rangos Horarios con la cual actualizar</param>
        public void ActualizarHorarios(List<RangoHorario> pListaRangoHorario)
        {
            this.RangoFechaSeleccionado().ListaRangosHorario = pListaRangoHorario;
            this.ActualizarListaHorarios(this.RangoFechaSeleccionado());
            this.MarcarFilasIncompletas();
            this.ActivarAceptar();
            if (this.iRangosFechaCompletos)
            {
                this.CampoCompleto(this.pictureBox_ComprobacionRH, true);
            }
        }

        /// <summary>
        /// Devuelve los RangosHorarios
        /// </summary>
        /// <param name="listaRangosFecha"></param>
        /// <returns></returns>
        private List<RangoHorario> ListaRangosHorariosRF()
        {
            List<RangoHorario> listaRangoHorarios = new List<RangoHorario>();
            RangoFecha pRangoFecha = this.RangoFechaSeleccionado();
            List<RangoFecha> listaResutlado = this.iCampaña.ListaRangosFecha.FindAll(x =>
                            ((x.FechaInicio <= pRangoFecha.FechaInicio) && (x.FechaFin >= pRangoFecha.FechaInicio)) ||
                            ((x.FechaInicio <= pRangoFecha.FechaFin) && (x.FechaFin >= pRangoFecha.FechaFin)) ||
                            ((x.FechaInicio >= pRangoFecha.FechaInicio) && (x.FechaFin <= pRangoFecha.FechaFin)));
            foreach (RangoFecha rangoFecha in listaResutlado)
            {
                listaRangoHorarios.AddRange(rangoFecha.ListaRangosHorario);
            }
            foreach (RangoHorario rangoHorario in pRangoFecha.ListaRangosHorario)
            {
                listaRangoHorarios.Remove(rangoHorario);
            }
            return listaRangoHorarios;
        }
        #endregion
        #endregion

        #region Región: Pestaña Imágenes
        #region Eventos
        /// <summary>
        /// Evento que surge cuando el TableLayoutPanel cambia de tamaño
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void tableLayoutPanel_ImagesCentrales_SizeChanged(object sender, EventArgs e)
        {
            TableLayoutPanel panelTabla = (TableLayoutPanel)sender;
            //Se resta 6 porque el PictureBox es siempre más chico que la tabla
            int nuevoAlto = (panelTabla.Height - 6) - ((panelTabla.Height - 6) % 9);
            this.CambiarTamaño(nuevoAlto);
        }

        /// <summary>
        /// Evento que surge cuando pestaña Imágenes tiene control
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void tabPage_Imágenes_Enter(object sender, EventArgs e)
        {
            int nuevoAlto = (this.tableLayoutPanel_ImCentrales.Height - 6) - ((tableLayoutPanel_ImCentrales.Height - 6) % 9);
            this.CambiarTamaño(nuevoAlto);
            this.label_Imagenes_TiempoT.Text = this.textBox_IntervaloTiempo.Text + " segundos";
            this.ActualizarTiempoRestante();
        }

        /// <summary>
        /// Evento que surge al hacer clic en el botón agregar imágenes
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void button_AgregarImagenes_Click(object sender, EventArgs e)
        {
            DialogResult resultado = this.openFileDialog_Imagenes.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                try
                {
                    foreach (string rutaImagen in this.openFileDialog_Imagenes.FileNames)
                    {
                    
                    Imagen pImagen = new Imagen()
                    {
                        Picture = Image.FromFile(rutaImagen)
                    };
                    this.iCampaña.ListaImagenes.Add(pImagen);
                    }
                }
                catch (OutOfMemoryException)
                {
                    MessageBox.Show("Borre algunas imágenes o intente cargando imágenes\n" +
                                     "de menor calidad");
                }
                this.ConfigurarComponentesMiniaturas();
                this.ActivarAceptar();
            }
        }

        /// <summary>
        /// Evento que surge al salir de un campo numérico de las imágenes
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void textBox_Numerico_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "")
            {
                textBox.Text = "0";
            }
            int indice = this.iListaTextBoxesMiniatura.IndexOf(textBox);
            if (this.iCampaña.ListaImagenes.Count > 0)
            {
                this.iCampaña.ListaImagenes[this.iIndiceImagenActual + indice].Tiempo = Convert.ToInt16(textBox.Text);
            }
            this.CampoCompleto(this.pictureBox_ComprobacionTiempoIm, this.TiemposImagenesCompletos());
            this.ActivarAceptar();
            this.ActualizarTiempoRestante();
        }

        /// <summary>
        /// Evento que surge al hacer clic en el botón atrás
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void button_Atras_Click(object sender, EventArgs e)
        {
            this.button_Siguiente.Enabled = true;
            this.button_Atras.Enabled = !(this.iIndiceImagenActual == 1);
            this.iIndiceImagenActual--;
            this.ConfigurarComponentesMiniaturas();
        }

        /// <summary>
        /// Evento que surge al hacer clic en el botón siguiente
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void button_Siguiente_Click(object sender, EventArgs e)
        {
            this.button_Atras.Enabled = true;
            this.button_Siguiente.Enabled = !(this.iIndiceImagenActual + 5 == this.iCampaña.ListaImagenes.Count);
            this.iIndiceImagenActual++;
            this.ConfigurarComponentesMiniaturas();
        }

        #region ToolStrips
        /// <summary>
        /// Evento que surge al hacer clic en el botón aumentar imagen de la primera imagen
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void toolStrip_Button_AumentarImagen1_Click(object sender, EventArgs e)
        {
            this.pictureBox_ImCentral1.Image = this.iCampaña.ListaImagenes[this.iIndiceImagenActual].Picture;
            this.textBox_ImCentral1_Tiempo.Text = this.textBox_ImMin1.Text;
        }

        /// <summary>
        /// Evento que surge al hacer clic en el botón aumentar imagen de la segunda imagen
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void toolStrip_Button_AumentarImagen2_Click(object sender, EventArgs e)
        {
            this.pictureBox_ImCentral1.Image = this.iCampaña.ListaImagenes[this.iIndiceImagenActual + 1].Picture;
            this.textBox_ImCentral1_Tiempo.Text = this.textBox_ImMin2.Text;
        }

        /// <summary>
        /// Evento que surge al hacer clic en el botón aumentar imagen de la tercera imagen
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void toolStrip_Button_AumentarImagen3_Click(object sender, EventArgs e)
        {
            this.pictureBox_ImCentral2.Image = this.iCampaña.ListaImagenes[this.iIndiceImagenActual + 2].Picture;
            this.textBox_ImCentral2_Tiempo.Text = this.textBox_ImMin3.Text;
        }

        /// <summary>
        /// Evento que surge al hacer clic en el botón aumentar imagen de la cuarta imagen
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void toolStrip_Button_AumentarImagen4_Click(object sender, EventArgs e)
        {
            this.pictureBox_ImCentral2.Image = this.iCampaña.ListaImagenes[this.iIndiceImagenActual + 3].Picture;
            this.textBox_ImCentral2_Tiempo.Text = this.textBox_ImMin4.Text;
        }

        /// <summary>
        /// Evento que surge al hacer clic en el botón eliminar imagen de la n°1
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void toolStrip_Button_EliminarImagen1_Click(object sender, EventArgs e)
        {
            this.iCampaña.ListaImagenes.RemoveAt(this.iIndiceImagenActual);
            this.pictureBox_ImMin1.Image.Dispose();
            this.ConfigurarComponentesMiniaturas();
            this.ActualizarTiempoRestante();
        }

        /// <summary>
        /// Evento que surge al hacer clic en el botón eliminar imagen de la n°2
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void toolStrip_Button_EliminarImagen2_Click(object sender, EventArgs e)
        {
            this.iCampaña.ListaImagenes.RemoveAt(this.iIndiceImagenActual + 1);
            this.pictureBox_ImMin2.Image.Dispose();
            this.ConfigurarComponentesMiniaturas();
            this.ActualizarTiempoRestante();
        }

        /// <summary>
        /// Evento que surge al hacer clic en el botón eliminar imagen de la n°3
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void toolStrip_Button_EliminarImagen3_Click(object sender, EventArgs e)
        {
            this.iCampaña.ListaImagenes.RemoveAt(this.iIndiceImagenActual + 2);
            this.pictureBox_ImMin3.Image.Dispose();
            this.ConfigurarComponentesMiniaturas();
            this.ActualizarTiempoRestante();
        }

        /// <summary>
        /// Evento que surge al hacer clic en el botón eliminar imagen de la n°4
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void toolStrip_Button_EliminarImagen4_Click(object sender, EventArgs e)
        {
            this.iCampaña.ListaImagenes.RemoveAt(this.iIndiceImagenActual + 3);
            this.pictureBox_ImMin4.Image.Dispose();
            this.ConfigurarComponentesMiniaturas();
            this.ActualizarTiempoRestante();
        }

        /// <summary>
        /// Evento que surge al hacer clic en el botón modificar imagen de la primera imagen
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void toolStripImMin1_Button_ModificarImagen_Click(object sender, EventArgs e)
        {
            this.openFileDialog_Imagenes.Multiselect = false;
            DialogResult resultado = this.openFileDialog_Imagenes.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                try
                {
                    Imagen imagenActual = this.iCampaña.ListaImagenes[this.iIndiceImagenActual];
                    string rutaImagen = this.openFileDialog_Imagenes.FileName;
                    imagenActual.Picture.Dispose();
                    imagenActual.Picture = Image.FromFile(rutaImagen);
                    this.iListaPictureBoxMiniatura[this.iIndiceImagenActual].Image = imagenActual.Picture;
                }
                catch (OutOfMemoryException)
                {
                    MessageBox.Show("Borre algunas imágenes o intente cargando imágenes\n" +
                                     "de menor calidad");
                }
            }
            this.openFileDialog_Imagenes.Multiselect = true;
        }

        /// <summary>
        /// Evento que surge al hacer clic en el botón modificar imagen de la primera imagen
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void toolStripImMin2_Button_ModificarImagen_Click(object sender, EventArgs e)
        {
            this.openFileDialog_Imagenes.Multiselect = false;
            DialogResult resultado = this.openFileDialog_Imagenes.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                try
                {
                    Imagen imagenActual = this.iCampaña.ListaImagenes[this.iIndiceImagenActual + 1];
                    string rutaImagen = this.openFileDialog_Imagenes.FileName;
                    imagenActual.Picture.Dispose();
                    imagenActual.Picture = Image.FromFile(rutaImagen);
                    this.iListaPictureBoxMiniatura[this.iIndiceImagenActual + 1].Image = imagenActual.Picture;
                }
                catch (OutOfMemoryException)
                {
                    MessageBox.Show("Borre algunas imágenes o intente cargando imágenes\n" +
                                     "de menor calidad");
                }
            }
            this.openFileDialog_Imagenes.Multiselect = true;
        }

        /// <summary>
        /// Evento que surge al hacer clic en el botón modificar imagen de la primera imagen
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void toolStripImMin3_Button_ModificarImagen_Click(object sender, EventArgs e)
        {
            this.openFileDialog_Imagenes.Multiselect = false;
            DialogResult resultado = this.openFileDialog_Imagenes.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                try
                {
                    Imagen imagenActual = this.iCampaña.ListaImagenes[this.iIndiceImagenActual + 2];
                    string rutaImagen = this.openFileDialog_Imagenes.FileName;
                    imagenActual.Picture.Dispose();
                    imagenActual.Picture = Image.FromFile(rutaImagen);
                    this.iListaPictureBoxMiniatura[this.iIndiceImagenActual + 2].Image = imagenActual.Picture;
                }
                catch (OutOfMemoryException)
                {
                    MessageBox.Show("Borre algunas imágenes o intente cargando imágenes\n" +
                                     "de menor calidad");
                }
            }
            this.openFileDialog_Imagenes.Multiselect = true;
        }

        /// <summary>
        /// Evento que surge al hacer clic en el botón modificar imagen de la primera imagen
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void toolStripImMin4_Button_ModificarImagen_Click(object sender, EventArgs e)
        {
            this.openFileDialog_Imagenes.Multiselect = false;
            DialogResult resultado = this.openFileDialog_Imagenes.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                try
                {
                    Imagen imagenActual = this.iCampaña.ListaImagenes[this.iIndiceImagenActual + 3];
                    string rutaImagen = this.openFileDialog_Imagenes.FileName;
                    imagenActual.Picture.Dispose();
                    imagenActual.Picture = Image.FromFile(rutaImagen);
                    this.iListaPictureBoxMiniatura[this.iIndiceImagenActual + 3].Image = imagenActual.Picture;
                }
                catch (OutOfMemoryException)
                {
                    MessageBox.Show("Borre algunas imágenes o intente cargando imágenes\n" +
                                     "de menor calidad");
                }
            }
            this.openFileDialog_Imagenes.Multiselect = true;
        }
        #endregion
        #endregion

        #region Métodos Extra
        /// <summary>
        /// Evento que surge cuando el TableLayoutPanel cambia de tamaño
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void CambiarTamaño(int nuevoAlto)
        {
            this.pictureBox_ImCentral1.Size = new Size(nuevoAlto * 16 / 9, nuevoAlto);
            this.pictureBox_ImCentral2.Size = new Size(nuevoAlto * 16 / 9, nuevoAlto);
        }

        /// <summary>
        /// Configura la pestaña Imágenes
        /// </summary>
        private void ConfigurarPestañaImagenes()
        {
            //Imagen Miniatura 1
            this.toolStripImMin1_Button_EliminarImagen.Image = ImagenServices.CambiarTamañoImagen(SystemIcons.Error.ToBitmap(),
                                this.toolStripImMin1_Button_EliminarImagen.Width, this.toolStripImMin1_Button_EliminarImagen.Height);
            this.toolStripImMin1_Button_AumentarImagen.Image = ImagenServices.CambiarTamañoImagen(Properties.Resources.Aumentar,
                                this.toolStripImMin1_Button_AumentarImagen.Width, this.toolStripImMin1_Button_AumentarImagen.Height);
            this.toolStripImMin1_Button_ModificarImagen.Image = ImagenServices.CambiarTamañoImagen(Properties.Resources.Modificar,
                                this.toolStripImMin1_Button_ModificarImagen.Width, this.toolStripImMin1_Button_ModificarImagen.Height);
            this.toolStripImMin1_Button_EliminarImagen.ToolTipText = "Eliminar";
            this.toolStripImMin1_Button_AumentarImagen.ToolTipText = "Aumentar";
            this.toolStripImMin1_Button_ModificarImagen.ToolTipText = "Modificar";

            //Imagen Miniatura 2
            this.toolStripImMin2_Button_EliminarImagen.Image = ImagenServices.CambiarTamañoImagen(SystemIcons.Error.ToBitmap(),
                                this.toolStripImMin2_Button_EliminarImagen.Width, this.toolStripImMin2_Button_EliminarImagen.Height);
            this.toolStripImMin2_Button_AumentarImagen.Image = ImagenServices.CambiarTamañoImagen(Properties.Resources.Aumentar,
                    this.toolStripImMin2_Button_AumentarImagen.Width, this.toolStripImMin2_Button_AumentarImagen.Height);
            this.toolStripImMin2_Button_ModificarImagen.Image = ImagenServices.CambiarTamañoImagen(Properties.Resources.Modificar,
                    this.toolStripImMin2_Button_ModificarImagen.Width, this.toolStripImMin2_Button_ModificarImagen.Height);
            this.toolStripImMin2_Button_EliminarImagen.ToolTipText = "Eliminar";
            this.toolStripImMin2_Button_AumentarImagen.ToolTipText = "Aumentar";
            this.toolStripImMin2_Button_ModificarImagen.ToolTipText = "Modificar";

            //Imagen Miniatura 3
            this.toolStripImMin3_Button_EliminarImagen.Image = ImagenServices.CambiarTamañoImagen(SystemIcons.Error.ToBitmap(),
                                this.toolStripImMin3_Button_EliminarImagen.Width, this.toolStripImMin3_Button_EliminarImagen.Height);
            this.toolStripImMin3_Button_AumentarImagen.Image = ImagenServices.CambiarTamañoImagen(Properties.Resources.Aumentar,
                                this.toolStripImMin3_Button_AumentarImagen.Width, this.toolStripImMin3_Button_AumentarImagen.Height);
            this.toolStripImMin3_Button_ModificarImagen.Image = ImagenServices.CambiarTamañoImagen(Properties.Resources.Modificar,
                    this.toolStripImMin3_Button_ModificarImagen.Width, this.toolStripImMin3_Button_ModificarImagen.Height);
            this.toolStripImMin3_Button_EliminarImagen.ToolTipText = "Eliminar";
            this.toolStripImMin3_Button_AumentarImagen.ToolTipText = "Aumentar";
            this.toolStripImMin3_Button_ModificarImagen.ToolTipText = "Modificar";

            //Imagen Miniatura 4
            this.toolStripImMin4_Button_EliminarImagen.Image = ImagenServices.CambiarTamañoImagen(SystemIcons.Error.ToBitmap(),
                                this.toolStripImMin4_Button_EliminarImagen.Width, this.toolStripImMin4_Button_EliminarImagen.Height);
            this.toolStripImMin4_Button_AumentarImagen.Image = ImagenServices.CambiarTamañoImagen(Properties.Resources.Aumentar,
                                 this.toolStripImMin4_Button_AumentarImagen.Width, this.toolStripImMin4_Button_AumentarImagen.Height);
            this.toolStripImMin4_Button_ModificarImagen.Image = ImagenServices.CambiarTamañoImagen(Properties.Resources.Modificar,
                    this.toolStripImMin4_Button_ModificarImagen.Width, this.toolStripImMin4_Button_ModificarImagen.Height);
            this.toolStripImMin4_Button_EliminarImagen.ToolTipText = "Eliminar";
            this.toolStripImMin4_Button_AumentarImagen.ToolTipText = "Aumentar";
            this.toolStripImMin4_Button_ModificarImagen.ToolTipText = "Modificar";

            int cantidadIm = this.iCampaña.ListaImagenes.Count;
            this.button_Siguiente.Enabled = cantidadIm > 4;
            this.button_Atras.Enabled = false;
            this.ConfigurarComponentesMiniaturas();
        }

        /// <summary>
        /// Comprueba si hay imágenes y si éstas tienen colocado un tiempo de muestra
        /// </summary>
        /// <returns>Tipo de dato booleano que representa si todas las imágenes tienen tiempo de muestra asignado</returns>
        private bool TiemposImagenesCompletos()
        {
            bool resultado = this.iCampaña.ListaImagenes.Count > 0;
            IEnumerator<Imagen> enumerador = this.iCampaña.ListaImagenes.GetEnumerator();
            while (enumerador.MoveNext() && resultado)
            {
                resultado = (enumerador.Current.Tiempo != 0);
            }
            resultado = resultado && (this.TiempoTotalImagenes() == Convert.ToInt16(this.textBox_IntervaloTiempo.Text));
            return resultado;
        }

        /// <summary>
        /// Muestra las imágenes
        /// </summary>
        private void ConfigurarComponentesMiniaturas()
        {
            int cantidad = this.iCampaña.ListaImagenes.Count;
            if (cantidad > 4)
            {
                cantidad = 4;
            }
            if (this.iIndiceImagenActual + cantidad > this.iCampaña.ListaImagenes.Count - 1)
            {
                this.iIndiceImagenActual = this.iCampaña.ListaImagenes.Count - cantidad;
            }
            for (int i = 0; i < cantidad; i++)
            {
                this.ConfigurarMiniatura(i, true);
                PictureBox pictureBoxActual = this.iListaPictureBoxMiniatura[i];
                pictureBoxActual.Image = this.iCampaña.ListaImagenes[this.iIndiceImagenActual + i].Picture;
                this.iListaTextBoxesMiniatura[i].Text = this.iCampaña.ListaImagenes[this.iIndiceImagenActual + i].Tiempo.ToString();
            }
            for (int i = cantidad; i < 4; i++)
            {
                this.iListaPictureBoxMiniatura[i].Image = null;
                this.ConfigurarMiniatura(i, false);
                this.iListaTextBoxesMiniatura[i].Text = "0";
            }

            this.ActivarBotonesMovimiento();
            this.CampoCompleto(this.pictureBox_ComprobacionImagenes, this.iCampaña.ListaImagenes.Count > 0);
            this.CampoCompleto(this.pictureBox_ComprobacionTiempoIm, this.TiemposImagenesCompletos());
        }

        /// <summary>
        /// Habilita o deshabilita el TextBox y ToolStripContainer (y así el PictureBox) del número de miniatura pasado por parámetro
        /// </summary>
        /// <param name="pNumeroMiniatura">Número de miniatura a habilitar o deshabilitar</param>
        /// <param name="value">Valor de habilitación o deshabilitación</param>
        public void ConfigurarMiniatura(int pNumeroMiniatura,bool value)
        {
            this.iListaTextBoxesMiniatura[pNumeroMiniatura].Enabled = value;
            this.iListaToolStripContainerMiniatura[pNumeroMiniatura].Enabled = value;
        }

        /// <summary>
        /// Activa botones dependiendo de la cantidad de imágenes y de la posición actual
        /// </summary>
        public void ActivarBotonesMovimiento()
        {
            int cantIm = this.iCampaña.ListaImagenes.Count;
            this.button_Atras.Enabled = (cantIm > 0) && (this.iIndiceImagenActual > 0);
            this.button_Siguiente.Enabled = (cantIm > 0) && (this.iIndiceImagenActual + 4 < cantIm);
        }

        /// <summary>
        /// Actualiza el valor del tiempo restante
        /// </summary>
        public void ActualizarTiempoRestante()
        {
            int tiempo = this.TiempoTotalImagenes();
            int intervaloTiempo = Convert.ToInt16(this.textBox_IntervaloTiempo.Text);
            Color colorFondo = Color.Black;
            string mensaje = "";
            if(tiempo < intervaloTiempo)
            {
                colorFondo = Color.Red;
                mensaje = " [++]";
            }
            else if(tiempo > intervaloTiempo)
            {
                colorFondo = Color.Blue;
                mensaje = " [--]";
            }
            this.label_Imagenes_TiempoR.Text = (intervaloTiempo - tiempo).ToString() + " segundos" + mensaje;
            this.label_Imagenes_TiempoR.ForeColor = colorFondo;
        }

        /// <summary>
        /// Devuelve el tiempo total que se mostraran todas las imágenes
        /// </summary>
        /// <returns>Tipo de dato entero que representa el total de reproducción de las imágenes</returns>
        public int TiempoTotalImagenes()
        {
            int tiempo = 0;
            foreach (Imagen pImagen in this.iCampaña.ListaImagenes)
            {
                tiempo += pImagen.Tiempo;
            }
            return tiempo;
        }
        #endregion

        #region Procesos segundo Plano
        /// <summary>
        /// Evento que surge cuando el Proceso en segundo plano empieza a cargar Imágenes
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_CargarImagenes_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = Comunicacion.ObtenerImagenesCampaña((int)e.Argument);
        }

        /// <summary>
        /// Evento que surge cuando el Proceso en segundo plano termina de cargar Imágenes
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_CargarImagenes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                string mensaje = "Se encontró el siguiente problema al cargar las imágenes /n" + e.Error.Message;
                mensaje += "¿Desea intentar nuevamente o Cancelar la operación de modificación?";
                DialogResult result = MessageBox.Show(mensaje, "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    this.backgroundWorker_CargarImagenes.RunWorkerAsync(this.iCampaña.Codigo);
                }
                else
                {
                    this.iCerrarCodigo = true;
                    this.Close();
                }
            }
            else
            {
                this.iCampaña.ListaImagenes = (List<Imagen>)e.Result;
                this.ConfigurarPestañaImagenes();
                this.label_Imagenes_TiempoT.Text = this.textBox_IntervaloTiempo.Text + " segundos";
                this.ActualizarTiempoRestante();
                this.DesHabilitarTab(this.tabControl.TabPages[2], true);
                this.tabControl.TabPages[2].Text = "Imágenes";
                this.ActivarAceptar();
            }
        }
        #endregion
        #endregion

        #region Región: Procesos segundo Plano
        /// <summary>
        /// Evento que surge cuando el Proceso en segundo plano empieza a guardar
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_BotonAceptar_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            this.iFuncionVentana(this.iCampaña);
        }

        /// <summary>
        /// Evento que surge cuando el backgroundworker realacionado al botón Aceptar ha finalizado su trabajo
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_BotonAceptar_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.Owner.Hide();
                this.Show();
                MessageBox.Show("Se encontró el siguiente problema al guardar /n" + e.Error.Message);
            }
            else
            {
                this.iCerrarCodigo = true;
                ((Form_Campaña)this.Owner).EnEspera(true);
                MessageBox.Show("Los datos se han guardado correctamente");
                ((Form_Campaña)this.Owner).ActualizarDGV();
                this.Close();
            }
        }
        #endregion
    }
}

