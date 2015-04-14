namespace SnowExplorer
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mapMain = new DotSpatial.Controls.Map();
            this.legend1 = new DotSpatial.Controls.Legend();
            this.spatialStatusStrip1 = new DotSpatial.Controls.SpatialStatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnGetData = new System.Windows.Forms.Button();
            this.btnDrawPolygon = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.grpUnits = new System.Windows.Forms.GroupBox();
            this.radEnglish = new System.Windows.Forms.RadioButton();
            this.radMetric = new System.Windows.Forms.RadioButton();
            this.cmbBackground = new System.Windows.Forms.ComboBox();
            this.lblBackground = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.pnlLegendandResults = new System.Windows.Forms.Panel();
            this.grpResults = new System.Windows.Forms.GroupBox();
            this.tbVolume = new System.Windows.Forms.TextBox();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnZoomExtents = new System.Windows.Forms.Button();
            this.btnPan = new System.Windows.Forms.Button();
            this.appManager1 = new DotSpatial.Controls.AppManager();
            this.spatialHeaderControl1 = new DotSpatial.Controls.SpatialHeaderControl();
            this.btnHelp = new System.Windows.Forms.Button();
            this.spatialStatusStrip1.SuspendLayout();
            this.grpUnits.SuspendLayout();
            this.pnlLegendandResults.SuspendLayout();
            this.grpResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spatialHeaderControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // mapMain
            // 
            this.mapMain.AllowDrop = true;
            this.mapMain.BackColor = System.Drawing.Color.White;
            this.mapMain.CollectAfterDraw = false;
            this.mapMain.CollisionDetection = false;
            this.mapMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapMain.ExtendBuffer = false;
            this.mapMain.FunctionMode = DotSpatial.Controls.FunctionMode.None;
            this.mapMain.IsBusy = false;
            this.mapMain.IsZoomedToMaxExtent = false;
            this.mapMain.Legend = this.legend1;
            this.mapMain.Location = new System.Drawing.Point(0, 0);
            this.mapMain.Name = "mapMain";
            this.mapMain.ProgressHandler = this.spatialStatusStrip1;
            this.mapMain.ProjectionModeDefine = DotSpatial.Controls.ActionMode.Prompt;
            this.mapMain.ProjectionModeReproject = DotSpatial.Controls.ActionMode.Prompt;
            this.mapMain.RedrawLayersWhileResizing = false;
            this.mapMain.SelectionEnabled = true;
            this.mapMain.Size = new System.Drawing.Size(502, 381);
            this.mapMain.TabIndex = 0;
            this.mapMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mapMain_MouseClick);
            this.mapMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mapMain_MouseDoubleClick);
            // 
            // legend1
            // 
            this.legend1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.legend1.BackColor = System.Drawing.Color.White;
            this.legend1.ControlRectangle = new System.Drawing.Rectangle(0, 0, 142, 154);
            this.legend1.DocumentRectangle = new System.Drawing.Rectangle(0, 0, 187, 428);
            this.legend1.HorizontalScrollEnabled = true;
            this.legend1.Indentation = 30;
            this.legend1.IsInitialized = false;
            this.legend1.Location = new System.Drawing.Point(3, 3);
            this.legend1.MinimumSize = new System.Drawing.Size(5, 5);
            this.legend1.Name = "legend1";
            this.legend1.ProgressHandler = null;
            this.legend1.ResetOnResize = false;
            this.legend1.SelectionFontColor = System.Drawing.Color.Black;
            this.legend1.SelectionHighlight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(238)))), ((int)(((byte)(252)))));
            this.legend1.Size = new System.Drawing.Size(142, 154);
            this.legend1.TabIndex = 16;
            this.legend1.Text = "legend1";
            this.legend1.VerticalScrollEnabled = true;
            // 
            // spatialStatusStrip1
            // 
            this.spatialStatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.spatialStatusStrip1.Location = new System.Drawing.Point(0, 440);
            this.spatialStatusStrip1.Name = "spatialStatusStrip1";
            this.spatialStatusStrip1.ProgressBar = this.toolStripProgressBar1;
            this.spatialStatusStrip1.ProgressLabel = this.toolStripStatusLabel1;
            this.spatialStatusStrip1.Size = new System.Drawing.Size(684, 22);
            this.spatialStatusStrip1.TabIndex = 15;
            this.spatialStatusStrip1.Text = "spatialStatusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(18, 13);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(80, 50);
            this.btnGetData.TabIndex = 1;
            this.btnGetData.Text = "Get Snow Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // btnDrawPolygon
            // 
            this.btnDrawPolygon.Location = new System.Drawing.Point(117, 13);
            this.btnDrawPolygon.Name = "btnDrawPolygon";
            this.btnDrawPolygon.Size = new System.Drawing.Size(80, 50);
            this.btnDrawPolygon.TabIndex = 2;
            this.btnDrawPolygon.Text = "Draw Polygon";
            this.btnDrawPolygon.UseVisualStyleBackColor = true;
            this.btnDrawPolygon.Click += new System.EventHandler(this.btnDrawPolygon_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(212, 13);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(80, 50);
            this.btnCalculate.TabIndex = 3;
            this.btnCalculate.Text = "Calculate Snow Volume";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // grpUnits
            // 
            this.grpUnits.Controls.Add(this.radEnglish);
            this.grpUnits.Controls.Add(this.radMetric);
            this.grpUnits.Location = new System.Drawing.Point(309, 5);
            this.grpUnits.Name = "grpUnits";
            this.grpUnits.Size = new System.Drawing.Size(90, 57);
            this.grpUnits.TabIndex = 4;
            this.grpUnits.TabStop = false;
            this.grpUnits.Text = "Units";
            this.grpUnits.Visible = false;
            // 
            // radEnglish
            // 
            this.radEnglish.AutoSize = true;
            this.radEnglish.Location = new System.Drawing.Point(6, 37);
            this.radEnglish.Name = "radEnglish";
            this.radEnglish.Size = new System.Drawing.Size(59, 17);
            this.radEnglish.TabIndex = 1;
            this.radEnglish.Text = "English";
            this.radEnglish.UseVisualStyleBackColor = true;
            // 
            // radMetric
            // 
            this.radMetric.AutoSize = true;
            this.radMetric.Checked = true;
            this.radMetric.Location = new System.Drawing.Point(6, 19);
            this.radMetric.Name = "radMetric";
            this.radMetric.Size = new System.Drawing.Size(54, 17);
            this.radMetric.TabIndex = 0;
            this.radMetric.TabStop = true;
            this.radMetric.Text = "Metric";
            this.radMetric.UseVisualStyleBackColor = true;
            // 
            // cmbBackground
            // 
            this.cmbBackground.FormattingEnabled = true;
            this.cmbBackground.Items.AddRange(new object[] {
            "DEM - Utah",
            "Topology - Utah",
            "Imagery -Utah"});
            this.cmbBackground.Location = new System.Drawing.Point(424, 38);
            this.cmbBackground.Name = "cmbBackground";
            this.cmbBackground.Size = new System.Drawing.Size(89, 21);
            this.cmbBackground.TabIndex = 5;
            this.cmbBackground.Visible = false;
            this.cmbBackground.SelectedIndexChanged += new System.EventHandler(this.cmbBackground_SelectedIndexChanged);
            // 
            // lblBackground
            // 
            this.lblBackground.AutoSize = true;
            this.lblBackground.Location = new System.Drawing.Point(421, 22);
            this.lblBackground.Name = "lblBackground";
            this.lblBackground.Size = new System.Drawing.Size(92, 13);
            this.lblBackground.TabIndex = 6;
            this.lblBackground.Text = "Background Map:";
            this.lblBackground.Visible = false;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(527, 17);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(61, 42);
            this.btnOpen.TabIndex = 8;
            this.btnOpen.Text = "Open File";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // pnlLegendandResults
            // 
            this.pnlLegendandResults.Controls.Add(this.legend1);
            this.pnlLegendandResults.Controls.Add(this.grpResults);
            this.pnlLegendandResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLegendandResults.Location = new System.Drawing.Point(0, 0);
            this.pnlLegendandResults.Name = "pnlLegendandResults";
            this.pnlLegendandResults.Size = new System.Drawing.Size(145, 381);
            this.pnlLegendandResults.TabIndex = 9;
            // 
            // grpResults
            // 
            this.grpResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpResults.Controls.Add(this.tbVolume);
            this.grpResults.Location = new System.Drawing.Point(12, 163);
            this.grpResults.Name = "grpResults";
            this.grpResults.Size = new System.Drawing.Size(136, 205);
            this.grpResults.TabIndex = 0;
            this.grpResults.TabStop = false;
            this.grpResults.Text = "Results";
            // 
            // tbVolume
            // 
            this.tbVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbVolume.Location = new System.Drawing.Point(0, 21);
            this.tbVolume.Multiline = true;
            this.tbVolume.Name = "tbVolume";
            this.tbVolume.Size = new System.Drawing.Size(136, 178);
            this.tbVolume.TabIndex = 0;
            // 
            // spcMain
            // 
            this.spcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spcMain.Location = new System.Drawing.Point(18, 69);
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.lblDate);
            this.spcMain.Panel1.Controls.Add(this.mapMain);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.pnlLegendandResults);
            this.spcMain.Size = new System.Drawing.Size(651, 381);
            this.spcMain.SplitterDistance = 502;
            this.spcMain.TabIndex = 10;
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.BackColor = System.Drawing.Color.White;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(297, 9);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(197, 19);
            this.lblDate.TabIndex = 1;
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Location = new System.Drawing.Point(21, 73);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(51, 36);
            this.btnZoomIn.TabIndex = 11;
            this.btnZoomIn.Text = "Zoom In";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Location = new System.Drawing.Point(21, 113);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(51, 36);
            this.btnZoomOut.TabIndex = 12;
            this.btnZoomOut.Text = "Zoom Out";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnZoomExtents
            // 
            this.btnZoomExtents.Location = new System.Drawing.Point(21, 153);
            this.btnZoomExtents.Name = "btnZoomExtents";
            this.btnZoomExtents.Size = new System.Drawing.Size(51, 36);
            this.btnZoomExtents.TabIndex = 13;
            this.btnZoomExtents.Text = "Extent";
            this.btnZoomExtents.UseVisualStyleBackColor = true;
            this.btnZoomExtents.Click += new System.EventHandler(this.btnZoomExtents_Click);
            // 
            // btnPan
            // 
            this.btnPan.Location = new System.Drawing.Point(21, 193);
            this.btnPan.Name = "btnPan";
            this.btnPan.Size = new System.Drawing.Size(51, 36);
            this.btnPan.TabIndex = 14;
            this.btnPan.Text = "Pan Toggle";
            this.btnPan.UseVisualStyleBackColor = true;
            this.btnPan.Click += new System.EventHandler(this.btnPan_Click);
            // 
            // appManager1
            // 
            this.appManager1.Directories = ((System.Collections.Generic.List<string>)(resources.GetObject("appManager1.Directories")));
            this.appManager1.DockManager = null;
            this.appManager1.HeaderControl = this.spatialHeaderControl1;
            this.appManager1.Legend = this.legend1;
            this.appManager1.Map = this.mapMain;
            this.appManager1.ProgressHandler = this.spatialStatusStrip1;
            this.appManager1.ShowExtensionsDialogMode = DotSpatial.Controls.ShowExtensionsDialogMode.Default;
            // 
            // spatialHeaderControl1
            // 
            this.spatialHeaderControl1.ApplicationManager = null;
            this.spatialHeaderControl1.MenuStrip = null;
            this.spatialHeaderControl1.ToolbarsContainer = null;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(594, 17);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(61, 42);
            this.btnHelp.TabIndex = 16;
            this.btnHelp.Text = "HELP";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.spatialStatusStrip1);
            this.Controls.Add(this.btnPan);
            this.Controls.Add(this.btnZoomExtents);
            this.Controls.Add(this.btnZoomOut);
            this.Controls.Add(this.btnZoomIn);
            this.Controls.Add(this.spcMain);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.lblBackground);
            this.Controls.Add(this.cmbBackground);
            this.Controls.Add(this.grpUnits);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnDrawPolygon);
            this.Controls.Add(this.btnGetData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Snow Explorer";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.spatialStatusStrip1.ResumeLayout(false);
            this.spatialStatusStrip1.PerformLayout();
            this.grpUnits.ResumeLayout(false);
            this.grpUnits.PerformLayout();
            this.pnlLegendandResults.ResumeLayout(false);
            this.grpResults.ResumeLayout(false);
            this.grpResults.PerformLayout();
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spatialHeaderControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DotSpatial.Controls.Map mapMain;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Button btnDrawPolygon;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.GroupBox grpUnits;
        private System.Windows.Forms.RadioButton radEnglish;
        private System.Windows.Forms.RadioButton radMetric;
        private System.Windows.Forms.ComboBox cmbBackground;
        private System.Windows.Forms.Label lblBackground;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Panel pnlLegendandResults;
        private System.Windows.Forms.GroupBox grpResults;
        private System.Windows.Forms.TextBox tbVolume;
        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnZoomExtents;
        private System.Windows.Forms.Button btnPan;
        private DotSpatial.Controls.AppManager appManager1;
        private DotSpatial.Controls.SpatialHeaderControl spatialHeaderControl1;
        private DotSpatial.Controls.Legend legend1;
        private DotSpatial.Controls.SpatialStatusStrip spatialStatusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnHelp;
    }
}

