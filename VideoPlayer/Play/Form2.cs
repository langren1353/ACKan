using System;
using System.Net;
using System.Web;
using System.Windows.Forms;

namespace VideoPlayer
{
    public partial class Form2 : Form
    {
        public int flag = 0;
        public String errorInfo = "";
        public String endUrl = "";
        public String cookie = "";
        public String name = "";
        public Form2()
        {
            WebClient web = new WebClient();
            //web.DownloadFile("http://xfxa.ctfs.ftn.qq.com/ftn_handler/f58be44b6eb1f88e35ab4c84139b87262d70f0845d6118abbfca707fcc6a771e3c58813f6f478e2d758cab76d629cfec07069b393d1838a9be739d076acd979d?compressed=0&dtype=1&fname=A.mp4", "D:/A.txt");
            //MessageBox.Show(MyHttp.myHttpStringGet("http://xfxa.ctfs.ftn.qq.com/ftn_handler/f58be44b6eb1f88e35ab4c84139b87262d70f0845d6118abbfca707fcc6a771e3c58813f6f478e2d758cab76d629cfec07069b393d1838a9be739d076acd979d?compressed=0&dtype=1&fname=A.mp4", "UTF-8"));
            //MessageBox.Show(MyHttp.myHttpStringGet("http://xfxa.ctfs.ftn.qq.com/ftn_handler/f58be44b6eb1f88e35ab4c84139b87262d70f0845d6118abbfca707fcc6a771e3c58813f6f478e2d758cab76d629cfec07069b393d1838a9be739d076acd979d?compressed=0&dtype=1&fname=A.mp4", "UTF-8"));
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textUrl.Text.Equals("") && this.textCookie.Text.Equals(""))
            {
                flag = myFunction();
                //this.textBox1.Text = this.endUrl + "\n" + this.cookie;

                this.textUrl.Text = this.endUrl;
                this.textCookie.Text = this.cookie;
            }
            this.endUrl = Form1.defaultHost + this.textUrl.Text;
            this.cookie = this.textCookie.Text;
            this.flag = 1;
            //MessageBox.Show(this.endUrl+"\n"+this.cookie);
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private int myFunction()
        {
            //try
            //{
            String magnet = textBox1.Text.Trim();
            // 需要检测是否为磁力在操作
            String key = MyReg.Reg_GetFirstString(magnet, "(?<=btih:)(\\S{40})");
            String HTML = MyHttp.myHttpStringGet("http://i.vod.xunlei.com/req_subBT/info_hash/" + key + "/req_num/1000/req_offset/0", "UTF-8");
            //MessageBox.Show(HTML);
            String index = MyReg.Reg_GetFirstString(HTML, "index.*?(\\d)"); // 视频所在index
            String fileName = MyReg.Reg_GetFirstString(HTML, "name\":\\s *\"([^\"]+)\"");
            if (index.Equals("")) {
                errorInfo = "暂时找不到该资源";
                return -1;
            }
            String data = "torrent_para={\"uin\":\"123456\",\"hash\":\""+key+"\",\"taskname\":\"M\",\"data\":[{\"index\":" + index + ",\"filesize\":1,\"filename\":\"m.mkv\"}]}";
            HTML = MyHttp.myHttpStringPost("http://fenxiang.qq.com/upload/index.php/upload_c/checkExist", "UTF-8", data);
            //MessageBox.Show(data);
            String fileHash = MyReg.Reg_GetFirstString(HTML, "\"([^\"]{40})\"");
            Int64 filesize = Int64.Parse(MyReg.Reg_GetFirstString(HTML, "file_size.*?(\\d+)"));
            if (fileHash.Equals("") || fileHash.Equals("0000000000000000000000000000000000000000") || filesize < 138622344)
            {
                errorInfo = "资源已经过期";
                return -1;
            }
            data = "hash=" + fileHash + "&filename=m.mkv";
            HTML = MyHttp.myHttpStringPost("http://lixian.qq.com/handler/lixian/get_http_url.php", "UTF-8", data);
            String httpUrl = MyReg.Reg_GetFirstString(HTML, "(/ftn_handler/[\\w\\d]{128})")+"?compressed=0&dtype=1&fname=m.mkv";
            String cookieData = "FTN5K=" + MyReg.Reg_GetFirstString(HTML, "com_cookie.*?([\\w\\d]+)");
            Console.WriteLine(HTML);
            //MessageBox.Show(HTML);
            if (httpUrl.Equals("")) {
                errorInfo = "查找资源错误";
                return -1;
            }
            this.endUrl = httpUrl;
            this.cookie = cookieData;
            this.name = HttpUtility.UrlDecode(fileName);


            //this.URL = this.URL.Replace("xflxsrc.store.qq.com:443", "xfxa.ctfs.ftn.qq.com");//???
            //this.endUrl = this.endUrl.Replace("xflxsrc.store.qq.com:443", "sh.ctfs.ftn.qq.com");//???
            //}
            //catch (Exception e) { //未知异常错误
            //    MessageBox.Show(e.Message);
            //    Console.WriteLine(e);
            //    return -2;
            //}
            return 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.endUrl = this.textBox1.Text.Trim();
            this.flag = 1;
            DialogResult = DialogResult.OK;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.textUrl.Text.Equals("") && this.textCookie.Text.Equals(""))
            {
                flag = myFunction();
                //this.textBox1.Text = this.endUrl + "\n" + this.cookie;

                this.textUrl.Text = this.endUrl;
                this.textCookie.Text = this.cookie;
            }
            this.endUrl = Form1.defaultHost + this.textUrl.Text;
            this.cookie = this.textCookie.Text;
            this.flag = 1;
        }
    }
}
