namespace UI
{
    partial class Vista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vista));
            this.tableLayoutPanel_Vista = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox_Campaña = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel_InformacionAdicional = new System.Windows.Forms.FlowLayoutPanel();
            this.label_TextoBanner = new System.Windows.Forms.Label();
            this.timer_TextoDeslizante = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker_ChequeoBanner = new System.ComponentModel.BackgroundWorker();
            this.timer_Chequeo = new System.Windows.Forms.Timer(this.components);
            this.timer_ImagenesCampaña = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker_ChequeoCampaña = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_InicializarTimers = new System.ComponentModel.BackgroundWorker();
            this.timer_Cambio = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker_CargarDiaSiguiente = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_RSS = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel_Vista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Campaña)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_Vista
            // 
            this.tableLayoutPanel_Vista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel_Vista.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel_Vista.ColumnCount = 2;
            this.tableLayoutPanel_Vista.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel_Vista.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel_Vista.Controls.Add(this.pictureBox_Campaña, 0, 0);
            this.tableLayoutPanel_Vista.Controls.Add(this.flowLayoutPanel_InformacionAdicional, 1, 0);
            this.tableLayoutPanel_Vista.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Vista.Name = "tableLayoutPanel_Vista";
            this.tableLayoutPanel_Vista.RowCount = 1;
            this.tableLayoutPanel_Vista.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Vista.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 441F));
            this.tableLayoutPanel_Vista.Size = new System.Drawing.Size(758, 441);
            this.tableLayoutPanel_Vista.TabIndex = 0;
            // 
            // pictureBox_Campaña
            // 
            this.pictureBox_Campaña.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_Campaña.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_Campaña.Name = "pictureBox_Campaña";
            this.pictureBox_Campaña.Size = new System.Drawing.Size(600, 435);
            this.pictureBox_Campaña.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Campaña.TabIndex = 0;
            this.pictureBox_Campaña.TabStop = false;
            // 
            // flowLayoutPanel_InformacionAdicional
            // 
            this.flowLayoutPanel_InformacionAdicional.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel_InformacionAdicional.AutoSize = true;
            this.flowLayoutPanel_InformacionAdicional.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel_InformacionAdicional.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.flowLayoutPanel_InformacionAdicional.Location = new System.Drawing.Point(609, 3);
            this.flowLayoutPanel_InformacionAdicional.Name = "flowLayoutPanel_InformacionAdicional";
            this.flowLayoutPanel_InformacionAdicional.Size = new System.Drawing.Size(146, 0);
            this.flowLayoutPanel_InformacionAdicional.TabIndex = 1;
            // 
            // label_TextoBanner
            // 
            this.label_TextoBanner.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label_TextoBanner.AutoSize = true;
            this.label_TextoBanner.BackColor = System.Drawing.Color.Transparent;
            this.label_TextoBanner.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20F);
            this.label_TextoBanner.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label_TextoBanner.Location = new System.Drawing.Point(656, 444);
            this.label_TextoBanner.Name = "label_TextoBanner";
            this.label_TextoBanner.Size = new System.Drawing.Size(88, 32);
            this.label_TextoBanner.TabIndex = 1;
            this.label_TextoBanner.Text = "Textó";
            this.label_TextoBanner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer_TextoDeslizante
            // 
            this.timer_TextoDeslizante.Tick += new System.EventHandler(this.timer_TextoDeslizante_Tick);
            // 
            // backgroundWorker_ChequeoBanner
            // 
            this.backgroundWorker_ChequeoBanner.WorkerReportsProgress = true;
            this.backgroundWorker_ChequeoBanner.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_ChequeoBanner_DoWork);
            this.backgroundWorker_ChequeoBanner.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_ChequeoBanner_Completed);
            // 
            // timer_Chequeo
            // 
            this.timer_Chequeo.Tick += new System.EventHandler(this.timer_Chequeo_Tick);
            // 
            // timer_ImagenesCampaña
            // 
            this.timer_ImagenesCampaña.Tick += new System.EventHandler(this.timer_ImagenesCampaña_Tick);
            // 
            // backgroundWorker_ChequeoCampaña
            // 
            this.backgroundWorker_ChequeoCampaña.WorkerReportsProgress = true;
            this.backgroundWorker_ChequeoCampaña.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_ChequeoCampaña_DoWork);
            this.backgroundWorker_ChequeoCampaña.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_ChequeoCampaña_RunWorkerCompleted);
            // 
            // backgroundWorker_InicializarTimers
            // 
            this.backgroundWorker_InicializarTimers.WorkerReportsProgress = true;
            this.backgroundWorker_InicializarTimers.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_InicializarTimers_DoWork);
            this.backgroundWorker_InicializarTimers.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_InicializarTimers_ProgressChanged);
            // 
            // timer_Cambio
            // 
            this.timer_Cambio.Tick += new System.EventHandler(this.timer_Cambio_Tick);
            // 
            // backgroundWorker_RSS
            // 
            this.backgroundWorker_RSS.WorkerReportsProgress = true;
            this.backgroundWorker_RSS.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_RSS_DoWork);
            // 
            // Vista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(758, 487);
            this.Controls.Add(this.label_TextoBanner);
            this.Controls.Add(this.tableLayoutPanel_Vista);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Vista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vista";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Vista_FormClosing);
            this.tableLayoutPanel_Vista.ResumeLayout(false);
            this.tableLayoutPanel_Vista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Campaña)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Vista;
        private System.Windows.Forms.PictureBox pictureBox_Campaña;
        private System.Windows.Forms.Timer timer_TextoDeslizante;
        private System.Windows.Forms.Label label_TextoBanner;
        private System.ComponentModel.BackgroundWorker backgroundWorker_ChequeoBanner;
        private System.Windows.Forms.Timer timer_Chequeo;
        private System.Windows.Forms.Timer timer_ImagenesCampaña;
        private System.ComponentModel.BackgroundWorker backgroundWorker_ChequeoCampaña;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_InformacionAdicional;
        private System.ComponentModel.BackgroundWorker backgroundWorker_InicializarTimers;
        private System.Windows.Forms.Timer timer_Cambio;
        private System.ComponentModel.BackgroundWorker backgroundWorker_CargarDiaSiguiente;
        private System.ComponentModel.BackgroundWorker backgroundWorker_RSS;
    }
}