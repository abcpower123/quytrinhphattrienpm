using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Healthy_Food_Menu
{
    public partial class BMI_cal : Form
    {
        public BMI_cal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float chieucao=0, cannang=0,bmi=0;
            try
            {
                chieucao = float.Parse(textBox1.Text) / 100;
                cannang = float.Parse(textBox2.Text) ;
                bmi =  cannang / (chieucao*chieucao);
                string output;
                if (bmi<18.5)
                {
                    output = "Bạn gầy, nên sử dụng thực đơn tăng cân.";
                }
                else if(bmi < 22.9)
                {
                    output = "Bạn bình thương, nên sử dụng thực đơn bình thường";
                }
                else
                {
                    output = "Bạn thừa cân, nên sử dụng thực đơn giảm cân.";
                }
                lbResult.Text = "BMI= "+bmi.ToString("0.00")+". "+output;
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn nhập thông số không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
