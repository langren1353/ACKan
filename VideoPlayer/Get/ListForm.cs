using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VideoPlayer.Get
{
    public partial class ListForm : Form
    {
        public static String oldText = "";
        public ListForm()
        {
            InitializeComponent();
            this.textBox1.Text = oldText;
            this.textBox1.ForeColor = Color.Gray;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String[] result = dealText();
            if (result.Length != 0) 
            {
                WindowsFormsApplication2.Form1 fm1 = (WindowsFormsApplication2.Form1)this.Owner;
                fm1.Btn2ListFormDeal(result);
                this.Close();
            }
            else {
                if (MessageBox.Show("无效", "没有磁力，别玩了", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    this.Close();
            }
        }
        private String[] dealText() {
            String text = this.textBox1.Text.Trim();
            oldText = text;
            return MyReg.Reg_GetAllString(text, "([\\d\\w]{40})");
        }
        private void ListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            WindowsFormsApplication2.Form1 fm1 = (WindowsFormsApplication2.Form1)this.Owner;
            fm1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            String text = Clipboard.GetText();
            if (!text.Equals("") && text.IndexOf("magnet")>-1) {
                this.textBox1.Text = text;
            }
        }
    }
}
