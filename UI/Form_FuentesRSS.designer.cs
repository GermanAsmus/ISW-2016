namespace UI
{
    partial class Form_FuentesRSS
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
            this.button_Nuevo = new System.Windows.Forms.Button();
            this.label_URL = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label_Descripcion = new System.Windows.Forms.Label();
            this.textBox_URL = new System.Windows.Forms.TextBox();
            this.textBox_Descripcion = new System.Windows.Forms.TextBox();
            this.button_Modificar = new System.Windows.Forms.Button();
            this.button_Eliminar = new System.Windows.Forms.Button();
            this.button_Volver = new System.Windows.Forms.Button();
            this.button_Aceptar = new System.Windows.Forms.Button();
            this.backgroundWorker_Fuentes = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_ObtenerRSS = new System.ComponentModel.BackgroundWorker();
            this.label_Información = new System.Windows.Forms.Label();
            this.pictureBox_ComprobacionURL = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox_ComprobacionDescripcion = new System.Windows.Forms.PictureBox();
            this.label_ComprobacionURL = new System.Windows.Forms.Label();
            this.label_ComprobacionDescripcion = new System.Windows.Forms.Label();
            this.button_Agregar = new System.Windows.Forms.Button();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.backgroundWorker_FuenteRSSSeleccion = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_ValorRSS = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ComprobacionURL)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ComprobacionDescripcion)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Nuevo
            // 
            this.button_Nuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Nuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button_Nuevo.Location = new System.Drawing.Point(436, 28);
            this.button_Nuevo.Name = "button_Nuevo";
            this.button_Nuevo.Size = new System.Drawing.Size(82, 31);
            this.button_Nuevo.TabIndex = 3;
            this.button_Nuevo.Text = "&Nuevo";
            this.button_Nuevo.UseVisualStyleBackColor = true;
            this.button_Nuevo.Click += new System.EventHandler(this.button_Nuevo_Click);
            // 
            // label_URL
            // 
            this.label_URL.AutoSize = true;
            this.label_URL.Enabled = false;
            this.label_URL.Location = new System.Drawing.Point(57, 16);
            this.label_URL.Name = "label_URL";
            this.label_URL.Size = new System.Drawing.Size(32, 13);
            this.label_URL.TabIndex = 4;
            this.label_URL.Text = "&URL:";
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(1, 65);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(722, 283);
            this.dataGridView.TabIndex = 5;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // label_Descripcion
            // 
            this.label_Descripcion.AutoSize = true;
            this.label_Descripcion.Enabled = false;
            this.label_Descripcion.Location = new System.Drawing.Point(23, 42);
            this.label_Descripcion.Name = "label_Descripcion";
            this.label_Descripcion.Size = new System.Drawing.Size(66, 13);
            this.label_Descripcion.TabIndex = 6;
            this.label_Descripcion.Text = "&Descripción:";
            // 
            // textBox_URL
            // 
            this.textBox_URL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_URL.Location = new System.Drawing.Point(104, 13);
            this.textBox_URL.Name = "textBox_URL";
            this.textBox_URL.Size = new System.Drawing.Size(300, 20);
            this.textBox_URL.TabIndex = 5;
            this.textBox_URL.Leave += new System.EventHandler(this.textBox_URL_Leave);
            // 
            // textBox_Descripcion
            // 
            this.textBox_Descripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Descripcion.Location = new System.Drawing.Point(104, 39);
            this.textBox_Descripcion.Name = "textBox_Descripcion";
            this.textBox_Descripcion.Size = new System.Drawing.Size(300, 20);
            this.textBox_Descripcion.TabIndex = 7;
            this.textBox_Descripcion.Leave += new System.EventHandler(this.textBox_Descripcion_Leave);
            // 
            // button_Modificar
            // 
            this.button_Modificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Modificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button_Modificar.Location = new System.Drawing.Point(536, 28);
            this.button_Modificar.Name = "button_Modificar";
            this.button_Modificar.Size = new System.Drawing.Size(82, 31);
            this.button_Modificar.TabIndex = 9;
            this.button_Modificar.Text = "&Modificar";
            this.button_Modificar.UseVisualStyleBackColor = true;
            this.button_Modificar.Click += new System.EventHandler(this.button_Modificar_Click);
            // 
            // button_Eliminar
            // 
            this.button_Eliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Eliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button_Eliminar.Location = new System.Drawing.Point(636, 28);
            this.button_Eliminar.Name = "button_Eliminar";
            this.button_Eliminar.Size = new System.Drawing.Size(82, 31);
            this.button_Eliminar.TabIndex = 10;
            this.button_Eliminar.Text = "&Eliminar";
            this.button_Eliminar.UseVisualStyleBackColor = true;
            this.button_Eliminar.Click += new System.EventHandler(this.button_Eliminar_Click);
            this.button_Eliminar.MouseLeave += new System.EventHandler(this.button_Eliminar_MouseLeave);
            this.button_Eliminar.MouseHover += new System.EventHandler(this.button_Eliminar_MouseHover);
            // 
            // button_Volver
            // 
            this.button_Volver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Volver.Location = new System.Drawing.Point(636, 354);
            this.button_Volver.Name = "button_Volver";
            this.button_Volver.Size = new System.Drawing.Size(82, 31);
            this.button_Volver.TabIndex = 11;
            this.button_Volver.Text = "&Volver";
            this.button_Volver.UseVisualStyleBackColor = true;
            this.button_Volver.Click += new System.EventHandler(this.button_Volver_Click);
            // 
            // button_Aceptar
            // 
            this.button_Aceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Aceptar.Location = new System.Drawing.Point(536, 354);
            this.button_Aceptar.Name = "button_Aceptar";
            this.button_Aceptar.Size = new System.Drawing.Size(82, 31);
            this.button_Aceptar.TabIndex = 12;
            this.button_Aceptar.Text = "&Aceptar";
            this.button_Aceptar.UseVisualStyleBackColor = true;
            this.button_Aceptar.Click += new System.EventHandler(this.button_Aceptar_Click);
            // 
            // backgroundWorker_Fuentes
            // 
            this.backgroundWorker_Fuentes.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_Fuentes_DoWork);
            this.backgroundWorker_Fuentes.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_Fuentes_RunWorkerCompleted);
            // 
            // backgroundWorker_ObtenerRSS
            // 
            this.backgroundWorker_ObtenerRSS.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_ObtenerRSS_DoWork);
            this.backgroundWorker_ObtenerRSS.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_ObtenerRSS_RunWorkerCompleted);
            // 
            // label_Información
            // 
            this.label_Información.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Información.AutoSize = true;
            this.label_Información.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label_Información.ForeColor = System.Drawing.Color.Red;
            this.label_Información.Location = new System.Drawing.Point(412, 8);
            this.label_Información.Name = "label_Información";
            this.label_Información.Size = new System.Drawing.Size(309, 13);
            this.label_Información.TabIndex = 13;
            this.label_Información.Text = "*Al eliminar una fuente se eliminan todos los Banners asociados*";
            this.label_Información.Visible = false;
            // 
            // pictureBox_ComprobacionURL
            // 
            this.pictureBox_ComprobacionURL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_ComprobacionURL.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_ComprobacionURL.Name = "pictureBox_ComprobacionURL";
            this.pictureBox_ComprobacionURL.Size = new System.Drawing.Size(21, 22);
            this.pictureBox_ComprobacionURL.TabIndex = 5;
            this.pictureBox_ComprobacionURL.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox_ComprobacionDescripcion, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_ComprobacionURL, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox_ComprobacionURL, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_ComprobacionDescripcion, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 355);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(506, 28);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // pictureBox_ComprobacionDescripcion
            // 
            this.pictureBox_ComprobacionDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_ComprobacionDescripcion.Location = new System.Drawing.Point(256, 3);
            this.pictureBox_ComprobacionDescripcion.Name = "pictureBox_ComprobacionDescripcion";
            this.pictureBox_ComprobacionDescripcion.Size = new System.Drawing.Size(21, 22);
            this.pictureBox_ComprobacionDescripcion.TabIndex = 7;
            this.pictureBox_ComprobacionDescripcion.TabStop = false;
            // 
            // label_ComprobacionURL
            // 
            this.label_ComprobacionURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ComprobacionURL.AutoSize = true;
            this.label_ComprobacionURL.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ComprobacionURL.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label_ComprobacionURL.Location = new System.Drawing.Point(30, 0);
            this.label_ComprobacionURL.Name = "label_ComprobacionURL";
            this.label_ComprobacionURL.Size = new System.Drawing.Size(30, 28);
            this.label_ComprobacionURL.TabIndex = 8;
            this.label_ComprobacionURL.Text = "URL";
            this.label_ComprobacionURL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_ComprobacionDescripcion
            // 
            this.label_ComprobacionDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ComprobacionDescripcion.AutoSize = true;
            this.label_ComprobacionDescripcion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ComprobacionDescripcion.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label_ComprobacionDescripcion.Location = new System.Drawing.Point(283, 0);
            this.label_ComprobacionDescripcion.Name = "label_ComprobacionDescripcion";
            this.label_ComprobacionDescripcion.Size = new System.Drawing.Size(75, 28);
            this.label_ComprobacionDescripcion.TabIndex = 6;
            this.label_ComprobacionDescripcion.Text = "Descripción";
            this.label_ComprobacionDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_Agregar
            // 
            this.button_Agregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Agregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button_Agregar.Location = new System.Drawing.Point(436, 28);
            this.button_Agregar.Name = "button_Agregar";
            this.button_Agregar.Size = new System.Drawing.Size(82, 31);
            this.button_Agregar.TabIndex = 19;
            this.button_Agregar.Text = "A&gregar";
            this.button_Agregar.UseVisualStyleBackColor = true;
            this.button_Agregar.Visible = false;
            this.button_Agregar.Click += new System.EventHandler(this.button_Agregar_Click);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button_Cancelar.Location = new System.Drawing.Point(536, 28);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(82, 31);
            this.button_Cancelar.TabIndex = 20;
            this.button_Cancelar.Text = "&Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Visible = false;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // backgroundWorker_FuenteRSSSeleccion
            // 
            this.backgroundWorker_FuenteRSSSeleccion.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_FuenteRSSSeleccion_DoWork);
            this.backgroundWorker_FuenteRSSSeleccion.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_FuenteRSSSeleccion_RunWorkerCompleted);
            // 
            // backgroundWorker_ValorRSS
            // 
            this.backgroundWorker_ValorRSS.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_ValorRSS_DoWork);
            this.backgroundWorker_ValorRSS.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_ValorRSS_RunWorkerCompleted);
            // 
            // Form_FuentesRSS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 397);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label_Información);
            this.Controls.Add(this.button_Aceptar);
            this.Controls.Add(this.button_Volver);
            this.Controls.Add(this.button_Eliminar);
            this.Controls.Add(this.textBox_Descripcion);
            this.Controls.Add(this.textBox_URL);
            this.Controls.Add(this.label_Descripcion);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.label_URL);
            this.Controls.Add(this.button_Modificar);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Agregar);
            this.Controls.Add(this.button_Nuevo);
            this.MinimumSize = new System.Drawing.Size(740, 436);
            this.Name = "Form_FuentesRSS";
            this.Text = "Administrador de Fuentes RSS";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ComprobacionURL)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ComprobacionDescripcion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_Nuevo;
        private System.Windows.Forms.Label label_URL;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label_Descripcion;
        private System.Windows.Forms.TextBox textBox_URL;
        private System.Windows.Forms.TextBox textBox_Descripcion;
        private System.Windows.Forms.Button button_Modificar;
        private System.Windows.Forms.Button button_Eliminar;
        private System.Windows.Forms.Button button_Volver;
        private System.Windows.Forms.Button button_Aceptar;
        private System.ComponentModel.BackgroundWorker backgroundWorker_Fuentes;
        private System.ComponentModel.BackgroundWorker backgroundWorker_ObtenerRSS;
        private System.Windows.Forms.Label label_Información;
        private System.Windows.Forms.PictureBox pictureBox_ComprobacionURL;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_ComprobacionDescripcion;
        private System.Windows.Forms.PictureBox pictureBox_ComprobacionDescripcion;
        private System.Windows.Forms.Label label_ComprobacionURL;
        private System.Windows.Forms.Button button_Agregar;
        private System.Windows.Forms.Button button_Cancelar;
        private System.ComponentModel.BackgroundWorker backgroundWorker_FuenteRSSSeleccion;
        private System.ComponentModel.BackgroundWorker backgroundWorker_ValorRSS;
    }
}