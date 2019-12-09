using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Healthy_Care
{
    public partial class SettingApp : Form
    {
        public SettingApp()
        {
            InitializeComponent();
            setting = Application_Setting.ApplicationSetting.LoadSetting();
            if (setting == null) setting = new Application_Setting.ApplicationSetting();
            checkBox1.Checked = setting.notiStatus.BreakE;
            checkBox2.Checked = setting.notiStatus.taskE;
            checkBox3.Checked = setting.notiStatus.drinkE;
            checkBox4.Checked = setting.silenceMode;
            checkBox5.Checked = setting.isAutoStart;
        }
        Application_Setting.ApplicationSetting setting;
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            setting.silenceMode = checkBox4.Checked;
            if (checkBox4.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                groupBox1.Enabled = false;


            }
            else
            {
                groupBox1.Enabled = true;
            }
        }

        private void SettingApp_Load(object sender, EventArgs e)
        {
           
        }
        private void saveSetting()
        {
            Application_Setting.ApplicationSetting.SaveSeting(setting);
            MessageBox.Show("Đã lưu thiết lập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            saveSetting();

            if (setting.isAutoStart)
            {
                RegistryKey regkey = Registry.CurrentUser.CreateSubKey("Software\\IThealthcare");
                //mo registry khoi dong cung win
                RegistryKey regstart = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                string keyvalue = "1";
                //string subkey = "Software\\ManhQuyen";
                try
                {
                    //chen gia tri key
                    regkey.SetValue("Index", keyvalue);
                    //regstart.SetValue("taoregistrytronghethong", "E:\\Studing\\Bai Tap\\CSharp\\Channel 4\\bai temp\\tao registry trong he thong\\tao registry trong he thong\\bin\\Debug\\tao registry trong he thong.exe");
                    regstart.SetValue("IThealthcare", Application.StartupPath + "\\Healthy Care.exe");
                    ////dong tien trinh ghi key
                    //regkey.Close();
                }
                catch (System.Exception ex)
                {
                }
            }
            else
            {
                try
                {
                    Registry.CurrentUser.DeleteSubKey("Software\\IThealthcare");
                    RegistryKey regstart = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                    regstart.DeleteValue("IThealthcare");
                }
                catch (Exception exx)
                {

                }
            }
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            setting.notiStatus.BreakE = checkBox1.Checked;
           
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            setting.notiStatus.taskE = checkBox2.Checked;
          
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            setting.notiStatus.drinkE = checkBox3.Checked;
           
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            setting.isAutoStart = checkBox5.Checked;
        }
    }
}
