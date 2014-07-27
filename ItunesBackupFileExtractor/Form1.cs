using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using MetroFramework.Forms;


namespace ItunesBackupFileExtractor
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private string[] BackupFiles;
        private IEnumerable<ExtensionTypeElem> ExtensionTypeList;
        private string OutputFolder;
        private string iTunesBackupFolder;
        private List<string> checkedCheckbox;

        public Form1()
        {
            
            InitializeComponent();
        }

        /// <summary>
        /// On loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //Print the app version on the form title
            this.Text += string.Format(" v{0}", Application.ProductVersion);
            checkedCheckbox = null;
        }

        /// <summary>
        /// Browse iTunes backup folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBackupFolderBrowse_Click(object sender, EventArgs e)
        {
            txtBackupFolder.Text = BrowseMe();
        }

        /// <summary>
        /// Browse output folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOutputFolderBrowse_Click(object sender, EventArgs e)
        {
            txtOutputFolder.Text = BrowseMe();
        }

        /// <summary>
        /// On Launch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLaunch_Click(object sender, EventArgs e)
        {
            try
            {
                if (backgroundWorker1.IsBusy != true)
                {
                    if (string.IsNullOrEmpty(txtBackupFolder.Text) || string.IsNullOrEmpty(txtOutputFolder.Text))
                    {
                        throw new Exception("Please select the iTunes backup folder and the output folder.");
                    }

                    OutputFolder = txtOutputFolder.Text.EndsWith("\\") ? txtOutputFolder.Text : txtOutputFolder.Text + "\\";
                    iTunesBackupFolder = txtBackupFolder.Text.EndsWith("\\") ? txtBackupFolder.Text : txtBackupFolder.Text + "\\";

                    //Getting files from selected directory
                    BackupFiles = Directory.GetFiles(iTunesBackupFolder, "*.*", SearchOption.TopDirectoryOnly);
                    if (BackupFiles.Count() == 0)
                    {
                        throw new Exception("Nothing found in your iTunes backup folder. Select the right folder and try again.");
                    }

                    if (checkedCheckbox == null || checkedCheckbox.Count==0)
                    {
                        throw new Exception("Please select a checkbox.");
                    }

                    //Getting file extensions from the config file
                    ExtensionTypeList = GetExtensionTypeList();

                    //Launch background worker
                    backgroundWorker1.RunWorkerAsync();

                    btnLaunch.Enabled = false;
                    btnCancel.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// On chkAll Checked Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            var checkboxes = from c in this.Controls.OfType<CheckBox>()
                             select c;
            checkboxes.ToList().ForEach(c => c.Checked = chkAll.Checked);
        }

        /// <summary>
        /// On checkBox Checked Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            var checkboxes = from c in this.Controls.OfType<CheckBox>()
                             where c.Checked
                             select c.Text;

            checkedCheckbox=checkboxes.ToList();
        }

        /// <summary>
        /// On Button Cancel Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                backgroundWorker1.CancelAsync();
            }
        }

        /// <summary>
        /// On Background Worker is doing is Hard Work
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            List<MbdbExtract.MBDBFile> MbdbFileList = MbdbExtract.ReadMBDB(iTunesBackupFolder);

            if (MbdbFileList==null)
            {
                throw new Exception("Bad MBDB file.");
            }

            if (!checkedCheckbox.Contains("All"))
            {
                //Get all the extensions corresponding to the checked chekbox
                var extensionType = ExtensionTypeList.Where(et => checkedCheckbox.Contains(et.Type)).Select(m => m.Extension);

                //Only get the files with the right extension
                MbdbFileList = MbdbFileList.Where(bf => !string.IsNullOrEmpty(Path.GetExtension(bf.FilePath)) && extensionType.Contains(Path.GetExtension(bf.FilePath).Replace(".", ""))).ToList();
            }

            //Ok let's go!
            foreach (string filename in BackupFiles)
            { 
                //Check if the operation has been canceled
                if (backgroundWorker1.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }

                String FilenameWithExtension = Path.GetFileName(filename);
                string[] FilenameSplit = FilenameWithExtension.Split('.');
                string ext = FilenameSplit.Count() == 1 ? FilenameWithExtension : null;
                if (ext != null)
                {
                    //
                    var backupfile = MbdbFileList.Where(bf => bf.EncryptedFilename == ext).Select(bf => bf.FilePath);
                    
                    //if backupfile has element we get the first one
                    string path=backupfile.Count() > 0 ? backupfile.FirstOrDefault() : null;
                    if (!string.IsNullOrEmpty(path))
                    {
                        File.Copy(filename, OutputFolder+ Path.GetFileName(path), true);
                    }
                }
            }
        }

        /// <summary>
        /// On job completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnCancel.Enabled = false;
            btnLaunch.Enabled = true;

            if (e.Cancelled == true)
            {
                MessageBox.Show("Backup extract canceled!", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Backup extract done!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Browse folder and return the selected path
        /// </summary>
        /// <returns></returns>
        public static string BrowseMe()
        {
            string folder = string.Empty;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                folder = fbd.SelectedPath;
            }
            return folder;
        }

        /// <summary>
        /// Get all the ExtensionTypeElement contained in the config file
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ExtensionTypeElem> GetExtensionTypeList()
        {
            ConfigHelper section = (ConfigHelper)ConfigurationManager.GetSection("ExtensionTypeList");
            if (section != null)
            {
                return section.ETCol.Cast<ExtensionTypeElem>();
            }
            else
            {
                throw new Exception("Bad file format. Check your config file and try again.");
            }
        }

    }
}
