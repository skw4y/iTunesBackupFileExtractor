namespace ItunesBackupFileExtractor
{
    partial class Form1
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
            this.btnLaunch = new MetroFramework.Controls.MetroButton();
            this.txtBackupFolder = new MetroFramework.Controls.MetroTextBox();
            this.btnBackupFolderBrowse = new MetroFramework.Controls.MetroButton();
            this.btnOutputFolderBrowse = new MetroFramework.Controls.MetroButton();
            this.txtOutputFolder = new MetroFramework.Controls.MetroTextBox();
            this.lblBackupFolder = new MetroFramework.Controls.MetroLabel();
            this.lblOutputFolder = new MetroFramework.Controls.MetroLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.chkImages = new MetroFramework.Controls.MetroCheckBox();
            this.chkVideos = new MetroFramework.Controls.MetroCheckBox();
            this.chkAudio = new MetroFramework.Controls.MetroCheckBox();
            this.chkDocuments = new MetroFramework.Controls.MetroCheckBox();
            this.chkDBFiles = new MetroFramework.Controls.MetroCheckBox();
            this.chkAll = new MetroFramework.Controls.MetroCheckBox();
            this.label1 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // btnLaunch
            // 
            this.btnLaunch.Highlight = false;
            this.btnLaunch.Location = new System.Drawing.Point(46, 316);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(117, 23);
            this.btnLaunch.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnLaunch.StyleManager = null;
            this.btnLaunch.TabIndex = 0;
            this.btnLaunch.Text = "Go!";
            this.btnLaunch.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // txtBackupFolder
            // 
            this.txtBackupFolder.CustomBackground = false;
            this.txtBackupFolder.CustomForeColor = false;
            this.txtBackupFolder.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.txtBackupFolder.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.txtBackupFolder.Location = new System.Drawing.Point(13, 97);
            this.txtBackupFolder.Multiline = false;
            this.txtBackupFolder.Name = "txtBackupFolder";
            this.txtBackupFolder.SelectedText = "";
            this.txtBackupFolder.Size = new System.Drawing.Size(421, 20);
            this.txtBackupFolder.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBackupFolder.StyleManager = null;
            this.txtBackupFolder.TabIndex = 1;
            this.txtBackupFolder.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBackupFolder.UseStyleColors = false;
            // 
            // btnBackupFolderBrowse
            // 
            this.btnBackupFolderBrowse.Highlight = false;
            this.btnBackupFolderBrowse.Location = new System.Drawing.Point(440, 97);
            this.btnBackupFolderBrowse.Name = "btnBackupFolderBrowse";
            this.btnBackupFolderBrowse.Size = new System.Drawing.Size(26, 20);
            this.btnBackupFolderBrowse.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnBackupFolderBrowse.StyleManager = null;
            this.btnBackupFolderBrowse.TabIndex = 2;
            this.btnBackupFolderBrowse.Text = "...";
            this.btnBackupFolderBrowse.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnBackupFolderBrowse.Click += new System.EventHandler(this.btnBackupFolderBrowse_Click);
            // 
            // btnOutputFolderBrowse
            // 
            this.btnOutputFolderBrowse.Highlight = false;
            this.btnOutputFolderBrowse.Location = new System.Drawing.Point(440, 147);
            this.btnOutputFolderBrowse.Name = "btnOutputFolderBrowse";
            this.btnOutputFolderBrowse.Size = new System.Drawing.Size(26, 20);
            this.btnOutputFolderBrowse.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnOutputFolderBrowse.StyleManager = null;
            this.btnOutputFolderBrowse.TabIndex = 4;
            this.btnOutputFolderBrowse.Text = "...";
            this.btnOutputFolderBrowse.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnOutputFolderBrowse.Click += new System.EventHandler(this.btnOutputFolderBrowse_Click);
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.BackColor = System.Drawing.SystemColors.Control;
            this.txtOutputFolder.CustomBackground = false;
            this.txtOutputFolder.CustomForeColor = false;
            this.txtOutputFolder.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.txtOutputFolder.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.txtOutputFolder.Location = new System.Drawing.Point(13, 147);
            this.txtOutputFolder.Multiline = false;
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.SelectedText = "";
            this.txtOutputFolder.Size = new System.Drawing.Size(421, 20);
            this.txtOutputFolder.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtOutputFolder.StyleManager = null;
            this.txtOutputFolder.TabIndex = 3;
            this.txtOutputFolder.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtOutputFolder.UseStyleColors = false;
            // 
            // lblBackupFolder
            // 
            this.lblBackupFolder.AutoSize = true;
            this.lblBackupFolder.CustomBackground = false;
            this.lblBackupFolder.CustomForeColor = false;
            this.lblBackupFolder.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.lblBackupFolder.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.lblBackupFolder.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.lblBackupFolder.Location = new System.Drawing.Point(11, 75);
            this.lblBackupFolder.Name = "lblBackupFolder";
            this.lblBackupFolder.Size = new System.Drawing.Size(133, 19);
            this.lblBackupFolder.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblBackupFolder.StyleManager = null;
            this.lblBackupFolder.TabIndex = 5;
            this.lblBackupFolder.Text = "iTunes backup folder:";
            this.lblBackupFolder.Theme = MetroFramework.MetroThemeStyle.Light;
            this.lblBackupFolder.UseStyleColors = false;
            // 
            // lblOutputFolder
            // 
            this.lblOutputFolder.AutoSize = true;
            this.lblOutputFolder.CustomBackground = false;
            this.lblOutputFolder.CustomForeColor = false;
            this.lblOutputFolder.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.lblOutputFolder.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.lblOutputFolder.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.lblOutputFolder.Location = new System.Drawing.Point(11, 125);
            this.lblOutputFolder.Name = "lblOutputFolder";
            this.lblOutputFolder.Size = new System.Drawing.Size(92, 19);
            this.lblOutputFolder.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblOutputFolder.StyleManager = null;
            this.lblOutputFolder.TabIndex = 6;
            this.lblOutputFolder.Text = "Output folder:";
            this.lblOutputFolder.Theme = MetroFramework.MetroThemeStyle.Light;
            this.lblOutputFolder.UseStyleColors = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Highlight = false;
            this.btnCancel.Location = new System.Drawing.Point(292, 316);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 23);
            this.btnCancel.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnCancel.StyleManager = null;
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkImages
            // 
            this.chkImages.AutoSize = true;
            this.chkImages.CustomBackground = false;
            this.chkImages.CustomForeColor = false;
            this.chkImages.FontSize = MetroFramework.MetroLinkSize.Small;
            this.chkImages.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.chkImages.Location = new System.Drawing.Point(117, 240);
            this.chkImages.Name = "chkImages";
            this.chkImages.Size = new System.Drawing.Size(56, 15);
            this.chkImages.Style = MetroFramework.MetroColorStyle.Blue;
            this.chkImages.StyleManager = null;
            this.chkImages.TabIndex = 8;
            this.chkImages.Text = "Image";
            this.chkImages.Theme = MetroFramework.MetroThemeStyle.Light;
            this.chkImages.UseStyleColors = false;
            this.chkImages.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chkVideos
            // 
            this.chkVideos.AutoSize = true;
            this.chkVideos.CustomBackground = false;
            this.chkVideos.CustomForeColor = false;
            this.chkVideos.FontSize = MetroFramework.MetroLinkSize.Small;
            this.chkVideos.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.chkVideos.Location = new System.Drawing.Point(252, 240);
            this.chkVideos.Name = "chkVideos";
            this.chkVideos.Size = new System.Drawing.Size(53, 15);
            this.chkVideos.Style = MetroFramework.MetroColorStyle.Blue;
            this.chkVideos.StyleManager = null;
            this.chkVideos.TabIndex = 9;
            this.chkVideos.Text = "Video";
            this.chkVideos.Theme = MetroFramework.MetroThemeStyle.Light;
            this.chkVideos.UseStyleColors = false;
            this.chkVideos.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chkAudio
            // 
            this.chkAudio.AutoSize = true;
            this.chkAudio.CustomBackground = false;
            this.chkAudio.CustomForeColor = false;
            this.chkAudio.FontSize = MetroFramework.MetroLinkSize.Small;
            this.chkAudio.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.chkAudio.Location = new System.Drawing.Point(117, 286);
            this.chkAudio.Name = "chkAudio";
            this.chkAudio.Size = new System.Drawing.Size(55, 15);
            this.chkAudio.Style = MetroFramework.MetroColorStyle.Blue;
            this.chkAudio.StyleManager = null;
            this.chkAudio.TabIndex = 10;
            this.chkAudio.Text = "Audio";
            this.chkAudio.Theme = MetroFramework.MetroThemeStyle.Light;
            this.chkAudio.UseStyleColors = false;
            this.chkAudio.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chkDocuments
            // 
            this.chkDocuments.AutoSize = true;
            this.chkDocuments.CustomBackground = false;
            this.chkDocuments.CustomForeColor = false;
            this.chkDocuments.FontSize = MetroFramework.MetroLinkSize.Small;
            this.chkDocuments.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.chkDocuments.Location = new System.Drawing.Point(117, 263);
            this.chkDocuments.Name = "chkDocuments";
            this.chkDocuments.Size = new System.Drawing.Size(79, 15);
            this.chkDocuments.Style = MetroFramework.MetroColorStyle.Blue;
            this.chkDocuments.StyleManager = null;
            this.chkDocuments.TabIndex = 11;
            this.chkDocuments.Text = "Document";
            this.chkDocuments.Theme = MetroFramework.MetroThemeStyle.Light;
            this.chkDocuments.UseStyleColors = false;
            this.chkDocuments.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chkDBFiles
            // 
            this.chkDBFiles.AutoSize = true;
            this.chkDBFiles.CustomBackground = false;
            this.chkDBFiles.CustomForeColor = false;
            this.chkDBFiles.FontSize = MetroFramework.MetroLinkSize.Small;
            this.chkDBFiles.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.chkDBFiles.Location = new System.Drawing.Point(252, 263);
            this.chkDBFiles.Name = "chkDBFiles";
            this.chkDBFiles.Size = new System.Drawing.Size(71, 15);
            this.chkDBFiles.Style = MetroFramework.MetroColorStyle.Blue;
            this.chkDBFiles.StyleManager = null;
            this.chkDBFiles.TabIndex = 12;
            this.chkDBFiles.Text = "Database";
            this.chkDBFiles.Theme = MetroFramework.MetroThemeStyle.Light;
            this.chkDBFiles.UseStyleColors = false;
            this.chkDBFiles.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.CustomBackground = false;
            this.chkAll.CustomForeColor = false;
            this.chkAll.FontSize = MetroFramework.MetroLinkSize.Small;
            this.chkAll.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.chkAll.Location = new System.Drawing.Point(231, 199);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(37, 15);
            this.chkAll.Style = MetroFramework.MetroColorStyle.Blue;
            this.chkAll.StyleManager = null;
            this.chkAll.TabIndex = 13;
            this.chkAll.Text = "All";
            this.chkAll.Theme = MetroFramework.MetroThemeStyle.Light;
            this.chkAll.UseStyleColors = false;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.CustomBackground = false;
            this.label1.CustomForeColor = false;
            this.label1.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.label1.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.label1.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.label1.Location = new System.Drawing.Point(11, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 19);
            this.label1.Style = MetroFramework.MetroColorStyle.Blue;
            this.label1.StyleManager = null;
            this.label1.TabIndex = 14;
            this.label1.Text = "Select the type of files to extract:";
            this.label1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.label1.UseStyleColors = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 353);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.chkDBFiles);
            this.Controls.Add(this.chkDocuments);
            this.Controls.Add(this.chkAudio);
            this.Controls.Add(this.chkVideos);
            this.Controls.Add(this.chkImages);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblOutputFolder);
            this.Controls.Add(this.lblBackupFolder);
            this.Controls.Add(this.btnOutputFolderBrowse);
            this.Controls.Add(this.txtOutputFolder);
            this.Controls.Add(this.btnBackupFolderBrowse);
            this.Controls.Add(this.txtBackupFolder);
            this.Controls.Add(this.btnLaunch);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "iTunes Backup File Extractor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnLaunch;
        private MetroFramework.Controls.MetroTextBox txtBackupFolder;
        private MetroFramework.Controls.MetroButton btnBackupFolderBrowse;
        private MetroFramework.Controls.MetroButton btnOutputFolderBrowse;
        private MetroFramework.Controls.MetroTextBox txtOutputFolder;
        private MetroFramework.Controls.MetroLabel lblBackupFolder;
        private MetroFramework.Controls.MetroLabel lblOutputFolder;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private MetroFramework.Controls.MetroButton btnCancel;
        private MetroFramework.Controls.MetroCheckBox chkImages;
        private MetroFramework.Controls.MetroCheckBox chkVideos;
        private MetroFramework.Controls.MetroCheckBox chkAudio;
        private MetroFramework.Controls.MetroCheckBox chkDocuments;
        private MetroFramework.Controls.MetroCheckBox chkDBFiles;
        private MetroFramework.Controls.MetroCheckBox chkAll;
        private MetroFramework.Controls.MetroLabel label1;
    }
}

