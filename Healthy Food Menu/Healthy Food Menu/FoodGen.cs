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
    public partial class FoodGen : Form
    {
        public FoodGen()
        {
            InitializeComponent();
        }
        float tuoi=-1;
        static List<Food> foods;
        static Menu[] menutuan =new Menu[7];
        float mindamcan, mintinhbotcan, minbeocan, minxocan, maxdamcan, maxtinhbotcan, maxbeocan, maxxocan;

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void FoodGen_Load(object sender, EventArgs e)
        {
            LoadJson();
            if (foods == null)
            {
                genDefaultFood();
                SaveJson();
            }
            for (int i = 0; i < 7; i++)
            {
                menutuan[i] = new Menu();
            }

        }
        private void genDefaultFood()
        {

            foods = new List<Food>();
            foods.Add(new Food("Cơm", "Tinh bột", 75, 8.6f, 0, 0));
            foods.Add(new Food("Bánh mì", "Tinh bột", 52, 7.9f, 0, 0));
            foods.Add(new Food("Bún phở", "Tinh bột", 32, 3.2f, 0, 0));
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
        void loadlist()
        {
            int maxFood = 0;
            for (int i = 0; i < 7; i++)
            {
                if (maxFood < menutuan[i].menu.Count)
                {
                    maxFood = menutuan[i].menu.Count;
                }
            }
            for (int i = 0; i < maxFood; i++)
            {
                ListViewItem x = null;
                if (menutuan[0].menu.Count <= i)
                {
                    x = listView1.Items.Add("");
                }
                else x = listView1.Items.Add(menutuan[0].menu[i].food.ten + ": " + menutuan[0].menu[i].qty.ToString("0.00") + "g");
                for (int z = 1; z < 7; z++)
                {
                     if (menutuan[z].menu.Count<=i)
                     {

                         x.SubItems.Add("");
                     }
                     else
                     x.SubItems.Add(menutuan[z].menu[i].food.ten + ": " + menutuan[z].menu[i].qty.ToString("0.00") + "g");
                    
                }
                
    
            }
        }
        bool checknhamchan(Food a, int i)
        {
            if (i<2)
            {
                return true;
            }
            
            for (int z = 0; z < i-2; z++)
            {
                if (menutuan[z].menu.Where(x=>x.food.ten.Equals(a.ten)).Count()>3)
                {
                    return false;
                }
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            for (int i = 0; i < 7; i++)
            {
                menutuan[i].menu.Clear();
            }
            //validate
            try
            {
                tuoi = float.Parse(textBox1.Text);
                if (tuoi<0)
                {
                    tuoi = -1;
                    throw new Exception();
                }
                else if (tuoi<=0.5)
                {
                    listView1.Items.Clear();
                    var x = listView1.Items.Add("Sữa mẹ");
                    for (int i = 0; i < 6; i++)
                    {
                        x.SubItems.Add("Sữa mẹ");
                        
                    }
                    return;
                }
                else if (tuoi <=2)
                {
                    listView1.Items.Clear();
                    var x = listView1.Items.Add("Sữa mẹ");
                    for (int i = 1; i < 7; i++)
                    {
                        x.SubItems.Add("Sữa mẹ");

                    }
                    mintinhbotcan = maxtinhbotcan = 100;
                    mindamcan = maxdamcan = 24;
                    minbeocan = maxbeocan = 15;
                    minxocan = maxxocan = 80;
                }
                else if(tuoi <= 5)
                {
                    mintinhbotcan = 120; maxtinhbotcan = 160;
                    mindamcan = 100;maxdamcan = 120;
                    minbeocan = 30;maxbeocan = 40;
                    minxocan = 150; maxxocan = 200;
                }
                else if(tuoi<=13)
                {
                    mintinhbotcan = 200; maxtinhbotcan = 300;
                    mindamcan = 80; maxdamcan = 100;
                    minbeocan = 40; maxbeocan = 50;
                    minxocan = 300; maxxocan = 450;
                }
                else if (tuoi <= 18)
                {
                    mintinhbotcan = 400; maxtinhbotcan = 500;
                    mindamcan = 110; maxdamcan = 120;
                    minbeocan = 30; maxbeocan = 45;
                    minxocan = 400; maxxocan = 500;
                }
                else  if (tuoi <= 35)
                {
                    mintinhbotcan = 400; maxtinhbotcan = 500;
                    mindamcan = 150; maxdamcan = 200;
                    minbeocan = 0; maxbeocan = 30;
                    minxocan = 400; maxxocan = 500;
                }
                else if (tuoi <=60)
                {
                    mintinhbotcan = 370; maxtinhbotcan = 450;
                    mindamcan = 130; maxdamcan = 170;
                    minbeocan = 0; maxbeocan = 20;
                    minxocan = 350; maxxocan = 450;
                }
                else
                {
                    mintinhbotcan = 230; maxtinhbotcan = 250;
                    mindamcan = 80; maxdamcan = 100;
                    minbeocan = 0; maxbeocan = 10;
                    minxocan = 250; maxxocan = 280;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Nhập tuổi phải là số dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //gen
            Random r = new Random();
            for (int z = 0; z < 7; z++) //7day
            {
                //gen thuc an tinh bot
                var listTB = foods.Where(x => x.nhom.Equals("Tinh bột")).ToList();
                if (checknhamchan(foods.Where(x => x.ten.Equals("Cơm")).FirstOrDefault(),z))
                {

                }
                
                int soluong = r.Next(1, 4); //soluong mon an
                for (int i = 0; i < soluong ; i++)
                    {
                        int iget = r.Next(0, listTB.Count);
                        var thucan = listTB[iget];
                    if (checknhamchan(thucan,z)==false)
                    {
                        listTB.Remove(thucan);
                        i--;
                        continue;
                    }
                        float luongcanan = maxtinhbotcan / soluong / thucan.tinhbot * 100;
                    
                        menutuan[z].menu.Add(new MenuItem(thucan, luongcanan));
                    
                    listTB.Remove(thucan);
                }

                //gen thuc an dam/beo
                var listdam = foods.Where(x => x.nhom.Equals("Đạm")).ToList();
                int soluongDam = r.Next(1, 4); //soluong mon an
                for (int i = 0; i < soluongDam; i++)
                {
                    int iget = r.Next(0, listdam.Count>3?3: listdam.Count);
                    var thucan = listdam[iget];
                        if (checknhamchan(thucan, z) == false)
                    {
                        listdam.Remove(thucan);
                        i--;
                        continue;
                    }
                    float luongcanan =  maxdamcan / soluongDam / thucan.dam * 100;

                    menutuan[z].menu.Add(new MenuItem(thucan, luongcanan));

                    listdam.Remove(thucan);
                }

                //gen thuc an xo
                var listso = foods.Where(x => x.nhom.Equals("Xơ/hoa quả")).ToList();
                int soluongXo = r.Next(1, 4); //soluong mon an
                for (int i = 0; i < soluongXo; i++)
                {
                    int iget = r.Next(0, listso.Count);
                    var thucan = listso[iget];
                    if (checknhamchan(thucan, z) == false)
                    {
                        listso.Remove(thucan);
                        i--;
                        continue;
                    }
                    float luongcanan = maxxocan / soluongXo / thucan.xo * 50;

                    menutuan[z].menu.Add(new MenuItem(thucan, luongcanan));

                    listso.Remove(thucan);
                }

            }
            
            loadlist();
        }
    }
}
