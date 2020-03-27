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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoveCuteForm));
            this.EditBtn = new System.Windows.Forms.Button();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.SyncBtn = new System.Windows.Forms.Button();
            this.SyncList = new System.Windows.Forms.ListBox();
            this.AddBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.ArrowPic = new System.Windows.Forms.PictureBox();
            this.SyncAllBtn = new System.Windows.Forms.Button();
            this.SyncTimer = new System.Windows.Forms.Timer(this.components);
            this.FreqTrackBar = new System.Windows.Forms.TrackBar();
            this.FreqLabel = new System.Windows.Forms.Label();
            this.FreqValueDisplay = new System.Windows.Forms.Label();
            this.LogLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ArrowPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FreqTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // EditBtn
            // 
            this.EditBtn.Enabled = false;
            this.EditBtn.Location = new System.Drawing.Point(592, 284);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(95, 36);
            this.EditBtn.TabIndex = 1;
            this.EditBtn.Text = "Edit";
            this.EditBtn.UseVisualStyleBackColor = true;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // LogBox
            // 
            this.LogBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.LogBox.Location = new System.Drawing.Point(12, 293);
            this.LogBox.MaxLength = 50;
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogBox.Size = new System.Drawing.Size(454, 154);
            this.LogBox.TabIndex = 7;
            // 
            // SyncBtn
            // 
            this.SyncBtn.Enabled = false;
            this.SyncBtn.Location = new System.Drawing.Point(592, 411);
            this.SyncBtn.Name = "SyncBtn";
            this.SyncBtn.Size = new System.Drawing.Size(95, 36);
            this.SyncBtn.TabIndex = 3;
            this.SyncBtn.Text = "Sync Now";
            this.SyncBtn.UseVisualStyleBackColor = true;
            this.SyncBtn.Click += new System.EventHandler(this.SyncBtn_Click);
            // 
            // SyncList
            // 
            this.SyncList.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.SyncList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.SyncList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SyncList.FormattingEnabled = true;
            this.SyncList.ItemHeight = 30;
            this.SyncList.Location = new System.Drawing.Point(12, 12);
            this.SyncList.Name = "SyncList";
            this.SyncList.Size = new System.Drawing.Size(776, 244);
            this.SyncList.TabIndex = 8;
            this.SyncList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.DrawSyncListBoxItem);
            this.SyncList.SelectedIndexChanged += new System.EventHandler(this.SyncList_SelectedIndexChanged);
            this.SyncList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SyncList_MouseDoubleClick);
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(491, 284);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(95, 36);
            this.AddBtn.TabIndex = 0;
            this.AddBtn.Text = "New";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Clicked);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Enabled = false;
            this.DeleteBtn.Location = new System.Drawing.Point(693, 284);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(95, 36);
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
            this.SyncAllBtn.Location = new System.Drawing.Point(693, 411);
            this.SyncAllBtn.Name = "SyncAllBtn";
            this.SyncAllBtn.Size = new System.Drawing.Size(95, 36);
            this.SyncAllBtn.TabIndex = 4;
            this.SyncAllBtn.Text = "Sync All Now";
            this.SyncAllBtn.UseVisualStyleBackColor = true;
            this.SyncAllBtn.Click += new System.EventHandler(this.SyncAllBtn_Click);
            // 
            // SyncTimer
            // 
            this.SyncTimer.Interval = 15000;
            this.SyncTimer.Tick += new System.EventHandler(this.SyncTimer_Tick);
            // 
            // FreqTrackBar
            // 
            this.FreqTrackBar.LargeChange = 1;
            this.FreqTrackBar.Location = new System.Drawing.Point(592, 360);
            this.FreqTrackBar.Maximum = 5;
            this.FreqTrackBar.Name = "FreqTrackBar";
            this.FreqTrackBar.Size = new System.Drawing.Size(196, 45);
            this.FreqTrackBar.TabIndex = 13;
            this.FreqTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.FreqTrackBar.Value = 5;
            this.FreqTrackBar.Scroll += new System.EventHandler(this.FreqTrackBar_Scroll);
            // 
            // FreqLabel
            // 
            this.FreqLabel.AutoSize = true;
            this.FreqLabel.Location = new System.Drawing.Point(564, 344);
            this.FreqLabel.Name = "FreqLabel";
            this.FreqLabel.Size = new System.Drawing.Size(112, 13);
            this.FreqLabel.TabIndex = 14;
            this.FreqLabel.Text = "Auto Sync Frequency:";
            // 
            // FreqValueDisplay
            // 
            this.FreqValueDisplay.AutoSize = true;
            this.FreqValueDisplay.Location = new System.Drawing.Point(682, 344);
            this.FreqValueDisplay.Name = "FreqValueDisplay";
            this.FreqValueDisplay.Size = new System.Drawing.Size(73, 13);
            this.FreqValueDisplay.TabIndex = 15;
            this.FreqValueDisplay.Text = "Auto Sync Off";
            // 
            // LogLabel
            // 
            this.LogLabel.AutoSize = true;
            this.LogLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogLabel.Location = new System.Drawing.Point(12, 275);
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(68, 16);
            this.LogLabel.TabIndex = 16;
            this.LogLabel.Text = "Event Log";
            // 
            // MoveCuteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 459);
            this.Controls.Add(this.LogLabel);
            this.Controls.Add(this.FreqValueDisplay);
            this.Controls.Add(this.FreqLabel);
            this.Controls.Add(this.FreqTrackBar);
            this.Controls.Add(this.SyncAllBtn);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.SyncList);
            this.Controls.Add(this.SyncBtn);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.EditBtn);
            this.Controls.Add(this.ArrowPic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MoveCuteForm";
            this.Text = "MoveCute";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MoveCuteForm_FormClosing);
            this.Load += new System.EventHandler(this.MoveCuteForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ArrowPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FreqTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.TextBox LogBox;
        private System.Windows.Forms.Button SyncBtn;
        private System.Windows.Forms.ListBox SyncList;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.PictureBox ArrowPic;
        private System.Windows.Forms.Button SyncAllBtn;
        private System.Windows.Forms.Timer SyncTimer;
        private System.Windows.Forms.TrackBar FreqTrackBar;
        private System.Windows.Forms.Label FreqLabel;
        private System.Windows.Forms.Label FreqValueDisplay;
        private System.Windows.Forms.Label LogLabel;
    }
}

