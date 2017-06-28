namespace Client
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
            this.getMP3Box = new System.Windows.Forms.GroupBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.addBtn = new System.Windows.Forms.Button();
            this.pathBtn = new System.Windows.Forms.Button();
            this.connectBtn = new System.Windows.Forms.Button();
            this.serverList = new System.Windows.Forms.ListView();
            this.MusicName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Artist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PlayTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BitRate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pathText = new System.Windows.Forms.TextBox();
            this.portText = new System.Windows.Forms.TextBox();
            this.ipText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.playMP3Box = new System.Windows.Forms.GroupBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.songLabel = new System.Windows.Forms.Label();
            this.nextBtn = new System.Windows.Forms.Button();
            this.playBtn = new System.Windows.Forms.Button();
            this.prevBtn = new System.Windows.Forms.Button();
            this.removeBtn = new System.Windows.Forms.Button();
            this.playList = new System.Windows.Forms.ListView();
            this.playMusicName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.playArtist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.playPlayTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.playBitRate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.getMP3Box.SuspendLayout();
            this.playMP3Box.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // getMP3Box
            // 
            this.getMP3Box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.getMP3Box.Controls.Add(this.progressBar);
            this.getMP3Box.Controls.Add(this.addBtn);
            this.getMP3Box.Controls.Add(this.pathBtn);
            this.getMP3Box.Controls.Add(this.connectBtn);
            this.getMP3Box.Controls.Add(this.serverList);
            this.getMP3Box.Controls.Add(this.pathText);
            this.getMP3Box.Controls.Add(this.portText);
            this.getMP3Box.Controls.Add(this.ipText);
            this.getMP3Box.Controls.Add(this.label4);
            this.getMP3Box.Controls.Add(this.label3);
            this.getMP3Box.Controls.Add(this.label2);
            this.getMP3Box.Controls.Add(this.label1);
            this.getMP3Box.Location = new System.Drawing.Point(12, 12);
            this.getMP3Box.Name = "getMP3Box";
            this.getMP3Box.Size = new System.Drawing.Size(300, 391);
            this.getMP3Box.TabIndex = 0;
            this.getMP3Box.TabStop = false;
            this.getMP3Box.Text = "Get Mp3 File";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(18, 132);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(267, 23);
            this.progressBar.TabIndex = 12;
            this.progressBar.Click += new System.EventHandler(this.progressBar_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(151, 174);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(134, 25);
            this.addBtn.TabIndex = 10;
            this.addBtn.Text = "재생 목록에 추가";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // pathBtn
            // 
            this.pathBtn.Location = new System.Drawing.Point(151, 63);
            this.pathBtn.Name = "pathBtn";
            this.pathBtn.Size = new System.Drawing.Size(134, 25);
            this.pathBtn.TabIndex = 9;
            this.pathBtn.Text = "Find Path";
            this.pathBtn.UseVisualStyleBackColor = true;
            this.pathBtn.Click += new System.EventHandler(this.pathBtn_Click);
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(18, 63);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(127, 25);
            this.connectBtn.TabIndex = 8;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // serverList
            // 
            this.serverList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MusicName,
            this.Artist,
            this.PlayTime,
            this.BitRate});
            this.serverList.Location = new System.Drawing.Point(18, 202);
            this.serverList.Name = "serverList";
            this.serverList.Size = new System.Drawing.Size(267, 176);
            this.serverList.TabIndex = 7;
            this.serverList.UseCompatibleStateImageBehavior = false;
            this.serverList.View = System.Windows.Forms.View.Details;
            // 
            // MusicName
            // 
            this.MusicName.Text = "Music Name";
            this.MusicName.Width = 90;
            // 
            // Artist
            // 
            this.Artist.Text = "Artist";
            // 
            // PlayTime
            // 
            this.PlayTime.Text = "Play Time";
            this.PlayTime.Width = 78;
            // 
            // BitRate
            // 
            this.BitRate.Text = "Bit Rate";
            // 
            // pathText
            // 
            this.pathText.Location = new System.Drawing.Point(177, 98);
            this.pathText.Name = "pathText";
            this.pathText.Size = new System.Drawing.Size(108, 21);
            this.pathText.TabIndex = 6;
            // 
            // portText
            // 
            this.portText.Location = new System.Drawing.Point(213, 36);
            this.portText.Name = "portText";
            this.portText.Size = new System.Drawing.Size(72, 21);
            this.portText.TabIndex = 5;
            // 
            // ipText
            // 
            this.ipText.Location = new System.Drawing.Point(50, 36);
            this.ipText.Name = "ipText";
            this.ipText.Size = new System.Drawing.Size(112, 21);
            this.ipText.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Server Music List";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "MP3 File Download Path : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP : ";
            // 
            // playMP3Box
            // 
            this.playMP3Box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playMP3Box.Controls.Add(this.trackBar1);
            this.playMP3Box.Controls.Add(this.songLabel);
            this.playMP3Box.Controls.Add(this.nextBtn);
            this.playMP3Box.Controls.Add(this.playBtn);
            this.playMP3Box.Controls.Add(this.prevBtn);
            this.playMP3Box.Controls.Add(this.removeBtn);
            this.playMP3Box.Controls.Add(this.playList);
            this.playMP3Box.Controls.Add(this.label5);
            this.playMP3Box.Location = new System.Drawing.Point(327, 12);
            this.playMP3Box.Name = "playMP3Box";
            this.playMP3Box.Size = new System.Drawing.Size(300, 391);
            this.playMP3Box.TabIndex = 1;
            this.playMP3Box.TabStop = false;
            this.playMP3Box.Text = "Play MP3 File";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(17, 43);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(267, 45);
            this.trackBar1.TabIndex = 16;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // songLabel
            // 
            this.songLabel.AutoSize = true;
            this.songLabel.Location = new System.Drawing.Point(85, 18);
            this.songLabel.Name = "songLabel";
            this.songLabel.Size = new System.Drawing.Size(125, 12);
            this.songLabel.TabIndex = 15;
            this.songLabel.Text = "선택된 곡이 없습니다.";
            // 
            // nextBtn
            // 
            this.nextBtn.Image = global::Client.Properties.Resources.Next;
            this.nextBtn.Location = new System.Drawing.Point(218, 110);
            this.nextBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(66, 46);
            this.nextBtn.TabIndex = 14;
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // playBtn
            // 
            this.playBtn.Image = global::Client.Properties.Resources.Play;
            this.playBtn.Location = new System.Drawing.Point(122, 110);
            this.playBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(66, 46);
            this.playBtn.TabIndex = 13;
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // prevBtn
            // 
            this.prevBtn.Image = global::Client.Properties.Resources.Prev;
            this.prevBtn.Location = new System.Drawing.Point(17, 110);
            this.prevBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.Size = new System.Drawing.Size(66, 46);
            this.prevBtn.TabIndex = 12;
            this.prevBtn.UseVisualStyleBackColor = true;
            this.prevBtn.Click += new System.EventHandler(this.prevBtn_Click);
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(150, 171);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(134, 25);
            this.removeBtn.TabIndex = 11;
            this.removeBtn.Text = "재생 목록에서 삭제 ";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // playList
            // 
            this.playList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.playMusicName,
            this.playArtist,
            this.playPlayTime,
            this.playBitRate});
            this.playList.Location = new System.Drawing.Point(17, 202);
            this.playList.Name = "playList";
            this.playList.Size = new System.Drawing.Size(267, 176);
            this.playList.TabIndex = 5;
            this.playList.UseCompatibleStateImageBehavior = false;
            this.playList.View = System.Windows.Forms.View.Details;
            // 
            // playMusicName
            // 
            this.playMusicName.Text = "Music Name";
            this.playMusicName.Width = 104;
            // 
            // playArtist
            // 
            this.playArtist.Text = "Artist";
            // 
            // playPlayTime
            // 
            this.playPlayTime.Text = "Play Time";
            this.playPlayTime.Width = 86;
            // 
            // playBitRate
            // 
            this.playBitRate.Text = "Bit Rate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "Play List";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 415);
            this.Controls.Add(this.playMP3Box);
            this.Controls.Add(this.getMP3Box);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.getMP3Box.ResumeLayout(false);
            this.getMP3Box.PerformLayout();
            this.playMP3Box.ResumeLayout(false);
            this.playMP3Box.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox getMP3Box;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button pathBtn;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.ListView serverList;
        private System.Windows.Forms.ColumnHeader MusicName;
        private System.Windows.Forms.ColumnHeader Artist;
        private System.Windows.Forms.ColumnHeader PlayTime;
        private System.Windows.Forms.ColumnHeader BitRate;
        private System.Windows.Forms.TextBox pathText;
        private System.Windows.Forms.TextBox portText;
        private System.Windows.Forms.TextBox ipText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox playMP3Box;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.ListView playList;
        private System.Windows.Forms.ColumnHeader playMusicName;
        private System.Windows.Forms.ColumnHeader playArtist;
        private System.Windows.Forms.ColumnHeader playPlayTime;
        private System.Windows.Forms.ColumnHeader playBitRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label songLabel;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Button prevBtn;
    }
}

