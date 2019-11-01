using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Healthy_Food_Menu
{
    public partial class EditData : Form
    {
        static List<Food> foods=null;
        public EditData()
        {
            InitializeComponent();
        }
        #region docghifile
        static void SaveJson()
        {
            string data = JsonConvert.SerializeObject(foods);
            if (!Directory.Exists("data")) Directory.CreateDirectory("data");

            File.WriteAllText(Application.StartupPath + "/data/Data.json", data);
        }
        void LoadJson()
        {
            if (!File.Exists(Application.StartupPath + "/data/Data.json"))
            {
                return;
            }
            string data = File.ReadAllText(Application.StartupPath + "/data/Data.json");
            foods = JsonConvert.DeserializeObject<List<Food>>(data);
        }
        #endregion
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EditData_Load(object sender, EventArgs e)
        {
            LoadJson();
            if (foods==null)
            {
                genDefaultFood();
                SaveJson();
            }
            loadIntoListView();

        }


        private void genDefaultFood()
        {
         
            foods = new List<Food>();
            foods.Add(new Food("Cơm","Tinh bột",75,8.6f,0,0));
            foods.Add(new Food("Bánh mì", "Tinh bột", 62, 7.9f, 0, 0));
            foods.Add(new Food("Bún phở", "Tinh bột", 52, 3.2f, 0, 0));
            foods.Add(new Food("Bắp", "Tinh bột", 39, 4.1f, 0, 0));

            foods.Add(new Food("Thịt heo", "Đạm", 0, 25.7f, 20.8f, 0));
            foods.Add(new Food("Thịt bò", "Đạm", 0, 26.1f, 15.8f, 0));
            foods.Add(new Food("Thịt gà", "Đạm", 0, 23.1f, 8.4f, 0));
            foods.Add(new Food("Trứng gà", "Đạm", 0, 14.8f, 11.6f, 0));

            foods.Add(new Food("Sữa bò", "Đạm", 0, 3.9f, 3.8f, 0));
            foods.Add(new Food("Sữa đậu nành", "Đạm", 0, 3.6f, 1.8f, 0));
            foods.Add(new Food("Cá", "Đạm", 0, 17, 12, 0));
            foods.Add(new Food("Tôm/mực", "Đạm", 0, 31, 1.4f, 0));

            foods.Add(new Food("Rau các loại", "Xơ/hoa quả", 0, 0, 0, 58.4f));
            foods.Add(new Food("Táo", "Xơ/hoa quả", 0, 0, 0, 42.4f));
            foods.Add(new Food("Bơ", "Xơ/hoa quả", 0, 0, 0, 27));
            foods.Add(new Food("Chuối", "Xơ/hoa quả", 0, 0, 0, 22.6f));

        }
        private Food GetFoodFromListView()
        {
            return foods[listView1.Items.IndexOf(listView1.SelectedItems[0])];
        }
        private void loadIntoListView()
        {
            if (foods != null)
            {
                listView1.Items.Clear();

                foreach (var item in foods)
                {
                    var x = listView1.Items.Add(item.ten);

                    x.SubItems.Add(item.tinhbot.ToString("0.00")+"%");
                    x.SubItems.Add(item.dam.ToString("0.00") + "%");
                    x.SubItems.Add(item.beo.ToString("0.00") + "%");
                    x.SubItems.Add(item.xo.ToString("0.00") + "%");
                    x.SubItems.Add(item.nhom);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Hãy chọn thức ăn cần sửa ở bảng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Food a = new Food();
            Food b = GetFoodFromListView();
            a.setvaluefromFood(b);
            var x = new EditDetail(a).ShowDialog();
            if (x == DialogResult.OK)
            {
                b.setvaluefromFood(a);
                SaveJson();

                loadIntoListView();
                listView1.SelectedItems.Clear();

                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Food a = new Food();
            a.nhom = "Tinh bột";
            var x = new EditDetail(a).ShowDialog();
            if (x == DialogResult.OK)
            {
                foods.Add(a);
                SaveJson();

                
                loadIntoListView();
                listView1.SelectedItems.Clear();

                MessageBox.Show("Thêm thức ăn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Hãy chọn thức ăn bên dưới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foods.Remove(GetFoodFromListView());
            SaveJson();

           
            loadIntoListView();
            listView1.SelectedItems.Clear();
            MessageBox.Show("Xóa thức ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            button2.PerformClick();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            genDefaultFood();
            SaveJson();
            loadIntoListView();
            listView1.SelectedItems.Clear();
            MessageBox.Show("Khôi phục kho dữ liệu thức ăn gốc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
