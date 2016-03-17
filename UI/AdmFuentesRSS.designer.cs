namespace UI
{
    partial class AdmFuentesRSS
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
            this.button_Agregar = new System.Windows.Forms.Button();
            this.label_URL = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label_Descripcion = new System.Windows.Forms.Label();
            this.textBox_URL = new System.Windows.Forms.TextBox();
            this.textBox_Descripcion = new System.Windows.Forms.TextBox();
            this.button_Modificar = new System.Windows.Forms.Button();
            this.button_Eliminar = new System.Windows.Forms.Button();
            this.button_Volver = new System.Windows.Forms.Button();
            this.button_Aceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Agregar
            // 
            this.button_Agregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Agregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button_Agregar.Location = new System.Drawing.Point(436, 28);
            this.button_Agregar.Name = "button_Agregar";
            this.button_Agregar.Size = new System.Drawing.Size(82, 31);
            this.button_Agregar.TabIndex = 3;
            this.button_Agregar.Text = "A&gregar";
            this.button_Agregar.UseVisualStyleBackColor = true;
            this.button_Agregar.Click += new System.EventHandler(this.button_Agregar_Click);
            // 
            // label_URL
            // 
            this.label_URL.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_URL.AutoSize = true;
            this.label_URL.Location = new System.Drawing.Point(57, 16);
            this.label_URL.Name = "label_URL";
            this.label_URL.Size = new System.Drawing.Size(32, 13);
            this.label_URL.TabIndex = 4;
            this.label_URL.Text = "&URL:";
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(1, 65);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(722, 283);
            this.dataGridView.TabIndex = 5;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // label_Descripcion
            // 
            this.label_Descripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_Descripcion.AutoSize = true;
            this.label_Descripcion.Location = new System.Drawing.Point(23, 42);
            this.label_Descripcion.Name = "label_Descripcion";
            this.label_Descripcion.Size = new System.Drawing.Size(66, 13);
            this.label_Descripcion.TabIndex = 6;
            this.label_Descripcion.Text = "&Descripción:";
            // 
            // textBox_URL
            // 
            this.textBox_URL.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_URL.Location = new System.Drawing.Point(104, 13);
            this.textBox_URL.Name = "textBox_URL";
            this.textBox_URL.Size = new System.Drawing.Size(300, 20);
            this.textBox_URL.TabIndex = 5;
            // 
            // textBox_Descripcion
            // 
            this.textBox_Descripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_Descripcion.Location = new System.Drawing.Point(104, 39);
            this.textBox_Descripcion.Name = "textBox_Descripcion";
            this.textBox_Descripcion.Size = new System.Drawing.Size(300, 20);
            this.textBox_Descripcion.TabIndex = 7;
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
            // AdmFuentesRSS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 397);
            this.Controls.Add(this.button_Aceptar);
            this.Controls.Add(this.button_Volver);
            this.Controls.Add(this.button_Eliminar);
            this.Controls.Add(this.button_Modificar);
            this.Controls.Add(this.textBox_Descripcion);
            this.Controls.Add(this.textBox_URL);
            this.Controls.Add(this.label_Descripcion);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.label_URL);
            this.Controls.Add(this.button_Agregar);
            this.MinimumSize = new System.Drawing.Size(740, 436);
            this.Name = "AdmFuentesRSS";
            this.Text = "Administrador de Fuentes RSS";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_Agregar;
        private System.Windows.Forms.Label label_URL;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label_Descripcion;
        private System.Windows.Forms.TextBox textBox_URL;
        private System.Windows.Forms.TextBox textBox_Descripcion;
        private System.Windows.Forms.Button button_Modificar;
        private System.Windows.Forms.Button button_Eliminar;
        private System.Windows.Forms.Button button_Volver;
        private System.Windows.Forms.Button button_Aceptar;
    }
}