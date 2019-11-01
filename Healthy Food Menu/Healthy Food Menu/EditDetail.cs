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
    public partial class EditDetail : Form
    {
        private Food food;
        public EditDetail(Food f)
        {
            InitializeComponent();
            food = f;
        }
      
        private void EditDetail_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = food;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Phải có tên thức ăn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();

            }
            else
            {
                

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
