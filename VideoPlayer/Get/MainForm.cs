using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using VideoPlayer.Dialog;

namespace WindowsFormsApplication2 {
    public partial class Form1 : Form {
        CiteValue CiteValue = new CiteValue();// 初始化，默认是BT-SOSO
        SynchronizationContext _syncContext = null;
        int allcount = 0; // 列表：总记录数
        String urlPlay = VideoPlayer.Form1.defaultHost+"/ftn_handler/CODE?compressed=0&dtype=1&fname=A.";
        String requestUrl = Program.DEBUG_URL+"/CodeDeal/find"; //http://bt-soso.com:8080/CodeDeal/find
        bool isFinish = false;
        bool is_clearAll = false;
        int defaultNameSize = 0;
        VideoPlayer.Form1 playForm;
        public static String version = " V2.5";
        public int mutiCount = 0;
        class Alldata{
            public int curIndex;
            public static int allcount = 0;
            public String size;
            public String name;
            public String location;
            public String hot;
            public String time;

            public int canPlay;
            public int fileCount;
            public String namePlay;
            public String fileSize;
            public String codeUrl;
            public String filetype;
            public String cookie;
        }

        Alldata[] alldata = new Alldata[500];
        //String[] size = null;// 大小
        //String[] name = null;// 名称
        //String[] namePlay = null;// 名称
        //String[] location = null;// 地址
        //String[] hot = null;// 热度
        //String[] time = null;// 创建时间
        //String[] code = null;

