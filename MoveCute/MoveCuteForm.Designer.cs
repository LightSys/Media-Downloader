namespace MoveCute
{
    partial class MoveCuteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoveCuteForm));
            this.EditBtn = new System.Windows.Forms.Button();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.FileSystemWatcher = new System.IO.FileSystemWatcher();
            this.SyncBtn = new System.Windows.Forms.Button();
            this.SyncLst = new System.Windows.Forms.ListBox();
            this.AddBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.ArrowPic = new System.Windows.Forms.PictureBox();
            this.SyncAllBtn = new System.Windows.Forms.Button();
            this.ScheduleBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FileSystemWatcher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrowPic)).BeginInit();
            this.SuspendLayout();
            // 
            // EditBtn
            // 
            this.EditBtn.Enabled = false;
            this.EditBtn.Location = new System.Drawing.Point(592, 317);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(95, 27);
            this.EditBtn.TabIndex = 1;
            this.EditBtn.Text = "Edit";
            this.EditBtn.UseVisualStyleBackColor = true;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(12, 293);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(380, 178);
            this.LogBox.TabIndex = 7;
            // 
            // FileSystemWatcher
            // 
            this.FileSystemWatcher.EnableRaisingEvents = true;
            this.FileSystemWatcher.Path = "C:\\Users\\edric\\Desktop\\folder1";
            this.FileSystemWatcher.SynchronizingObject = this;
            this.FileSystemWatcher.Changed += new System.IO.FileSystemEventHandler(this.FileSystemWatcher_Changed);
            // 
            // SyncBtn
            // 
            this.SyncBtn.Enabled = false;
            this.SyncBtn.Location = new System.Drawing.Point(491, 435);
            this.SyncBtn.Name = "SyncBtn";
            this.SyncBtn.Size = new System.Drawing.Size(95, 27);
            this.SyncBtn.TabIndex = 3;
            this.SyncBtn.Text = "Sync Now";
            this.SyncBtn.UseVisualStyleBackColor = true;
            this.SyncBtn.Click += new System.EventHandler(this.SyncBtn_Click);
            // 
            // SyncLst
            // 
            this.SyncLst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            this.SyncLst.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.SyncLst.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SyncLst.FormattingEnabled = true;
            this.SyncLst.ItemHeight = 30;
            this.SyncLst.Location = new System.Drawing.Point(12, 12);
            this.SyncLst.Name = "SyncLst";
            this.SyncLst.Size = new System.Drawing.Size(776, 244);
            this.SyncLst.TabIndex = 8;
            this.SyncLst.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.DrawSyncListBoxItem);
            this.SyncLst.SelectedIndexChanged += new System.EventHandler(this.SyncList_SelectedIndexChanged);
            this.SyncLst.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SyncLst_MouseDoubleClick);
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(491, 317);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(95, 27);
            this.AddBtn.TabIndex = 0;
            this.AddBtn.Text = "New";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Clicked);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Enabled = false;
            this.DeleteBtn.Location = new System.Drawing.Point(693, 317);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(95, 27);
            this.DeleteBtn.TabIndex = 2;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // ArrowPic
            // 
            this.ArrowPic.Image = ((System.Drawing.Image)(resources.GetObject("ArrowPic.Image")));
            this.ArrowPic.Location = new System.Drawing.Point(738, 209);
            this.ArrowPic.Name = "ArrowPic";
            this.ArrowPic.Size = new System.Drawing.Size(50, 50);
            this.ArrowPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ArrowPic.TabIndex = 11;
            this.ArrowPic.TabStop = false;
            this.ArrowPic.Visible = false;
            // 
            // SyncAllBtn
            // 
            this.SyncAllBtn.Location = new System.Drawing.Point(592, 435);
            this.SyncAllBtn.Name = "SyncAllBtn";
            this.SyncAllBtn.Size = new System.Drawing.Size(95, 27);
            this.SyncAllBtn.TabIndex = 4;
            this.SyncAllBtn.Text = "Sync All";
            this.SyncAllBtn.UseVisualStyleBackColor = true;
            this.SyncAllBtn.Click += new System.EventHandler(this.SyncAllBtn_Click);
            // 
            // ScheduleBtn
            // 
            this.ScheduleBtn.Enabled = false;
            this.ScheduleBtn.Location = new System.Drawing.Point(693, 435);
            this.ScheduleBtn.Name = "ScheduleBtn";
            this.ScheduleBtn.Size = new System.Drawing.Size(95, 27);
            this.ScheduleBtn.TabIndex = 5;
            this.ScheduleBtn.Text = "Sync Schedule";
            this.ScheduleBtn.UseVisualStyleBackColor = true;
            // 
            // MoveCuteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 483);
            this.Controls.Add(this.ScheduleBtn);
            this.Controls.Add(this.SyncAllBtn);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.SyncLst);
            this.Controls.Add(this.SyncBtn);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.EditBtn);
            this.Controls.Add(this.ArrowPic);
            this.Name = "MoveCuteForm";
            this.Text = "MoveCute";
            ((System.ComponentModel.ISupportInitialize)(this.FileSystemWatcher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrowPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.TextBox LogBox;
        private System.IO.FileSystemWatcher FileSystemWatcher;
        private System.Windows.Forms.Button SyncBtn;
        private System.Windows.Forms.ListBox SyncLst;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.PictureBox ArrowPic;
        private System.Windows.Forms.Button ScheduleBtn;
        private System.Windows.Forms.Button SyncAllBtn;
    }
}

