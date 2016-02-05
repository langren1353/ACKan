using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using AxAPlayer3Lib;

///<summary>

///类说明：APlayerDemo

///作用：对APlayer的简单应用

///作者：王龙

///联系QQ:78847023 Email:wanglong126@139.com

///编写日期：2015-08-19  最后更新日期：2015-08-21

///感谢博客园-IT周见智 分享的经验

///感谢开发者论坛各位大大分享的经验

///API说明地址：http://aplayer.open.xunlei.com/

///AD:http://www.diycms.com  http://www.ezu88.com


///</summary>
namespace VideoPlayer
{
    public partial class Form1 : Form
    {
        ToolTip tip = new ToolTip();
        PlayClass _play = new PlayClass();
        AxPlayer _Player;
        private int oldState = -1;
        private int tryCount = 0;
        private String defaultHost = "http://xfcd.ctfs.ftn.qq.com"; // 保留传递过来的url值，用于替换
        private String[] otherHost = new String[] { "http://sh.ctfs.ftn.qq.com", "http://hz.ftn.qq.com", "http://cd.ctfs.ftn.qq.com", "http://tj.ctfs.ftn.qq.com", "http://xfsh.ctfs.ftn.qq.com", "http://xfxa.ctfs.ftn.qq.com", "http://xa.ctfs.ftn.qq.com" , "http://sz.ctfs.ftn.qq.com" };

        private String playurl = "";
        private String cookie = "";
        private String filename = "";
        public delegate void DataChangeHandler(Boolean visible); //定义一个委托
        public event DataChangeHandler dtHandler;
        Form maxForm;
        public static class SIZE_TYPE {
            public const int FULLSCREEN = 0;
            public const int DEFAULTSIZE = 1;
        }
        public static class OLDFORMSIZE
        {
            public static int oldAXPlayerHeight;
            public static int oldAXPlayerWidth;
            public static int oldAXPlayerLeft;
            public static int oldAXPlayerTop;
        }
        public Form1()
        {
            InitializeComponent();
            pictureBox1_Click_1(this.pictureBox1, null);
        }
        public Form1(String url ,String cookie, String title)
        {
            this.playurl = url;
            this.cookie = cookie;
            this.filename = title;
            InitializeComponent();
            pictureBox1_Click_1(this.pictureBox1, null);
        }
        
    /// <summary>
    /// 窗体加载
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Form1_Load(object sender, EventArgs e)
        {
            _Player = axPlayer1;
            axPlayer1.OnBuffer += new _IPlayerEvents_OnBufferEventHandler(axPlayer1_OnBuffer);
            axPlayer1.OnStateChanged += new _IPlayerEvents_OnStateChangedEventHandler(axPlayer1_OnStateChanged);
            axPlayer1.OnSeekCompleted += new _IPlayerEvents_OnSeekCompletedEventHandler(axPlayer1_OnSeekCompleted);
            axPlayer1.OnOpenSucceeded += new EventHandler(axPlayer1_OnOpenSucceeded);
            axPlayer1.OnDownloadCodec += new _IPlayerEvents_OnDownloadCodecEventHandler(axPlayer1_OnDownloadCodec);
            axPlayer1.SetCustomLogo(Properties.Resources.logo.GetHbitmap().ToInt32());  //自定义logo
            axPlayer1.SetVolume(50);
            colorSlider2.Enabled = false;
            TransparentOperation();
            this.Resize += new EventHandler(FormResize);
            //axPlayer1.SetConfig(1002, "700"); // 设置当网络没有读取到数据时，等待多少个视频帧进入缓冲（可以通过视频帧率换算成时间），默认为 500
            //axPlayer1.SetConfig(1003, "600"); // 设置在缓冲状态下，缓冲多少个帧退出缓冲，默认为 1000
            //axPlayer1.SetConfig(1003, "560"); //设置未缓冲状态下，最多预先读取多少个帧，即数据读取时间点超前当前播放时间点的距离。

        }
        void TransparentOperation()
        {


            //pic_play_pause.Parent = panelbottom;

           // colorSlider2.Parent = panelbottom;
           
        }

