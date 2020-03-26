using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveCute
{
    public partial class SyncForm : Form
    {
        public FileSync FileSync { get; set; }

        public SyncForm()
        {
            InitializeComponent();
            FileSync = new FileSync();
            Text = "New File Sync";
        }

        public SyncForm(FileSync fs)
        {
            InitializeComponent();
            FileSync = fs;
            SrcBox.Text = fs.SrcMacro;
            DestBox.Text = fs.DestPath;
            Text = "Edit File Sync";
        }

        private void SrcBtn_Click(object sender, EventArgs e)
        {
            SrcFileDlg.ShowDialog();
        }

        private void DestBtn_Click(object sender, EventArgs e)
        {
            DestFileDlg.ShowDialog();
        }

        private void SrcFileDlg_FileOk(object sender, CancelEventArgs e)
        {
            SrcBox.Text = SrcFileDlg.FileName;
        }

        private void DestFileDlg_FileOk(object sender, CancelEventArgs e)
        {
            DestBox.Text = DestFileDlg.FileName;
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            FileSync.SrcMacro = SrcBox.Text;
            FileSync.DestPath = DestBox.Text;
            Close();
        }
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void SrcBox_TextChanged(object sender, EventArgs e)
        {
            UpdateSaveBtnEnabled();
            if (string.IsNullOrWhiteSpace(SrcBox.Text)) return;
            SampleBox.Clear();
            try
            {
                SampleBox.Text = FileSync.EvaluateMacro(SrcBox.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void DestBox_TextChanged(object sender, EventArgs e)
        {
            UpdateSaveBtnEnabled();
        }

        private void UpdateSaveBtnEnabled()
        {
            SaveBtn.Enabled = !string.IsNullOrWhiteSpace(SrcBox.Text) && !string.IsNullOrWhiteSpace(DestBox.Text);
        }
    }
}
