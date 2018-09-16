using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;
using System.Threading;

namespace updater_script_builder
{
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
        }

        private void checkUpdate_Click(object sender, EventArgs e)
        {
            string Kpath;
            Kpath = Directory.GetCurrentDirectory();
            Kconfig Kconfig = new Kconfig(Kpath + "/Config/config.ini");
            string Kversion = Kconfig.ReadValue("Application", "Version");
            string Kcode = Kconfig.ReadValue("Application", "Code");
            string Klog = Kconfig.ReadValue("Update", "Log");
            //Load Version

            int Kintstatus = 0;
            updateBox.Text = "Checking Server...";

            //Set a ping thread

            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();
            options.DontFragment = true;
            string data = "DroidBetaDevTeam";
            updateBox.Text = updateBox.Text + "\r\n|-Config Checking Service";
            //Thread.Sleep(1000);
            byte[] Kbf = Encoding.ASCII.GetBytes(data);
            int timeout = 500;
            PingReply reply = pingSender.Send("119.28.45.140", timeout, Kbf, options);

            //Ping Injudger
            if (reply.Status == IPStatus.Success)
            {
                updateBox.Text = updateBox.Text + "\r\n|-Success!";
                Kintstatus = 1;

            }
            else
            {
                updateBox.Text = updateBox.Text + "\r\n|-Fail!Please check your Internet conection.";
                Kintstatus = 0;
            }

            if (Kintstatus == 1)
            {
                string Kurl = "http://git.droidbeta.com/Kucashu/RandomAppication/version";
                WebClient wc = new WebClient();
                Stream us = wc.OpenRead(Kurl);
                StreamReader Kwcode = new StreamReader(us, Encoding.UTF8);
                string KnewVersion = Kwcode.ReadToEnd();
                Kurl = "http://git.droidbeta.com/Kucashu/RandomAppication/log";
                us = wc.OpenRead(Kurl);
                Kwcode = new StreamReader(us, Encoding.UTF8);
                string KnewLog = Kwcode.ReadToEnd();

                //Close source function
                us.Close();
                Kwcode.Close();

                if (Kversion == KnewVersion)
                {
                    updateBox.Text = "[当前版本]\r\nVersion:" + Kversion + "\r\nCode Name:" + Kcode + "\r\n\r\n[最新版本]\r\n" + KnewVersion + "\r\n\r\n[更新日志]\r\n" + Klog;
                }
                else
                {
                    updateBox.Text = "[当前版本]\r\nVersion:" + Kversion + "\r\nCode Name:" + Kcode + "\r\n\r\n[最新版本]\r\n" + KnewVersion + "\r\n\r\n[更新日志]\r\n" + KnewLog + "\r\n\r\n[往期更新日志]\r\n" + Klog;
                    if (MessageBox.Show("是否更新最新版本",
                         "新版本提示",
                          MessageBoxButtons.OKCancel,
                          MessageBoxIcon.Warning,
                          MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        System.Diagnostics.Process.Start("http://git.droidbeta.com/Kucashu/updater-script-builder/Appilication.zip");
                    }
                }
            }
        }

        private void Update_Load(object sender, EventArgs e)
        {
            string Kpath;
            Kpath = Directory.GetCurrentDirectory();
            Kconfig Kconfig = new Kconfig(Kpath + "/Config/config.ini");
            string Kversion = Kconfig.ReadValue("Application", "Version");
            string Kcode = Kconfig.ReadValue("Application", "Code");
            string Klog = Kconfig.ReadValue("Update", "Log");
            updateBox.Text = "[当前版本]\r\nVersion:" + Kversion + "\r\nCode Name:" + Kcode + "\r\n\r\n[最新版本]\r\n未知\r\n\r\n[更新日志]\r\n" + Klog;
        }

        public class Kconfig
        {
            [System.Runtime.InteropServices.DllImport("kernel32")]
            private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
            [System.Runtime.InteropServices.DllImport("kernel32")]
            private static extern int GetPrivateProfileString(string section, string key, string def, System.Text.StringBuilder retVal, int size, string filePath);
            private string mPath = null;
            public Kconfig(string path)
            {
                this.mPath = path;
            }

            public void Writue(string section, string key, string value)
            {
                WritePrivateProfileString(section, key, value, mPath);
            }
            public string ReadValue(string section, string key)
            {
                System.Text.StringBuilder temp = new System.Text.StringBuilder(255);
                GetPrivateProfileString(section, key, "", temp, 255, mPath);

                return temp.ToString();

            }
        }
    }
}
