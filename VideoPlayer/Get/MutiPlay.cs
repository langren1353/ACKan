using System;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;

namespace VideoPlayer.Get
{
    public partial class MutiPlay : Form
    {
        SynchronizationContext _syncContext = null;
        private String TRCode;
        private String urlPlay = Form1.defaultHost + "/ftn_handler/CODE?compressed=0&dtype=1&fname=A.";
        private String requestUrl = Program.DEBUG_MUTI_URL + "/CodeDeal/find2";
        private String[] Fname;
        private String[] Fsize;
        private String[] Fcode; // code 为空则不能播，size=1不能播
        private String[] Fcookie;

        private int tmpCount = 0;
        public class PlayInfo{
            public String url;
            public String cookie;
            public String name;
        }
        public PlayInfo playinfo = new PlayInfo();
        public MutiPlay()
        {
            InitializeComponent();
            _syncContext = SynchronizationContext.Current;
        }
        public MutiPlay(String TRCode)
        {
            //this.Location = new Point(Screen.GetWorkingArea(this).Width / 2 + 300, Screen.GetWorkingArea(this).Height / 2 - 200);
            InitializeComponent();
            _syncContext = SynchronizationContext.Current;
            if (TRCode.Length > 40)
                this.TRCode = MyReg.Reg_GetFirstString(TRCode, "(?<=btih:)(\\S{40})");
            Thread thread = new Thread(getThread);
            thread.Start();
            Thread.Sleep(700);
            timer1.Enabled = true;
        }
        public void getThread()
        {
            try
            {
                String code = TRCode;
                String HTML = MyHttp.myHttpStringPost(requestUrl, "UTF-8", "CODE=" + code);
                //Thread.Sleep(50);
                Fname = MyReg.Reg_GetAllString(HTML, "B\\d+=(.*)\\r\\n");
                Fcookie = MyReg.Reg_GetAllString(HTML, "D\\d+=(.*)\\r\\n");
                Fcode = MyReg.Reg_GetAllString(HTML, "C\\d+=(.*)\\r\\n");
                for (int i = 0; i < Fname.Length; i++) //解码
                {
                    String ttext = HttpUtility.UrlDecode(Fname[i]);
                    int index = ttext.IndexOf("】") + 1;
                    Fname[i] = ttext.Substring(index);
                    Fcookie[i] = "FTN5K=" + Fcookie[i];
                    Fcode[i] = myDecode(Fcode[i]);
                }
                Fsize = MyReg.Reg_GetAllString(HTML, "E\\d+=(.*)\\r\\n");
                timer1.Enabled = false;
                _syncContext.Post(Sync_data, "查询结束~~");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Console.WriteLine(e.Message);
            }
        }
        private String myDecode(String old)
        {
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
        public void Sync_data(Object obj)
        {
            String text = (String)obj;
            this.Text = text;
            for (int i = 0; i < Fname.Length; i++) {
                String[] oneRow = new String[4];
                oneRow[0] = i+"";
                oneRow[1] = Fsize[i];
                oneRow[2] = Fname[i];
                String canPlayRow = "点击播放";
                if (Fcode[i].Length == 0 || Fsize.Equals("1"))
                    canPlayRow = "无效";
                oneRow[3] = canPlayRow;
                this.dataGridView1.Rows.Add(oneRow);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String columnName = dataGridView1.Columns[e.ColumnIndex].Name;
                if (columnName.Equals("CFcanplay"))
                {
                    tryToPlay();
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
        }
        public void tryToPlay() {
            int rowIndex = Int32.Parse((String)dataGridView1.SelectedRows[0].Cells[0].Value);
            //MessageBox.Show(columnName);
            String text = (String)dataGridView1.SelectedRows[0].Cells[3].Value;
            if (text.Equals("点击播放"))
            {
                //MessageBox.Show("播放");
                String filetype = MyReg.Reg_GetLastString(this.Fname[rowIndex], ".*\\.(.*)");
                playinfo.url = urlPlay.Replace("CODE", this.Fcode[rowIndex]) + filetype;
                playinfo.cookie = this.Fcookie[rowIndex];
                playinfo.name = this.Fname[rowIndex];
                DialogResult = DialogResult.OK;
            }
            else {
                //MessageBox.Show("不做事");
                return;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tmpCount++;
            if (tmpCount == 4)
            {
                this.Text = "查询中";
                tmpCount = 0;
                return;
            }
            this.Text += ".";
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tryToPlay();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Ignore;
            this.Close();
        }
        
    }
}
