namespace VideoPlayer
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playpause = new System.Windows.Forms.ToolStripMenuItem();
            this.停止toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.快进 = new System.Windows.Forms.ToolStripMenuItem();
            this.后退 = new System.Windows.Forms.ToolStripMenuItem();
            this.显示字母ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.在最前toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.播放时在最前toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.截图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelpro = new System.Windows.Forms.Panel();
            this.colorSlider2 = new MB.Controls.ColorSlider();
            this.axPlayer1 = new AxAPlayer3Lib.AxPlayer();
            this.panelbottom = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.colorSlidersound = new MB.Controls.ColorSlider();
            this.piclist = new System.Windows.Forms.PictureBox();
            this.picsavapic = new System.Windows.Forms.PictureBox();
            this.picopen = new System.Windows.Forms.PictureBox();
            this.picsound = new System.Windows.Forms.PictureBox();
            this.picstop = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pic_play_pause = new System.Windows.Forms.PictureBox();
            this.paneltop = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picmin = new System.Windows.Forms.PictureBox();
            this.lbltitle = new System.Windows.Forms.Label();
            this.picmax = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.picico = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.picclose = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.timerMaxscreem = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.panelpro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axPlayer1)).BeginInit();
            this.panelbottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piclist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picsavapic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picopen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picsound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picstop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_play_pause)).BeginInit();
            this.paneltop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picclose)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playpause,
            this.停止toolStripMenuItem2,
            this.快进,
            this.后退,
            this.显示字母ToolStripMenuItem,
            this.在最前toolStripMenuItem3,
            this.截图ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 158);
            // 
            // playpause
            // 
            this.playpause.Name = "playpause";
            this.playpause.Size = new System.Drawing.Size(124, 22);
            this.playpause.Text = "播放";
            this.playpause.Click += new System.EventHandler(this.playpause_Click);
            // 
            // 停止toolStripMenuItem2
            // 
            this.停止toolStripMenuItem2.Name = "停止toolStripMenuItem2";
            this.停止toolStripMenuItem2.Size = new System.Drawing.Size(124, 22);
            this.停止toolStripMenuItem2.Text = "停止";
            this.停止toolStripMenuItem2.Click += new System.EventHandler(this.停止toolStripMenuItem2_Click);
            // 
            // 快进
            // 
            this.快进.Name = "快进";
            this.快进.Size = new System.Drawing.Size(124, 22);
            this.快进.Text = "快进";
            // 
            // 后退
            // 
            this.后退.Name = "后退";
            this.后退.Size = new System.Drawing.Size(124, 22);
            this.后退.Text = "后退";
            // 
            // 显示字母ToolStripMenuItem
            // 
            this.显示字母ToolStripMenuItem.Name = "显示字母ToolStripMenuItem";
            this.显示字母ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.显示字母ToolStripMenuItem.Text = "显示字幕";
            this.显示字母ToolStripMenuItem.Click += new System.EventHandler(this.显示字母ToolStripMenuItem_Click);
            // 
            // 在最前toolStripMenuItem3
            // 
            this.在最前toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.播放时在最前toolStripMenuItem3,
            this.toolStripMenuItem2});
            this.在最前toolStripMenuItem3.Name = "在最前toolStripMenuItem3";
            this.在最前toolStripMenuItem3.Size = new System.Drawing.Size(124, 22);
            this.在最前toolStripMenuItem3.Text = "在最前";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Checked = true;
            this.toolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem1.Text = "总是在最前";
            // 
            // 播放时在最前toolStripMenuItem3
            // 
            this.播放时在最前toolStripMenuItem3.Name = "播放时在最前toolStripMenuItem3";
            this.播放时在最前toolStripMenuItem3.Size = new System.Drawing.Size(148, 22);
            this.播放时在最前toolStripMenuItem3.Text = "播放时在最前";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem2.Text = "取消最前";
            // 
            // 截图ToolStripMenuItem
            // 
            this.截图ToolStripMenuItem.Name = "截图ToolStripMenuItem";
            this.截图ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.截图ToolStripMenuItem.Text = "截图";
            this.截图ToolStripMenuItem.Click += new System.EventHandler(this.截图ToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelpro
            // 
            this.panelpro.Controls.Add(this.colorSlider2);
            this.panelpro.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelpro.Location = new System.Drawing.Point(0, 460);
            this.panelpro.Name = "panelpro";
            this.panelpro.Size = new System.Drawing.Size(792, 10);
            this.panelpro.TabIndex = 61;
            // 
            // colorSlider2
            // 
            this.colorSlider2.BackColor = System.Drawing.Color.Transparent;
            this.colorSlider2.BarInnerColor = System.Drawing.Color.Gray;
            this.colorSlider2.BarOuterColor = System.Drawing.Color.Gray;
            this.colorSlider2.BarPenColor = System.Drawing.Color.Gray;
            this.colorSlider2.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.colorSlider2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorSlider2.ElapsedInnerColor = System.Drawing.Color.DarkBlue;
            this.colorSlider2.ElapsedOuterColor = System.Drawing.Color.MediumBlue;
            this.colorSlider2.LargeChange = ((uint)(5u));
            this.colorSlider2.Location = new System.Drawing.Point(0, 0);
            this.colorSlider2.Name = "colorSlider2";
            this.colorSlider2.Size = new System.Drawing.Size(792, 10);
            this.colorSlider2.SmallChange = ((uint)(1u));
            this.colorSlider2.TabIndex = 51;
            this.colorSlider2.TabStop = false;
            this.colorSlider2.Text = "colorSlider2";
            this.colorSlider2.ThumbInnerColor = System.Drawing.Color.Lime;
            this.colorSlider2.ThumbOuterColor = System.Drawing.SystemColors.InactiveBorder;
            this.colorSlider2.ThumbPenColor = System.Drawing.Color.OrangeRed;
            this.colorSlider2.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            this.colorSlider2.ThumbSize = 7;
            this.colorSlider2.Value = 0;
            this.colorSlider2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.colorSlider2_Scroll);
            this.colorSlider2.MouseHover += new System.EventHandler(this.colorSlider2_MouseHover);
            // 
            // axPlayer1
            // 
            this.axPlayer1.ContextMenuStrip = this.contextMenuStrip1;
            this.axPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axPlayer1.Enabled = true;
            this.axPlayer1.Location = new System.Drawing.Point(0, 24);
            this.axPlayer1.Name = "axPlayer1";
            this.axPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPlayer1.OcxState")));
            this.axPlayer1.Size = new System.Drawing.Size(792, 436);
            this.axPlayer1.TabIndex = 1;
            this.axPlayer1.OnMessage += new AxAPlayer3Lib._IPlayerEvents_OnMessageEventHandler(this.axPlayer1_OnMessage);
            this.axPlayer1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.axPlayer1_PreviewKeyDown);
            // 
            // panelbottom
            // 
            this.panelbottom.BackColor = System.Drawing.Color.Transparent;
            this.panelbottom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelbottom.BackgroundImage")));
            this.panelbottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelbottom.Controls.Add(this.label3);
            this.panelbottom.Controls.Add(this.label2);
            this.panelbottom.Controls.Add(this.label5);
            this.panelbottom.Controls.Add(this.colorSlidersound);
            this.panelbottom.Controls.Add(this.piclist);
            this.panelbottom.Controls.Add(this.picsavapic);
            this.panelbottom.Controls.Add(this.picopen);
            this.panelbottom.Controls.Add(this.picsound);
            this.panelbottom.Controls.Add(this.picstop);
            this.panelbottom.Controls.Add(this.label1);
            this.panelbottom.Controls.Add(this.pic_play_pause);
            this.panelbottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelbottom.Location = new System.Drawing.Point(0, 470);
            this.panelbottom.Name = "panelbottom";
            this.panelbottom.Size = new System.Drawing.Size(792, 38);
            this.panelbottom.TabIndex = 59;
            this.panelbottom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Move_MouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(133, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 13, 0, 0);
            this.label3.Size = new System.Drawing.Size(53, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "准备就绪";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(72, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 13, 0, 0);
            this.label2.Size = new System.Drawing.Size(61, 38);
            this.label2.TabIndex = 63;
            this.label2.Text = "00:00:00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(61, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 13, 0, 0);
            this.label5.Size = new System.Drawing.Size(11, 25);
            this.label5.TabIndex = 64;
            this.label5.Text = "/";
            // 
            // colorSlidersound
            // 
            this.colorSlidersound.BackColor = System.Drawing.Color.Transparent;
            this.colorSlidersound.BarInnerColor = System.Drawing.Color.DodgerBlue;
            this.colorSlidersound.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.colorSlidersound.ElapsedInnerColor = System.Drawing.SystemColors.HotTrack;
            this.colorSlidersound.ElapsedOuterColor = System.Drawing.Color.DarkTurquoise;
            this.colorSlidersound.LargeChange = ((uint)(5u));
            this.colorSlidersound.Location = new System.Drawing.Point(467, 14);
            this.colorSlidersound.Name = "colorSlidersound";
            this.colorSlidersound.Size = new System.Drawing.Size(107, 12);
            this.colorSlidersound.SmallChange = ((uint)(1u));
            this.colorSlidersound.TabIndex = 70;
            this.colorSlidersound.TabStop = false;
            this.colorSlidersound.Text = "colorSlider1";
            this.colorSlidersound.ThumbOuterColor = System.Drawing.Color.Transparent;
            this.colorSlidersound.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            this.colorSlidersound.ThumbSize = 7;
            this.colorSlidersound.Scroll += new System.Windows.Forms.ScrollEventHandler(this.colorSlider1_Scroll);
            // 
            // piclist
            // 
            this.piclist.ErrorImage = ((System.Drawing.Image)(resources.GetObject("piclist.ErrorImage")));
            this.piclist.Image = ((System.Drawing.Image)(resources.GetObject("piclist.Image")));
            this.piclist.Location = new System.Drawing.Point(758, 6);
            this.piclist.Name = "piclist";
            this.piclist.Size = new System.Drawing.Size(26, 25);
            this.piclist.TabIndex = 67;
            this.piclist.TabStop = false;
            this.piclist.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseDown);
            this.piclist.MouseEnter += new System.EventHandler(this.Pic_MouseEnter);
            this.piclist.MouseLeave += new System.EventHandler(this.Pic_MouseLeave);
            this.piclist.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_MouseUp);
            // 
            // picsavapic
            // 
            this.picsavapic.ErrorImage = ((System.Drawing.Image)(resources.GetObject("picsavapic.ErrorImage")));
            this.picsavapic.Image = ((System.Drawing.Image)(resources.GetObject("picsavapic.Image")));
            this.picsavapic.Location = new System.Drawing.Point(708, 6);
            this.picsavapic.Name = "picsavapic";
            this.picsavapic.Size = new System.Drawing.Size(25, 25);
            this.picsavapic.TabIndex = 67;
            this.picsavapic.TabStop = false;
            this.picsavapic.Click += new System.EventHandler(this.pictureBox5_Click);
            this.picsavapic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseDown);
            this.picsavapic.MouseEnter += new System.EventHandler(this.Pic_MouseEnter);
            this.picsavapic.MouseLeave += new System.EventHandler(this.Pic_MouseLeave);
            this.picsavapic.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_MouseUp);
            // 
            // picopen
            // 
            this.picopen.ErrorImage = ((System.Drawing.Image)(resources.GetObject("picopen.ErrorImage")));
            this.picopen.Image = ((System.Drawing.Image)(resources.GetObject("picopen.Image")));
            this.picopen.Location = new System.Drawing.Point(733, 6);
            this.picopen.Name = "picopen";
            this.picopen.Size = new System.Drawing.Size(25, 25);
            this.picopen.TabIndex = 67;
            this.picopen.TabStop = false;
            this.picopen.Click += new System.EventHandler(this.pictureBox4_Click);
            this.picopen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseDown);
            this.picopen.MouseEnter += new System.EventHandler(this.Pic_MouseEnter);
            this.picopen.MouseLeave += new System.EventHandler(this.Pic_MouseLeave);
            this.picopen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_MouseUp);
            // 
            // picsound
            // 
            this.picsound.ErrorImage = ((System.Drawing.Image)(resources.GetObject("picsound.ErrorImage")));
            this.picsound.Image = ((System.Drawing.Image)(resources.GetObject("picsound.Image")));
            this.picsound.Location = new System.Drawing.Point(431, 5);
            this.picsound.Name = "picsound";
            this.picsound.Size = new System.Drawing.Size(30, 30);
            this.picsound.TabIndex = 66;
            this.picsound.TabStop = false;
            this.picsound.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseDown);
            this.picsound.MouseEnter += new System.EventHandler(this.Pic_MouseEnter);
            this.picsound.MouseLeave += new System.EventHandler(this.Pic_MouseLeave);
            this.picsound.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_MouseUp);
            // 
            // picstop
            // 
            this.picstop.ErrorImage = ((System.Drawing.Image)(resources.GetObject("picstop.ErrorImage")));
            this.picstop.Image = ((System.Drawing.Image)(resources.GetObject("picstop.Image")));
            this.picstop.Location = new System.Drawing.Point(243, 8);
            this.picstop.Name = "picstop";
            this.picstop.Size = new System.Drawing.Size(30, 30);
            this.picstop.TabIndex = 65;
            this.picstop.TabStop = false;
            this.picstop.Click += new System.EventHandler(this.pictureBox2_Click);
            this.picstop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseDown);
            this.picstop.MouseEnter += new System.EventHandler(this.Pic_MouseEnter);
            this.picstop.MouseLeave += new System.EventHandler(this.Pic_MouseLeave);
            this.picstop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_MouseUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 13, 0, 0);
            this.label1.Size = new System.Drawing.Size(61, 38);
            this.label1.TabIndex = 62;
            this.label1.Text = "00:00:00";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pic_play_pause
            // 
            this.pic_play_pause.BackColor = System.Drawing.Color.Transparent;
            this.pic_play_pause.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pic_play_pause.ErrorImage")));
            this.pic_play_pause.Image = ((System.Drawing.Image)(resources.GetObject("pic_play_pause.Image")));
            this.pic_play_pause.Location = new System.Drawing.Point(328, 3);
            this.pic_play_pause.Name = "pic_play_pause";
            this.pic_play_pause.Size = new System.Drawing.Size(57, 35);
            this.pic_play_pause.TabIndex = 14;
            this.pic_play_pause.TabStop = false;
            this.pic_play_pause.Click += new System.EventHandler(this.pic_play_pause_Click);
            this.pic_play_pause.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseDown);
            this.pic_play_pause.MouseEnter += new System.EventHandler(this.Pic_MouseEnter);
            this.pic_play_pause.MouseLeave += new System.EventHandler(this.Pic_MouseLeave);
            // 
            // paneltop
            // 
            this.paneltop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("paneltop.BackgroundImage")));
            this.paneltop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.paneltop.Controls.Add(this.pictureBox1);
            this.paneltop.Controls.Add(this.picmin);
            this.paneltop.Controls.Add(this.lbltitle);
            this.paneltop.Controls.Add(this.picmax);
            this.paneltop.Controls.Add(this.label4);
            this.paneltop.Controls.Add(this.picico);
            this.paneltop.Controls.Add(this.label6);
            this.paneltop.Controls.Add(this.picclose);
            this.paneltop.Dock = System.Windows.Forms.DockStyle.Top;
            this.paneltop.Location = new System.Drawing.Point(0, 0);
            this.paneltop.Name = "paneltop";
            this.paneltop.Size = new System.Drawing.Size(792, 24);
            this.paneltop.TabIndex = 62;
            this.paneltop.DoubleClick += new System.EventHandler(this.paneltop_DoubleClick);
            this.paneltop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Move_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(686, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pictureBox1.Size = new System.Drawing.Size(26, 24);
            this.pictureBox1.TabIndex = 64;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // picmin
            // 
            this.picmin.BackColor = System.Drawing.Color.Transparent;
            this.picmin.Dock = System.Windows.Forms.DockStyle.Right;
            this.picmin.ErrorImage = ((System.Drawing.Image)(resources.GetObject("picmin.ErrorImage")));
            this.picmin.Image = ((System.Drawing.Image)(resources.GetObject("picmin.Image")));
            this.picmin.Location = new System.Drawing.Point(712, 0);
            this.picmin.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.picmin.Name = "picmin";
            this.picmin.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.picmin.Size = new System.Drawing.Size(22, 24);
            this.picmin.TabIndex = 28;
            this.picmin.TabStop = false;
            this.picmin.Click += new System.EventHandler(this.picmin_Click);
            this.picmin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picmin_MouseDown);
            this.picmin.MouseEnter += new System.EventHandler(this.picmin_MouseEnter);
            this.picmin.MouseLeave += new System.EventHandler(this.picmin_MouseLeave);
            this.picmin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picmin_MouseUp);
            // 
            // lbltitle
            // 
            this.lbltitle.BackColor = System.Drawing.Color.Transparent;
            this.lbltitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbltitle.ForeColor = System.Drawing.Color.White;
            this.lbltitle.Location = new System.Drawing.Point(84, 0);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(596, 24);
            this.lbltitle.TabIndex = 20;
            this.lbltitle.Text = "AC 看片神器";
            this.lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbltitle.Click += new System.EventHandler(this.lbltitle_Click);
            this.lbltitle.DoubleClick += new System.EventHandler(this.lbltitle_DoubleClick);
            this.lbltitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Move_MouseDown);
            // 
            // picmax
            // 
            this.picmax.BackColor = System.Drawing.Color.Transparent;
            this.picmax.Dock = System.Windows.Forms.DockStyle.Right;
            this.picmax.ErrorImage = ((System.Drawing.Image)(resources.GetObject("picmax.ErrorImage")));
            this.picmax.Image = ((System.Drawing.Image)(resources.GetObject("picmax.Image")));
            this.picmax.Location = new System.Drawing.Point(734, 0);
            this.picmax.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.picmax.Name = "picmax";
            this.picmax.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.picmax.Size = new System.Drawing.Size(22, 24);
            this.picmax.TabIndex = 27;
            this.picmax.TabStop = false;
            this.picmax.Click += new System.EventHandler(this.picmax_Click);
            this.picmax.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseDown);
            this.picmax.MouseEnter += new System.EventHandler(this.Pic_MouseEnter);
            this.picmax.MouseLeave += new System.EventHandler(this.Pic_MouseLeave);
            this.picmax.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_MouseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(26, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5, 6, 0, 0);
            this.label4.Size = new System.Drawing.Size(58, 18);
            this.label4.TabIndex = 21;
            this.label4.Text = "ACPlayer";
            this.label4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Move_MouseDown);
            // 
            // picico
            // 
            this.picico.BackColor = System.Drawing.Color.Transparent;
            this.picico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picico.Dock = System.Windows.Forms.DockStyle.Left;
            this.picico.Image = global::VideoPlayer.Properties.Resources.ico;
            this.picico.Location = new System.Drawing.Point(10, 0);
            this.picico.Margin = new System.Windows.Forms.Padding(10, 2, 3, 3);
            this.picico.Name = "picico";
            this.picico.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.picico.Size = new System.Drawing.Size(16, 24);
            this.picico.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picico.TabIndex = 23;
            this.picico.TabStop = false;
            this.picico.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Move_MouseDown);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.ForeColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 24);
            this.label6.TabIndex = 25;
            // 
            // picclose
            // 
            this.picclose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picclose.BackgroundImage")));
            this.picclose.Dock = System.Windows.Forms.DockStyle.Right;
            this.picclose.ErrorImage = ((System.Drawing.Image)(resources.GetObject("picclose.ErrorImage")));
            this.picclose.Location = new System.Drawing.Point(756, 0);
            this.picclose.Name = "picclose";
            this.picclose.Size = new System.Drawing.Size(36, 24);
            this.picclose.TabIndex = 26;
            this.picclose.TabStop = false;
            this.picclose.Click += new System.EventHandler(this.pictureBox1_Click);
            this.picclose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseDown);
            this.picclose.MouseEnter += new System.EventHandler(this.Pic_MouseEnter);
            this.picclose.MouseLeave += new System.EventHandler(this.Pic_MouseLeave);
            this.picclose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_MouseUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(0, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 28);
            this.label7.TabIndex = 0;
            this.label7.Text = "正在载入中........";
            this.label7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Move_MouseDown);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(300, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(193, 28);
            this.label8.TabIndex = 64;
            this.label8.Text = "正在尝试第1个接口";
            this.label8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Move_MouseDown);
            // 
            // timerMaxscreem
            // 
            this.timerMaxscreem.Interval = 1000;
            this.timerMaxscreem.Tick += new System.EventHandler(this.timerMaxscreem_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(792, 508);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.axPlayer1);
            this.Controls.Add(this.panelpro);
            this.Controls.Add(this.panelbottom);
            this.Controls.Add(this.paneltop);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(792, 508);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACPlayer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelpro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axPlayer1)).EndInit();
            this.panelbottom.ResumeLayout(false);
            this.panelbottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piclist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picsavapic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picopen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picsound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picstop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_play_pause)).EndInit();
            this.paneltop.ResumeLayout(false);
            this.paneltop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picclose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 显示字母ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 截图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playpause;
        private System.Windows.Forms.ToolStripMenuItem 停止toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 快进;
        private System.Windows.Forms.ToolStripMenuItem 后退;
        private System.Windows.Forms.ToolStripMenuItem 在最前toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 播放时在最前toolStripMenuItem3;
        private System.Windows.Forms.PictureBox pic_play_pause;
        private AxAPlayer3Lib.AxPlayer axPlayer1;
        private System.Windows.Forms.Panel panelbottom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picsound;
        private System.Windows.Forms.PictureBox picstop;
        private System.Windows.Forms.PictureBox picopen;
        private System.Windows.Forms.PictureBox piclist;
        private System.Windows.Forms.PictureBox picsavapic;
        private MB.Controls.ColorSlider colorSlidersound;
        private System.Windows.Forms.Panel panelpro;
        private MB.Controls.ColorSlider colorSlider2;
        private System.Windows.Forms.Panel paneltop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.PictureBox picmax;
        private System.Windows.Forms.PictureBox picico;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox picclose;
        private System.Windows.Forms.PictureBox picmin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timerMaxscreem;
    }
}

