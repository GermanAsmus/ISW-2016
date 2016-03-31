namespace UI
{
    partial class Form_Banner
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Banner));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.button_Agregar = new System.Windows.Forms.Button();
            this.button_Eliminar = new System.Windows.Forms.Button();
            this.label_Banner = new System.Windows.Forms.Label();
            this.button_Modificar = new System.Windows.Forms.Button();
            this.backgroundWorker_Obtener = new System.ComponentModel.BackgroundWorker();
            this.button_Busqueda = new System.Windows.Forms.Button();
            this.button_regresar = new System.Windows.Forms.Button();
            this.tableLayoutPanel_Banner = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox_Filtro = new System.Windows.Forms.GroupBox();
            this.pictureBox_Hasta = new System.Windows.Forms.PictureBox();
            this.pictureBox_Desde = new System.Windows.Forms.PictureBox();
            this.pictureBox_Tipo = new System.Windows.Forms.PictureBox();
            this.pictureBox_Nombre = new System.Windows.Forms.PictureBox();
            this.dateTimePicker_FechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_FechaDesde = new System.Windows.Forms.DateTimePicker();
            this.label_Hasta = new System.Windows.Forms.Label();
            this.label_Desde = new System.Windows.Forms.Label();
            this.radioButton_RSS = new System.Windows.Forms.RadioButton();
            this.radioButton_Texto = new System.Windows.Forms.RadioButton();
            this.checkBox_RangoFechas = new System.Windows.Forms.CheckBox();
            this.textBox_Nombre = new System.Windows.Forms.TextBox();
            this.checkBox_Tipo = new System.Windows.Forms.CheckBox();
            this.checkBox_Nombre = new System.Windows.Forms.CheckBox();
            this.button_Mostrar = new System.Windows.Forms.Button();
            this.backgroundWorker_Eliminar = new System.ComponentModel.BackgroundWorker();
            this.label_Operacion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tableLayoutPanel_Banner.SuspendLayout();
            this.groupBox_Filtro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Hasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Desde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Tipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Nombre)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(326, 3);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(479, 251);
            this.dataGridView.TabIndex = 2;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // button_Agregar
            // 
            this.button_Agregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Agregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Agregar.Location = new System.Drawing.Point(532, 51);
            this.button_Agregar.Name = "button_Agregar";
            this.button_Agregar.Size = new System.Drawing.Size(82, 31);
            this.button_Agregar.TabIndex = 0;
            this.button_Agregar.Text = "&Agregar";
            this.button_Agregar.UseVisualStyleBackColor = true;
            this.button_Agregar.Click += new System.EventHandler(this.button_Agregar_Click);
            // 
            // button_Eliminar
            // 
            this.button_Eliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Eliminar.Enabled = false;
            this.button_Eliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Eliminar.Location = new System.Drawing.Point(718, 51);
            this.button_Eliminar.Name = "button_Eliminar";
            this.button_Eliminar.Size = new System.Drawing.Size(82, 31);
            this.button_Eliminar.TabIndex = 2;
            this.button_Eliminar.Text = "&Eliminar";
            this.button_Eliminar.UseVisualStyleBackColor = true;
            this.button_Eliminar.Click += new System.EventHandler(this.button_Eliminar_Click);
            // 
            // label_Banner
            // 
            this.label_Banner.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_Banner.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label_Banner.Location = new System.Drawing.Point(0, -2);
            this.label_Banner.Name = "label_Banner";
            this.label_Banner.Size = new System.Drawing.Size(808, 49);
            this.label_Banner.TabIndex = 6;
            this.label_Banner.Text = "Banner";
            this.label_Banner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_Modificar
            // 
            this.button_Modificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Modificar.Enabled = false;
            this.button_Modificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Modificar.Location = new System.Drawing.Point(625, 51);
            this.button_Modificar.Name = "button_Modificar";
            this.button_Modificar.Size = new System.Drawing.Size(82, 31);
            this.button_Modificar.TabIndex = 1;
            this.button_Modificar.Text = "&Modificar";
            this.button_Modificar.UseVisualStyleBackColor = true;
            this.button_Modificar.Click += new System.EventHandler(this.button_Modificar_Click);
            // 
            // backgroundWorker_Obtener
            // 
            this.backgroundWorker_Obtener.WorkerSupportsCancellation = true;
            this.backgroundWorker_Obtener.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_Obtener_DoWork);
            this.backgroundWorker_Obtener.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_Obtener_RunWorkerCompleted);
            // 
            // button_Busqueda
            // 
            this.button_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Busqueda.Image = ((System.Drawing.Image)(resources.GetObject("button_Busqueda.Image")));
            this.button_Busqueda.Location = new System.Drawing.Point(280, 217);
            this.button_Busqueda.Name = "button_Busqueda";
            this.button_Busqueda.Size = new System.Drawing.Size(31, 29);
            this.button_Busqueda.TabIndex = 15;
            this.button_Busqueda.UseVisualStyleBackColor = true;
            this.button_Busqueda.Click += new System.EventHandler(this.button_Busqueda_Click);
            // 
            // button_regresar
            // 
            this.button_regresar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_regresar.Location = new System.Drawing.Point(714, 354);
            this.button_regresar.Name = "button_regresar";
            this.button_regresar.Size = new System.Drawing.Size(82, 31);
            this.button_regresar.TabIndex = 16;
            this.button_regresar.Text = "&Volver";
            this.button_regresar.UseVisualStyleBackColor = true;
            this.button_regresar.Click += new System.EventHandler(this.button_Regresar_Click);
            // 
            // tableLayoutPanel_Banner
            // 
            this.tableLayoutPanel_Banner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel_Banner.AutoSize = true;
            this.tableLayoutPanel_Banner.ColumnCount = 2;
            this.tableLayoutPanel_Banner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_Banner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_Banner.Controls.Add(this.dataGridView, 1, 0);
            this.tableLayoutPanel_Banner.Controls.Add(this.groupBox_Filtro, 0, 0);
            this.tableLayoutPanel_Banner.Location = new System.Drawing.Point(0, 88);
            this.tableLayoutPanel_Banner.Name = "tableLayoutPanel_Banner";
            this.tableLayoutPanel_Banner.RowCount = 1;
            this.tableLayoutPanel_Banner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Banner.Size = new System.Drawing.Size(808, 257);
            this.tableLayoutPanel_Banner.TabIndex = 11;
            // 
            // groupBox_Filtro
            // 
            this.groupBox_Filtro.Controls.Add(this.pictureBox_Hasta);
            this.groupBox_Filtro.Controls.Add(this.pictureBox_Desde);
            this.groupBox_Filtro.Controls.Add(this.pictureBox_Tipo);
            this.groupBox_Filtro.Controls.Add(this.pictureBox_Nombre);
            this.groupBox_Filtro.Controls.Add(this.dateTimePicker_FechaHasta);
            this.groupBox_Filtro.Controls.Add(this.dateTimePicker_FechaDesde);
            this.groupBox_Filtro.Controls.Add(this.label_Hasta);
            this.groupBox_Filtro.Controls.Add(this.label_Desde);
            this.groupBox_Filtro.Controls.Add(this.radioButton_RSS);
            this.groupBox_Filtro.Controls.Add(this.radioButton_Texto);
            this.groupBox_Filtro.Controls.Add(this.checkBox_RangoFechas);
            this.groupBox_Filtro.Controls.Add(this.textBox_Nombre);
            this.groupBox_Filtro.Controls.Add(this.checkBox_Tipo);
            this.groupBox_Filtro.Controls.Add(this.checkBox_Nombre);
            this.groupBox_Filtro.Controls.Add(this.button_Busqueda);
            this.groupBox_Filtro.Location = new System.Drawing.Point(3, 3);
            this.groupBox_Filtro.Name = "groupBox_Filtro";
            this.groupBox_Filtro.Size = new System.Drawing.Size(317, 251);
            this.groupBox_Filtro.TabIndex = 3;
            this.groupBox_Filtro.TabStop = false;
            this.groupBox_Filtro.Text = "Filtros";
            // 
            // pictureBox_Hasta
            // 
            this.pictureBox_Hasta.Location = new System.Drawing.Point(297, 192);
            this.pictureBox_Hasta.Name = "pictureBox_Hasta";
            this.pictureBox_Hasta.Size = new System.Drawing.Size(17, 17);
            this.pictureBox_Hasta.TabIndex = 20;
            this.pictureBox_Hasta.TabStop = false;
            // 
            // pictureBox_Desde
            // 
            this.pictureBox_Desde.Location = new System.Drawing.Point(297, 158);
            this.pictureBox_Desde.Name = "pictureBox_Desde";
            this.pictureBox_Desde.Size = new System.Drawing.Size(17, 17);
            this.pictureBox_Desde.TabIndex = 19;
            this.pictureBox_Desde.TabStop = false;
            // 
            // pictureBox_Tipo
            // 
            this.pictureBox_Tipo.Location = new System.Drawing.Point(296, 94);
            this.pictureBox_Tipo.Name = "pictureBox_Tipo";
            this.pictureBox_Tipo.Size = new System.Drawing.Size(17, 17);
            this.pictureBox_Tipo.TabIndex = 18;
            this.pictureBox_Tipo.TabStop = false;
            // 
            // pictureBox_Nombre
            // 
            this.pictureBox_Nombre.Location = new System.Drawing.Point(297, 21);
            this.pictureBox_Nombre.Name = "pictureBox_Nombre";
            this.pictureBox_Nombre.Size = new System.Drawing.Size(17, 17);
            this.pictureBox_Nombre.TabIndex = 17;
            this.pictureBox_Nombre.TabStop = false;
            // 
            // dateTimePicker_FechaHasta
            // 
            this.dateTimePicker_FechaHasta.Location = new System.Drawing.Point(85, 190);
            this.dateTimePicker_FechaHasta.Name = "dateTimePicker_FechaHasta";
            this.dateTimePicker_FechaHasta.Size = new System.Drawing.Size(209, 20);
            this.dateTimePicker_FechaHasta.TabIndex = 14;
            this.dateTimePicker_FechaHasta.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // dateTimePicker_FechaDesde
            // 
            this.dateTimePicker_FechaDesde.Location = new System.Drawing.Point(85, 156);
            this.dateTimePicker_FechaDesde.Name = "dateTimePicker_FechaDesde";
            this.dateTimePicker_FechaDesde.Size = new System.Drawing.Size(209, 20);
            this.dateTimePicker_FechaDesde.TabIndex = 12;
            this.dateTimePicker_FechaDesde.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // label_Hasta
            // 
            this.label_Hasta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Hasta.AutoSize = true;
            this.label_Hasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Hasta.Location = new System.Drawing.Point(26, 193);
            this.label_Hasta.Name = "label_Hasta";
            this.label_Hasta.Size = new System.Drawing.Size(39, 15);
            this.label_Hasta.TabIndex = 13;
            this.label_Hasta.Text = "&Hasta";
            // 
            // label_Desde
            // 
            this.label_Desde.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Desde.AutoSize = true;
            this.label_Desde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Desde.Location = new System.Drawing.Point(26, 159);
            this.label_Desde.Name = "label_Desde";
            this.label_Desde.Size = new System.Drawing.Size(43, 15);
            this.label_Desde.TabIndex = 11;
            this.label_Desde.Text = "&Desde";
            // 
            // radioButton_RSS
            // 
            this.radioButton_RSS.AutoSize = true;
            this.radioButton_RSS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.radioButton_RSS.Location = new System.Drawing.Point(185, 93);
            this.radioButton_RSS.Name = "radioButton_RSS";
            this.radioButton_RSS.Size = new System.Drawing.Size(91, 19);
            this.radioButton_RSS.TabIndex = 8;
            this.radioButton_RSS.Text = "Fuente RSS";
            this.radioButton_RSS.UseVisualStyleBackColor = true;
            // 
            // radioButton_Texto
            // 
            this.radioButton_Texto.AutoSize = true;
            this.radioButton_Texto.Checked = true;
            this.radioButton_Texto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.radioButton_Texto.Location = new System.Drawing.Point(46, 93);
            this.radioButton_Texto.Name = "radioButton_Texto";
            this.radioButton_Texto.Size = new System.Drawing.Size(119, 19);
            this.radioButton_Texto.TabIndex = 7;
            this.radioButton_Texto.TabStop = true;
            this.radioButton_Texto.Text = "Fuente Texto Fijo";
            this.radioButton_Texto.UseVisualStyleBackColor = true;
            // 
            // checkBox_RangoFechas
            // 
            this.checkBox_RangoFechas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_RangoFechas.AutoSize = true;
            this.checkBox_RangoFechas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_RangoFechas.Location = new System.Drawing.Point(9, 127);
            this.checkBox_RangoFechas.Name = "checkBox_RangoFechas";
            this.checkBox_RangoFechas.Size = new System.Drawing.Size(109, 20);
            this.checkBox_RangoFechas.TabIndex = 10;
            this.checkBox_RangoFechas.Text = "&Rango Fecha";
            this.checkBox_RangoFechas.UseVisualStyleBackColor = true;
            this.checkBox_RangoFechas.CheckedChanged += new System.EventHandler(this.checkBox_RangoFechas_CheckedChanged);
            // 
            // textBox_Nombre
            // 
            this.textBox_Nombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Nombre.Location = new System.Drawing.Point(85, 18);
            this.textBox_Nombre.Name = "textBox_Nombre";
            this.textBox_Nombre.Size = new System.Drawing.Size(209, 22);
            this.textBox_Nombre.TabIndex = 5;
            this.textBox_Nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Nombre_KeyPress);
            this.textBox_Nombre.Leave += new System.EventHandler(this.textBox_Nombre_Leave);
            // 
            // checkBox_Tipo
            // 
            this.checkBox_Tipo.AutoSize = true;
            this.checkBox_Tipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Tipo.Location = new System.Drawing.Point(9, 59);
            this.checkBox_Tipo.Name = "checkBox_Tipo";
            this.checkBox_Tipo.Size = new System.Drawing.Size(55, 20);
            this.checkBox_Tipo.TabIndex = 6;
            this.checkBox_Tipo.Text = "&Tipo";
            this.checkBox_Tipo.UseVisualStyleBackColor = true;
            this.checkBox_Tipo.CheckedChanged += new System.EventHandler(this.checkBox_Tipo_CheckedChanged);
            // 
            // checkBox_Nombre
            // 
            this.checkBox_Nombre.AutoSize = true;
            this.checkBox_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Nombre.Location = new System.Drawing.Point(9, 19);
            this.checkBox_Nombre.Name = "checkBox_Nombre";
            this.checkBox_Nombre.Size = new System.Drawing.Size(76, 20);
            this.checkBox_Nombre.TabIndex = 4;
            this.checkBox_Nombre.Text = "&Nombre";
            this.checkBox_Nombre.UseVisualStyleBackColor = true;
            this.checkBox_Nombre.CheckedChanged += new System.EventHandler(this.checkBox_Nombre_CheckedChanged);
            // 
            // button_Mostrar
            // 
            this.button_Mostrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Mostrar.Location = new System.Drawing.Point(6, 51);
            this.button_Mostrar.MinimumSize = new System.Drawing.Size(104, 31);
            this.button_Mostrar.Name = "button_Mostrar";
            this.button_Mostrar.Size = new System.Drawing.Size(104, 31);
            this.button_Mostrar.TabIndex = 3;
            this.button_Mostrar.Text = "M&ostar Filtros";
            this.button_Mostrar.UseVisualStyleBackColor = true;
            this.button_Mostrar.Click += new System.EventHandler(this.button_Mostrar_Click);
            // 
            // backgroundWorker_Eliminar
            // 
            this.backgroundWorker_Eliminar.WorkerSupportsCancellation = true;
            this.backgroundWorker_Eliminar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_Eliminar_DoWork);
            this.backgroundWorker_Eliminar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_Eliminar_RunWorkerCompleted);
            // 
            // label_Operacion
            // 
            this.label_Operacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Operacion.AutoSize = true;
            this.label_Operacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Operacion.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label_Operacion.Location = new System.Drawing.Point(12, 373);
            this.label_Operacion.Name = "label_Operacion";
            this.label_Operacion.Size = new System.Drawing.Size(64, 15);
            this.label_Operacion.TabIndex = 18;
            this.label_Operacion.Text = "Operación";
            // 
            // Form_Banner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 397);
            this.Controls.Add(this.label_Operacion);
            this.Controls.Add(this.button_Mostrar);
            this.Controls.Add(this.tableLayoutPanel_Banner);
            this.Controls.Add(this.button_regresar);
            this.Controls.Add(this.button_Modificar);
            this.Controls.Add(this.label_Banner);
            this.Controls.Add(this.button_Eliminar);
            this.Controls.Add(this.button_Agregar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(618, 357);
            this.Name = "Form_Banner";
            this.Text = "Configurar Banner";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tableLayoutPanel_Banner.ResumeLayout(false);
            this.groupBox_Filtro.ResumeLayout(false);
            this.groupBox_Filtro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Hasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Desde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Tipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Nombre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button button_Agregar;
        private System.Windows.Forms.Button button_Eliminar;
        private System.Windows.Forms.Label label_Banner;
        private System.Windows.Forms.Button button_Busqueda;
        private System.Windows.Forms.Button button_Modificar;
        private System.ComponentModel.BackgroundWorker backgroundWorker_Obtener;
        private System.Windows.Forms.Button button_regresar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Banner;
        private System.Windows.Forms.GroupBox groupBox_Filtro;
        private System.Windows.Forms.Label label_Hasta;
        private System.Windows.Forms.Label label_Desde;
        private System.Windows.Forms.RadioButton radioButton_RSS;
        private System.Windows.Forms.RadioButton radioButton_Texto;
        private System.Windows.Forms.CheckBox checkBox_RangoFechas;
        private System.Windows.Forms.TextBox textBox_Nombre;
        private System.Windows.Forms.CheckBox checkBox_Tipo;
        private System.Windows.Forms.CheckBox checkBox_Nombre;
        private System.Windows.Forms.Button button_Mostrar;
        private System.ComponentModel.BackgroundWorker backgroundWorker_Eliminar;
        private System.Windows.Forms.DateTimePicker dateTimePicker_FechaHasta;
        private System.Windows.Forms.DateTimePicker dateTimePicker_FechaDesde;
        private System.Windows.Forms.PictureBox pictureBox_Hasta;
        private System.Windows.Forms.PictureBox pictureBox_Desde;
        private System.Windows.Forms.PictureBox pictureBox_Nombre;
        private System.Windows.Forms.PictureBox pictureBox_Tipo;
        private System.Windows.Forms.Label label_Operacion;
    }
}