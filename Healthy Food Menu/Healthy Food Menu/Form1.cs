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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BMI_cal bm = new BMI_cal();
            bm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditData ed = new EditData();
            ed.ShowDialog();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            FoodGen fr = new FoodGen();
            fr.ShowDialog();
        }

        private void tínhBMIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void xâyDựngThựcĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.PerformClick();
        }

        private void chỉnhSửaCsdlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button3.PerformClick();
        }

        private void giớiThiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Chương trình sản phẩm môn trí tuệ nhân tạo áp dụng hệ chuyên gia\r\n Giáo viên hướng dẫn: Trần Huyển Trang\r\n Nhóm sinh viên thực hiện: \r\n 1. Đặng Thanh Hào" +
                "\r\n 2. Lê Hoàng Vũ\r\n 3. Trịnh Thị Hiền \r\n 4. Lê Trung Gia Hưng \r\n 5. Trương Công Khương \r\n 6. Đặng Lê Hoàng \r\n Lớp 16cntt3 Đại học sư phạm- ĐHDN","Giới thiệu",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
