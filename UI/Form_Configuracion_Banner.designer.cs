namespace UI
{
    partial class Form_Configuracion_Banner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Configuracion_Banner));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label_Banner = new System.Windows.Forms.Label();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.button_Aceptar = new System.Windows.Forms.Button();
            this.backgroundWorker_BotonAceptar = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel_Pictures = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox_ComprobacionRH = new System.Windows.Forms.PictureBox();
            this.pictureBox_ComprobacionFuente = new System.Windows.Forms.PictureBox();
            this.pictureBox_ComprobacionNombre = new System.Windows.Forms.PictureBox();
            this.label_ComprobacionNombre = new System.Windows.Forms.Label();
            this.label_ComprobacionFuente = new System.Windows.Forms.Label();
            this.label_ComprobacionRangosFecha = new System.Windows.Forms.Label();
            this.label_ComprobacionRangoHorario = new System.Windows.Forms.Label();
            this.pictureBox_ComprobacionRF = new System.Windows.Forms.PictureBox();
            this.timer_Prueba = new System.Windows.Forms.Timer(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_ConfiguracionBasica = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel_Fuente = new System.Windows.Forms.TableLayoutPanel();
            this.comboBox_Fuente = new System.Windows.Forms.ComboBox();
            this.label_Fuente = new System.Windows.Forms.Label();
            this.label_Prueba = new System.Windows.Forms.Label();
            this.label_Nombre = new System.Windows.Forms.Label();
            this.textBox_Nombre = new System.Windows.Forms.TextBox();
            this.panel_Prueba = new System.Windows.Forms.Panel();
            this.label_ValorPrueba = new System.Windows.Forms.Label();
            this.tabPage_RangosHorarios = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel_RangosFecha = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox_RangoFecha = new System.Windows.Forms.GroupBox();
            this.button_EliminarFecha = new System.Windows.Forms.Button();
            this.button_AgregarFecha = new System.Windows.Forms.Button();
            this.dataGridView_Fecha = new System.Windows.Forms.DataGridView();
            this.dateTimePicker_RangoFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label_RangoFechaHasta = new System.Windows.Forms.Label();
            this.label_RangoFechaDesde = new System.Windows.Forms.Label();
            this.dateTimePicker_RangoFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.groupBox_RangoHorario = new System.Windows.Forms.GroupBox();
            this.button_AgregarHora = new System.Windows.Forms.Button();
            this.dataGridView_Hora = new System.Windows.Forms.DataGridView();
            this.backgroundWorker_RSS = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel_Pictures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ComprobacionRH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ComprobacionFuente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ComprobacionNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ComprobacionRF)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage_ConfiguracionBasica.SuspendLayout();
            this.panel_Prueba.SuspendLayout();
            this.tabPage_RangosHorarios.SuspendLayout();
            this.tableLayoutPanel_RangosFecha.SuspendLayout();
            this.groupBox_RangoFecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Fecha)).BeginInit();
            this.groupBox_RangoHorario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Hora)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Banner
            // 
            this.label_Banner.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_Banner.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label_Banner.Location = new System.Drawing.Point(0, 0);
            this.label_Banner.Name = "label_Banner";
            this.label_Banner.Size = new System.Drawing.Size(743, 49);
            this.label_Banner.TabIndex = 4;
            this.label_Banner.Text = "Banner";
            this.label_Banner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.AccessibleDescription = "";
            this.button_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.button_Cancelar.Location = new System.Drawing.Point(640, 455);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(93, 43);
            this.button_Cancelar.TabIndex = 14;
            this.button_Cancelar.Text = "&Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // button_Aceptar
            // 
            this.button_Aceptar.AccessibleDescription = "Guarda datos";
            this.button_Aceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Aceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.button_Aceptar.Location = new System.Drawing.Point(533, 455);
            this.button_Aceptar.Name = "button_Aceptar";
            this.button_Aceptar.Size = new System.Drawing.Size(93, 43);
            this.button_Aceptar.TabIndex = 13;
            this.button_Aceptar.Text = "&Aceptar";
            this.button_Aceptar.UseVisualStyleBackColor = true;
            this.button_Aceptar.Click += new System.EventHandler(this.button_Aceptar_Click);
            // 
            // backgroundWorker_BotonAceptar
            // 
            this.backgroundWorker_BotonAceptar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_BotonAceptar_DoWork);
            this.backgroundWorker_BotonAceptar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_BotonAceptar_RunWorkerCompleted);
            // 
            // tableLayoutPanel_Pictures
            // 
            this.tableLayoutPanel_Pictures.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel_Pictures.ColumnCount = 4;
            this.tableLayoutPanel_Pictures.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel_Pictures.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Pictures.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel_Pictures.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Pictures.Controls.Add(this.pictureBox_ComprobacionRH, 2, 1);
            this.tableLayoutPanel_Pictures.Controls.Add(this.pictureBox_ComprobacionFuente, 0, 1);
            this.tableLayoutPanel_Pictures.Controls.Add(this.pictureBox_ComprobacionNombre, 0, 0);
            this.tableLayoutPanel_Pictures.Controls.Add(this.label_ComprobacionNombre, 1, 0);
            this.tableLayoutPanel_Pictures.Controls.Add(this.label_ComprobacionFuente, 1, 1);
            this.tableLayoutPanel_Pictures.Controls.Add(this.label_ComprobacionRangosFecha, 3, 0);
            this.tableLayoutPanel_Pictures.Controls.Add(this.label_ComprobacionRangoHorario, 3, 1);
            this.tableLayoutPanel_Pictures.Controls.Add(this.pictureBox_ComprobacionRF, 2, 0);
            this.tableLayoutPanel_Pictures.Location = new System.Drawing.Point(6, 451);
            this.tableLayoutPanel_Pictures.Name = "tableLayoutPanel_Pictures";
            this.tableLayoutPanel_Pictures.RowCount = 2;
            this.tableLayoutPanel_Pictures.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Pictures.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Pictures.Size = new System.Drawing.Size(521, 56);
            this.tableLayoutPanel_Pictures.TabIndex = 10;
            // 
            // pictureBox_ComprobacionRH
            // 
            this.pictureBox_ComprobacionRH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_ComprobacionRH.Location = new System.Drawing.Point(263, 31);
            this.pictureBox_ComprobacionRH.Name = "pictureBox_ComprobacionRH";
            this.pictureBox_ComprobacionRH.Size = new System.Drawing.Size(21, 22);
            this.pictureBox_ComprobacionRH.TabIndex = 7;
            this.pictureBox_ComprobacionRH.TabStop = false;
            // 
            // pictureBox_ComprobacionFuente
            // 
            this.pictureBox_ComprobacionFuente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_ComprobacionFuente.Location = new System.Drawing.Point(3, 31);
            this.pictureBox_ComprobacionFuente.Name = "pictureBox_ComprobacionFuente";
            this.pictureBox_ComprobacionFuente.Size = new System.Drawing.Size(21, 22);
            this.pictureBox_ComprobacionFuente.TabIndex = 6;
            this.pictureBox_ComprobacionFuente.TabStop = false;
            // 
            // pictureBox_ComprobacionNombre
            // 
            this.pictureBox_ComprobacionNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_ComprobacionNombre.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_ComprobacionNombre.Name = "pictureBox_ComprobacionNombre";
            this.pictureBox_ComprobacionNombre.Size = new System.Drawing.Size(21, 22);
            this.pictureBox_ComprobacionNombre.TabIndex = 5;
            this.pictureBox_ComprobacionNombre.TabStop = false;
            // 
            // label_ComprobacionNombre
            // 
            this.label_ComprobacionNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ComprobacionNombre.AutoSize = true;
            this.label_ComprobacionNombre.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ComprobacionNombre.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label_ComprobacionNombre.Location = new System.Drawing.Point(30, 0);
            this.label_ComprobacionNombre.Name = "label_ComprobacionNombre";
            this.label_ComprobacionNombre.Size = new System.Drawing.Size(52, 28);
            this.label_ComprobacionNombre.TabIndex = 0;
            this.label_ComprobacionNombre.Text = "Nombre";
            this.label_ComprobacionNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_ComprobacionFuente
            // 
            this.label_ComprobacionFuente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ComprobacionFuente.AutoSize = true;
            this.label_ComprobacionFuente.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ComprobacionFuente.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label_ComprobacionFuente.Location = new System.Drawing.Point(30, 28);
            this.label_ComprobacionFuente.Name = "label_ComprobacionFuente";
            this.label_ComprobacionFuente.Size = new System.Drawing.Size(45, 28);
            this.label_ComprobacionFuente.TabIndex = 1;
            this.label_ComprobacionFuente.Text = "Fuente";
            this.label_ComprobacionFuente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_ComprobacionRangosFecha
            // 
            this.label_ComprobacionRangosFecha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ComprobacionRangosFecha.AutoSize = true;
            this.label_ComprobacionRangosFecha.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ComprobacionRangosFecha.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label_ComprobacionRangosFecha.Location = new System.Drawing.Point(290, 0);
            this.label_ComprobacionRangosFecha.Name = "label_ComprobacionRangosFecha";
            this.label_ComprobacionRangosFecha.Size = new System.Drawing.Size(87, 28);
            this.label_ComprobacionRangosFecha.TabIndex = 3;
            this.label_ComprobacionRangosFecha.Text = "Rangos Fecha";
            this.label_ComprobacionRangosFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_ComprobacionRangoHorario
            // 
            this.label_ComprobacionRangoHorario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ComprobacionRangoHorario.AutoSize = true;
            this.label_ComprobacionRangoHorario.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ComprobacionRangoHorario.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label_ComprobacionRangoHorario.Location = new System.Drawing.Point(290, 28);
            this.label_ComprobacionRangoHorario.Name = "label_ComprobacionRangoHorario";
            this.label_ComprobacionRangoHorario.Size = new System.Drawing.Size(102, 28);
            this.label_ComprobacionRangoHorario.TabIndex = 2;
            this.label_ComprobacionRangoHorario.Text = "Rangos Horarios";
            this.label_ComprobacionRangoHorario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox_ComprobacionRF
            // 
            this.pictureBox_ComprobacionRF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_ComprobacionRF.Location = new System.Drawing.Point(263, 3);
            this.pictureBox_ComprobacionRF.Name = "pictureBox_ComprobacionRF";
            this.pictureBox_ComprobacionRF.Size = new System.Drawing.Size(21, 22);
            this.pictureBox_ComprobacionRF.TabIndex = 4;
            this.pictureBox_ComprobacionRF.TabStop = false;
            // 
            // timer_Prueba
            // 
            this.timer_Prueba.Interval = 20;
            this.timer_Prueba.Tick += new System.EventHandler(this.timer_Prueba_Tick);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage_ConfiguracionBasica);
            this.tabControl.Controls.Add(this.tabPage_RangosHorarios);
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(1, 52);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(742, 393);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl.TabIndex = 18;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage_ConfiguracionBasica
            // 
            this.tabPage_ConfiguracionBasica.BackColor = System.Drawing.Color.White;
            this.tabPage_ConfiguracionBasica.Controls.Add(this.tableLayoutPanel_Fuente);
            this.tabPage_ConfiguracionBasica.Controls.Add(this.comboBox_Fuente);
            this.tabPage_ConfiguracionBasica.Controls.Add(this.label_Fuente);
            this.tabPage_ConfiguracionBasica.Controls.Add(this.label_Prueba);
            this.tabPage_ConfiguracionBasica.Controls.Add(this.label_Nombre);
            this.tabPage_ConfiguracionBasica.Controls.Add(this.textBox_Nombre);
            this.tabPage_ConfiguracionBasica.Controls.Add(this.panel_Prueba);
            this.tabPage_ConfiguracionBasica.Location = new System.Drawing.Point(4, 25);
            this.tabPage_ConfiguracionBasica.Name = "tabPage_ConfiguracionBasica";
            this.tabPage_ConfiguracionBasica.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ConfiguracionBasica.Size = new System.Drawing.Size(734, 364);
            this.tabPage_ConfiguracionBasica.TabIndex = 0;
            this.tabPage_ConfiguracionBasica.Text = "Configuración Básica";
            // 
            // tableLayoutPanel_Fuente
            // 
            this.tableLayoutPanel_Fuente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel_Fuente.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel_Fuente.ColumnCount = 1;
            this.tableLayoutPanel_Fuente.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Fuente.Location = new System.Drawing.Point(111, 122);
            this.tableLayoutPanel_Fuente.Name = "tableLayoutPanel_Fuente";
            this.tableLayoutPanel_Fuente.RowCount = 1;
            this.tableLayoutPanel_Fuente.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_Fuente.Size = new System.Drawing.Size(617, 183);
            this.tableLayoutPanel_Fuente.TabIndex = 21;
            // 
            // comboBox_Fuente
            // 
            this.comboBox_Fuente.FormattingEnabled = true;
            this.comboBox_Fuente.Location = new System.Drawing.Point(111, 79);
            this.comboBox_Fuente.Name = "comboBox_Fuente";
            this.comboBox_Fuente.Size = new System.Drawing.Size(282, 24);
            this.comboBox_Fuente.TabIndex = 20;
            this.comboBox_Fuente.SelectedIndexChanged += new System.EventHandler(this.comboBox_Fuente_SelectedIndexChanged);
            // 
            // label_Fuente
            // 
            this.label_Fuente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Fuente.AutoSize = true;
            this.label_Fuente.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label_Fuente.Location = new System.Drawing.Point(14, 79);
            this.label_Fuente.Name = "label_Fuente";
            this.label_Fuente.Size = new System.Drawing.Size(66, 22);
            this.label_Fuente.TabIndex = 2;
            this.label_Fuente.Text = "&Fuente";
            // 
            // label_Prueba
            // 
            this.label_Prueba.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Prueba.AutoSize = true;
            this.label_Prueba.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label_Prueba.Location = new System.Drawing.Point(14, 310);
            this.label_Prueba.Name = "label_Prueba";
            this.label_Prueba.Size = new System.Drawing.Size(68, 22);
            this.label_Prueba.TabIndex = 5;
            this.label_Prueba.Text = "Prueba";
            // 
            // label_Nombre
            // 
            this.label_Nombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Nombre.AutoSize = true;
            this.label_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label_Nombre.Location = new System.Drawing.Point(14, 21);
            this.label_Nombre.Name = "label_Nombre";
            this.label_Nombre.Size = new System.Drawing.Size(73, 22);
            this.label_Nombre.TabIndex = 0;
            this.label_Nombre.Text = "&Nombre";
            // 
            // textBox_Nombre
            // 
            this.textBox_Nombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Nombre.Location = new System.Drawing.Point(111, 21);
            this.textBox_Nombre.Name = "textBox_Nombre";
            this.textBox_Nombre.Size = new System.Drawing.Size(617, 26);
            this.textBox_Nombre.TabIndex = 1;
            this.textBox_Nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Nombre_KeyPress);
            this.textBox_Nombre.Leave += new System.EventHandler(this.textBox_Nombre_Leave);
            // 
            // panel_Prueba
            // 
            this.panel_Prueba.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Prueba.BackColor = System.Drawing.Color.LightGray;
            this.panel_Prueba.Controls.Add(this.label_ValorPrueba);
            this.panel_Prueba.Location = new System.Drawing.Point(18, 335);
            this.panel_Prueba.Name = "panel_Prueba";
            this.panel_Prueba.Size = new System.Drawing.Size(710, 24);
            this.panel_Prueba.TabIndex = 19;
            // 
            // label_ValorPrueba
            // 
            this.label_ValorPrueba.AutoSize = true;
            this.label_ValorPrueba.BackColor = System.Drawing.Color.Transparent;
            this.label_ValorPrueba.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ValorPrueba.Location = new System.Drawing.Point(3, 0);
            this.label_ValorPrueba.Name = "label_ValorPrueba";
            this.label_ValorPrueba.Size = new System.Drawing.Size(0, 20);
            this.label_ValorPrueba.TabIndex = 18;
            // 
            // tabPage_RangosHorarios
            // 
            this.tabPage_RangosHorarios.BackColor = System.Drawing.Color.White;
            this.tabPage_RangosHorarios.Controls.Add(this.tableLayoutPanel_RangosFecha);
            this.tabPage_RangosHorarios.Location = new System.Drawing.Point(4, 25);
            this.tabPage_RangosHorarios.Name = "tabPage_RangosHorarios";
            this.tabPage_RangosHorarios.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_RangosHorarios.Size = new System.Drawing.Size(734, 364);
            this.tabPage_RangosHorarios.TabIndex = 1;
            this.tabPage_RangosHorarios.Text = "Rangos horarios";
            // 
            // tableLayoutPanel_RangosFecha
            // 
            this.tableLayoutPanel_RangosFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel_RangosFecha.AutoSize = true;
            this.tableLayoutPanel_RangosFecha.ColumnCount = 2;
            this.tableLayoutPanel_RangosFecha.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.34506F));
            this.tableLayoutPanel_RangosFecha.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.65494F));
            this.tableLayoutPanel_RangosFecha.Controls.Add(this.groupBox_RangoFecha, 0, 0);
            this.tableLayoutPanel_RangosFecha.Controls.Add(this.groupBox_RangoHorario, 1, 0);
            this.tableLayoutPanel_RangosFecha.Location = new System.Drawing.Point(-4, 0);
            this.tableLayoutPanel_RangosFecha.Name = "tableLayoutPanel_RangosFecha";
            this.tableLayoutPanel_RangosFecha.RowCount = 1;
            this.tableLayoutPanel_RangosFecha.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_RangosFecha.Size = new System.Drawing.Size(739, 368);
            this.tableLayoutPanel_RangosFecha.TabIndex = 21;
            // 
            // groupBox_RangoFecha
            // 
            this.groupBox_RangoFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_RangoFecha.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox_RangoFecha.Controls.Add(this.button_EliminarFecha);
            this.groupBox_RangoFecha.Controls.Add(this.button_AgregarFecha);
            this.groupBox_RangoFecha.Controls.Add(this.dataGridView_Fecha);
            this.groupBox_RangoFecha.Controls.Add(this.dateTimePicker_RangoFechaHasta);
            this.groupBox_RangoFecha.Controls.Add(this.label_RangoFechaHasta);
            this.groupBox_RangoFecha.Controls.Add(this.label_RangoFechaDesde);
            this.groupBox_RangoFecha.Controls.Add(this.dateTimePicker_RangoFechaDesde);
            this.groupBox_RangoFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_RangoFecha.Location = new System.Drawing.Point(3, 3);
            this.groupBox_RangoFecha.Name = "groupBox_RangoFecha";
            this.groupBox_RangoFecha.Size = new System.Drawing.Size(402, 362);
            this.groupBox_RangoFecha.TabIndex = 22;
            this.groupBox_RangoFecha.TabStop = false;
            this.groupBox_RangoFecha.Text = "Rango de Fechas";
            // 
            // button_EliminarFecha
            // 
            this.button_EliminarFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_EliminarFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button_EliminarFecha.Image = ((System.Drawing.Image)(resources.GetObject("button_EliminarFecha.Image")));
            this.button_EliminarFecha.Location = new System.Drawing.Point(371, 112);
            this.button_EliminarFecha.Name = "button_EliminarFecha";
            this.button_EliminarFecha.Size = new System.Drawing.Size(25, 23);
            this.button_EliminarFecha.TabIndex = 6;
            this.button_EliminarFecha.UseVisualStyleBackColor = true;
            this.button_EliminarFecha.Click += new System.EventHandler(this.button_EliminarFecha_Click);
            // 
            // button_AgregarFecha
            // 
            this.button_AgregarFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_AgregarFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button_AgregarFecha.Image = ((System.Drawing.Image)(resources.GetObject("button_AgregarFecha.Image")));
            this.button_AgregarFecha.Location = new System.Drawing.Point(340, 112);
            this.button_AgregarFecha.Name = "button_AgregarFecha";
            this.button_AgregarFecha.Size = new System.Drawing.Size(25, 23);
            this.button_AgregarFecha.TabIndex = 5;
            this.button_AgregarFecha.UseVisualStyleBackColor = true;
            this.button_AgregarFecha.Click += new System.EventHandler(this.button_AgregarFecha_Click);
            // 
            // dataGridView_Fecha
            // 
            this.dataGridView_Fecha.AllowUserToDeleteRows = false;
            this.dataGridView_Fecha.AllowUserToResizeRows = false;
            this.dataGridView_Fecha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Fecha.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Fecha.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView_Fecha.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView_Fecha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.Format = "D";
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Fecha.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView_Fecha.EnableHeadersVisualStyles = false;
            this.dataGridView_Fecha.Location = new System.Drawing.Point(3, 141);
            this.dataGridView_Fecha.MultiSelect = false;
            this.dataGridView_Fecha.Name = "dataGridView_Fecha";
            this.dataGridView_Fecha.ReadOnly = true;
            this.dataGridView_Fecha.RowHeadersVisible = false;
            dataGridViewCellStyle8.Format = "d";
            dataGridViewCellStyle8.NullValue = null;
            this.dataGridView_Fecha.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView_Fecha.RowTemplate.DefaultCellStyle.Format = "D";
            this.dataGridView_Fecha.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_Fecha.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Fecha.Size = new System.Drawing.Size(393, 215);
            this.dataGridView_Fecha.TabIndex = 15;
            this.dataGridView_Fecha.TabStop = false;
            this.dataGridView_Fecha.SelectionChanged += new System.EventHandler(this.dataGridView_Fecha_SelectionChanged);
            // 
            // dateTimePicker_RangoFechaHasta
            // 
            this.dateTimePicker_RangoFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_RangoFechaHasta.Location = new System.Drawing.Point(108, 74);
            this.dateTimePicker_RangoFechaHasta.Name = "dateTimePicker_RangoFechaHasta";
            this.dateTimePicker_RangoFechaHasta.Size = new System.Drawing.Size(252, 22);
            this.dateTimePicker_RangoFechaHasta.TabIndex = 4;
            // 
            // label_RangoFechaHasta
            // 
            this.label_RangoFechaHasta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_RangoFechaHasta.AutoSize = true;
            this.label_RangoFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_RangoFechaHasta.Location = new System.Drawing.Point(36, 77);
            this.label_RangoFechaHasta.Name = "label_RangoFechaHasta";
            this.label_RangoFechaHasta.Size = new System.Drawing.Size(44, 16);
            this.label_RangoFechaHasta.TabIndex = 3;
            this.label_RangoFechaHasta.Text = "&Hasta";
            // 
            // label_RangoFechaDesde
            // 
            this.label_RangoFechaDesde.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_RangoFechaDesde.AutoSize = true;
            this.label_RangoFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_RangoFechaDesde.Location = new System.Drawing.Point(36, 40);
            this.label_RangoFechaDesde.Name = "label_RangoFechaDesde";
            this.label_RangoFechaDesde.Size = new System.Drawing.Size(49, 16);
            this.label_RangoFechaDesde.TabIndex = 1;
            this.label_RangoFechaDesde.Text = "&Desde";
            // 
            // dateTimePicker_RangoFechaDesde
            // 
            this.dateTimePicker_RangoFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_RangoFechaDesde.Location = new System.Drawing.Point(108, 37);
            this.dateTimePicker_RangoFechaDesde.Name = "dateTimePicker_RangoFechaDesde";
            this.dateTimePicker_RangoFechaDesde.Size = new System.Drawing.Size(252, 22);
            this.dateTimePicker_RangoFechaDesde.TabIndex = 2;
            // 
            // groupBox_RangoHorario
            // 
            this.groupBox_RangoHorario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_RangoHorario.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox_RangoHorario.Controls.Add(this.button_AgregarHora);
            this.groupBox_RangoHorario.Controls.Add(this.dataGridView_Hora);
            this.groupBox_RangoHorario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_RangoHorario.Location = new System.Drawing.Point(411, 3);
            this.groupBox_RangoHorario.Name = "groupBox_RangoHorario";
            this.groupBox_RangoHorario.Size = new System.Drawing.Size(325, 362);
            this.groupBox_RangoHorario.TabIndex = 21;
            this.groupBox_RangoHorario.TabStop = false;
            this.groupBox_RangoHorario.Text = "Rango Horario";
            // 
            // button_AgregarHora
            // 
            this.button_AgregarHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_AgregarHora.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_AgregarHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button_AgregarHora.Image = global::UI.Properties.Resources.Modificar;
            this.button_AgregarHora.Location = new System.Drawing.Point(294, 20);
            this.button_AgregarHora.Name = "button_AgregarHora";
            this.button_AgregarHora.Size = new System.Drawing.Size(25, 23);
            this.button_AgregarHora.TabIndex = 11;
            this.button_AgregarHora.UseVisualStyleBackColor = true;
            this.button_AgregarHora.Click += new System.EventHandler(this.button_AgregarHora_Click);
            // 
            // dataGridView_Hora
            // 
            this.dataGridView_Hora.AllowUserToAddRows = false;
            this.dataGridView_Hora.AllowUserToDeleteRows = false;
            this.dataGridView_Hora.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Hora.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Hora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Hora.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.Format = "T";
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Hora.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView_Hora.EnableHeadersVisualStyles = false;
            this.dataGridView_Hora.Location = new System.Drawing.Point(4, 49);
            this.dataGridView_Hora.Name = "dataGridView_Hora";
            this.dataGridView_Hora.ReadOnly = true;
            this.dataGridView_Hora.RowHeadersVisible = false;
            this.dataGridView_Hora.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Hora.Size = new System.Drawing.Size(316, 307);
            this.dataGridView_Hora.TabIndex = 16;
            // 
            // backgroundWorker_RSS
            // 
            this.backgroundWorker_RSS.WorkerSupportsCancellation = true;
            this.backgroundWorker_RSS.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_RSS_DoWork);
            this.backgroundWorker_RSS.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RSS_RunWorkerCompleted);
            // 
            // Form_Configuracion_Banner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 510);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.tableLayoutPanel_Pictures);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Aceptar);
            this.Controls.Add(this.label_Banner);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(659, 509);
            this.Name = "Form_Configuracion_Banner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurar Banner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Configuracion_FormClosing);
            this.tableLayoutPanel_Pictures.ResumeLayout(false);
            this.tableLayoutPanel_Pictures.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ComprobacionRH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ComprobacionFuente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ComprobacionNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ComprobacionRF)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage_ConfiguracionBasica.ResumeLayout(false);
            this.tabPage_ConfiguracionBasica.PerformLayout();
            this.panel_Prueba.ResumeLayout(false);
            this.panel_Prueba.PerformLayout();
            this.tabPage_RangosHorarios.ResumeLayout(false);
            this.tabPage_RangosHorarios.PerformLayout();
            this.tableLayoutPanel_RangosFecha.ResumeLayout(false);
            this.groupBox_RangoFecha.ResumeLayout(false);
            this.groupBox_RangoFecha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Fecha)).EndInit();
            this.groupBox_RangoHorario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Hora)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label_Banner;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Button button_Aceptar;
        private System.ComponentModel.BackgroundWorker backgroundWorker_BotonAceptar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Pictures;
        private System.Windows.Forms.Label label_ComprobacionRangosFecha;
        private System.Windows.Forms.Label label_ComprobacionFuente;
        private System.Windows.Forms.Label label_ComprobacionNombre;
        private System.Windows.Forms.Label label_ComprobacionRangoHorario;
        private System.Windows.Forms.PictureBox pictureBox_ComprobacionRH;
        private System.Windows.Forms.PictureBox pictureBox_ComprobacionFuente;
        private System.Windows.Forms.PictureBox pictureBox_ComprobacionRF;
        private System.Windows.Forms.PictureBox pictureBox_ComprobacionNombre;
        private System.Windows.Forms.Timer timer_Prueba;
        private System.Windows.Forms.Label label_Fuente;
        private System.Windows.Forms.Label label_Prueba;
        private System.Windows.Forms.TextBox textBox_Nombre;
        private System.Windows.Forms.Panel panel_Prueba;
        private System.Windows.Forms.Label label_ValorPrueba;
        private System.Windows.Forms.DataGridView dataGridView_Hora;
        private System.Windows.Forms.GroupBox groupBox_RangoHorario;
        private System.Windows.Forms.DateTimePicker dateTimePicker_RangoFechaDesde;
        private System.Windows.Forms.Label label_RangoFechaDesde;
        private System.Windows.Forms.Label label_RangoFechaHasta;
        private System.Windows.Forms.DateTimePicker dateTimePicker_RangoFechaHasta;
        private System.Windows.Forms.DataGridView dataGridView_Fecha;
        private System.Windows.Forms.Button button_AgregarFecha;
        private System.Windows.Forms.Button button_EliminarFecha;
        private System.Windows.Forms.GroupBox groupBox_RangoFecha;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_RangosFecha;
        private System.Windows.Forms.TabPage tabPage_RangosHorarios;
        private System.Windows.Forms.Label label_Nombre;
        private System.Windows.Forms.TabPage tabPage_ConfiguracionBasica;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button button_AgregarHora;
        private System.ComponentModel.BackgroundWorker backgroundWorker_RSS;
        private System.Windows.Forms.ComboBox comboBox_Fuente;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Fuente;
    }
}