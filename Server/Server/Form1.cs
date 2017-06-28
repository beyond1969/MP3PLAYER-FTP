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

namespace Server
{
    public partial class Form1 : Form
    {
        private Boolean isPathSelected = false;
        private Boolean isServerStarted = false;
        private IWMPPlaylist playList;
        private WindowsMediaPlayer wmp;

        private NetworkStream m_NetStream;
        private TcpListener m_Listener;
        private FileInfo[] fi;

        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];

        private Thread m_Thread;

        public MusicList m_musicList;
        public RequestMusic m_requestMusic;
        public string requestNo;
        public FileStream fs;
        public FileName m_fileName;



        public Form1()
        {
            InitializeComponent();
            IPHostEntry ipHost = Dns.GetHostByName(Dns.GetHostName());
            string ip_addr = ipHost.AddressList[0].ToString();
            ipText.Text = ip_addr;
            ipText.Enabled = false;
            portText.Text = "8000";     // default Port number
        }

        private void ipText_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (isServerStarted == true)
            {
                this.m_Listener.Stop();
                this.m_NetStream.Close();
                this.m_Thread.Abort();
                startBtn.Text = "Start";
                isServerStarted = false;
                pathBtn.Enabled = true;
            }
            else
            {
                // port 채워졌는지 예외처리 필요
                if (isPathSelected == true)
                {
                    this.m_Thread = new Thread(new ThreadStart(RUN));
                    this.m_Thread.Start();
                    startBtn.Text = "Stop";
                    isServerStarted = true;
                    pathBtn.Enabled = false;
                }
                else
                    MessageBox.Show("전송 가능한 MP3 파일이 없습니다. 경로를 다시 지정하십시오.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pathBtn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            string path = folderBrowserDialog1.SelectedPath;
            pathText.Text = path;
            pathText.Enabled = false;

            musicList.Items.Clear();

            wmp = new WindowsMediaPlayer();
            IWMPMedia mp3File;
            playList = wmp.newPlaylist("MusicPlayer", "");
            
            DirectoryInfo di = new DirectoryInfo(path);
            fi = di.GetFiles("*.mp3");
            foreach(var item in fi)
            {
                mp3File = wmp.newMedia(@"" + path + "\\" + item.Name);
                string[] file_info = new string[4];
                double duration;
                string bitrates;
                file_info[0] = mp3File.getItemInfo("Title");
                file_info[1] = mp3File.getItemInfo("Author");
                duration = mp3File.duration;
                file_info[2] = ((int)duration / 60) + "분" + ((int)duration % 60) + "초";
                bitrates = mp3File.getItemInfo("Bitrate");
                file_info[3] = bitrates.Remove(3,3) + "kbps";

                ListViewItem list_item = new ListViewItem(file_info);
                musicList.Items.Add(list_item);

                playList.appendItem(mp3File);

                isPathSelected = true;
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        public void RUN()
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                serverMessage("Server-start\nStorage Path:" + pathText.Text+"\n");
                this.m_Listener = new TcpListener(Int32.Parse(portText.Text));
            }));
            this.m_Listener.Start();

            serverMessage("waiting client access...\n");
            

            Socket client = this.m_Listener.AcceptSocket();

            if (client.Connected)
            {
                serverMessage("client access!\n");
                this.m_NetStream = new NetworkStream(client);
            }

            serverMessage("리스트 전송...\n");
            
            this.Invoke(new MethodInvoker(delegate ()
            {
                for (int i = 0; i < musicList.Items.Count; i++)
                {
                    m_musicList = new MusicList();
                    m_musicList.Type = (int)PacketType.음악리스트;
                    m_musicList.Length = musicList.Items.Count;
                    string strText = null;
                    for (int j = 0; j < 4; j++)
                    {
                        strText += musicList.Items[i].SubItems[j].Text;
                        strText += "_";
                    }
                    m_musicList.list = strText;
                    Packets.Serialize(m_musicList).CopyTo(this.sendBuffer, 0);

                    this.Send();
                }
            }));

            serverMessage("리스트 전송 완료\n");


            /* 요청 파일 전송 대기 */
            int nRead = 0;

            while (client.Connected)
            {
                serverMessage("요청 대기중...\n");
                try
                {
                    nRead = 0;
                    nRead = this.m_NetStream.Read(this.readBuffer, 0, 1024 * 4);
                }catch
                {
                    this.m_NetStream = null;
                    break;
                }
                this.m_requestMusic = (RequestMusic)Packets.Deserialize(this.readBuffer);
                this.requestNo = this.m_requestMusic.requestNo;
                int index = Int32.Parse(this.requestNo);
                string filename = fi[index].Name;

                /* mp3 길이 전송 */
                string songname = pathText.Text + "\\\\" + filename;
                
                fs = new FileStream(songname, FileMode.Open, FileAccess.Read);
                int fileLength = (int)fs.Length;
                byte[] lengthB = BitConverter.GetBytes(fileLength);
                
                /* mp3 파일명 전송 */
                m_fileName = new FileName();
                m_fileName.fileName = filename;
                m_fileName.Length = fileLength;
                Packets.Serialize(m_fileName).CopyTo(this.sendBuffer, 0);
                this.Send();
                /* mp3 전송 */
                int count = fileLength / (1024 * 4) + 1;
                BinaryReader br = new BinaryReader(fs);
                for(int i = 0; i< count; i++)
                {
                    lengthB = br.ReadBytes(1024 * 4);
                    lengthB.CopyTo(this.sendBuffer, 0);
                    this.Send();
                }
                br.Close();
                fs.Close();
            }
        }
        
        public void Send()
        {
            this.m_NetStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.m_NetStream.Flush();

            for (int i = 0; i < 1024 * 4; i++)
                this.sendBuffer[i] = 0;
        }

        public void serverMessage(string msg)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                serverText.AppendText(msg);
            }));
        }

        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
        }
    }
}