        public Form1() {
            InitializeComponent();
            this.AddOwnedForm(playForm);
            _syncContext = SynchronizationContext.Current;
            this.Text += version;
        }
        private void input_search_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                button1_Click(null, null);
            }
        }
        private void button1_Click(object sender, EventArgs e) {
            this.CiteValue.curIndex = 1;
            this.allcount = Alldata.allcount = 0;
            doSearchThread();
        }
        public void doSearchThread() { // 避免和主线程(UI)冲突-导致卡顿
            Thread thread = new Thread(doSearch);
            thread.Start();
        }
        private void doSearch() {
            try {
                isFinish = false;
                //this.lblStatus.Text = "搜索中....";
                _syncContext.Post(Sync_lbl, "搜索中....");
                String skw = input_search.Text.Trim();
                if (skw.Equals("")) { MessageBox.Show(this, "没有找到相关搜索结果\r\n O_O"); return; }
                // 获取网页源码--> HTMLVALUE
                HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(CiteValue.getSearchURL(skw));
                httpReq.Method = "GET";
                HttpWebResponse httpResp = (HttpWebResponse)httpReq.GetResponse();
                Stream stream = httpResp.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream);
                String HTMLVALUE = streamReader.ReadToEnd();
                stream.Close();
                httpResp.Close();
                
                insetIntoListViewWithHTTPVAULE(HTMLVALUE);
                //lblStatus.Text = "搜索完成，请低调使用";
                _syncContext.Post(Sync_lbl, "搜索完成，请低调使用");
            }
            catch (Exception ee) {
                Console.WriteLine(ee.Message);
            }
        }
        public void insetIntoListViewWithHTTPVAULE(String HTML) {
            if (CiteValue.getIsExist(HTML) == false){
                this.dataGridView1.Rows.Clear();
                String[] oneRow = new String[7];
                oneRow[0] = "";
                oneRow[1] = "";
                oneRow[2] = "找不到资源";
                oneRow[3] = "换一个再搜索试试吧 喵~~~";
                oneRow[4] = "";
                oneRow[5] = "";
                oneRow[6] = "";
                this.dataGridView1.Rows.Add(oneRow);
                MessageBox.Show(this, "没有找到相关搜索结果\r\n O_O");
                return;
            }
            HTML = Reg_replace(HTML, "</?span[^>]*>", ""); // 去除原来的高亮等之类的特殊关键字
            HTML = Reg_replace(HTML, "\\/\\*.*\\*\\/", ""); // 去除原始代码中的注释
            HTML = Reg_replace(HTML, "<script[^>]*>[\\s\\S]*?</script>", ""); // 去除原始代码中的Script代码
            HTML = Reg_replace(HTML, "&nbsp;&nbsp;<b>新</b>", "");
            //Console.Write(HTML);
            // this.textBox1.Text = HTML;
            //return;

            String[] size = CiteValue.regGetSize(HTML);// 大小
            String[] name = CiteValue.regGetName(HTML);// 名称
            String[] location = CiteValue.regGetLocation(HTML);// 地址
            String[] hot = CiteValue.regGetHot(HTML);// 热度
            String[] time = CiteValue.regGetTime(HTML);// 创建时间

            if (!(size.Length == name.Length && name.Length == location.Length && location.Length == hot.Length && hot.Length == time.Length))
            {
                MessageBox.Show("数据获取异常，点击右下角\n反馈能帮助软件更加完善");
                return;
            }
            Alldata.allcount = size.Length;
            for (int i = 0; i < size.Length; i++) {
                alldata[i] = new Alldata();
                alldata[i].size = size[i];
                alldata[i].name = name[i];
                alldata[i].location = location[i];
                alldata[i].hot = hot[i];
                alldata[i].time = time[i];
            }
            size = name = location = hot = time = null;
            // 获得当前页数，获得最大页数
            try {
                this.CiteValue.curIndex = CiteValue.regGetCurIndex(HTML);
            }
            catch (Exception ee) {
                Console.WriteLine(ee);
            }
            try
            {
                this.CiteValue.maxIndex = CiteValue.regGetMaxIndex(HTML);
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }
            //MessageBox.Show(this.CiteValue.curIndex + " "+ this.CiteValue.maxIndex);
            _syncContext.Post(Sync_ListView, new object());
            //if (this.CiteValue.maxIndex < this.CiteValue.curIndex) this.CiteValue.maxIndex = this.CiteValue.curIndex;
            _syncContext.Post(SetComboxSize, new object());
            //SetComboxSize(this.CiteValue.maxIndex, this.CiteValue.curIndex);
        }
        public void Sync_lbl(Object obj) {
            this.lblStatus.Text = obj.ToString();
        }
        public void Sync_LinklableData(Object obj)
        {
            try {
                String[] data = (String[])obj;
                int index = Int32.Parse(data[0]);
                int canplay = Int32.Parse(data[1]);
                String text;
                switch (canplay) {
                    case -3: //查找资源错误
                    case -2: //资源已经过期
                    case -1: //暂时找不到该资源
                        text = "无效"; break;
                    case 1:
                        text = "点击播放"; break;
                    case 2:
                        text = "选择播放"; break;
                    default: //未知错误
                        text = "无效"; break;
                }
                dataGridView1.Rows[index].Cells[6].Value = text;
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }
        public void Sync_ListView(Object obj) {
            //this.listView1.Items.Clear();
            this.dataGridView1.Rows.Clear();
            for (int i = 0; i < Alldata.allcount; i++) {
                String[] oneRow = new String[7];
                oneRow[0] = i+"";
                oneRow[1] = alldata[i].size;
                oneRow[2] = alldata[i].name;
                oneRow[3] = alldata[i].location;
                oneRow[4] = alldata[i].hot + "\u2103";
                oneRow[5] = alldata[i].time;
                oneRow[6] = "检测中";
                this.dataGridView1.Rows.Add(oneRow);
            }
            int count = dataGridView1.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                Thread athread = new Thread(ThreadGetAllPlayAddr);
                athread.Start(i);
            }
            //this.listView1.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，
            //try {
            //    for (int i = 0; i < size.Length; i++) {   //添加数据
            //        ListViewItem lvi = new ListViewItem();
            //        lvi.Text = (allcount++) + "";
            //        lvi.SubItems.Add(size[i]);
            //        lvi.SubItems.Add(name[i]);
            //        lvi.SubItems.Add(location[i]);
            //        lvi.SubItems.Add(hot[i] + "\u2103");
            //        lvi.SubItems.Add(time[i]);

                    
            //        this.listView1.Items.Add(lvi);
            //        LinkLabel linklbl = new LinkLabel();
            //        int curCount = this.listView1.Items.Count;
            //        linklbl.Text = "查询第"+ (curCount-1)+"个";
            //        linklbl.Location = new Point(this.listView1.Items[curCount -1].Bounds.Right-58, this.listView1.Items[curCount - 1].Bounds.Top);
            //        linklbl.Click += this.TryToPlay;
            //        this.listView1.Controls.Add(linklbl);
                    
            //    }
            //} catch (Exception ee) {
            //    MessageBox.Show(this, ee.Message);
            //}
            //this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。
        }
        public void ThreadGetAllPlayAddr(Object obj) {
            int i = (int)obj;
            try {
                String magnet = (String)dataGridView1.Rows[i].Cells[3].Value;
                String code = MyReg.Reg_GetFirstString(magnet, "(?<=btih:)(\\S{40})");
                String HTML = MyHttp.myHttpStringPost(requestUrl, "UTF-8", "CODE=" + code);
                //Thread.Sleep(50);
                int canPlay = MyReg.Reg_GetFirstNum(HTML, "A=(.*)?\\r\\n");
                alldata[i].namePlay = HttpUtility.UrlDecode(MyReg.Reg_GetFirstString(HTML, "B=(.*)?\\r\\n"));
                alldata[i].codeUrl = myDecode(MyReg.Reg_GetFirstString(HTML, "C=(.*)?\\r\\n"));
                alldata[i].filetype = MyReg.Reg_GetFirstString(HTML, "D=(.*)?\\r\\n");
                alldata[i].cookie = "FTN5K=" + MyReg.Reg_GetFirstString(HTML, "E=(.*)?\\r\\n");
                alldata[i].fileCount = Int32.Parse(MyReg.Reg_GetFirstString(HTML, "F=(.*)?\\r\\n"));
                //MessageBox.Show("["+ alldata[i].codeUrl + "]");
                alldata[i].canPlay = canPlay;
                //if(canPlay == 1) //使用invoke传递消息，通知修改linklable的值,传递{index, canplay}
                _syncContext.Post(Sync_LinklableData, new String[] { i + "", canPlay + "" });
            }
            catch (Exception ee) {
                //MessageBox.Show("查询站点炸了，静待修复...");
                Console.WriteLine(i);
            }
        }
        public String Reg_replace(String source, String regStr, String replaceStr) {
            Regex reg = new Regex(regStr);
            String outSS = reg.Replace(source, replaceStr);
            return outSS;
        }
  
        public void SetComboxSize(Object obj) { //size >= 1
            int size = this.CiteValue.maxIndex;
            int curindex = this.CiteValue.curIndex;
            if (size < 0 || curindex > size) {
                size = curindex = this.CiteValue.maxIndex = this.CiteValue.curIndex = 1;
            }
            this.comboBox1.Items.Clear();
            for (int i = 1; i <= size; i++) {
                this.comboBox1.Items.Add("第" + i + "页");
            }
            this.comboBox1.SelectedIndex = curindex - 1; // combox内部是从0开始编号的，-固定
            isFinish = true;
            renewButtonState();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            //this.curIndex = this.comboBox1.SelectedIndex+1;
            if (isFinish == false) return; // 表示是代码调用，非事件调用
            isFinish = false;
            this.CiteValue.curIndex = this.comboBox1.SelectedIndex + 1;
            renewButtonState();
            this.doSearchThread();
        }

        public void renewButtonState() {
            Console.Write(this.CiteValue.curIndex +" "+ this.CiteValue.maxIndex);
            if (this.CiteValue.curIndex == 1)
                this.btnPre.Enabled = false;
            else
                this.btnPre.Enabled = true;
            if (this.CiteValue.curIndex == this.CiteValue.maxIndex)
                this.btnNext.Enabled = false;
            else
                this.btnNext.Enabled = true;
        }

        private void btnPre_Click(object sender, EventArgs e) {
            this.CiteValue.curIndex--;
            doSearchThread();
        }

        private void btnNext_Click(object sender, EventArgs e) {
            this.CiteValue.curIndex++;
            doSearchThread();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e) {
            if (!this.radioButton1.Checked) return;
            CiteValue.CITE_SEARCH_FLAG = 0;
            if (input_search.Text.Length != 0)
                doSearchThread();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e) {
            if (!this.radioButton2.Checked) return;
            CiteValue.CITE_SEARCH_FLAG = 1;
            if (input_search.Text.Length != 0)
                doSearchThread();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e) {
            if (!this.radioButton3.Checked) return;
            CiteValue.CITE_SEARCH_FLAG = 2;
            if (input_search.Text.Length != 0)
                doSearchThread();
        }
        private void Form1_Load(object sender, EventArgs e) {
            this.comboBox2.SelectedIndex = 0;
            lblStatus.Text = "检测更新中..."; // 
            WebCheckTimer.Enabled = true;
            defaultNameSize = this.dataGridView1.Columns[2].Width;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e){
            try {
                String data = (String)dataGridView1.SelectedCells[3].Value;
                //// 准备copy到剪切板
                Clipboard.SetData(DataFormats.Text, data);
                lblStatus.Text = "地址已经复制到剪切板";
                Thread thread = new Thread(Thread_RenewLbl);
                thread.Start();
            }
            catch (Exception ee) {
                Console.WriteLine(ee.Message);
            }
        }
        private void listView1_DoubleClick(object sender, EventArgs e) {
            String text = this.listView1.FocusedItem.SubItems[3].Text;
            // 准备copy到剪切板
            Clipboard.SetData(DataFormats.Text, text);
            lblStatus.Text = "地址已经复制到剪切板";
            Thread thread = new Thread(Thread_RenewLbl);
            thread.Start();
        }

        public void Thread_RenewLbl() {
            Thread.Sleep(500);
            _syncContext.Post(Sync_lbl, "请低调使用");
        }
        private void ContextM_OutAddr_Click(object sender, EventArgs e) {
            String outSS = "";
            //foreach (ListViewItem item in listView1.Items) {
            //    count++;
            //    if (item.Selected == true) {
            //        outSS += (item.SubItems[3].Text + "\r\n");
            //    }
            //    if (count == 15) {
            //        outSS +=  "\r\n";
            //    }
            //}
            DataGridViewSelectedRowCollection select = dataGridView1.SelectedRows;
            IEnumerator enumetor = select.GetEnumerator();
            while (enumetor.MoveNext()) {
                DataGridViewRow row =  (DataGridViewRow)enumetor.Current;
                outSS+=(row.Cells[3].Value+"\r\n");
            }
            WriteToFile("./地址导出.txt", outSS);
            /**llllllllllllll*/
            lblStatus.Text = "导出成功";
        }
        private void ContextM_OutName_Click(object sender, EventArgs e) {
            String outSS = "";
            //foreach (ListViewItem item in listView1.Items) {
            //    if (item.Selected == true) {
            //        outSS += (item.SubItems[2].Text + "\r\n");
            //    }
            //}
            DataGridViewSelectedRowCollection select = dataGridView1.SelectedRows;
            IEnumerator enumetor = select.GetEnumerator();
            while (enumetor.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)enumetor.Current;
                outSS += (row.Cells[2].Value + "\r\n");
            }
            WriteToFile("./名称导出.txt", outSS);
            /**llllllllllllll*/
            lblStatus.Text = "导出成功";
        }
        private void WriteToFile(String location, String text) {
            FileStream filestream = new FileStream(location, FileMode.OpenOrCreate);
            StreamWriter swriter = new StreamWriter(filestream);
            swriter.Write(text);
            swriter.Flush();
            swriter.Close();
            filestream.Close();
        }
        private String myDecode(String old) {
            char c;
            char[] olds = old.ToCharArray();
            char[] all = "abcdefghijklmnopqrstuvwxzy".ToCharArray(); //24
            StringBuilder outBuffer = new StringBuilder();
            for (int i = 0; i < old.Length; i++)
            {
                c = olds[i];
                if (c >= 'a' && c <= 'z')
                    c = all[(c - 'a' + 8) % 24];
                outBuffer.Append(c);
            }
            return outBuffer.ToString();
        }
        private String myEncode(String old)
        {
            char c;
            char[] olds = old.ToCharArray();
            char[] all = "abcdefghijklmnopqrstuvwxzy".ToCharArray(); //24
            StringBuilder outBuffer = new StringBuilder();
            for (int i = 0; i < old.Length; i++)
            {
                c = olds[i];
                if (c >= 'a' && c <= 'z')
                    c = all[(c - 'a' + 16) % 24];
                outBuffer.Append(c);
            }
            return outBuffer.ToString();
        }
        private void button3_Click(object sender, EventArgs e) {
            this.TopMost = !this.TopMost;
            int i = this.Text.IndexOf("[置顶]");
            if (i < 0)
            {
                this.Text += "[置顶]";
            }
            else {
                this.Text = this.Text.Substring(0, i);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
            CiteValue.CITE_FILAG = this.comboBox2.SelectedIndex;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e) {
                textBox1.SelectAll();
        }

        private void btnNewMovie_Click(object sender, EventArgs e) {
            RecentMovies frm2 = new RecentMovies();
            frm2.Owner = this;
            frm2.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            // 删除原来已经存在的图片文件
            try {
                for (int i = 0; i < 50; i++) {
                    String imgDir = System.IO.Path.GetTempPath() + "ACKANii" + i + ".jpg";
                    if (File.Exists(imgDir))
                        File.Delete(imgDir);
                }
                this.playForm.Close();
            } catch (Exception ee) {
                Console.WriteLine(ee.Message);
            }
            Environment.Exit(0);
        }
        public void dealVisible(Boolean visible) {
            //MessageBox.Show("设置为可见");
            this.Visible = visible;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            { //选中的是标题栏
                try
                {
                    String columnName = dataGridView1.Columns[e.ColumnIndex].Name;
                    if (columnName.Equals("CPlay"))
                    {
                        tryToPlay();
                    }
                }
                catch (Exception ee)
                {
                    Console.WriteLine(ee.Message);
                }
            }
        }
        public void tryToPlay() {
            int rowIndex = Int32.Parse((String)dataGridView1.SelectedRows[0].Cells[0].Value);
            VideoPlayer.Get.MutiPlay fm1 = new VideoPlayer.Get.MutiPlay(alldata[rowIndex].location);
            String text = (String)dataGridView1.SelectedRows[0].Cells[6].Value;
            if (!text.Equals("无效"))
            {
                //MessageBox.Show(alldata[rowIndex].fileCount+"");
                if (alldata[rowIndex].fileCount == 1)
                {
                    //MessageBox.Show("播放");
                    String url = urlPlay.Replace("CODE", alldata[rowIndex].codeUrl) + alldata[rowIndex].filetype;
                    String cookie = alldata[rowIndex].cookie;
                    String name = alldata[rowIndex].namePlay;
                    //MessageBox.Show(url+"\n"+cookie);
                    Console.WriteLine(url + "\n" + cookie);
                    try
                    {
                        playForm = null;
                        playForm = new VideoPlayer.Form1(url, cookie, name);
                        playForm.Show();
                        playForm.dtHandler += new VideoPlayer.Form1.DataChangeHandler(dealVisible); //定义一个委托
                                                                                                    //playForm.Visible = true;
                                                                                                    //this.AddOwnedForm(playForm);
                                                                                                    //this.AddOwnedForm(playForm);
                        this.Visible = false;
                        playForm.Play();
                    }
                    catch (Exception ee)
                    {
                        Console.WriteLine(ee.Message);
                    }
                }
                else {
                    //弹出窗口，窗口中请求第二个地址，样式和本dataview相似
                    //MessageBox.Show("多个资源");
                    DialogResult result = fm1.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        try
                        {
                            playForm = null;
                            playForm = new VideoPlayer.Form1(fm1.playinfo.url, fm1.playinfo.cookie, fm1.playinfo.name);
                            playForm.Show();
                            playForm.dtHandler += new VideoPlayer.Form1.DataChangeHandler(dealVisible); //定义一个委托
                            this.Visible = false;
                            playForm.Play();
                        }
                        catch (Exception ee)
                        {
                            MessageBox.Show(ee.Message);
                            Console.WriteLine(ee.Message);
                        }
                    }
                    else if (result == DialogResult.Ignore) {
                        //MessageBox.Show("播放");
                        String url = urlPlay.Replace("CODE", alldata[rowIndex].codeUrl) + alldata[rowIndex].filetype;
                        String cookie = alldata[rowIndex].cookie;
                        String name = alldata[rowIndex].namePlay;
                        //MessageBox.Show(url+"\n"+cookie);
                        Console.WriteLine(url + "\n" + cookie);
                        try
                        {
                            playForm = null;
                            playForm = new VideoPlayer.Form1(url, cookie, name);
                            playForm.Show();
                            playForm.dtHandler += new VideoPlayer.Form1.DataChangeHandler(dealVisible); //定义一个委托
                                                                                                        //playForm.Visible = true;
                                                                                                        //this.AddOwnedForm(playForm);
                                                                                                        //this.AddOwnedForm(playForm);
                            this.Visible = false;
                            playForm.Play();
                        }
                        catch (Exception ee)
                        {
                            MessageBox.Show(ee.Message);
                            Console.WriteLine(ee.Message);
                        }
                    }
                }
            }
            else {
                MessageBox.Show("不做事");
                return;
            }
        }
        private void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            try {
                if (e.Column.Name.Equals("CSize")) {
                    //if (e.CellValue1.Equals(e.CellValue2)) {
                    //    e.SortResult = -1;
                    //    e.Handled = true;
                    //}
                    String[] data1 = MyReg.Reg_GetFirstMutiString(e.CellValue1.ToString(), "(\\d+\\.?\\d*)+\\s*(GB|MB)");
                    String[] data2 = MyReg.Reg_GetFirstMutiString(e.CellValue2.ToString(), "(\\d+\\.?\\d*)+\\s*(GB|MB)");
                    double ddata1 = double.Parse(data1[0]); int flag1 = data1[1].Equals("MB") ? 0 : 1;
                    double ddata2 = double.Parse(data2[0]); int flag2 = data2[1].Equals("MB") ? 0 : 1;
                    int flag = flag1 - flag2;
                    if (flag == 0) { //单位相同比大小
                        flag = (ddata1 - ddata2) >= 0 ? 1 : -1;
                    }
                    e.SortResult = flag;
                    e.Handled = true;
                } else if (e.Column.Name.Equals("CHot") || e.Column.Name.Equals("CNum")) {//热度排序和index排序
                    int data1 = MyReg.Reg_GetFirstNum(e.CellValue1.ToString(), "(\\d+)");
                    int data2 = MyReg.Reg_GetFirstNum(e.CellValue2.ToString(), "(\\d+)");
                    e.SortResult = data1 - data2;
                    e.Handled = true; //不要会炸
                }
            }
            catch (Exception ee) {
                Console.WriteLine("我日了狗"+ee.Message);
            }
            //   如果是学号或成绩列，则按浮点数处理
            //if (e.Column.Name == "大小")
            //{
            //    if(data1.)
            //    e.SortResult = (Convert.ToDouble(e.CellValue1) - Convert.ToDouble(e.CellValue2) > 0) ? 1 : (Convert.ToDouble(e.CellValue1) - Convert.ToDouble(e.CellValue2) < 0) ? -1 : 0;
            //    e.Handled = true;
            //}
            ////否则，按字符串比较
            //else
            //{
            //    return;
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VideoPlayer.Get.ListForm listform = new VideoPlayer.Get.ListForm();
            this.AddOwnedForm(listform);
            this.Enabled = false;
            listform.Show();
        }
        public void Btn2ListFormDeal(String[] mangnets) {
            //alldata = new Alldata[500];
            int min = mangnets.Length >= 500 ? 500 : mangnets.Length;
            mutiCount = min;
            //if (min > 0) allcount = min;
            _syncContext.Post(Sync_lbl, "获取中。。。");
            for (int i = 0; i < min; i++)
            {
                alldata[Alldata.allcount] = new Alldata();
                alldata[Alldata.allcount].location = "magnet:?xt=urn:btih:"+mangnets[i];
                alldata[Alldata.allcount].curIndex = Alldata.allcount;
                Thread athread = new Thread(ThreadGetAllPlayAddr2);
                athread.Start(Alldata.allcount);
                Alldata.allcount++;
            }
        }
        public void ThreadGetAllPlayAddr2(Object obj) {
            try {
                int i = (int)obj;
                
                String magnet = alldata[i].location;
                String code = MyReg.Reg_GetFirstString(magnet, "(?<=btih:)([\\d\\w]{40})");
                Console.WriteLine(i);
                String HTML = MyHttp.myHttpStringPost(requestUrl, "UTF-8", "CODE=" + code);
                //Thread.Sleep(50);
                
                int canPlay = MyReg.Reg_GetFirstNum(HTML, "A=(.*)?\\r\\n");
                String text = HttpUtility.UrlDecode(MyReg.Reg_GetFirstString(HTML, "B=(.*)?\\r\\n"));
                int index = text.IndexOf("】")+1;
                index = index > -1 ? index : 0;
                alldata[i].namePlay = text.Substring(index);
                alldata[i].codeUrl = myDecode(MyReg.Reg_GetFirstString(HTML, "C=(.*)?\\r\\n"));
                alldata[i].filetype = MyReg.Reg_GetFirstString(HTML, "D=(.*)?\\r\\n");
                alldata[i].cookie = "FTN5K=" + MyReg.Reg_GetFirstString(HTML, "E=(.*)?\\r\\n");
                alldata[i].fileCount = Int32.Parse(MyReg.Reg_GetFirstString(HTML, "F=(.*)?\\r\\n"));
                alldata[i].fileSize = MyReg.Reg_GetFirstString(HTML, "G=(.*)?\\r\\n");
                //MessageBox.Show("["+ alldata[i].codeUrl + "]");
                alldata[i].canPlay = canPlay;
                //if(canPlay == 1) //使用invoke传递消息，通知修改linklable的值,传递{index, canplay}
                if (i == mutiCount-1)
                    _syncContext.Post(Sync_lbl, "获取完成");
                _syncContext.Post(Sync_OneRowDataGrid, alldata[i]);
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }
        public void Sync_OneRowDataGrid(Object obj) {
            Alldata onedata = (Alldata)obj;
            int index = onedata.curIndex;
            int canplay = onedata.canPlay;
            String text;
            switch (canplay)
            {
                case -3: //查找资源错误
                case -2: //资源已经过期
                case -1: //暂时找不到该资源
                    text = "无效"; break;
                case 1:
                    text = "点击播放"; break;
                case 2:
                    text = "选择播放"; break;
                default: //未知错误
                    text = "无效"; break;
            }
            String[] oneRow = new String[7];
            oneRow[0] = index+"";
            oneRow[1] = onedata.fileSize;
            oneRow[2] = onedata.namePlay;
            oneRow[3] = onedata.location;
            oneRow[4] = "1"+ "\u2103";
            oneRow[5] = "--";
            oneRow[6] = text;
            this.dataGridView1.Rows.Add(oneRow);
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tryToPlay();
        }

        private void input_search_Click(object sender, EventArgs e)
        {
            if (input_search.Tag == null) {
                this.input_search.SelectAll();
                this.input_search.Tag = 0;
            }
        }

        private void input_search_Leave(object sender, EventArgs e)
        {
            this.input_search.Tag = null;
        }
        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //VideoPlayer.Dialog.Form1 Dia_fankui = new VideoPlayer.Dialog.Form1();
            //if (Dia_fankui.ShowDialog() == DialogResult.OK)
            //    ;
            System.Diagnostics.Process.Start("http://bbs.kafan.cn/thread-1870031-1-1.html");
        }

        private void WebCheckTimer_Tick(object sender, EventArgs e)
        {
            WebCheckTimer.Enabled = false;
            Thread webCheckThread = new Thread(webCheckThreadFunc);
            webCheckThread.Start();
        }
        public void webCheckThreadFunc()
        {
            //try
            //{
            //    WebClient webc = new WebClient();
            //    String data = webc.DownloadString("http://www.bt-soso.com/sitemap.xml");
            //    if (data.Length > 0)
            //        lblStatus.Text = "网站连接正常 O_O";
            //    else
            //        throw new Exception();
            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show(this, "网站连接出了问题，请联系网站站长", "啊~~出问题了");
            //    System.Diagnostics.Process.Start("http://wpa.qq.com/msgrd?v=3&uin=1695885434&site=qq&menu=yes");
            //}
            try
            {
                String HTML = MyHttp.myHttpStringGet("http://www.kafan.cn/home.php?mod=space&uid=866624&do=blog&id=11178", "GBK");
                String version = MyReg.Reg_GetFirstString(HTML, "【(V\\d+.\\d+)】");
                if (!version.Equals("V2.5") && !version.Equals(""))
                {
                    String text = MyReg.Reg_GetFirstString(HTML, "】([^【]+)");
                    text = text.Replace("|", "\n");
                    if (MessageBox.Show(this, version + text, "点击更新~", MessageBoxButtons.OKCancel, MessageBoxIcon.None, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        System.Diagnostics.Process.Start("http://bbs.kafan.cn/thread-1870031-1-1.html");
                        this.Close();
                    }
                }
                this.lblStatus.Text = "当前是最新版本";
            }
            catch (Exception ee)
            {
                //MessageBox.Show(this, "检测更新失败", "啊~~出问题了");
            }
        }

        private void dataGridView1_Resize(object sender, EventArgs e)
        {
            Console.WriteLine(this.Width - 700);
            this.dataGridView1.Columns[2].Width = defaultNameSize + this.Width - 700;
        }

        private void 复制名称ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String name = (String)dataGridView1.SelectedRows[0].Cells[2].Value;
                Clipboard.SetData(DataFormats.Text, name);
            }
            catch (Exception ee)
            {

            }

        }

        private void 复制地址ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                String addr = (String)dataGridView1.SelectedRows[0].Cells[3].Value;
                Clipboard.SetData(DataFormats.Text, addr);
            }
            catch (Exception ee)
            {

            }
        }
        private readonly int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private readonly int MOUSEEVENTF_LEFTUP = 0x0004;
        private readonly int MOUSEEVENTF_ABSOLUTE = 0x8000;

        [System.Runtime.InteropServices.DllImport("user32")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (ModifierKeys == Keys.Shift && e.Button == MouseButtons.Right)
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, e.X, e.Y, 0, IntPtr.Zero);
                mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, e.X, e.Y, 0, IntPtr.Zero);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://bbs.kafan.cn/thread-1870031-1-1.html");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }
    }
}
