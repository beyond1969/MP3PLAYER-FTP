namespace Server
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ipText = new System.Windows.Forms.TextBox();
            this.portText = new System.Windows.Forms.TextBox();
            this.pathText = new System.Windows.Forms.TextBox();
            this.serverText = new System.Windows.Forms.TextBox();
            this.musicList = new System.Windows.Forms.ListView();
            this.MusicName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Artist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PlayTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BitRate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.startBtn = new System.Windows.Forms.Button();
            this.pathBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "MP3 File Storage Path : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "서버 상태";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(271, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "Music List";
            // 
            // ipText
            // 
            this.ipText.Location = new System.Drawing.Point(46, 20);
            this.ipText.Name = "ipText";
            this.ipText.Size = new System.Drawing.Size(288, 21);
            this.ipText.TabIndex = 5;
            this.ipText.TextChanged += new System.EventHandler(this.ipText_TextChanged);
            // 
            // portText
            // 
            this.portText.Location = new System.Drawing.Point(385, 20);
            this.portText.Name = "portText";
            this.portText.Size = new System.Drawing.Size(66, 21);
            this.portText.TabIndex = 6;
            // 
            // pathText
            // 
            this.pathText.Location = new System.Drawing.Point(209, 51);
            this.pathText.Name = "pathText";
            this.pathText.Size = new System.Drawing.Size(242, 21);
            this.pathText.TabIndex = 7;
            // 
            // serverText
            // 
            this.serverText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.serverText.Location = new System.Drawing.Point(14, 122);
            this.serverText.Multiline = true;
            this.serverText.Name = "serverText";
            this.serverText.Size = new System.Drawing.Size(254, 303);
            this.serverText.TabIndex = 8;
            // 
            // musicList
            // 
            this.musicList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MusicName,
            this.Artist,
            this.PlayTime,
            this.BitRate});
            this.musicList.Location = new System.Drawing.Point(274, 122);
            this.musicList.Name = "musicList";
            this.musicList.Size = new System.Drawing.Size(351, 303);
            this.musicList.TabIndex = 9;
            this.musicList.UseCompatibleStateImageBehavior = false;
            this.musicList.View = System.Windows.Forms.View.Details;
            // 
            // MusicName
            // 
            this.MusicName.Text = "Music Name";
            this.MusicName.Width = 134;
            // 
            // Artist
            // 
            this.Artist.Text = "Artist";
            // 
            // PlayTime
            // 
            this.PlayTime.Text = "Play Time";
            this.PlayTime.Width = 96;
            // 
            // BitRate
            // 
            this.BitRate.Text = "Bit Rate";
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(471, 18);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(132, 23);
            this.startBtn.TabIndex = 10;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // pathBtn
            // 
            this.pathBtn.Location = new System.Drawing.Point(471, 49);
            this.pathBtn.Name = "pathBtn";
            this.pathBtn.Size = new System.Drawing.Size(132, 23);
            this.pathBtn.TabIndex = 11;
            this.pathBtn.Text = "Find Path";
            this.pathBtn.UseVisualStyleBackColor = true;
            this.pathBtn.Click += new System.EventHandler(this.pathBtn_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 437);
            this.Controls.Add(this.pathBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.musicList);
            this.Controls.Add(this.serverText);
            this.Controls.Add(this.pathText);
            this.Controls.Add(this.portText);
            this.Controls.Add(this.ipText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ipText;
        private System.Windows.Forms.TextBox portText;
        private System.Windows.Forms.TextBox pathText;
        private System.Windows.Forms.TextBox serverText;
        private System.Windows.Forms.ListView musicList;
        private System.Windows.Forms.ColumnHeader MusicName;
        private System.Windows.Forms.ColumnHeader Artist;
        private System.Windows.Forms.ColumnHeader PlayTime;
        private System.Windows.Forms.ColumnHeader BitRate;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button pathBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

