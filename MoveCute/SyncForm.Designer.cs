﻿namespace MoveCute
{
    partial class SyncForm
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
            this.SrcBox = new System.Windows.Forms.TextBox();
            this.DestBox = new System.Windows.Forms.TextBox();
            this.SrcFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.DestFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.SrcBtn = new System.Windows.Forms.Button();
            this.DestBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SampleBox = new System.Windows.Forms.TextBox();
            this.SrcLbl = new System.Windows.Forms.Label();
            this.DestLbl = new System.Windows.Forms.Label();
            this.MatchLbl = new System.Windows.Forms.Label();
            this.WarnLbl = new System.Windows.Forms.Label();
            this.HelpBtn = new System.Windows.Forms.Button();
            this.HourOffsetLabel = new System.Windows.Forms.Label();
            this.OffsetBox = new System.Windows.Forms.NumericUpDown();
            this.OffsetHelpLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SrcBox
            // 
            this.SrcBox.Location = new System.Drawing.Point(12, 35);
            this.SrcBox.Name = "SrcBox";
            this.SrcBox.Size = new System.Drawing.Size(340, 20);
            this.SrcBox.TabIndex = 0;
            this.SrcBox.TextChanged += new System.EventHandler(this.SrcBox_TextChanged);
            // 
            // DestBox
            // 
            this.DestBox.Location = new System.Drawing.Point(12, 177);
            this.DestBox.Name = "DestBox";
            this.DestBox.Size = new System.Drawing.Size(340, 20);
            this.DestBox.TabIndex = 1;
            this.DestBox.TextChanged += new System.EventHandler(this.DestBox_TextChanged);
            // 
            // SrcFileDlg
            // 
            this.SrcFileDlg.CheckFileExists = false;
            this.SrcFileDlg.CheckPathExists = false;
            this.SrcFileDlg.FileName = "file.mp3";
            this.SrcFileDlg.FileOk += new System.ComponentModel.CancelEventHandler(this.SrcFileDlg_FileOk);
            // 
            // DestFileDlg
            // 
            this.DestFileDlg.CheckFileExists = false;
            this.DestFileDlg.CheckPathExists = false;
            this.DestFileDlg.FileName = "file.mp3";
            this.DestFileDlg.FileOk += new System.ComponentModel.CancelEventHandler(this.DestFileDlg_FileOk);
            // 
            // SrcBtn
            // 
            this.SrcBtn.Location = new System.Drawing.Point(361, 33);
            this.SrcBtn.Name = "SrcBtn";
            this.SrcBtn.Size = new System.Drawing.Size(75, 23);
            this.SrcBtn.TabIndex = 2;
            this.SrcBtn.Text = "Choose File";
            this.SrcBtn.UseVisualStyleBackColor = true;
            this.SrcBtn.Click += new System.EventHandler(this.SrcBtn_Click);
            // 
            // DestBtn
            // 
            this.DestBtn.Location = new System.Drawing.Point(361, 177);
            this.DestBtn.Name = "DestBtn";
            this.DestBtn.Size = new System.Drawing.Size(75, 23);
            this.DestBtn.TabIndex = 3;
            this.DestBtn.Text = "Choose File";
            this.DestBtn.UseVisualStyleBackColor = true;
            this.DestBtn.Click += new System.EventHandler(this.DestBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveBtn.Enabled = false;
            this.SaveBtn.Location = new System.Drawing.Point(361, 275);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 5;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.Location = new System.Drawing.Point(280, 275);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 6;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // SampleBox
            // 
            this.SampleBox.Location = new System.Drawing.Point(12, 90);
            this.SampleBox.Multiline = true;
            this.SampleBox.Name = "SampleBox";
            this.SampleBox.ReadOnly = true;
            this.SampleBox.Size = new System.Drawing.Size(340, 23);
            this.SampleBox.TabIndex = 7;
            this.SampleBox.WordWrap = false;
            // 
            // SrcLbl
            // 
            this.SrcLbl.AutoSize = true;
            this.SrcLbl.Location = new System.Drawing.Point(9, 19);
            this.SrcLbl.Name = "SrcLbl";
            this.SrcLbl.Size = new System.Drawing.Size(111, 13);
            this.SrcLbl.TabIndex = 8;
            this.SrcLbl.Text = "Source Search Macro";
            // 
            // DestLbl
            // 
            this.DestLbl.AutoSize = true;
            this.DestLbl.Location = new System.Drawing.Point(9, 161);
            this.DestLbl.Name = "DestLbl";
            this.DestLbl.Size = new System.Drawing.Size(79, 13);
            this.DestLbl.TabIndex = 9;
            this.DestLbl.Text = "Destination File";
            // 
            // MatchLbl
            // 
            this.MatchLbl.AutoSize = true;
            this.MatchLbl.Location = new System.Drawing.Point(9, 74);
            this.MatchLbl.Name = "MatchLbl";
            this.MatchLbl.Size = new System.Drawing.Size(56, 13);
            this.MatchLbl.TabIndex = 10;
            this.MatchLbl.Text = "File Match";
            // 
            // WarnLbl
            // 
            this.WarnLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.WarnLbl.Location = new System.Drawing.Point(18, 253);
            this.WarnLbl.Name = "WarnLbl";
            this.WarnLbl.Size = new System.Drawing.Size(418, 19);
            this.WarnLbl.TabIndex = 11;
            this.WarnLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // HelpBtn
            // 
            this.HelpBtn.Location = new System.Drawing.Point(12, 119);
            this.HelpBtn.Name = "HelpBtn";
            this.HelpBtn.Size = new System.Drawing.Size(75, 23);
            this.HelpBtn.TabIndex = 12;
            this.HelpBtn.Text = "Macro Help";
            this.HelpBtn.UseVisualStyleBackColor = true;
            this.HelpBtn.Click += new System.EventHandler(this.HelpBtn_Click);
            // 
            // HourOffsetLabel
            // 
            this.HourOffsetLabel.AutoSize = true;
            this.HourOffsetLabel.Location = new System.Drawing.Point(12, 209);
            this.HourOffsetLabel.Name = "HourOffsetLabel";
            this.HourOffsetLabel.Size = new System.Drawing.Size(66, 13);
            this.HourOffsetLabel.TabIndex = 14;
            this.HourOffsetLabel.Text = "Hours Offset";
            // 
            // OffsetBox
            // 
            this.OffsetBox.Location = new System.Drawing.Point(12, 225);
            this.OffsetBox.Maximum = new decimal(new int[] {
            72,
            0,
            0,
            0});
            this.OffsetBox.Minimum = new decimal(new int[] {
            72,
            0,
            0,
            -2147483648});
            this.OffsetBox.Name = "OffsetBox";
            this.OffsetBox.Size = new System.Drawing.Size(120, 20);
            this.OffsetBox.TabIndex = 15;
            this.OffsetBox.ValueChanged += new System.EventHandler(this.OffsetBox_ValueChanged);
            // 
            // OffsetHelpLabel
            // 
            this.OffsetHelpLabel.AutoSize = true;
            this.OffsetHelpLabel.Location = new System.Drawing.Point(138, 227);
            this.OffsetHelpLabel.Name = "OffsetHelpLabel";
            this.OffsetHelpLabel.Size = new System.Drawing.Size(219, 13);
            this.OffsetHelpLabel.TabIndex = 16;
            this.OffsetHelpLabel.Text = "A Negative offset makes dates match sooner";
            // 
            // SyncForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 310);
            this.Controls.Add(this.OffsetHelpLabel);
            this.Controls.Add(this.OffsetBox);
            this.Controls.Add(this.HourOffsetLabel);
            this.Controls.Add(this.HelpBtn);
            this.Controls.Add(this.WarnLbl);
            this.Controls.Add(this.MatchLbl);
            this.Controls.Add(this.DestLbl);
            this.Controls.Add(this.SrcLbl);
            this.Controls.Add(this.SampleBox);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.DestBtn);
            this.Controls.Add(this.SrcBtn);
            this.Controls.Add(this.DestBox);
            this.Controls.Add(this.SrcBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "SyncForm";
            this.Text = "New File Sync";
            ((System.ComponentModel.ISupportInitialize)(this.OffsetBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SrcBox;
        private System.Windows.Forms.TextBox DestBox;
        private System.Windows.Forms.OpenFileDialog SrcFileDlg;
        private System.Windows.Forms.OpenFileDialog DestFileDlg;
        private System.Windows.Forms.Button SrcBtn;
        private System.Windows.Forms.Button DestBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.TextBox SampleBox;
        private System.Windows.Forms.Label SrcLbl;
        private System.Windows.Forms.Label DestLbl;
        private System.Windows.Forms.Label MatchLbl;
        private System.Windows.Forms.Label WarnLbl;
        private System.Windows.Forms.Button HelpBtn;
        private System.Windows.Forms.Label HourOffsetLabel;
        private System.Windows.Forms.NumericUpDown OffsetBox;
        private System.Windows.Forms.Label OffsetHelpLabel;
    }
}