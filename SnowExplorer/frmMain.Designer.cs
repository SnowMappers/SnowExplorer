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
            this.btnGetData = new System.Windows.Forms.Button();
            this.btnDrawPolygon = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.grpUnits = new System.Windows.Forms.GroupBox();
            this.radEnglish = new System.Windows.Forms.RadioButton();
            this.radMetric = new System.Windows.Forms.RadioButton();
            this.cmbBackground = new System.Windows.Forms.ComboBox();
            this.lblBackground = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.pnlLegendandResults = new System.Windows.Forms.Panel();
            this.grpLegend = new System.Windows.Forms.GroupBox();
            this.chkBackground = new System.Windows.Forms.CheckBox();
            this.chkRaster = new System.Windows.Forms.CheckBox();
            this.chkPolygon = new System.Windows.Forms.CheckBox();
            this.grpResults = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnZoomExtents = new System.Windows.Forms.Button();
            this.grpUnits.SuspendLayout();
            this.pnlLegendandResults.SuspendLayout();
            this.grpLegend.SuspendLayout();
            this.grpResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
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
            this.mapMain.Legend = null;
            this.mapMain.Location = new System.Drawing.Point(0, 0);
            this.mapMain.Name = "mapMain";
            this.mapMain.ProgressHandler = null;
            this.mapMain.ProjectionModeDefine = DotSpatial.Controls.ActionMode.Prompt;
            this.mapMain.ProjectionModeReproject = DotSpatial.Controls.ActionMode.Prompt;
            this.mapMain.RedrawLayersWhileResizing = false;
            this.mapMain.SelectionEnabled = true;
            this.mapMain.Size = new System.Drawing.Size(502, 269);
            this.mapMain.TabIndex = 0;
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(18, 14);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(80, 50);
            this.btnGetData.TabIndex = 1;
            this.btnGetData.Text = "Get Snow Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // btnDrawPolygon
            // 
            this.btnDrawPolygon.Location = new System.Drawing.Point(117, 14);
            this.btnDrawPolygon.Name = "btnDrawPolygon";
            this.btnDrawPolygon.Size = new System.Drawing.Size(80, 50);
            this.btnDrawPolygon.TabIndex = 2;
            this.btnDrawPolygon.Text = "Draw Polygon";
            this.btnDrawPolygon.UseVisualStyleBackColor = true;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(212, 14);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(80, 50);
            this.btnCalculate.TabIndex = 3;
            this.btnCalculate.Text = "Calculate Snow Volume";
            this.btnCalculate.UseVisualStyleBackColor = true;
            // 
            // grpUnits
            // 
            this.grpUnits.Controls.Add(this.radEnglish);
            this.grpUnits.Controls.Add(this.radMetric);
            this.grpUnits.Location = new System.Drawing.Point(309, 6);
            this.grpUnits.Name = "grpUnits";
            this.grpUnits.Size = new System.Drawing.Size(90, 57);
            this.grpUnits.TabIndex = 4;
            this.grpUnits.TabStop = false;
            this.grpUnits.Text = "Units";
            // 
            // radEnglish
            // 
            this.radEnglish.AutoSize = true;
            this.radEnglish.Location = new System.Drawing.Point(6, 37);
            this.radEnglish.Name = "radEnglish";
            this.radEnglish.Size = new System.Drawing.Size(59, 17);
            this.radEnglish.TabIndex = 1;
            this.radEnglish.TabStop = true;
            this.radEnglish.Text = "English";
            this.radEnglish.UseVisualStyleBackColor = true;
            // 
            // radMetric
            // 
            this.radMetric.AutoSize = true;
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
            this.cmbBackground.Location = new System.Drawing.Point(424, 39);
            this.cmbBackground.Name = "cmbBackground";
            this.cmbBackground.Size = new System.Drawing.Size(89, 21);
            this.cmbBackground.TabIndex = 5;
            // 
            // lblBackground
            // 
            this.lblBackground.AutoSize = true;
            this.lblBackground.Location = new System.Drawing.Point(421, 23);
            this.lblBackground.Name = "lblBackground";
            this.lblBackground.Size = new System.Drawing.Size(92, 13);
            this.lblBackground.TabIndex = 6;
            this.lblBackground.Text = "Background Map:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(607, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(62, 42);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(527, 18);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(61, 42);
            this.btnOpen.TabIndex = 8;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // pnlLegendandResults
            // 
            this.pnlLegendandResults.Controls.Add(this.grpLegend);
            this.pnlLegendandResults.Controls.Add(this.grpResults);
            this.pnlLegendandResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLegendandResults.Location = new System.Drawing.Point(0, 0);
            this.pnlLegendandResults.Name = "pnlLegendandResults";
            this.pnlLegendandResults.Size = new System.Drawing.Size(145, 269);
            this.pnlLegendandResults.TabIndex = 9;
            // 
            // grpLegend
            // 
            this.grpLegend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLegend.Controls.Add(this.chkBackground);
            this.grpLegend.Controls.Add(this.chkRaster);
            this.grpLegend.Controls.Add(this.chkPolygon);
            this.grpLegend.Location = new System.Drawing.Point(15, 24);
            this.grpLegend.Name = "grpLegend";
            this.grpLegend.Size = new System.Drawing.Size(114, 120);
            this.grpLegend.TabIndex = 1;
            this.grpLegend.TabStop = false;
            this.grpLegend.Text = "Legend";
            // 
            // chkBackground
            // 
            this.chkBackground.AutoSize = true;
            this.chkBackground.Location = new System.Drawing.Point(6, 87);
            this.chkBackground.Name = "chkBackground";
            this.chkBackground.Size = new System.Drawing.Size(108, 17);
            this.chkBackground.TabIndex = 2;
            this.chkBackground.Text = "Background Map";
            this.chkBackground.UseVisualStyleBackColor = true;
            // 
            // chkRaster
            // 
            this.chkRaster.AutoSize = true;
            this.chkRaster.Location = new System.Drawing.Point(7, 52);
            this.chkRaster.Name = "chkRaster";
            this.chkRaster.Size = new System.Drawing.Size(87, 17);
            this.chkRaster.TabIndex = 1;
            this.chkRaster.Text = "Snow Raster";
            this.chkRaster.UseVisualStyleBackColor = true;
            // 
            // chkPolygon
            // 
            this.chkPolygon.AutoSize = true;
            this.chkPolygon.Location = new System.Drawing.Point(7, 19);
            this.chkPolygon.Name = "chkPolygon";
            this.chkPolygon.Size = new System.Drawing.Size(64, 17);
            this.chkPolygon.TabIndex = 0;
            this.chkPolygon.Text = "Polygon";
            this.chkPolygon.UseVisualStyleBackColor = true;
            // 
            // grpResults
            // 
            this.grpResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpResults.Controls.Add(this.textBox1);
            this.grpResults.Location = new System.Drawing.Point(11, 150);
            this.grpResults.Name = "grpResults";
            this.grpResults.Size = new System.Drawing.Size(118, 96);
            this.grpResults.TabIndex = 0;
            this.grpResults.TabStop = false;
            this.grpResults.Text = "Results";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(11, 21);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(95, 64);
            this.textBox1.TabIndex = 0;
            // 
            // spcMain
            // 
            this.spcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spcMain.Location = new System.Drawing.Point(18, 78);
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.mapMain);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.pnlLegendandResults);
            this.spcMain.Size = new System.Drawing.Size(651, 269);
            this.spcMain.SplitterDistance = 502;
            this.spcMain.TabIndex = 10;
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Location = new System.Drawing.Point(21, 81);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(43, 36);
            this.btnZoomIn.TabIndex = 11;
            this.btnZoomIn.Text = "Zoom In";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Location = new System.Drawing.Point(21, 118);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(43, 36);
            this.btnZoomOut.TabIndex = 12;
            this.btnZoomOut.Text = "Zoom Out";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            // 
            // btnZoomExtents
            // 
            this.btnZoomExtents.Location = new System.Drawing.Point(23, 160);
            this.btnZoomExtents.Name = "btnZoomExtents";
            this.btnZoomExtents.Size = new System.Drawing.Size(43, 36);
            this.btnZoomExtents.TabIndex = 13;
            this.btnZoomExtents.Text = "Zoom Extent";
            this.btnZoomExtents.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 362);
            this.Controls.Add(this.btnZoomExtents);
            this.Controls.Add(this.btnZoomOut);
            this.Controls.Add(this.btnZoomIn);
            this.Controls.Add(this.spcMain);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblBackground);
            this.Controls.Add(this.cmbBackground);
            this.Controls.Add(this.grpUnits);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnDrawPolygon);
            this.Controls.Add(this.btnGetData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Snow Explorer";
            this.grpUnits.ResumeLayout(false);
            this.grpUnits.PerformLayout();
            this.pnlLegendandResults.ResumeLayout(false);
            this.grpLegend.ResumeLayout(false);
            this.grpLegend.PerformLayout();
            this.grpResults.ResumeLayout(false);
            this.grpResults.PerformLayout();
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Panel pnlLegendandResults;
        private System.Windows.Forms.GroupBox grpLegend;
        private System.Windows.Forms.CheckBox chkBackground;
        private System.Windows.Forms.CheckBox chkRaster;
        private System.Windows.Forms.CheckBox chkPolygon;
        private System.Windows.Forms.GroupBox grpResults;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnZoomExtents;
    }
}

