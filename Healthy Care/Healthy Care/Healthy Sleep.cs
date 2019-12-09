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
    public partial class Healthy_Sleep : Form
    {
        public Healthy_Sleep()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            string result = "Bây giờ là " + d.ToShortTimeString()+
            ". Nếu bạn đi ngủ ngay bây giờ, bạn nên cố gắng thức dậy vào một trong những thời điểm sau:";
            //time for start sleeping
            d.Add(TimeSpan.FromMinutes(15));
            //time for every cycle sleep
            for (int i = 1; i <= 6; i++)
            {
                d= d.Add(TimeSpan.FromMinutes( 90));
                result = result+"\r\n" + i.ToString() + ". " + d.ToShortTimeString();
            }
            MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            int distanceInput=int.Parse((numericUpDown1.Value*60+numericUpDown2.Value).ToString());
            int distanceNow = d.Hour*60+d.Minute;

            int distance = distanceInput - distanceNow;
            if (distance < 0) distance += 24 * 60;
            

            if (distance < 90)
            {
                MessageBox.Show("Có quá ít thời gian để ngủ kể cả khi bạn đi ngủ từ bây giờ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
                string result = "Bạn muốn thức giấc vào " + numericUpDown1.Value + ":" + numericUpDown2.Value + ". Bạn nên đi ngủ vào các thời điểm sau: ";

         
            d =d.Add(TimeSpan.FromMinutes(distance % 90));
            distance -= (distance% 90);
            
            result = result + "\r\n1. " + d.ToShortTimeString(); ;
            for (int i = 2;  distance>0; i++)
            {
                d = d.Add(TimeSpan.FromMinutes(90));
                distance -= 90;
                if (distance < 15) break;
                result = result + "\r\n" + i.ToString() + ". " + d.ToShortTimeString();
                
               
            }
            MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
