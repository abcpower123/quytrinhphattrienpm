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
    public partial class EyeCare : Form
    {
        public EyeCare()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 300)
            {
                MessageBox.Show("Thời gian vượt quá cho phép!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Application_Setting.ApplicationSetting setting = Application_Setting.ApplicationSetting.LoadSetting();
            if (setting == null)
                setting = new Application_Setting.ApplicationSetting();
            setting.notiStatus.breakTime = int.Parse(numericUpDown1.Value.ToString());
            Application_Setting.ApplicationSetting.SaveSeting(setting);
            MessageBox.Show("Thiết lập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 60;
        }

        private void EyeCare_Load(object sender, EventArgs e)
        {
            Application_Setting.ApplicationSetting setting = Application_Setting.ApplicationSetting.LoadSetting();
            if (setting != null)
                numericUpDown1.Value = setting.notiStatus.breakTime;
        }
    }
}
