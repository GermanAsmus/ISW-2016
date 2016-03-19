namespace UI
{
    partial class Form_FuenteTextoFijo
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
            this.button_Aceptar = new System.Windows.Forms.Button();
            this.button_Volver = new System.Windows.Forms.Button();
            this.textBox_ValorTextoFijo = new System.Windows.Forms.TextBox();
            this.label_IngresarValor = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_ComprobacionValorTF = new System.Windows.Forms.Label();
            this.pictureBox_ComprobacionValorTF = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ComprobacionValorTF)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Aceptar
            // 
            this.button_Aceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Aceptar.Location = new System.Drawing.Point(268, 200);
            this.button_Aceptar.Name = "button_Aceptar";
            this.button_Aceptar.Size = new System.Drawing.Size(82, 31);
            this.button_Aceptar.TabIndex = 3;
            this.button_Aceptar.Text = "&Aceptar";
            this.button_Aceptar.UseVisualStyleBackColor = true;
            this.button_Aceptar.Click += new System.EventHandler(this.button_Aceptar_Click);
            // 
            // button_Volver
            // 
            this.button_Volver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Volver.Location = new System.Drawing.Point(368, 200);
            this.button_Volver.Name = "button_Volver";
            this.button_Volver.Size = new System.Drawing.Size(82, 31);
            this.button_Volver.TabIndex = 4;
            this.button_Volver.Text = "&Volver";
            this.button_Volver.UseVisualStyleBackColor = true;
            this.button_Volver.Click += new System.EventHandler(this.button_Volver_Click);
            // 
            // textBox_ValorTextoFijo
            // 
            this.textBox_ValorTextoFijo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ValorTextoFijo.Location = new System.Drawing.Point(16, 26);
            this.textBox_ValorTextoFijo.Multiline = true;
            this.textBox_ValorTextoFijo.Name = "textBox_ValorTextoFijo";
            this.textBox_ValorTextoFijo.Size = new System.Drawing.Size(434, 168);
            this.textBox_ValorTextoFijo.TabIndex = 2;
            this.textBox_ValorTextoFijo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ValorTextoFijo_KeyPress);
            this.textBox_ValorTextoFijo.Leave += new System.EventHandler(this.textBox_ValorTextoFijo_Leave);
            // 
            // label_IngresarValor
            // 
            this.label_IngresarValor.AutoSize = true;
            this.label_IngresarValor.Location = new System.Drawing.Point(13, 7);
            this.label_IngresarValor.Name = "label_IngresarValor";
            this.label_IngresarValor.Size = new System.Drawing.Size(137, 13);
            this.label_IngresarValor.TabIndex = 1;
            this.label_IngresarValor.Text = "&Ingrese valor del Texto Fijo:";
            this.label_IngresarValor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label_ComprobacionValorTF, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox_ComprobacionValorTF, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 202);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(246, 28);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // label_ComprobacionValorTF
            // 
            this.label_ComprobacionValorTF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ComprobacionValorTF.AutoSize = true;
            this.label_ComprobacionValorTF.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ComprobacionValorTF.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label_ComprobacionValorTF.Location = new System.Drawing.Point(30, 0);
            this.label_ComprobacionValorTF.Name = "label_ComprobacionValorTF";
            this.label_ComprobacionValorTF.Size = new System.Drawing.Size(92, 28);
            this.label_ComprobacionValorTF.TabIndex = 6;
            this.label_ComprobacionValorTF.Text = "Valor Texto Fijo";
            this.label_ComprobacionValorTF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox_ComprobacionValorTF
            // 
            this.pictureBox_ComprobacionValorTF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_ComprobacionValorTF.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_ComprobacionValorTF.Name = "pictureBox_ComprobacionValorTF";
            this.pictureBox_ComprobacionValorTF.Size = new System.Drawing.Size(21, 22);
            this.pictureBox_ComprobacionValorTF.TabIndex = 5;
            this.pictureBox_ComprobacionValorTF.TabStop = false;
            // 
            // Form_FuenteTextoFijo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 243);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label_IngresarValor);
            this.Controls.Add(this.textBox_ValorTextoFijo);
            this.Controls.Add(this.button_Aceptar);
            this.Controls.Add(this.button_Volver);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(478, 282);
            this.MinimumSize = new System.Drawing.Size(478, 282);
            this.Name = "Form_FuenteTextoFijo";
            this.Text = "Fuente Texto Fijo";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ComprobacionValorTF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Aceptar;
        private System.Windows.Forms.Button button_Volver;
        private System.Windows.Forms.TextBox textBox_ValorTextoFijo;
        private System.Windows.Forms.Label label_IngresarValor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox_ComprobacionValorTF;
        private System.Windows.Forms.Label label_ComprobacionValorTF;
    }
}