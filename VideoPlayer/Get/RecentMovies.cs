using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication2 {
    public partial class RecentMovies : Form {
        public String[] title;
        public String[] detailHref;
        int curIndex;
        public RecentMovies() {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Form2_Load(object sender, System.EventArgs e) {
            listView1.Columns.Add("", 165);
            listView1.HeaderStyle = ColumnHeaderStyle.None; // 表头不可见
            getThread();
        }
        private void getThread() {
            Thread thread = new Thread(doSearch);
            String url = "http://top.baidu.com/buzz?b=26&c=1&fr=topcategory_c1";
            thread.Start(url);
        }
        private void doSearch(object url) {
            //_syncContext.Post(Sync_lbl, "搜索中....");
            // 获取网页源码--> HTMLVALUE
            String HTMLVALUE = getHTMLVALUE(url.ToString());
            initWithHTMLValue(HTMLVALUE);
            //_syncContext.Post(Sync_lbl, "搜索完成，请低调使用");
        }
        private void doSearch2(object url) {
            String HTMLVALUE = getHTMLVALUE(url.ToString());
            initWithHTMLDetail(HTMLVALUE);
        }
        public String getHTMLVALUE(String url) {
            try { 
                HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(url);
                httpReq.Method = "GET";
                HttpWebResponse httpResp = (HttpWebResponse)httpReq.GetResponse();
                Stream stream = httpResp.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding("GBK"));
                String HTMLVALUE = streamReader.ReadToEnd();
                stream.Close();
                httpResp.Close();
                return HTMLVALUE;
            } catch (Exception ee) {
                return "";
            }
        }
        private void initWithHTMLValue(String HTMLVALUE) {
            title = MyReg.Reg_GetAllString(HTMLVALUE, "<a class=\"list-title\"[^>]+>([^<]+)</a>");
            detailHref = MyReg.Reg_GetAllString(HTMLVALUE, "<a href=\"([^\"]+)\".*?>search</a>");
            if (title != null) {
                listView1.BeginUpdate();
                for (int i = 0; i < title.Length; i++) {
                    listView1.Items.Add(new ListViewItem(new string[] { title[i] }, 165));
                }
                listView1.EndUpdate();
            }
            this.Text = "获取成功，双击电影名称可获取详细信息";
        }
        private void initWithHTMLDetail(String HTMLVALUE) {
            String textDetail = MyReg.Reg_GetFirstString(HTMLVALUE, "<p class=\"text\">([^<]+)</p>");
            String imgUrl = MyReg.Reg_GetFirstString(HTMLVALUE, "src=\"(?=http://imgsrc)([^\"]+)\"");
            this.textBox1.Text = textDetail;
            String imgDir = System.IO.Path.GetTempPath() +"ACKANii"+ curIndex +".jpg";
            try {
                if (File.Exists(imgDir)) {
                    this.pictureBox1.Image = Bitmap.FromFile(imgDir);
                    return;
                }
            } catch (Exception e) {
                // 未知原因，获取图片失败，导致读取图片也失败的outofMemory错误
                try {
                    File.Delete(imgDir);
                } catch (Exception ee) {
                    // 文件争用
                }
            }
            try {
                WebClient mywebclient = new WebClient();
                //Console.WriteLine("获取图片中,,,,,,");
                mywebclient.DownloadFile(imgUrl, imgDir);
                Thread.Sleep(200);
                this.pictureBox1.Image = Bitmap.FromFile(imgDir);
            } catch (Exception ee) {
                // 未知的错误，获取图片成功，但是会返回”无法连接到远程服务器“错误
                // 可能由于没有下载完全，可能出现outofMemory错误
            }
        }
        private void listView1_DoubleClick(object sender, EventArgs e) {
            curIndex = listView1.SelectedIndices[0];
            //获得图片，下载图片，获得详情
            String url = "http://top.baidu.com/" + detailHref[curIndex].Substring(2);
            //MessageBox.Show(url);
            Thread thread = new Thread(doSearch2);
            thread.Start(url);
        }

        private void button1_Click(object sender, EventArgs e) {
            String url = "http://www.baidu.com/s?word=" + title[curIndex];
            System.Diagnostics.Process.Start(url);
        }

        private void button2_Click(object sender, EventArgs e) {
            String url = "http://baike.baidu.com/search/word?word=" + title[curIndex];
            System.Diagnostics.Process.Start(url);
        }

        private void button3_Click(object sender, EventArgs e) {
            Form1 fm1 = (Form1)this.Owner;
            fm1.Controls["input_search"].Text = title[curIndex];
            fm1.doSearchThread();
        }
    }
}
