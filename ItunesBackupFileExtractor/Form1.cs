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


namespace ItunesBackupFileExtractor
{
    public partial class Form1 : Form
    {
        private string[] BackupFiles;
        private IEnumerable<MagicNumberElem> MagicNumberList;
        private string OutputFolder;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text += string.Format(" v{0}", Application.ProductVersion);
        }

        private void btnBackupFolderBrowse_Click(object sender, EventArgs e)
        {
            txtBackupFolder.Text = BrowseMe();
        }

        private void btnOutputFolderBrowse_Click(object sender, EventArgs e)
        {
            txtOutputFolder.Text = BrowseMe();
        }

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

                    OutputFolder = txtOutputFolder.Text.EndsWith("\\") ? txtOutputFolder.Text : txtOutputFolder.Text +"\\";
                    BackupFiles = Directory.GetFiles(txtBackupFolder.Text, "*.*", SearchOption.TopDirectoryOnly);
                    if (BackupFiles.Count() == 0)
                    {
                        throw new Exception("Nothing found in your iTunes backup folder. Select the right folder and try again.");
                    }

                    MagicNumberList = GetMagicNumberList();

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                backgroundWorker1.CancelAsync();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (string filename in BackupFiles)
            {
                if (backgroundWorker1.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }

                String FilenameWithExtension = Path.GetFileName(filename);
                string[] FilenameSplit = FilenameWithExtension.Split('.');
                string ext = FilenameSplit.Count() == 1 ? GetExtension(filename, MagicNumberList) : null;
                if (ext != null)
                {
                    File.Copy(filename, Path.ChangeExtension(OutputFolder + FilenameWithExtension, ext),true);
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

            if ((e.Cancelled == true))
            {
                MessageBox.Show("Backup extract canceled!", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!(e.Error == null))
            {
                MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Backup extract done!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Browse and return the selected path
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
        /// Extract the extension from the file
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="MagicNumberList"></param>
        /// <returns></returns>
        public static string GetExtension(string filename, IEnumerable<MagicNumberElem> MagicNumberList)
        {
            using (BinaryReader br = new BinaryReader(File.Open(filename, FileMode.Open)))
            {
                byte[] buffer = new byte[16];
                buffer = br.ReadBytes(16);
                string HexString = GetHexStringByByteArray(buffer);
                var extension = MagicNumberList.Where(m => HexString.Contains(m.MagicNumber)).Select(m => m.Extension);
                return extension.Count() > 0 ? extension.FirstOrDefault() : null;
            }
        }

        /// <summary>
        /// Concat the byte array in a string
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string GetHexStringByByteArray(byte[] buffer)
        {
            string HexString = string.Empty;
            foreach (byte b in buffer)
            {
                HexString += b.ToString("X2");
            }
            return HexString;
        }

        /// <summary>
        /// Get all the MagicNumberElement contained in the config file
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<MagicNumberElem> GetMagicNumberList()
        {
            ConfigHelper section = (ConfigHelper)ConfigurationManager.GetSection("MagicNumberList");
            if (section != null)
            {
                return section.MNCol.Cast<MagicNumberElem>();
            }
            else
            {
                throw new Exception("Bad file format. Check your config file and try again.");
            }
        }
    }
}