        #region  axPlayer事件处理程序
        /// <summary>
        /// axPlayer的鼠标、键盘事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void axPlayer1_OnMessage(object sender, _IPlayerEvents_OnMessageEvent e)
        {
            //throw new NotImplementedException();
            switch (e.nMessage)
            {
                case conf.WM_LBUTTONDOWN:
                    if (_play.isScreen == false)
                        MoveForm();
                    break;
                case conf.WM_RBUTTONDOWN:
                     int tempstatus=axPlayer1.GetState();
                    if (axPlayer1.GetState()== 5)
                    {
                        contextMenuStrip1.Items["playpause"].Text = "暂停";
                    }
                    else
                    {
                        contextMenuStrip1.Items["playpause"].Text = "播放";
                    }
                    contextMenuStrip1.Show(axPlayer1, axPlayer1.PointToClient(Cursor.Position));
                    break;
                case conf.WM_LBUTTONDBLCLK:
                    FullScreenInAndOut();break;
                default: break;
	        }

            //switch (e.nMessage)
            //{

            //    case conf.WM_LBUTTONDOWN:
            //        //Functions.moveForm(this.Handle);//拖动窗口SendMessage   这里按下默认拖动窗口
            //        //VM_X = Control.MousePosition.X; //记录鼠标此刻位置
            //        //VM_Y = Control.MousePosition.Y;
            //        //System.Threading.Thread.Sleep(300); //300毫秒后执行interval时钟事件
            //        //interval.Enabled = true;
            //        //Functions.moveForm(this.Handle);
            //        break;
            //    case conf.WM_LBUTTONUP:
            //        //interval.Enabled = false;//鼠标弹起静止时钟 减耗内存
            //        break;
            //    case conf.WM_LBUTTONDBLCLK://双击全屏事件
            //        MessageBox.Show("双击");
            //        //interval.Enabled = false;
            //        maxScreen();


            //        break;
            //    case conf.WM_RBUTTONDOWN:
            //        MessageBox.Show("右键单击");
            //        //rightButtonMenu.Show(new Point(Control.MousePosition.X, Control.MousePosition.Y));
            //        break;
            //    default:
            //        break;

            //}
        }
        /// <summary>
        /// 格式不支持，需要下载解码器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void axPlayer1_OnDownloadCodec(object sender, _IPlayerEvents_OnDownloadCodecEvent e)
        {
            MessageBox.Show("需要解码器:" + e.strCodecPath);
              
        }
        /// <summary>
        /// 文件打开完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void axPlayer1_OnOpenSucceeded(object sender, EventArgs e)
        {
            label1.Text = "00:00:00";
            label2.Text = TimeToString(TimeSpan.FromMilliseconds(axPlayer1.GetDuration()));
            colorSlider2.Enabled = true;
            colorSlider2.Maximum = axPlayer1.GetDuration()/10;
            timer1.Start();
        }
        /// <summary>
        /// 跳转指定位置完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void axPlayer1_OnSeekCompleted(object sender, _IPlayerEvents_OnSeekCompletedEvent e)
        {
            //throw new NotImplementedException();
        }
        /// <summary>
        /// 播放器状态改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void axPlayer1_OnStateChanged(object sender, _IPlayerEvents_OnStateChangedEvent e)
        {
            if (e.nNewState == 0)  //就绪
            {
                //初始化
            }
            switch (e.nNewState)
            {
                case (int)PlayClass.PLAY_STATE.PS_READY:
                    colorSlider2.Maximum = 100;
                    colorSlider2.Value = 0;
                    colorSlider2.Enabled = false;
                    label1.Text = "00:00:00";
                    label2.Text = "00:00:00";
                    label3.Text = "准备就绪";
                    label7.Text = "准备中...";
                    timer1.Stop();
                    break;
                case (int)PlayClass.PLAY_STATE.PS_OPENING:
                    label3.Text = "正在打开"; 
                    label7.Text = "正在打开..."; break;
                case (int)PlayClass.PLAY_STATE.PS_PLAY:
                case (int)PlayClass.PLAY_STATE.PS_PLAYING:
                    label3.Text = "正在播放";
                    label7.Text = "";
                    this.label8.Text = "";
                    pic_play_pause.ErrorImage = VideoPlayer.Properties.Resources.pause;
                    ChangErrPic(pic_play_pause);break;
                case (int)PlayClass.PLAY_STATE.PS_PAUSED:
                case (int)PlayClass.PLAY_STATE.PS_PAUSING: label3.Text = "暂停播放";
                    label3.Text = "暂停";
                    pic_play_pause.ErrorImage = VideoPlayer.Properties.Resources.play;
                    ChangErrPic(pic_play_pause);break;
                case (int)PlayClass.PLAY_STATE.PS_CLOSING:
                    pic_play_pause.ErrorImage = VideoPlayer.Properties.Resources.play;
                    ChangErrPic(pic_play_pause);break;
                default:
                    break;
            }
            if (oldState == 1 && e.nNewState == 0)
            {
                oldState = e.nNewState;
                this.label8.Text = "正在尝试第" + (tryCount + 2) + "个接口";
                if (tryCount > otherHost.Length - 1)
                {
                    Close();
                }
                else {
                    String curUrl = this.playurl.Replace(defaultHost, otherHost[tryCount]);
                    this.Play(curUrl, cookie, this.filename);
                }
                tryCount++;
            }
            else {
                oldState = e.nNewState;
            }
            Console.WriteLine("播放器状态:"+e.nNewState);
        }
        /// <summary>
        /// 缓冲
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void axPlayer1_OnBuffer(object sender, _IPlayerEvents_OnBufferEvent e)
        {
            if (e.nPercent != 100)
            {
                label3.Text = "正在缓冲...(" + e.nPercent + "%)";
                label7.Text = "载入中...(" + e.nPercent + "%)";
            }
            else
            {
                label3.Text = "正在播放"; 
                label7.Text = "";
            }
        }



