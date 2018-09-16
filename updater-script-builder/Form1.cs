using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace updater_script_builder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void codeGround_TextChanged(object sender, EventArgs e)
        {

        }
        private void codeGround_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void codeGround_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.Enter) { }
            KeyDownUp(sender, e);
        }
        private void codeGround_KeyUp(object sender, KeyEventArgs e)
        {
            //codeGround.Text = e.KeyData.ToString();
            //codeGround.Text = e.KeyValue.ToString();
            //KeyDownUp(sender, e);
        }

        private void KeyDownUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)/* 判断是否为空格 */
            {
                RichTextBox rich = (RichTextBox)sender;
                string s = GetLastWord(rich.Text, rich.SelectionStart);

                if (AllClass().IndexOf(s) > -1)
                {
                    MySelect(rich, rich.SelectionStart, s, Color.Blue, true);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //codeGround.KeyDown += new KeyEventHandler(rich_KeyDown);   //这一行添加到Form1_Load中

            codeGround.SelectionFont = new Font("宋体", 12, (FontStyle.Regular));
            codeGround.Text = "public private static void true false string Regex RegexOptions new Get if else return\r"
                + "以上字符是加载字符.\r";
            codeGround.Select(codeGround.Text.Length, 0);
        }
        //void rich_KeyDown(object sender, KeyEventArgs e)
        //{
        //    //if (e.KeyData == Keys.Enter) { }


        //    RichTextBox rich = (RichTextBox)sender;
        //    string s = GetLastWord(rich.Text, rich.SelectionStart);

        //    if (AllClass().IndexOf(s) > -1)
        //    {
        //        MySelect(rich, rich.SelectionStart, s, Color.Blue, true);
        //    }
        //}


        /// <summary> 建立关键字 </summary>
        /// <returns></returns>
        public static List<string> AllClass()
        {
            List<string> list = new List<string>();
            list.Add("string");
            list.Add("public");
            list.Add("new");
            list.Add("int");
            list.Add("static");
            list.Add("Get");
            list.Add("RegexOptions");
            list.Add("Regex");
            list.Add("if");
            list.Add("else");
            list.Add("return");
            list.Add("void");
            list.Add("private");
            list.Add("true");
            list.Add("false");
            list.Add("");
            list.Add("");

            return list;
        }

        public static string GetLastWord(string str, int i)
        {
            string x = str;
            Regex reg = new Regex(@"[aA-zZ]+$", RegexOptions.RightToLeft);
            x = reg.Match(x).Value;

            Regex reg2 = new Regex(@"\s");
            x = reg2.Replace(x, "");

            return x;
        }


        public static void MySelect(System.Windows.Forms.RichTextBox tb, int i, string s, Color c, bool font)
        {
            tb.Select(i - s.Length, s.Length);
            tb.SelectionColor = c;

            if (font)
            {
                tb.SelectionFont = new Font("宋体", 12, (FontStyle.Bold));
            }
            //else
            //    tb.SelectionFont = new Font("宋体", 12, (FontStyle.Regular));

            //以下是把光标放到原来位置，并把光标后输入的文字重置
            tb.Select(i, 0);
            tb.SelectionFont = new Font("宋体", 12, (FontStyle.Regular));
            tb.SelectionColor = Color.Black;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }



        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
