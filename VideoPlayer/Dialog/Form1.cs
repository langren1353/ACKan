using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VideoPlayer.Dialog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://bbs.kafan.cn/thread-1870031-1-1.html");
            this.Close();
            //http://bbs.kafan.cn/thread-1870031-1-1.html
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://bbs.kafan.cn/thread-1934872-1-1.html");
            this.Close();
            //http://bbs.kafan.cn/thread-1934872-1-1.html
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.bt-soso.com/message.html");
            this.Close();
            //http://www.bt-soso.com/message.html
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