        #endregion

        /// <summary>
        /// 打开本地文件
        /// </summary>
        private void openfile()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "mp4|*.mp4|avi|*.avi|rm|*.rm|rmvb|*.rmvb|flv|*.flv|xr|*.xr|所有文件|*.*";
                ofd.Multiselect = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    axPlayer1.Open(ofd.FileName);
                }
            }
        }
        /// <summary>
        /// 打开网络文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            using (Form2 f = new Form2())
            {
                f.TopMost = true;
                if (f.ShowDialog() == DialogResult.OK)
                {
                    axPlayer1.Open(f.endUrl);
                    label3.Text = "正在打开.";
                    label7.Text = "打开中，不要慌，也不要紧张，\n刚开始都是很慢的";
                }
            }
        }

        private void PlayOrPause()
        {
            int tempstatus=_Player.GetState();
            if (tempstatus == 0)
            {
                using (Form2 f = new Form2())
                {
                    f.TopMost = true;
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        try {
                            if (f.flag == 1)
                            {
                                String url = f.endUrl;
                                //MessageBox.Show(f.cookie);
                                this.Play(url, f.cookie);
                            }
                            else {
                                MessageBox.Show(f.errorInfo);
                            }
                        }
                        catch (Exception e) {
                            MessageBox.Show("出现异常");
                        }
                    }
                    
                }
            }
            else if (tempstatus == 5 || tempstatus == 3)
            {
                if (axPlayer1.GetState() == 5)  //播放-暂停
                {
                    axPlayer1.Pause();
                }
                else
                {
                    axPlayer1.Play();
                }
            }
            
        }
        private void Stop()
        {
            axPlayer1.Close();
        }
        public void Play()
        {
            Play(this.playurl, this.cookie, this.filename);
        }
        public void Play(String url, String cookie) {
            Play(url, cookie, "AC 播放器");
        }
        public void Play(String url, String cookie, String title)
        {
            this.lbltitle.Text = title;
            if (!cookie.Equals(""))
                this.axPlayer1.SetConfig(1105, cookie);
            this.axPlayer1.Open(url);
        }
        /// <summary>
        /// 全屏
        /// </summary>
        /// 
        Boolean m_IsFullScreen = false;//标记是否全屏
        public void FullScreenInAndOut() // 直接调用，每次取反
        {

            if (_play.isScreen == false)
            {
                //记录播放器尺寸位置
                _play.position.Top = _Player.Top;
                _play.position.Left = _Player.Left;
                _play.position.Width = _Player.Width;
                _play.position.Height = _Player.Height;
                maxForm = new Form();//实例化新窗口设置屏幕设备大小 并置于播放器父窗口

                maxForm.Width = Screen.PrimaryScreen.Bounds.Width;
                maxForm.Height = Screen.PrimaryScreen.Bounds.Height;
                maxForm.FormBorderStyle = FormBorderStyle.None;
                _Player.Parent = maxForm;
                maxForm.Show();
                maxForm.TopMost = true;
                _play.isScreen = true;
                Win32.SetParent((int)_Player.Handle, (int)maxForm.Handle);
                _Player.Left = 0;
                _Player.Top = 0;
                _Player.Width = Screen.PrimaryScreen.Bounds.Width;
                _Player.Height = Screen.PrimaryScreen.Bounds.Height;
                label3.Text = "开启全屏播放";
            }
            else
            {
                _Player.Parent = this;
                _Player.Dock = DockStyle.Fill;
                _Player.BringToFront();
                _play.isScreen = false;
                Win32.SetParent((int)_Player.Handle, (int)this.Handle);
                _Player.Top = _play.position.Top + paneltop.Height;
                _Player.Left = _play.position.Left;
                _Player.Width = _play.position.Width;
                _Player.Height = _play.position.Height - paneltop.Height - panelbottom.Height - panelpro.Height;
                maxForm.Visible = false;
                maxForm.Close();
                maxForm.Dispose();
                label3.Text = "取消全屏播放";
            }
        }
        
        /// <summary>
        /// 定时更新进度条
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = TimeToString(TimeSpan.FromMilliseconds(axPlayer1.GetPosition()));
            colorSlider2.Value = (axPlayer1.GetPosition() <= 0 ? 0 : axPlayer1.GetPosition())/10;
            //Console.WriteLine(colorSlider2.Value/10+"/"+colorSlider2.Maximum/10);
        }

        /// <summary>
        /// 时间格式转换
        /// </summary>
        /// <param name="span"></param>
        /// <returns></returns>
        string TimeToString(TimeSpan span)
        {
            return span.Hours.ToString("00") + ":" +
            span.Minutes.ToString("00") + ":" +
            span.Seconds.ToString("00");
        }
        void MoveForm()
        {
            Functions.moveForm(this.Handle);//拖动窗口SendMessage   这里按下默认拖动窗口
            _play.VM_X = Control.MousePosition.X; //记录鼠标此刻位置
            _play.VM_Y = Control.MousePosition.Y;
            System.Threading.Thread.Sleep(300); //300毫秒后执行interval时钟事件
        
        }



        //以下具体设置 如APlayer.SetConfig()方法的用法请参见  开发文档chm

        /// <summary>
        /// 字幕   
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 显示字母ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((sender as ToolStripMenuItem).Text == "显示字幕")
            {
                (sender as ToolStripMenuItem).Text = "隐藏字幕";
                axPlayer1.SetConfig(504, "1");
            }
            else
            {
                (sender as ToolStripMenuItem).Text = "显示字幕";
                axPlayer1.SetConfig(504, "0");
            }
        }
        private void playpause_Click(object sender, EventArgs e)
        {
            PlayOrPause();
        }

        private void 停止toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 32)
            {
                PlayOrPause();
            }
            else
            {
                Console.WriteLine(e.KeyChar);
            }
            
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {
                MoveForm();
            }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm();
            }
        }

        private void pic_play_pause_Click(object sender, EventArgs e)
        {
            PlayOrPause();
        }

        private void Pic_MouseEnter(object sender, EventArgs e)
        {
            ChangePic((PictureBox)sender, PlayClass.MouseStaue.enter);
        }
        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            ChangePic((PictureBox)sender, PlayClass.MouseStaue.enter);
        }
        private void Pic_MouseLeave(object sender, EventArgs e)
        {
            ChangePic((PictureBox)sender, PlayClass.MouseStaue.level);
        }
        private void Pic_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ChangePic((PictureBox)sender, PlayClass.MouseStaue.down);
            }
        }
        void ChangErrPic(PictureBox pic)
        {
            Rectangle rectangle = pic.RectangleToClient(this.ClientRectangle);
            if (rectangle.Contains(MousePosition))
            {
                ChangePic(pic, PlayClass.MouseStaue.enter);
            }
            else
            {
                ChangePic(pic, PlayClass.MouseStaue.normal);
            }
        }
        void ChangePic(PictureBox pic, PlayClass.MouseStaue status)
        {
            pic.Image = ImageHelper.GetImageByAverageIndex(pic.ErrorImage, 4, (int)status);
        }
        void Move_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm();
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Rounding(7);
        }
        void FormResize(object sender, EventArgs e)
        {
            _Player.Width = this.Width;
            _Player.Height = this.Height - paneltop.Height - panelbottom.Height - panelpro.Height;
            picclose.Left = this.Width - picclose.Width - 1;
            picmax.Left = picclose.Left - picmax.Width;
            picmin.Left = picmax.Left - picmin.Width;
            piclist.Left = this.Width - piclist.Width - 8;
            picopen.Left = piclist.Left - picopen.Width;
            picsavapic.Left = picopen.Left - picsavapic.Width;
            pic_play_pause.Left = (this.Width - pic_play_pause.Width) / 2;
            picstop.Left = pic_play_pause.Left - picstop.Width - 10;
            picsound.Left = pic_play_pause.Left + pic_play_pause.Width + 10;
            colorSlidersound.Left = picsound.Left + picsound.Width + 5;

        }
        public bool Rounding(int angle = 0)
        {
            int hRgn;
            if (angle == 0)
            {
                angle = 5;
            }

            hRgn = Win32.CreateRoundRectRgn(0, 0, this.Width, this.Height, angle, angle);
            if (hRgn == 0)
            {
                return false;
            }
            if (Win32.SetWindowRgn(this.Handle.ToInt32(), hRgn, true) == 0)
            {
                return false;
            }
            Win32.DeleteObject(hRgn);
            return true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Stop();
            Close();
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {
            openfile();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            SavePic();
        }
        private void SavePic()
        {
            axPlayer1.SetConfig(702, Application.StartupPath + "\\截图.bmp");
        }

        private void 截图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavePic();
        }

        private void colorSlider1_Scroll(object sender, ScrollEventArgs e)
        {
            axPlayer1.SetVolume(colorSlidersound .Value* 10);  //10倍
        }

        private void colorSlider2_MouseHover(object sender, EventArgs e)
        {

            tip.Show(TimeToString(TimeSpan.FromMilliseconds(colorSlider2.Value*10)), colorSlider2, 2000);
        }

        private void colorSlider2_Scroll(object sender, ScrollEventArgs e)
        {
            //MessageBox.Show(colorSlider2.Value+" "+ colorSlider2.Maximum);
            axPlayer1.SetPosition(colorSlider2.Value*10);
            label1.Text = TimeToString(TimeSpan.FromMilliseconds(colorSlider2.Value*10));
        }

        private void picmax_Click(object sender, EventArgs e)
        {
            MaxOrMin();
        }
        void MaxOrMin()
        {
            if (this.Width != Screen.PrimaryScreen.WorkingArea.Width || this.Height != Screen.PrimaryScreen.WorkingArea.Height)
            {
                _play.position.Left = this.Left;
                _play.position.Top = this.Top;
                _play.position.Width = this.Width;
                _play.position.Height = this.Height;

                this.Left = this.Top = 0;
                this.Width = Screen.PrimaryScreen.WorkingArea.Width;
                this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            }
            else
            {
                this.Left = _play.position.Left;
                this.Top = _play.position.Top;
                this.Width = _play.position.Width;
                this.Height = _play.position.Height;
            }
        }

        private void lbltitle_DoubleClick(object sender, EventArgs e)
        {
            Console.WriteLine(lbltitle.Text);
        }

        private void lbltitle_Click(object sender, EventArgs e)
        {
            Console.WriteLine(lbltitle.Text);
        }

        private void paneltop_DoubleClick(object sender, EventArgs e)
        {
            Console.WriteLine(lbltitle.Text);           
        }

        private void picmin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ChangePic((PictureBox)sender, PlayClass.MouseStaue.down);
            }
        }

        private void picmin_MouseEnter(object sender, EventArgs e)
        {
            ChangePic((PictureBox)sender, PlayClass.MouseStaue.enter);
        }

        private void picmin_MouseLeave(object sender, EventArgs e)
        {
            ChangePic((PictureBox)sender, PlayClass.MouseStaue.level);
        }

        private void picmin_MouseUp(object sender, MouseEventArgs e)
        {
            ChangePic((PictureBox)sender, PlayClass.MouseStaue.enter);
        }

        private void picmin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void axPlayer1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //MessageBox.Show(e.KeyValue+"");
            switch (e.KeyValue) {
                case conf.WM_SPACE:
                    PlayOrPause();
                    break;
                case conf.WM_GoRight:
                    this.axPlayer1.SetPosition(this.axPlayer1.GetPosition() + 120000);
                    break;
                case conf.WM_GoLeft:
                    this.axPlayer1.SetPosition(this.axPlayer1.GetPosition() - 120000);
                    break;
                case conf.WM_Esc:
                    if (this.m_IsFullScreen == true)
                        FullScreenInAndOut();
                    else
                        this.Close();
                    break;
                case conf.WM_Enter:
                    FullScreenInAndOut();
                    break;
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (this.TopMost == false)
            {
                ChangePic((PictureBox)sender, PlayClass.MouseStaue.en);
                this.TopMost = true;
            }
            else {
                ChangePic((PictureBox)sender, PlayClass.MouseStaue.level);
                this.TopMost = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            try {
                WindowsFormsApplication2.Form1 fm1 = (WindowsFormsApplication2.Form1)this.Owner;
                fm1.Visible = true;
                VideoPlayer.Win32.SwitchToThisWindow(fm1.Handle, true);
            }
            catch (Exception ee) {
                Console.WriteLine(ee.Message);
            }
            if(dtHandler != null)
                dtHandler(true); //传递visible=true
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            if(this.TopMost == true)
                ChangePic((PictureBox)sender, PlayClass.MouseStaue.down);
            else
                ChangePic((PictureBox)sender, PlayClass.MouseStaue.enter);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            if (this.TopMost == true)
                ChangePic((PictureBox)sender, PlayClass.MouseStaue.en);
            else
                ChangePic((PictureBox)sender, PlayClass.MouseStaue.level);
        }

        private void timerMaxscreem_Tick(object sender, EventArgs e) //已经是maxmized状态下延时进行全屏
        {
            // 保存当前aplayer的top
            // top = 0
            _play.position.deltaTop = this.paneltop.Height;
            _play.position.deltaBottom = this.panelbottom.Height;
            // 设置为屏幕大小
            this.SuspendLayout();
            try {
                this.axPlayer1.Height = this.Height;
                this.axPlayer1.Width = this.Width;
                this.axPlayer1.Left = this.axPlayer1.Top = 0;
                this.panelpro.Top = this.axPlayer1.Height;
                this.FormBorderStyle = FormBorderStyle.None;
                m_IsFullScreen = true;
            }
            catch (Exception ee) {
                Console.WriteLine(ee.Message);
            }
            this.ResumeLayout(false);
            this.timerMaxscreem.Enabled = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //if (m_IsFullScreen == true)
            //    FullScreenInAndOut();
        }
        
        private void SizeChange(int SIZE_TYPE) {
            if (SIZE_TYPE == Form1.SIZE_TYPE.DEFAULTSIZE)
            {
                //转换为default大小
                this.axPlayer1.Height = Form1.OLDFORMSIZE.oldAXPlayerHeight;
                this.axPlayer1.Width = Form1.OLDFORMSIZE.oldAXPlayerWidth;
                this.axPlayer1.Left = Form1.OLDFORMSIZE.oldAXPlayerLeft;
                this.axPlayer1.Top = Form1.OLDFORMSIZE.oldAXPlayerTop;
            } else if (SIZE_TYPE == Form1.SIZE_TYPE.FULLSCREEN) {
                // 转换为全屏大小
                Form1.OLDFORMSIZE.oldAXPlayerHeight = this.axPlayer1.Height;
                Form1.OLDFORMSIZE.oldAXPlayerWidth = this.axPlayer1.Width;
                Form1.OLDFORMSIZE.oldAXPlayerLeft = this.axPlayer1.Left;
                Form1.OLDFORMSIZE.oldAXPlayerTop = this.axPlayer1.Top;

                this.axPlayer1.Height = this.Height;
                this.axPlayer1.Width = this.Width;
                this.axPlayer1.Left = 0;
                this.axPlayer1.Top = 0;
            }
        }
    }
}
