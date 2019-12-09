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
    public partial class Profile : Form
    {
        Account.model.Account profile;
        public Profile()
        {
            InitializeComponent();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            profile = Account.model.Account.LoadProfile();
           
            if (profile != null)
            {
                textBox1.Text = profile.name;
                textBox4.Text = profile.age.ToString();
                textBox5.Text = profile.height.ToString();
                textBox6.Text = profile.weight.ToString();
            }
                else profile = new Account.model.Account();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int age = int.Parse(textBox4.Text);
                int height = int.Parse(textBox5.Text);
                int weight = int.Parse(textBox6.Text);
                if (age < 0 || weight < 0 || height < 0) throw new Exception();
                profile.name = textBox1.Text;
                profile.age = age;
                profile.height = height;
                profile.weight = weight;
                Account.model.Account.SaveProfile(profile);
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Dữ liệu nhập lỗi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
