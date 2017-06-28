using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using WMPLib;
using Packet;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Client
{


    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        private bool playBtnClicked = false;
        private IWMPPlaylist playerList;
        private WindowsMediaPlayer wmp;
        private IWMPMedia currentPlay;
        private int fileNameIndex = 0;
        private double songPos;

        private NetworkStream m_NetStream;
        private TcpClient m_Client;

        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];

        private Thread m_Thread;
        private Thread m_Player;

        public MusicList m_musicList;
        public RequestMusic m_requestMusic;
        public string requestNo;
        public FileStream fs;
        public FileName m_fileName;

        public Form1()
        {
            InitializeComponent();
            pathText.Enabled = false;
        }

        private void pathBtn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            string path = folderBrowserDialog1.SelectedPath;
            pathText.Text = path;
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            if(ipText.Text == "" || portText.Text == "")
            {
                MessageBox.Show("ip 혹은 Port Number가 설정되지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
            {
                this.m_Thread = new Thread(new ThreadStart(RUN));
                this.m_Thread.Start();
                this.connectBtn.Text = "Disconnect";
                this.connectBtn.ForeColor = Color.Red;
            }
        }

        public void RUN()
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                this.m_Client = new TcpClient();
                try
                {
                    this.m_Client.Connect(this.ipText.Text, Int32.Parse(this.portText.Text));

                }
                catch
                {
                    MessageBox.Show("Cannot Access...");
                    return;
                }

                this.m_NetStream = this.m_Client.GetStream();
                int nRead = 0;
                bool whileFinish = true;
                int iterator = 0;

                while (whileFinish)
                {
                    try
                    {
                        nRead = 0;
                        nRead = this.m_NetStream.Read(this.readBuffer, 0, 1024 * 4);

                    }
                    catch
                    {
                        whileFinish = true;
                        this.m_NetStream = null;
                    }
                    object obj = Packets.Deserialize(this.readBuffer);
                    this.m_musicList = (MusicList)obj;
                    string[] listStr = new string[4];
                    listStr = m_musicList.list.Split('_');

                    ListViewItem listviewitem = new ListViewItem(listStr);
                    this.serverList.Items.Add(listviewitem);

                    iterator++;

                    if (iterator == this.m_musicList.Length)
                        whileFinish = false;
                }
            }));
           
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (pathText.Text == "")
            {
                MessageBox.Show("유효한 경로가 입력되지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // send request
            ListViewItem checkedItem = serverList.FocusedItem;
            this.requestNo = serverList.Items.IndexOf(checkedItem).ToString();
            int i = 0;
            while (true)
            {
                if(playList.Items.Count == 0)
                {
                    break;
                }
                string title = playList.Items[i].SubItems[0].Text;
                if (checkedItem.SubItems[0].Text.CompareTo(title) == 0)
                {
                    MessageBox.Show("이미 등록되었습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }else if(i+1 == playList.Items.Count)
                {
                    break;
                }

                i++;
            }
            m_requestMusic = new RequestMusic();

            m_requestMusic.requestNo = requestNo;

            Packets.Serialize(m_requestMusic).CopyTo(sendBuffer, 0);

            this.Send();
            // send request end
            
            
            progressBar.Value = 0;
            

            // recieve file name
            try
            {
                int nRead = 0;
                nRead = this.m_NetStream.Read(this.readBuffer, 0, 1024 * 4);

            }
            catch
            {
                //this.m_NetStream = null;
            }
            object obj = Packets.Deserialize(this.readBuffer);
            this.m_fileName = (FileName)obj;
            string filename = m_fileName.fileName;
            int size = m_fileName.Length;
            // recieve file name end

            // recieve file
            byte[] b = new byte[1024 * 4];
            int totalLength = 0;
            string songname = pathText.Text + "\\\\" + filename;

            fs = new FileStream(songname, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);

            while (totalLength < size)
            {
                int nRead = 0;
                try
                {
                    nRead = 0;
                    nRead = this.m_NetStream.Read(this.readBuffer, 0, 1024 * 4);

                }
                catch
                {
                    //this.m_NetStream = null;
                }

                int recieveLength = nRead;
                bw.Write(this.readBuffer, 0, recieveLength);
                totalLength += recieveLength;
                progressBar.PerformStep();
            }

            bw.Close();
            fs.Close();
            // recieve file end

            // add music list
            this.playList.Items.Add((ListViewItem)checkedItem.Clone());
            // add music list end

            // delete server list
            // this.serverList.Items.Remove(checkedItem);
            // delete server list end

            // append playerlist
            currentPlay = wmp.newMedia(@"" + pathText.Text + "\\" + filename);
            playerList.appendItem(currentPlay);
            // append playerlist end
        }

        public void Send()
        {
            this.m_NetStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.m_NetStream.Flush();

            for (int i = 0; i < 1024 * 4; i++)
                this.sendBuffer[i] = 0;
        }

        private void progressBar_Click(object sender, EventArgs e)
        {

        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            ListViewItem target = playList.FocusedItem;
            if(target.SubItems[0].Text == songLabel.Text)
            {
                MessageBox.Show("현재 재생중인 곡은 삭제할 수 없습니다!");
                return;
            }
            int index = playList.Items.IndexOf(target);
            playerList.removeItem(playerList.Item[index]);
            playList.Items.Remove(target);
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            MediaPlayer();
        }

        public void MediaPlayer()
        {
            Invoke(new MethodInvoker(delegate ()
            {
                if (playBtnClicked == false)
                {
                    if (trackBar1.Value == 0)   // 첫 실행
                    {
                        ListViewItem cur = playList.FocusedItem;
                        int index = cur.Index;
                        IWMPMedia curplay = playerList.Item[index];
                        IWMPMedia curname = wmp.newMedia(@"" + pathText.Text + "\\" + curplay.name + ".mp3");
                        playBtn.Image = Image.FromFile(@"image/Pause.PNG");
                        wmp.controls.playItem(curplay);
                        songLabel.Text = cur.SubItems[0].Text;
                        playBtnClicked = true;
                        trackBar1.Minimum = 0;
                        double duration = curname.duration;
                        trackBar1.Maximum = (int)duration;
                        trackBar1.Value = 0;
                        t.Interval = 1000;
                        t.Tick += new System.EventHandler(timer_Tick);
                        t.Start();
                    }else
                    {
                        playBtn.Image = Image.FromFile(@"image/Pause.PNG");
                        playBtnClicked = true;
                        wmp.controls.currentPosition = songPos;
                        wmp.controls.play();
                        t.Start();
                    }
                }
                else
                {
                    t.Stop();
                    songPos = wmp.controls.currentPosition;
                    playBtn.Image = Image.FromFile(@"image/Play.PNG");
                    wmp.controls.pause();
                    playBtnClicked = false;
                }
            }));
            
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            this.trackBar1.Value += 1;
            if(trackBar1.Value == trackBar1.Maximum)
            {
                trackBar1.Value = 0;
                t.Stop();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            wmp = new WindowsMediaPlayer();
            playerList = wmp.newPlaylist("MusicPlayer", "");
            wmp.currentPlaylist = playerList;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            wmp.controls.currentPosition = this.trackBar1.Value;
            
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            IWMPMedia nextMedia = wmp.currentMedia;
            if(nextMedia.name == wmp.currentPlaylist.Item[wmp.currentPlaylist.count-1].name)
            {
                MessageBox.Show("리스트의 마지막 곡입니다.");
            }else
            {
                // stop current media and initialize
                t.Stop();
                wmp.controls.stop();
                trackBar1.Value = 0;
                wmp.controls.next();
                nextMedia = wmp.currentMedia;
                IWMPMedia curname = wmp.newMedia(@"" + pathText.Text + "\\" + nextMedia.name + ".mp3");
                wmp.controls.playItem(nextMedia);
                songLabel.Text = curname.name;
                trackBar1.Minimum = 0;
                double duration = curname.duration;
                trackBar1.Maximum = (int)duration;
                t.Start();
            }
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            IWMPMedia prevMedia = wmp.currentMedia;
            if(prevMedia.name == wmp.currentPlaylist.Item[0].name)
            {
                MessageBox.Show("리스트의 첫번째 곡입니다.");
            }else
            {
                t.Stop();
                wmp.controls.stop();
                trackBar1.Value = 0;
                wmp.controls.previous();
                prevMedia = wmp.currentMedia;
                IWMPMedia curname = wmp.newMedia(@"" + pathText.Text + "\\" + prevMedia.name + ".mp3");
                wmp.controls.playItem(prevMedia);
                songLabel.Text = curname.name;
                trackBar1.Minimum = 0;
                double duration = curname.duration;
                trackBar1.Maximum = (int)duration;
                t.Start();
            }
        }
    }
}
