using System;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Diagnostics;

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
            KeyDownUp(sender, e);
        }
        private void codeGround_KeyUp(object sender, KeyEventArgs e)
        {

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
        private void Form1_Load_1(object sender, EventArgs e)
        {
            codeGround.KeyDown += new KeyEventHandler(codeGround_KeyDown);

            codeGround.SelectionFont = new Font("宋体", 12, (FontStyle.Regular));
            codeGround.Select(codeGround.Text.Length, 0);
        }



        /// <summary> 建立关键字 </summary>
        /// <returns></returns>
        public static List<string> AllClass()
        {
            List<string> list = new List<string>();
            list.Add("mount");
            list.Add("format");
            list.Add("delete");
            list.Add("delete_recursive");
            list.Add("show_progress");
            list.Add("set_progress");
            list.Add("package_extract_file");
            list.Add("file_getprop");
            list.Add("symlink");
            list.Add("set_perm");
            list.Add("set_perm_recursive");
            list.Add("getprop");
            list.Add("write_raw_image");
            list.Add("apply_patch");
            list.Add("apply_patch_space");
            list.Add("read_file");
            list.Add("ui_print");
            list.Add("run_program");
            list.Add("sha1_check");
            list.Add("apply_patch_check");
            list.Add("ifelse");
            list.Add("abort");
            list.Add("assert");
            list.Add("(");
            list.Add(")");
            list.Add("\"");
            list.Add("(\"");
            list.Add("\")");
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
                tb.SelectionFont = new Font("Calibri", 12, (FontStyle.Bold));
            }
            tb.Select(i, 0);
            tb.SelectionFont = new Font("Calibri", 12, (FontStyle.Regular));
            tb.SelectionColor = Color.Black;
        }




        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }



        private void cleanCode_Click(object sender, EventArgs e)
        {
            codeGround.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
             FileStream us = new FileStream("META-INF\\com\\google\\android\\updater-script", FileMode.OpenOrCreate, FileAccess.ReadWrite);     //use stream to write file
             StreamWriter sw = new StreamWriter(us);
             sw.WriteLine(codeGround.Text);
             sw.Close(); 
        }


        // Command Line Tools
        public static string CmdPath = @"C:\Windows\System32\cmd.exe";
        public static void commandRun(string cmd, out string output)
        {
            cmd = cmd.Trim().TrimEnd('&') + "&exit";
            using (Process p = new Process())
            {
                p.StartInfo.FileName = CmdPath;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true; 
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                p.StandardInput.WriteLine(cmd);
                p.StandardInput.AutoFlush = true;
                output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                p.Close();
            }
        }
    }
}
