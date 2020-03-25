namespace MoveCute
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
            this.label1 = new System.Windows.Forms.Label();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SrcLbl = new System.Windows.Forms.Label();
            this.DestLbl = new System.Windows.Forms.Label();
            this.MatchLbl = new System.Windows.Forms.Label();
            this.warnLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SrcBox
            // 
            this.SrcBox.Location = new System.Drawing.Point(15, 36);
            this.SrcBox.Name = "SrcBox";
            this.SrcBox.Size = new System.Drawing.Size(324, 20);
            this.SrcBox.TabIndex = 0;
            this.SrcBox.TextChanged += new System.EventHandler(this.SrcBox_TextChanged);
            // 
            // DestBox
            // 
            this.DestBox.Location = new System.Drawing.Point(15, 234);
            this.DestBox.Name = "DestBox";
            this.DestBox.Size = new System.Drawing.Size(324, 20);
            this.DestBox.TabIndex = 1;
            this.DestBox.TextChanged += new System.EventHandler(this.DestBox_TextChanged);
            // 
            // SrcFileDlg
            // 
            this.SrcFileDlg.FileName = "openFileDialog1";
            this.SrcFileDlg.FileOk += new System.ComponentModel.CancelEventHandler(this.SrcFileDlg_FileOk);
            // 
            // DestFileDlg
            // 
            this.DestFileDlg.FileName = "openFileDialog2";
            this.DestFileDlg.FileOk += new System.ComponentModel.CancelEventHandler(this.DestFileDlg_FileOk);
            // 
            // SrcBtn
            // 
            this.SrcBtn.Location = new System.Drawing.Point(345, 33);
            this.SrcBtn.Name = "SrcBtn";
            this.SrcBtn.Size = new System.Drawing.Size(75, 23);
            this.SrcBtn.TabIndex = 2;
            this.SrcBtn.Text = "Choose File";
            this.SrcBtn.UseVisualStyleBackColor = true;
            this.SrcBtn.Click += new System.EventHandler(this.SrcBtn_Click);
            // 
            // DestBtn
            // 
            this.DestBtn.Location = new System.Drawing.Point(345, 234);
            this.DestBtn.Name = "DestBtn";
            this.DestBtn.Size = new System.Drawing.Size(75, 23);
            this.DestBtn.TabIndex = 3;
            this.DestBtn.Text = "Choose File";
            this.DestBtn.UseVisualStyleBackColor = true;
            this.DestBtn.Click += new System.EventHandler(this.DestBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 78);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1label1label1label1label1labe\r\nl1label1label1label1la\r\nbel1label1label1label" +
    "\r\n1label1label1label1la\r\nbel1label1label1label\r\n1label1label1label1label1";
            // 
            // SaveBtn
            // 
            this.SaveBtn.Enabled = false;
            this.SaveBtn.Location = new System.Drawing.Point(361, 343);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 5;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(280, 343);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 6;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(15, 90);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(324, 23);
            this.textBox3.TabIndex = 7;
            // 
            // SrcLbl
            // 
            this.SrcLbl.AutoSize = true;
            this.SrcLbl.Location = new System.Drawing.Point(12, 20);
            this.SrcLbl.Name = "SrcLbl";
            this.SrcLbl.Size = new System.Drawing.Size(111, 13);
            this.SrcLbl.TabIndex = 8;
            this.SrcLbl.Text = "Source Search Macro";
            // 
            // DestLbl
            // 
            this.DestLbl.AutoSize = true;
            this.DestLbl.Location = new System.Drawing.Point(12, 218);
            this.DestLbl.Name = "DestLbl";
            this.DestLbl.Size = new System.Drawing.Size(79, 13);
            this.DestLbl.TabIndex = 9;
            this.DestLbl.Text = "Destination File";
            // 
            // MatchLbl
            // 
            this.MatchLbl.AutoSize = true;
            this.MatchLbl.Location = new System.Drawing.Point(15, 71);
            this.MatchLbl.Name = "MatchLbl";
            this.MatchLbl.Size = new System.Drawing.Size(56, 13);
            this.MatchLbl.TabIndex = 10;
            this.MatchLbl.Text = "File Match";
            // 
            // warnLbl
            // 
            this.warnLbl.AutoSize = true;
            this.warnLbl.Location = new System.Drawing.Point(12, 314);
            this.warnLbl.Name = "warnLbl";
            this.warnLbl.Size = new System.Drawing.Size(90, 13);
            this.warnLbl.TabIndex = 11;
            this.warnLbl.Text = "Warning Warning";
            // 
            // SyncForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 378);
            this.Controls.Add(this.warnLbl);
            this.Controls.Add(this.MatchLbl);
            this.Controls.Add(this.DestLbl);
            this.Controls.Add(this.SrcLbl);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DestBtn);
            this.Controls.Add(this.SrcBtn);
            this.Controls.Add(this.DestBox);
            this.Controls.Add(this.SrcBox);
            this.Name = "SyncForm";
            this.Text = "New File Sync";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label SrcLbl;
        private System.Windows.Forms.Label DestLbl;
        private System.Windows.Forms.Label MatchLbl;
        private System.Windows.Forms.Label warnLbl;
    }
}