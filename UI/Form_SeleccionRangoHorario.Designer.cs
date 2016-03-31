namespace UI
{
    partial class Form_SeleccionRangoHorario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_SeleccionRangoHorario));
            this.dataGridView_Horarios = new System.Windows.Forms.DataGridView();
            this.label_RangoFecha = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_NoDisponibles = new System.Windows.Forms.Label();
            this.label_Disponibles = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label_Seleccionados = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.dataGridView_HorariosSeleccionados = new System.Windows.Forms.DataGridView();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.button_Aceptar = new System.Windows.Forms.Button();
            this.backgroundWorker_ObtenerRangosHorariosFecha = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Horarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_HorariosSeleccionados)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Horarios
            // 
            this.dataGridView_Horarios.AllowUserToAddRows = false;
            this.dataGridView_Horarios.AllowUserToDeleteRows = false;
            this.dataGridView_Horarios.AllowUserToResizeColumns = false;
            this.dataGridView_Horarios.AllowUserToResizeRows = false;
            this.dataGridView_Horarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Horarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Horarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Horarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Horarios.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Horarios.Location = new System.Drawing.Point(12, 33);
            this.dataGridView_Horarios.MultiSelect = false;
            this.dataGridView_Horarios.Name = "dataGridView_Horarios";
            this.dataGridView_Horarios.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Horarios.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_Horarios.RowHeadersWidth = 60;
            this.dataGridView_Horarios.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView_Horarios.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_Horarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_Horarios.Size = new System.Drawing.Size(496, 373);
            this.dataGridView_Horarios.TabIndex = 0;
            this.dataGridView_Horarios.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView_Horarios_CellPainting);
            // 
            // label_RangoFecha
            // 
            this.label_RangoFecha.AutoSize = true;
            this.label_RangoFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_RangoFecha.Location = new System.Drawing.Point(12, 9);
            this.label_RangoFecha.Name = "label_RangoFecha";
            this.label_RangoFecha.Size = new System.Drawing.Size(57, 20);
            this.label_RangoFecha.TabIndex = 1;
            this.label_RangoFecha.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackColor = System.Drawing.Color.Crimson;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 426);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 33);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label_NoDisponibles
            // 
            this.label_NoDisponibles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_NoDisponibles.AutoSize = true;
            this.label_NoDisponibles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NoDisponibles.Location = new System.Drawing.Point(51, 433);
            this.label_NoDisponibles.Name = "label_NoDisponibles";
            this.label_NoDisponibles.Size = new System.Drawing.Size(109, 18);
            this.label_NoDisponibles.TabIndex = 3;
            this.label_NoDisponibles.Text = "No Disponibles";
            this.label_NoDisponibles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Disponibles
            // 
            this.label_Disponibles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Disponibles.AutoSize = true;
            this.label_Disponibles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Disponibles.Location = new System.Drawing.Point(225, 433);
            this.label_Disponibles.Name = "label_Disponibles";
            this.label_Disponibles.Size = new System.Drawing.Size(85, 18);
            this.label_Disponibles.TabIndex = 5;
            this.label_Disponibles.Text = "Disponibles";
            this.label_Disponibles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(189, 426);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 33);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // label_Seleccionados
            // 
            this.label_Seleccionados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Seleccionados.AutoSize = true;
            this.label_Seleccionados.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Seleccionados.Location = new System.Drawing.Point(402, 433);
            this.label_Seleccionados.Name = "label_Seleccionados";
            this.label_Seleccionados.Size = new System.Drawing.Size(106, 18);
            this.label_Seleccionados.TabIndex = 7;
            this.label_Seleccionados.Text = "Seleccionados";
            this.label_Seleccionados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox3.BackColor = System.Drawing.Color.RoyalBlue;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(366, 426);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(33, 33);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // dataGridView_HorariosSeleccionados
            // 
            this.dataGridView_HorariosSeleccionados.AllowUserToAddRows = false;
            this.dataGridView_HorariosSeleccionados.AllowUserToDeleteRows = false;
            this.dataGridView_HorariosSeleccionados.AllowUserToResizeColumns = false;
            this.dataGridView_HorariosSeleccionados.AllowUserToResizeRows = false;
            this.dataGridView_HorariosSeleccionados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_HorariosSeleccionados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_HorariosSeleccionados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView_HorariosSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_HorariosSeleccionados.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView_HorariosSeleccionados.Location = new System.Drawing.Point(514, 33);
            this.dataGridView_HorariosSeleccionados.Name = "dataGridView_HorariosSeleccionados";
            this.dataGridView_HorariosSeleccionados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_HorariosSeleccionados.Size = new System.Drawing.Size(317, 373);
            this.dataGridView_HorariosSeleccionados.TabIndex = 8;
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.AccessibleDescription = "";
            this.button_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.button_Cancelar.Location = new System.Drawing.Point(738, 417);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(93, 43);
            this.button_Cancelar.TabIndex = 16;
            this.button_Cancelar.Text = "&Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // button_Aceptar
            // 
            this.button_Aceptar.AccessibleDescription = "Guarda datos";
            this.button_Aceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Aceptar.Enabled = false;
            this.button_Aceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.button_Aceptar.Location = new System.Drawing.Point(630, 417);
            this.button_Aceptar.Name = "button_Aceptar";
            this.button_Aceptar.Size = new System.Drawing.Size(93, 43);
            this.button_Aceptar.TabIndex = 15;
            this.button_Aceptar.Text = "&Aceptar";
            this.button_Aceptar.UseVisualStyleBackColor = true;
            this.button_Aceptar.Click += new System.EventHandler(this.button_Aceptar_Click);
            // 
            // backgroundWorker_ObtenerRangosHorariosFecha
            // 
            this.backgroundWorker_ObtenerRangosHorariosFecha.WorkerSupportsCancellation = true;
            this.backgroundWorker_ObtenerRangosHorariosFecha.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_ObtenerRangosHorariosFecha_DoWork);
            this.backgroundWorker_ObtenerRangosHorariosFecha.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_ObtenerRangosHorariosFecha_RunWorkerCompleted);
            // 
            // Form_SeleccionRangoHorario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 471);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Aceptar);
            this.Controls.Add(this.dataGridView_HorariosSeleccionados);
            this.Controls.Add(this.label_Seleccionados);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label_Disponibles);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label_NoDisponibles);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label_RangoFecha);
            this.Controls.Add(this.dataGridView_Horarios);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_SeleccionRangoHorario";
            this.Text = "Form_SeleccionRangoHorario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_SeleccionRangoHorario_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Horarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_HorariosSeleccionados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Horarios;
        private System.Windows.Forms.Label label_RangoFecha;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_NoDisponibles;
        private System.Windows.Forms.Label label_Disponibles;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label_Seleccionados;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.DataGridView dataGridView_HorariosSeleccionados;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Button button_Aceptar;
        private System.ComponentModel.BackgroundWorker backgroundWorker_ObtenerRangosHorariosFecha;
    }
}