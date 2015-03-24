namespace SnowExplorer
{
    partial class frmGetData
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
            this.btnInternet = new System.Windows.Forms.Button();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.btnFile = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblLocalFile = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInternet
            // 
            this.btnInternet.Location = new System.Drawing.Point(209, 25);
            this.btnInternet.Name = "btnInternet";
            this.btnInternet.Size = new System.Drawing.Size(85, 38);
            this.btnInternet.TabIndex = 0;
            this.btnInternet.Text = "Get Data From Internet";
            this.btnInternet.UseVisualStyleBackColor = true;
            // 
            // dtpTime
            // 
            this.dtpTime.Location = new System.Drawing.Point(11, 43);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(192, 20);
            this.dtpTime.TabIndex = 1;
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(209, 127);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(85, 44);
            this.btnFile.TabIndex = 2;
            this.btnFile.Text = "Get Data From File";
            this.btnFile.UseVisualStyleBackColor = true;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(13, 24);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(82, 13);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "Select the date:";
            // 
            // lblLocalFile
            // 
            this.lblLocalFile.AutoSize = true;
            this.lblLocalFile.Location = new System.Drawing.Point(13, 132);
            this.lblLocalFile.Name = "lblLocalFile";
            this.lblLocalFile.Size = new System.Drawing.Size(128, 13);
            this.lblLocalFile.TabIndex = 4;
            this.lblLocalFile.Text = "Select the local raster file:";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(11, 151);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(191, 20);
            this.txtFileName.TabIndex = 5;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(140, 127);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(62, 23);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "Browse..";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // frmGetData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 182);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.lblLocalFile);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.btnInternet);
            this.Name = "frmGetData";
            this.Text = "Get Snow Data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInternet;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblLocalFile;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnBrowse;
    }
}