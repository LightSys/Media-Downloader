using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveCute
{
    public partial class MoveCuteForm : Form
    {
        public MoveCuteForm()
        {
            InitializeComponent();
        }

        public void LogLine(params string[] texts)
        {
            // TODO: character limit on the box?
            foreach (string text in texts)
            {
                LogBox.AppendText(text + "\r\n");
            } 
        }

        private void FileSystemWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            // TODO: something useful
            Console.WriteLine(e);
            LogLine("file changed");
        }

        public void CopyFile(string srcpath, string destpath)
        {
            try
            {
                if (!File.Exists(srcpath)) throw new Exception(srcpath + " doesn't exist.");

                // Ensure that the target does not exist.
                if (File.Exists(destpath)) File.Delete(destpath);

                // Copy the file.
                File.Copy(srcpath, destpath);
                LogLine(srcpath + " was copied to " + destpath + ".");

            }
            catch (Exception ex)
            {
                LogLine("Failed while moving file:" + ex.ToString());
            }

        }
        private void SyncList_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool selectionExists = SyncLst.SelectedIndex > -1;
            DeleteBtn.Enabled = selectionExists;
            EditBtn.Enabled = selectionExists;
        }

        private void DrawSyncListBoxItem(object sender, DrawItemEventArgs e)
        {
            ListBox list = (ListBox)sender;

            if (e.Index < 0) return;
            FileSync fs = (FileSync)list.Items[e.Index];

            e.DrawBackground();
            e.DrawFocusRectangle();

            Brush brush = new SolidBrush(e.ForeColor);
            SizeF destSize = e.Graphics.MeasureString(fs.DestPath, e.Font);
            int y = e.Bounds.Top + e.Bounds.Height / 2 - (int)destSize.Height / 2;
            
            e.Graphics.DrawString(fs.SrcMacro, e.Font, brush, 0, y);
            e.Graphics.DrawString(fs.DestPath, e.Font, brush, e.Bounds.Right - destSize.Width, y);

            //arrow
            int cx = e.Bounds.Left + (e.Bounds.Width / 2);
            int width = (int)destSize.Height;
            Rectangle rect = new Rectangle(cx - width/2, y, width, width);
            e.Graphics.DrawImage(ArrowPic.Image, rect); //TODO: better way of getting image?
        }

        private void AddBtn_Clicked(object sender, EventArgs e)
        {
            SyncForm syncForm = new SyncForm();
            syncForm.ShowDialog();

            FileSync fs = syncForm.FileSync;
            if (fs != null)
            {
                SyncLst.Items.Add(fs);
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (SyncLst.SelectedItem == null)
            {
                LogLine("Nothing selected to edit.");
                return;
            }
            SyncForm syncForm = new SyncForm((FileSync)SyncLst.SelectedItem);
            syncForm.ShowDialog(); //blocking
            SyncLst.Refresh();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (SyncLst.SelectedItem == null)
            {
                LogLine("Nothing selected to delete.");
                return;
            }
            SyncLst.Items.Remove(SyncLst.SelectedItem);
        }

        private void SyncLst_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SyncLst.IndexFromPoint(e.Location) == ListBox.NoMatches) return;
            EditBtn_Click(sender, e);
        }
    }
}
