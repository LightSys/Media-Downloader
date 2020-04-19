using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace MoveCute
{
    public partial class MoveCuteForm : Form
    {
        private static readonly int[] SyncDurations =
        {
            60 * 1000,
            30 * 60 * 1000,
            2 * 60 * 60 * 1000,
            8 * 60 * 60 * 1000,
            24 * 60 * 60 * 1000,
            -1
        };

        private static readonly string[] SyncDurationTitles =
        {
            "1 minute",
            "30 minutes",
            "2 hours",
            "8 hours",
            "24 hours",
            "Auto Sync Off",
        };

        public enum CopyResult{
            Success,
            UpToDate,
            Fail
        };

        private const int LOG_MAX_LENGTH = 3000;
        private const string DATETIME_FORMAT = "MMM d, HH:mm";
        private const string TIME_FORMAT = "HH:mm";
        private const string XML_FILE_PATH = @"MoveCute_data/fs.xml";

        public MoveCuteForm()
        {
            InitializeComponent();
        }

        private void MoveCuteForm_Load(object sender, EventArgs e)
        {
            LoadFSFile();
        }

        private void MoveCuteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StoreFSFile();
        }

        public void LogLine(params string[] texts)
        {
            // TODO: avoid scrolling if LogBox has focus
            foreach (string text in texts)
            {
                string timestamp = "[" + DateTime.Now.ToString(DATETIME_FORMAT) + "] ";
                string messsage = timestamp + text + "\r\n";
                LogBox.AppendText(messsage);
            }

            // trim text
            string t = LogBox.Text;
            if (t.Length > LOG_MAX_LENGTH)
            {
                int index = t.IndexOf('\n', t.Length - LOG_MAX_LENGTH);
                LogBox.Text = t.Substring(index + 1);
                LogBox.SelectionLength = LogBox.TextLength;
                LogBox.ScrollToCaret();
            }

        }

        private void SyncList_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool selectionExists = SyncList.SelectedIndex > -1;
            DeleteBtn.Enabled = selectionExists;
            EditBtn.Enabled = selectionExists;
            SyncBtn.Enabled = selectionExists;
        }

        private void DrawSyncListBoxItem(object sender, DrawItemEventArgs e)
        {
            ListBox list = (ListBox)sender;

            if (e.Index < 0) return;
            FileSync fs = (FileSync)list.Items[e.Index];

            e.DrawBackground();
            e.DrawFocusRectangle();

            Brush brush = new SolidBrush(e.ForeColor);
            int textHeight = e.Font.Height;
            
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.FormatFlags = StringFormatFlags.NoWrap;

            Rectangle rect = new Rectangle();
            rect.Y = e.Bounds.Top;
            rect.Width = e.Bounds.Width/2 - textHeight/2;
            rect.Height = e.Bounds.Height;

            // Left string
            format.Alignment = StringAlignment.Near;
            rect.X = e.Bounds.Left;
            string display = EllipsizeFront(fs.SrcMacro, rect.Width, e);
            e.Graphics.DrawString(display, e.Font, brush, rect, format);

            // Right string
            format.Alignment = StringAlignment.Far;
            rect.X = e.Bounds.Left + e.Bounds.Width/2 + textHeight/2;
            display = EllipsizeFront(fs.DestPath, rect.Width, e);
            e.Graphics.DrawString(display, e.Font, brush, rect, format);

            //arrow
            int cx = e.Bounds.Left + (e.Bounds.Width/2);
            int cy = e.Bounds.Top + (e.Bounds.Height/2);
            int width = textHeight;
            rect = new Rectangle(cx - width/2, cy - textHeight/2, width, textHeight);
            e.Graphics.DrawImage(ArrowPic.Image, rect); //TODO: better way of getting image?
        }

        private string EllipsizeFront(string s, int width, DrawItemEventArgs e)
        {
            if (e.Graphics.MeasureString(s, e.Font).Width <= width) return s;

            s = "..." + s;
            while (e.Graphics.MeasureString(s, e.Font).Width > width)
            {
                s = "..." + s.Substring(4);
            }

            return s;
        }

        private void AddBtn_Clicked(object sender, EventArgs e)
        {
            SyncForm syncForm = new SyncForm();
            syncForm.ShowDialog(); // blocking
            
            FileSync fs = syncForm.FileSync;

            if (string.IsNullOrWhiteSpace(fs.SrcMacro)) return;
            if (string.IsNullOrWhiteSpace(fs.DestPath)) return;
            
            SyncList.Items.Add(fs);

            StoreFSFile(); // maybe don't need this here.
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (SyncList.SelectedItem == null)
            {
                LogLine("Nothing selected to edit.");
                return;
            }
            SyncForm syncForm = new SyncForm((FileSync)SyncList.SelectedItem);
            syncForm.ShowDialog(); // blocking

            StoreFSFile(); // maybe don't need this here.
            SyncList.Refresh();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (SyncList.SelectedItem == null)
            {
                LogLine("Nothing selected to delete.");
                return;
            }

            SyncList.Items.Remove(SyncList.SelectedItem);
            
            if (SyncList.SelectedItem == null) AddBtn.Focus(); // avoid default focus on "Sync All" button
        }

        private void SyncList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SyncList.IndexFromPoint(e.Location) == ListBox.NoMatches) return;
            EditBtn_Click(sender, e);
        }

        public CopyResult CopyFile(FileSync fs, out string message)
        {
            try
            {
                string srcPath = fs.SrcPath; // calculates from SrcMacro
                string destPath = fs.DestPath;
                if (string.IsNullOrWhiteSpace(srcPath)) throw new Exception($"Macro didn't match anything.");
                if (!File.Exists(srcPath)) throw new Exception($"{srcPath} doesn't exist.");

                if (File.Exists(destPath))
                {
                    if (FilesAreEqual(srcPath, destPath))
                    {
                        message = $"{destPath} already up to date.";
                        return CopyResult.UpToDate;
                    }
                    else File.Delete(destPath);
                }

                File.Copy(srcPath, destPath);
                message = $"{srcPath} was copied to {destPath}";
                return CopyResult.Success;
            }
            catch (Exception ex)
            {
                message = $"Failed to copy to {fs.DestPath}:" + ex.Message;
                return CopyResult.Fail;
            }
        }

        private void SyncBtn_Click(object sender, EventArgs e)
        {
            if (SyncList.SelectedItem == null) LogLine("Nothing selected to sync.");

            FileSync fs = (FileSync)SyncList.SelectedItem;
            CopyFile(fs, out string message);
            LogLine(message);
        }

        private void SyncAllBtn_Click(object sender, EventArgs e)
        {
            if (SyncList.Items.Count == 0)
            {
                LogLine("Nothing to sync.");
                return;
            }
            int successes = 0;
            int upToDates = 0;
            int failures = 0;
            foreach (FileSync fs in SyncList.Items)
            {
                CopyResult copyResult = CopyFile(fs, out _);

                switch (copyResult)
                {
                    case CopyResult.Success:
                        successes++;
                        break;
                    case CopyResult.UpToDate:
                        upToDates++;
                        break;
                    case CopyResult.Fail:
                        failures++;
                        break;
                }
            }
            //TODO: get message from CopyFile, save to log file

            LogLine($"Sync Finished: {successes} copied. {upToDates} up-to-date. {failures} failed.");
        }

        private string CalculateNextTimeString(int duration)
        {
            if (duration < 0) return "";
            DateTime nextScheduled = DateTime.Now.AddMilliseconds(duration);
            return nextScheduled.ToString(TIME_FORMAT);
        }

        private void StartSyncTimer(int duration)
        {
            SyncTimer.Stop();
            if (duration < 0) return;
            SyncTimer.Interval = duration;
            SyncTimer.Start();
        }

        private void SyncTimer_Tick(object sender, EventArgs e)
        {
            LogLine("Starting Auto Sync...");
            SyncAllBtn_Click(sender, e);
            var now = DateTime.Now;
            var last = DateTime.ParseExact(NextSyncBox.Text, TIME_FORMAT, new CultureInfo("en-US"));
            var next = last.AddMilliseconds(SyncDurations[FreqTrackBar.Value]);
            var duration = next - now;
            //TODO: duration could be negative if sync takes too long (like reallly long).

            int ms = (int)duration.TotalMilliseconds;
            StartSyncTimer(ms);
            NextSyncBox.Text = CalculateNextTimeString(ms);
            NextSyncBox.Enabled = false;
            NextSyncBtn.Text = "Edit";
        }

        private void FreqTrackBar_Scroll(object sender, EventArgs e)
        {
            //TODO: maybe store value on close

            int idx = FreqTrackBar.Value;
            int duration = SyncDurations[idx];
            string title = SyncDurationTitles[idx];
            FreqValueDisplay.Text = title;

            StartSyncTimer(duration);
            NextSyncBox.Text = CalculateNextTimeString(duration);
            NextSyncBox.Enabled = false;
            NextSyncBtn.Text = "Edit";
        }

        private void NextSyncBtn_Click(object sender, EventArgs e)
        {
            bool saving = NextSyncBox.Enabled;
            //switch state
            NextSyncBtn.Text = saving ? "Edit" : "Save";
            NextSyncBox.Enabled = !saving;

            if (saving)
            {
                try
                {
                    var now = DateTime.Now;
                    var next = DateTime.ParseExact(NextSyncBox.Text, TIME_FORMAT, new CultureInfo("en-US"));
                    var duration = next - now;
                    if (duration.TotalMilliseconds < 0) duration = duration.Add(TimeSpan.FromDays(1));
                    StartSyncTimer((int)duration.TotalMilliseconds);
                    //TODO: proper string pluralization
                    int m = (int)Math.Round(duration.TotalMinutes);
                    int h = m / 60;
                    m = m % 60;
                    LogLine($"Sync scheduled for {h} hours and {m} minutes from now.");
                }
                catch (FormatException)
                {
                    LogLine("Failed to parse time: " + NextSyncBox.Text);
                    //TODO: this might be wrong. maybe should avoid changing timer and just find the right thing to put in the box.
                    int duration = SyncDurations[FreqTrackBar.Value];
                    StartSyncTimer(duration);
                    NextSyncBox.Text = CalculateNextTimeString(duration);
                }
            }
            else
            {
                // need to save the time we are about to edit?
                NextSyncBox.Focus();
            }
        }

        private void NextSyncBox_DoubleClick(object sender, EventArgs e)
        {
            //TODO: can't double click disabled box
            if (!NextSyncBox.Enabled) NextSyncBtn_Click(sender, e);
        }

        private void NextSyncBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!NextSyncBox.Enabled) return;
            if (e.KeyChar == (char)13) //enter
            {
                NextSyncBtn_Click(sender, e);
                e.Handled = true;
                //NextSyncBtn.Focus();
            }
        }

        private void StoreFSFile()
        {
            var fsArr = SyncList.Items.Cast<FileSync>().ToArray();

            Directory.CreateDirectory("MoveCute_data"); //noop if dir exists
            
            SerializeObject(fsArr, XML_FILE_PATH);
        }

        private void LoadFSFile()
        {
            // TODO: probably do this asynchronously
            var fsArr = DeSerializeObject<FileSync[]>(XML_FILE_PATH);
            if (fsArr == null)
            {
                LogLine("No previous configuration found.");
                return;
            }

            foreach (FileSync fs in fsArr)
            {
                SyncList.Items.Add(fs);
            }
        }

        // https://stackoverflow.com/questions/1358510
        static bool FilesAreEqual(string srcPath, string destPath)
        {
            const int BYTES_TO_READ = sizeof(long);

            FileInfo first = new FileInfo(srcPath);
            FileInfo second = new FileInfo(destPath);

            if (first.Length != second.Length)
                return false;

            int iterations = (int)Math.Ceiling((double)first.Length / BYTES_TO_READ);

            using (FileStream fs1 = first.OpenRead())
            using (FileStream fs2 = second.OpenRead())
            {
                byte[] one = new byte[BYTES_TO_READ];
                byte[] two = new byte[BYTES_TO_READ];

                for (int i = 0; i < iterations; i++)
                {
                    fs1.Read(one, 0, BYTES_TO_READ);
                    fs2.Read(two, 0, BYTES_TO_READ);

                    if (BitConverter.ToInt64(one, 0) != BitConverter.ToInt64(two, 0))
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializableObject"></param>
        /// <param name="fileName"></param>
        /// https://stackoverflow.com/questions/6115721/
        public void SerializeObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null) return;

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Deserializes an xml file into an object list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns>The deserialized object after reading the file successfully.</returns>
        public T DeSerializeObject<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) { return default; }

            T objectOut = default;

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(T);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                    }
                }
            }
            catch (Exception) { }

            return objectOut;
        }
    }
}
