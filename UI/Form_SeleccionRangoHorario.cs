using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using Servicios;
using System.Windows.Forms;
using Dominio;

namespace UI
{
    public partial class Form_SeleccionRangoHorario : Form
    {
        private static Color Disponible = Color.White;
        private static Color NoDisponible = Color.Crimson;
        private static Color Seleccionada = Color.RoyalBlue;

        #region Variables
        /// <summary>
        /// Array que contiene true si está disponible o false si no disponible
        /// </summary>
        bool[] iBoolArrayDisponibles;
        /// <summary>
        /// Array que contiene true si está seleccionada o false en caso contrario (disponible)
        /// </summary>
        bool[] iBoolArraySeleccionados;
        /// <summary>
        /// Variable que sirve para determinar si se ciera por el botón aceptar
        /// </summary>
        bool iCerrar;
        /// <summary>
        /// Rango de Fecha al cual agregar Rangos Horarios
        /// </summary>
        RangoFecha iRangoFecha;
        /// <summary>
        /// Variable que sirve para detemrinar si se trabaja con Rangos Horarios de Banners o de Campañas
        /// </summary>
        bool iEsBanner;
        /// <summary>
        /// Lista de Rangos Horarios Seleccionados por el usuario
        /// </summary>
        List<RangoHorario> iListaRangosHorariosSeleccionados;
        #endregion

        #region Región: Inicialización y Carga
        /// <summary>
        /// Constructor de la ventana
        /// </summary>
        /// <param name="pRangoFecha">Rango Fecha a agregar Listas de Horarios</param>
        /// <param name="listaRangoHorariosOcupados">Lista de horarios ocupados</param>
        internal Form_SeleccionRangoHorario(RangoFecha pRangoFecha, List<RangoHorario> listaRangoHorariosOcupados, bool pEsBanner)
        {
            InitializeComponent();
            this.ConfigurarDGVs();
            this.iEsBanner = pEsBanner;
            this.iRangoFecha = pRangoFecha;
            this.InicializacionArrays();
            this.iListaRangosHorariosSeleccionados = pRangoFecha.ListaRangosHorario;
            this.ArrayRangosHorarios(listaRangoHorariosOcupados, this.iBoolArrayDisponibles,false);
            this.ArrayRangosHorarios(this.iListaRangosHorariosSeleccionados, this.iBoolArrayDisponibles, false);
            this.ArrayRangosHorarios(this.iListaRangosHorariosSeleccionados, this.iBoolArraySeleccionados, true);
            this.iCerrar = true;
            this.dataGridView_Horarios.Enabled = false;
            this.backgroundWorker_ObtenerRangosHorariosFecha.RunWorkerAsync(pRangoFecha);
            this.label_RangoFecha.Text = pRangoFecha.FechaInicio.ToShortDateString() + " - " + pRangoFecha.FechaFin.ToShortDateString();
            this.CancelButton = this.button_Cancelar;
            this.AcceptButton = this.button_Aceptar;
            this.ActualizarListaHorarios();
        }

        /// <summary>
        /// Inicializa los arrays de rangos disponibles y seleccionados
        /// </summary>
        private void InicializacionArrays()
        {
            this.iBoolArrayDisponibles = new bool[24 * 60];
            this.iBoolArraySeleccionados = new bool[24 * 60];
            this.InicializarArray(this.iBoolArrayDisponibles, true);
            this.InicializarArray(this.iBoolArraySeleccionados, false);
        }

