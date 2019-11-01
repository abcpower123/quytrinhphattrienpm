using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Time_Management
{
    public partial class frmNewTask : Form
    {
        private Work congviec;
        public frmNewTask(Work congviec)
        {
            InitializeComponent();
            this.congviec = congviec;
            bindingSource1.DataSource = congviec;
        }


        private void pnImportant_Click(object sender, EventArgs e)
        {
            pnVienImportant.BackColor = Color.Blue;
            pnVienMedium.BackColor = SystemColors.Control;
            pnVienUsual.BackColor = SystemColors.Control;
            lbImportant.Text = "Quan trọng";
            
        }

        private void pnMedium_Click(object sender, EventArgs e)
        {

            pnVienMedium.BackColor = Color.Blue;
            pnVienImportant.BackColor = SystemColors.Control;
            pnVienUsual.BackColor = SystemColors.Control;
            lbImportant.Text = "Thường ngày";

        }

        private void pnUsual_Click(object sender, EventArgs e)
        {
            pnVienUsual.BackColor = Color.Blue;
            pnVienImportant.BackColor = SystemColors.Control;
            pnVienMedium.BackColor = SystemColors.Control;
            lbImportant.Text = "Đã hoàn thành";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                cbbLapLai.Enabled = true;
                cbbTimeNoti.Enabled = true;
                lblLapLai.Enabled = true;
                lbTimeNoti.Enabled = true;
            }
            else
            {
                cbbLapLai.Enabled = false;
                cbbTimeNoti.Enabled = false;
                lblLapLai.Enabled = false;
                lbTimeNoti.Enabled = false;
            }
        }

       
        private void frmNewTask_Load(object sender, EventArgs e)
        {
            
            checkBox1.DataBindings.Add("Checked", congviec, "IsNoti");
            if (!String.IsNullOrEmpty(congviec.Name))
            {
                if (congviec.Important.Equals("Quan trọng"))
                {
                    pnImportant_Click(sender, e);
                }
                if (congviec.Important.Equals("Thường ngày"))
                {
                    pnMedium_Click(sender, e);
                }
                if (congviec.Important.Equals("Đã hoàn thành"))
                {
                    pnUsual_Click(sender, e);
                }
            }
            else pnImportant_Click(sender, e);
            textBox1.SelectedText = "";
            textBox1.Focus();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Phải có tên công việc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();

            }
            else
            {
                congviec.Important = lbImportant.Text;
                congviec.Date = dateTimePicker1.Value;
              

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


    }
}