        /// <summary>
        /// Configura los DataGridView con sus columnas y filas
        /// </summary>
        private void ConfigurarDGVs()
        {
            //DGV Rangos Horarios Libres
            this.dataGridView_Horarios.AutoGenerateColumns = false;
            this.dataGridView_Horarios.AutoSize = false;
            for (int i = 0; i < 24; i++)
            {
                DataGridViewColumn column = new DataGridViewColumn()
                {
                    Name = i.ToString(),
                    Width = 30,
                    ValueType = typeof(string),
                    CellTemplate = new DataGridViewTextBoxCell()
                };
                this.dataGridView_Horarios.Columns.Add(column);
            }
            for (int i = 0; i < 60; i++)
            {
                DataGridViewRow fila = new DataGridViewRow();
                this.dataGridView_Horarios.Rows.Add(fila);
                this.dataGridView_Horarios.Rows[i].HeaderCell.Value = i.ToString() + "'";
            };
            //DGV Rangos Horarios Seleccionados
            this.dataGridView_HorariosSeleccionados.AutoGenerateColumns = false;
            this.dataGridView_HorariosSeleccionados.AutoSize = false;
            // Ininicializa la columna de la 'Hora Inicio'
            DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "HoraInicio",
                Name = "Hora de inicio",
                ValueType = typeof(TimeSpan)
            };
            this.dataGridView_HorariosSeleccionados.Columns.Add(columna);
            // Ininicializa la columna de la 'Hora Fin'
            columna = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "HoraFin",
                Name = "Hora Finalización",
                ValueType = typeof(TimeSpan)
            };
            this.dataGridView_HorariosSeleccionados.Columns.Add(columna);
        }

        /// <summary>
        /// Inicializa el DGV con los colores dependiendo de si están libres o no del array booleano
        /// </summary>
        /// <param name="array">Array booleano para actualizar lista de DGV</param>
        private void BoolArrayADGV()
        {
            //Celdas No disponibles y Disponibles
            for (int i = 0; i < 60; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    if(this.iBoolArrayDisponibles[j * (60) + i])
                    {
                        this.CeldaDisponible(this.dataGridView_Horarios[j, i]);
                    }
                    else if (this.iBoolArraySeleccionados[j * (60) + i])
                    {
                        this.CeldaSeleccionada(this.dataGridView_Horarios[j, i]);
                    }
                    else
                    {
                        this.CeldaNoDisponible(this.dataGridView_Horarios[j, i]);
                    }
                }
            }
        }
        #endregion

        #region Región: Eventos Comunes
        /// <summary>
        /// Evento que surge al hacer clic sobre el botón aceptar
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void button_Aceptar_Click(object sender, EventArgs e)
        {
            this.iCerrar = false;
            if (this.iEsBanner)
            {
                ((Form_Configuracion_Banner)this.Owner).ActualizarHorarios(this.iListaRangosHorariosSeleccionados);
            }
            else
            {
                ((Form_Configuracion_Campaña)this.Owner).ActualizarHorarios(this.iListaRangosHorariosSeleccionados);
            }
            this.Owner.Show();
            this.Close();
        }

        /// <summary>
        /// Evento que surge al hacer clic sobre el botón cancelar
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento que surge al seleccionar una celda del dataGridView
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void dataGridView_Horarios_SelectionChanged(object sender, EventArgs e)
        {
            int filaSelec = this.dataGridView_Horarios.CurrentCell.RowIndex;
            int colSelec = this.dataGridView_Horarios.CurrentCell.ColumnIndex;
            //Verifica que la celda No sea una No Disponible
            if ((filaSelec >= 0) && (colSelec >= 0) && 
            //   Celda Disponible                                      o  Celda Seleccionada
                (this.iBoolArrayDisponibles[filaSelec + colSelec * 60] || this.iBoolArraySeleccionados[filaSelec + colSelec * 60]))
            {
                int codigo = filaSelec + colSelec * 60;
                DataGridViewCell celda = this.dataGridView_Horarios[colSelec, filaSelec];
                //Celda Seleccionada
                if (this.iBoolArraySeleccionados[codigo])
                {
                    this.CeldaDisponible(celda);
                    this.iBoolArraySeleccionados[codigo] = false;
                    this.iBoolArrayDisponibles[codigo] = true;

                }//celda Disponible
                else //if (celda.Style.BackColor == Disponible)
                {
                    this.CeldaSeleccionada(celda);
                    this.iBoolArraySeleccionados[codigo] = true;
                    this.iBoolArrayDisponibles[codigo] = false;
                }
                this.CargarHorarios();
                this.iListaRangosHorariosSeleccionados.Sort(new ComparadorRHPorHoraInicio());
                this.ActualizarListaHorarios();
                this.ActivarAceptar();
            }
        }

        /// <summary>
        /// Evento que surge cuando la ventana comienza a cerrarse
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void Form_SeleccionRangoHorario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.iCerrar)
            {
                DialogResult result = MessageBox.Show("¿Está seguro que desea regresar sin guardar? Se perderán los datos", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    //this.Owner.AgregarListaHorarios(this.iListaRangosHorariosSeleccionados);
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// Evento que surge al pintar una celda del dataGridView
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void dataGridView_Horarios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex > 0 && e.RowIndex > 0)
            {
                if (this.iBoolArrayDisponibles[e.ColumnIndex * 60 + e.RowIndex])
                {
                    e.CellStyle.BackColor = Disponible;
                }
                else if (this.iBoolArraySeleccionados[e.ColumnIndex * 60 + e.RowIndex])
                {
                    e.CellStyle.BackColor = Seleccionada;
                }
                else
                {
                    e.CellStyle.BackColor = NoDisponible;
                }
            }            
        }
        #endregion

        #region Región: Métodos Comunes
        /// <summary>
        /// Inicializa el array con el valor value
        /// </summary>
        /// <param name="array">Array booleano a inicializar</param>
        /// <param name="value">Valor a inicializar array</param>
        public void InicializarArray(bool[] array,bool value)
        {
            //Array que contiene en sus posiciones boolenaos, que representa true si está libre o false si está ocupado
            //para lo cual se utilizan dos fórmulas de transformación
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }
        }

        /// <summary>
        /// Genera un array de booleans que representa los rangos horarios ocupados
        /// </summary>
        /// <param name="pListaRangosHorarios">Lista de rangos horarios No Disponibles</param>
        /// <param name="array">Array a rellenar</param>
        /// <param name="value">Valor con el cual llenar</param>
        internal void ArrayRangosHorarios(List<RangoHorario> pListaRangosHorarios, bool[] array, bool value)
        {
            foreach (RangoHorario pRH in pListaRangosHorarios)
            {
                int inicio = this.TimeSpanACodigo(pRH.HoraInicio);
                int fin = this.TimeSpanACodigo(pRH.HoraFin);
                for (; inicio < fin; inicio++)
                {
                    array[inicio] = value;
                }
            }
        }

        /// <summary>
        /// Actualiza la lista de Rangos Horarios seleccionados
        /// </summary>
        private void ActualizarListaHorarios()
        {
            this.dataGridView_HorariosSeleccionados.DataSource = typeof(List<RangoHorario>);
            this.dataGridView_HorariosSeleccionados.DataSource = this.iListaRangosHorariosSeleccionados;
            this.dataGridView_HorariosSeleccionados.Refresh();
            this.dataGridView_HorariosSeleccionados.Update();
        }

        /// <summary>
        /// Carga los horarios en la lista
        /// </summary>
        private void CargarHorarios()
        {
            //recorrer Lista y hacer que se transforme en un rango horario los continuos
            int i = 0;
            this.iListaRangosHorariosSeleccionados = new List<RangoHorario>();
            int codigoRH = 0;
            while (i < this.iBoolArraySeleccionados.Length)
            {
                int j = i;
                while ((i < this.iBoolArraySeleccionados.Length) && this.iBoolArraySeleccionados[i])
                {
                    i++;
                }
                if (i > j)
                {
                    RangoHorario rangoHorario = new RangoHorario()
                    {
                        HoraInicio = this.CodigoATimeSpan(j),
                        HoraFin = this.CodigoATimeSpan(i),
                        Codigo = codigoRH
                    };
                    codigoRH++;
                    this.iListaRangosHorariosSeleccionados.Add(rangoHorario);
                }
                i++;
            }
        }

        /// <summary>
        /// Obtiene el código de array a partir del TimeSpan
        /// </summary>
        /// <param name="rangoHorario">TimeSpan del rango hroario</param>
        /// <returns>Tipo de dato int que representa el código de dicho TimeSpan</returns>
        public int TimeSpanACodigo(TimeSpan rangoHorario)
        {
            int resultado = rangoHorario.Minutes + rangoHorario.Hours * 60;
            if(rangoHorario.Seconds != 0)
            {
                resultado = (24 * 60);
            }
            return resultado;
        }

        /// <summary>
        /// Transforma de codigo al TimeSpan correspondiente
        /// </summary>
        /// <param name="codigo">Código a trnasformar</param>
        /// <returns>Tipo de dato Timespan que respresenta aquél que se corresponde con el código dado</returns>
        private TimeSpan CodigoATimeSpan(int codigo)
        {
            int horas = (int)codigo / 60;
            int minutos = codigo % 60;
            TimeSpan resultado = new TimeSpan(horas, minutos, 0);
            if (codigo == 60 * 24)
            {
                resultado = new TimeSpan(23,59, 59);
            }
            return resultado;
        }

        /// <summary>
        /// Activa el botón aceptar si la cantidad de rangos seleccionados es mayor a cero
        /// </summary>
        private void ActivarAceptar()
        {
            this.button_Aceptar.Enabled = this.iListaRangosHorariosSeleccionados.Count > 0;
        }

        /// <summary>
        /// Formatea la celda como seleccionada
        /// </summary>
        /// <param name="celda">Celda a formatear</param>
        private void CeldaSeleccionada(DataGridViewCell celda)
        {
            celda.Style.BackColor = Seleccionada;
            celda.Value = "S";
            celda.ToolTipText = "Seleccionada";
        }

        /// <summary>
        /// Formatea la celda como disponible
        /// </summary>
        /// <param name="celda">Celda a formatear</param>
        private void CeldaDisponible(DataGridViewCell celda)
        {
            celda.Value = "D";
            celda.ToolTipText = "Disponible";
            celda.Style.BackColor = Disponible;
        }

        /// <summary>
        /// Formatea la celda como no disponible
        /// </summary>
        /// <param name="celda">Celda a formatear</param>
        private void CeldaNoDisponible(DataGridViewCell celda)
        {
            celda.Value = "ND";
            celda.ToolTipText = "No Disponible";
            celda.Style.BackColor = NoDisponible;
        }
        #endregion

        #region Región: Procesos Segundo Plano
        /// <summary>
        /// Evento que surge cuando el backGrounWorker comienza a realizar su trabajo
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_ObtenerRangosHorariosFecha_DoWork(object sender, DoWorkEventArgs e)
        {
            List<RangoHorario> listaRangos;
            if (this.iEsBanner)
            {
                listaRangos = Servicios.Fachada.RangosHorariosOcupadosBanner((RangoFecha)e.Argument);
            }
            else
            {
                listaRangos = Servicios.Fachada.RangosHorariosOcupadosCampaña((RangoFecha)e.Argument);
            }
            e.Result = listaRangos;
        }

        /// <summary>
        /// Evento que surge cuando el backGrounWorker termina su trabajo
        /// </summary>
        /// <param name="sender">Objeto que  envía el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private void backgroundWorker_ObtenerRangosHorariosFecha_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                DialogResult result = MessageBox.Show("Ha ocurrido un error al tratar de cargar los datos\n" +
                                                       "¿Desea reintentarlo o cancelar y salir?", "Atención",
                                                       MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning,
                                                       MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Retry)
                {
                    this.backgroundWorker_ObtenerRangosHorariosFecha.RunWorkerAsync(this.iRangoFecha);
                }
                else
                {
                    this.iCerrar = false;
                    this.Close();
                }
            }
            else if (!e.Cancelled)
            {
                List<RangoHorario> listaAuxiliar = (List<RangoHorario>)e.Result;
                this.ArrayRangosHorarios(listaAuxiliar, this.iBoolArrayDisponibles, false);
                this.BoolArrayADGV();
                this.ActivarAceptar();
                this.dataGridView_Horarios.Enabled = true;
                this.dataGridView_Horarios.SelectionChanged += new System.EventHandler(this.dataGridView_Horarios_SelectionChanged);
            }
        }
        #endregion

        #region Comparador
        /// <summary>
        /// Clase responsable de comparar dos fechas de rangos Horarios
        /// </summary>
        private class ComparadorRHPorHoraInicio : IComparer<RangoHorario>
        {
            /// <summary>
            /// Compara dos instancias de Rangos Hararios
            /// </summary>
            /// <param name="x">Primer Rango Horario</param>
            /// <param name="y">Segundo Rango Horario</param>
            /// <returns>Tipo de dato int que representa la comparación entre rangos horarios</returns>
            public int Compare(RangoHorario x, RangoHorario y)
            {
                return x.HoraInicio.CompareTo(y.HoraInicio);
            }
        }
        #endregion
    }
}
