using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Time_Management
{
    public partial class Form1 : Form
    {
        //for minimize all windows
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true)]
        static extern IntPtr SendMessage(IntPtr hWnd, Int32 Msg, IntPtr wParam, IntPtr lParam);

        const int WM_COMMAND = 0x111;
        const int MIN_ALL = 419;
        const int MIN_ALL_UNDO = 416;


        public Form1()
        {
            InitializeComponent();
            try
            {
                LoadJson();
                LoadSetting();
            }
            catch
            {

            }
            if (listCongViec == null)
            {
                listCongViec = new List<Work>();
            }
            if (appsetting==null)
            {
                appsetting = new Appsetting();
                appsetting.indexComboboxValue = 0;
                appsetting.isAutoStart = true;
                appsetting.noty = true;
                appsetting.numerricValue = 1;
            }
            LoadMatrix();

        }



        #region Peoperties
        private List<List<Button>> matrix;
        private static Appsetting appsetting;
        public static List<Work> listCongViec;
        public List<List<Button>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }
        private void SaveSeting()
        {
            string data = JsonConvert.SerializeObject(appsetting);
            if (!Directory.Exists("data")) Directory.CreateDirectory("data");

            File.WriteAllText(Application.StartupPath + "/data/config.json", data);
        }
        private void LoadSetting()
        {
            if (!File.Exists(Application.StartupPath + "/data/config.json"))
            {
                return;
            }
            string data = File.ReadAllText(Application.StartupPath + "/data/config.json");
            appsetting = JsonConvert.DeserializeObject<Appsetting>(data);
        }
        private List<string> dateOfWeek = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };


        void LoadMatrix()
        {
            Matrix = new List<List<Button>>();

            Button oldBtn = new Button() { Width = 0, Height = 0, Location = new Point(-Cons.margin, 0) };
            for (int i = 0; i < Cons.DayOfColumn; i++)
            {
                Matrix.Add(new List<Button>());
                for (int j = 0; j < Cons.DayOfWeek; j++)
                {
                    Button btn = new Button() { Width = Cons.dateButtonWidth, Height = Cons.dateButtonHeight };
                    btn.Location = new Point(oldBtn.Location.X + oldBtn.Width + Cons.margin, oldBtn.Location.Y);
                    btn.Click += btn_Click;

                    pnlMatrix.Controls.Add(btn);
                    Matrix[i].Add(btn);

                    oldBtn = btn;
                }
                oldBtn = new Button() { Width = 0, Height = 0, Location = new Point(-Cons.margin, oldBtn.Location.Y + Cons.dateButtonHeight) };
            }

            SetDefaultDate();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((sender as Button).Text))
                return;
            dtpkDate.Value = getDateFromButton(sender as Button);


        }
        private DateTime getDateFromButton(Button b)
        {
            return new DateTime(dtpkDate.Value.Year, dtpkDate.Value.Month, Convert.ToInt32(b.Text));
        }
        int DayOfMonth(DateTime date)
        {
            switch (date.Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 2:
                    if ((date.Year % 4 == 0 && date.Year % 100 != 0) || date.Year % 400 == 0)
                        return 29;
                    else
                        return 28;
                default:
                    return 30; ;
            }
        }

        void AddNumberIntoMatrixByDate(DateTime date)
        {
            ClearMatrix();
            DateTime useDate = new DateTime(date.Year, date.Month, 1);

            int line = 0;

            for (int i = 1; i <= DayOfMonth(date); i++)
            {
                int column = dateOfWeek.IndexOf(useDate.DayOfWeek.ToString());
                Button btn = Matrix[line][column];
                btn.Text = i.ToString();

                if (isEqualDate(useDate, DateTime.Now))
                {
                    btn.BackColor = Color.Yellow;
                }
                foreach (var work in listCongViec)
                {
                    if (work.updateDate(useDate) && work.Important.Equals("Quan trọng"))
                    {
                        btn.BackColor = Color.Red;
                        break;
                    }
                }
                if (isEqualDate(useDate, date))
                {
                    btn.BackColor = Color.Aqua;
                }


                if (column >= 6)
                    line++;

                useDate = useDate.AddDays(1);
            }
        }

        bool isEqualDate(DateTime dateA, DateTime dateB)
        {
            return dateA.Year == dateB.Year && dateA.Month == dateB.Month && dateA.Day == dateB.Day;
        }

        void ClearMatrix()
        {
            for (int i = 0; i < Matrix.Count; i++)
            {
                for (int j = 0; j < Matrix[i].Count; j++)
                {
                    Button btn = Matrix[i][j];
                    btn.Text = "";
                    btn.BackColor = Color.WhiteSmoke;
                }
            }
        }

        void SetDefaultDate()
        {
            dtpkDate.Value = DateTime.Now;
        }
        List<Work> sourceListView;
        private void dtpkDate_ValueChanged(object sender, EventArgs e)
        {
            AddNumberIntoMatrixByDate((sender as DateTimePicker).Value);
            loadListView();


        }

        private void loadListView()
        {
            if (listCongViec != null)
            {
                sourceListView = listCongViec.Where(p => p.updateDate(dtpkDate.Value) || isEqualDate(p.Date, dtpkDate.Value)).OrderBy(p1 => p1.Date).ToList();
                loadIntoListView();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddMonths(1);
        }

        private void btnPreviours_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddMonths(-1);
        }

        private void btnToDay_Click(object sender, EventArgs e)
        {
            SetDefaultDate();
        }

        #endregion


        private void Form1_Load(object sender, EventArgs e)
        {
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(28, 25);
            imageList.Images.Add(global::Time_Management.Properties.Resources.important);
            imageList.Images.Add(global::Time_Management.Properties.Resources.usual);
            imageList.Images.Add(global::Time_Management.Properties.Resources.done);
            listView1.SmallImageList = imageList;
            listView1.Columns[0].Width = -2;
            listView1.Columns[1].Width = -2;
            listView1.Columns[2].Width = -2;
            showHintTextbox(txtSearch, false);



            loadListView();
            
            LoadSetting();
            ApplySetting();
            //button12.PerformClick();
        }

        //add
        private void button1_Click(object sender, EventArgs e)
        {
            /* Work a = new Work("Hào", "Đặng Thanh Hào", "Hàng tháng", "Gia đình", "Quan trọng", new DateTime(1998, 04, 04), "Trong ngày", true);
             frmNewTask f = new frmNewTask(a);
             f.ShowDialog();
             SaveJson(a);*/

            Work a = new Work();
            a.Date = dtpkDate.Value;
            a.Recurrence = "1 lần";
            a.TimeNotify = "Trong ngày";
            a.Category = "Công việc";
            a.IsNoti = false;
            var x = new frmNewTask(a).ShowDialog();
            if (x == DialogResult.OK)
            {
                listCongViec.Add(a);
                SaveJson();

                AddNumberIntoMatrixByDate(dtpkDate.Value);
                loadListView();
                listView1.SelectedItems.Clear();

                MessageBox.Show("Thêm công việc thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        #region docghifile
        static void SaveJson()
        {
            string data = JsonConvert.SerializeObject(listCongViec);
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
            listCongViec = JsonConvert.DeserializeObject<List<Work>>(data);
        }
        #endregion

        void showHintTextbox(TextBox textBox, bool waterMarkActive)
        {
            waterMarkActive = true;
            textBox.ForeColor = Color.Gray;
            textBox.Text = "Nhập thông tin tìm kiếm";

            textBox.GotFocus += (source, e) =>
            {
                if (waterMarkActive)
                {
                    waterMarkActive = false;
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.LostFocus += (source, e) =>
            {
                if (!waterMarkActive && string.IsNullOrEmpty(textBox.Text))
                {
                    waterMarkActive = true;
                    textBox.Text = "Nhập thông tin tìm kiếm";
                    textBox.ForeColor = Color.Gray;
                }
            };
        }
        //delete
        private void button3_Click(object sender, EventArgs e)
        {
            //listView1.Items.IndexOf(listView1.SelectedItems[0])==-1
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Hãy chọn công việc cần xóa bên dưới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            listCongViec.Remove(GetWorkFromListView());
            SaveJson();

            AddNumberIntoMatrixByDate(dtpkDate.Value);
            loadListView();
            listView1.SelectedItems.Clear();
            MessageBox.Show("Xóa công việc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private Work GetWorkFromListView()
        {
            return sourceListView[listView1.Items.IndexOf(listView1.SelectedItems[0])];
        }
        //edit
        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Hãy chọn công việc cần sửa bên dưới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Work a = new Work();
            Work b = GetWorkFromListView();
            a.setvaluefromWork(b);
            var x = new frmNewTask(a).ShowDialog();
            if (x == DialogResult.OK)
            {
                b.setvaluefromWork(a);
                SaveJson();
                AddNumberIntoMatrixByDate(dtpkDate.Value);
                loadListView();
                listView1.SelectedItems.Clear();

                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Hãy chọn công việc cần sửa bên dưới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Work b = GetWorkFromListView();
            b.Important = "Đã hoàn thành";



            SaveJson();
            AddNumberIntoMatrixByDate(dtpkDate.Value);
            loadListView();
            listView1.SelectedItems.Clear();

            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

      
        private void loadIntoListView()
        {
            if (sourceListView != null)
            {
                listView1.Items.Clear();

                foreach (var item in sourceListView)
                {
                    int imageindex;
                    switch (item.Important)
                    {
                        case "Quan trọng":
                            imageindex = 0;
                            break;
                        case "Thường ngày":
                            imageindex = 1;
                            break;
                        case "Đã hoàn thành":
                            imageindex = 2;
                            break;
                        default:
                            imageindex = 0;
                            break;
                    }
                    var x = listView1.Items.Add(item.Date.Day + "/" + item.Date.Month + "/" + item.Date.Year + " - " + item.Date.ToShortTimeString(), imageindex);
                    
                    x.SubItems.Add(item.Category);
                    x.SubItems.Add(item.Name);
                }

            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            sourceListView = listCongViec.OrderBy(p => p.Date).ToList();
            loadIntoListView();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private bool AcontainB(string a, string b)
        {
            if (string.IsNullOrEmpty(a))
            {
                return false;
            }
            return a.ToLower().Contains(b.Trim().ToLower());
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                MessageBox.Show("Nhập thông tin vào ô tìm kiếm!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSearch.Focus();

                return;
            }
            sourceListView = listCongViec.Where(p => AcontainB(p.Name, txtSearch.Text) || AcontainB(p.Important, txtSearch.Text) || AcontainB(p.Category, txtSearch.Text)).OrderBy(p => p.Date).ToList();
            loadIntoListView();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipText = "";
           // btnToDay_Click(sender,e);
            var today = listCongViec.Where(p => p.Important!="Đã hoàn thành" &&isEqualDate(DateTime.Now,p.Date)).ToList();
            
            bool check = false;
            foreach (var item in today)
            {
                
                if (item.Date<DateTime.Now&&item.Recurrence=="1 lần")
                {
                    item.Important = "Đã hoàn thành";
                    
                    check = true;
                }
            }

            
            if (check)
            {
                SaveJson();
                btnToDay_Click(sender, e);
            }

            var listtoday = today.Where(p => p.Important != "Đã hoàn thành" && p.IsNoti&&p.Date>=DateTime.Now).OrderBy(p => p.Date).ToList();
            var listfeauture = listCongViec.Where( p => p.Important != "Đã hoàn thành" && p.Date > DateTime.Now && p.IsNoti && p.TimeNotify != "Trong ngày"&&!string.IsNullOrEmpty(p.TimeNotify)&&p.early(DateTime.Now)).ToList();
            
            if (listtoday.Count>0)
            {
                notifyIcon1.BalloonTipText = "Bạn có " + listtoday.Count + " công việc ngày hôm nay!\r\nCông việc tiếp theo:\r\n" + listtoday[0].Name + " vào lúc " + listtoday[0].Date.ToShortTimeString();
                
             }
            if (listfeauture.Count > 0)
            {
                notifyIcon1.BalloonTipText += "\r\nBạn có " + listfeauture.Count + " công việc quan trọng trong tương lại:";
               
            }
            if (!string.IsNullOrEmpty(notifyIcon1.BalloonTipText))
            {
                notifyIcon1.ShowBalloonTip(3000);
            }
            
            }
            


        

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

      
        private void ApplySetting()
        {
            timer1.Enabled = appsetting.noty;
            numericUpDown1.Value = appsetting.numerricValue;
            var x = int.Parse(numericUpDown1.Value.ToString());
            comboBox1.SelectedIndex = appsetting.indexComboboxValue;
            checkBox2.Checked = appsetting.isAutoStart;
            checkBox1.Checked = appsetting.noty;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    x *= 24 * 60000;
                    break;
                case 1:
                    x *=  60000;
                    break;
                default:
                    x *= 1000;
                    break;
            }
            timer1.Interval = x;
            timer1.Enabled = false;
            timer1.Enabled = checkBox1.Checked;

            if (checkBox2.Checked)
            {
                RegistryKey regkey = Registry.CurrentUser.CreateSubKey("Software\\TimeManagement");
                //mo registry khoi dong cung win
                RegistryKey regstart = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                string keyvalue = "1";
                //string subkey = "Software\\ManhQuyen";
                try
                {
                    //chen gia tri key
                    regkey.SetValue("Index", keyvalue);
                    //regstart.SetValue("taoregistrytronghethong", "E:\\Studing\\Bai Tap\\CSharp\\Channel 4\\bai temp\\tao registry trong he thong\\tao registry trong he thong\\bin\\Debug\\tao registry trong he thong.exe");
                    regstart.SetValue("TimeManagement", Application.StartupPath + "\\Time Management.exe");
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
                    Registry.CurrentUser.DeleteSubKey("Software\\TimeManagement");
                    RegistryKey regstart = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                    regstart.DeleteValue("TimeManagement");
                }
                catch (Exception e)
                {

                }
            }
        }
       
        private void button12_Click(object sender, EventArgs e)
        {
            int x = int.Parse(numericUpDown1.Value.ToString());
            appsetting.numerricValue = x;
            appsetting.indexComboboxValue = comboBox1.SelectedIndex;
            appsetting.isAutoStart = checkBox2.Checked;
            appsetting.noty = checkBox1.Checked;
            ApplySetting();
            SaveSeting();
            
            MessageBox.Show("Đã lưu thiết lập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                panel1.Enabled = true;
            }
            else panel1.Enabled = false;
            timer1.Enabled = checkBox1.Checked;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var x = MessageBox.Show("Bạn có chắc chắn muốn thoát hoàn toàn chương trình!\r\nChức năng nhắc nhở sẽ không hoạt động?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (x==DialogResult.Yes)
            {
                SaveSeting();
                Application.Exit();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //button12_Click(sender, e);
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            button12_Click(sender, e);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var x = MessageBox.Show("Bạn có chắc chắn muốn thoát hoàn toàn chương trình!\r\nChức năng nhắc nhở sẽ không hoạt động?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (x == DialogResult.Yes)
            {
                SaveSeting();

            }
            else e.Cancel = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
           
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            button4.PerformClick();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            IntPtr lHwnd = FindWindow("Shell_TrayWnd", null);
            SendMessage(lHwnd, WM_COMMAND, (IntPtr)MIN_ALL, IntPtr.Zero);
            System.Threading.Thread.Sleep(2000);
            SendMessage(lHwnd, WM_COMMAND, (IntPtr)MIN_ALL_UNDO, IntPtr.Zero);
            notifyIcon1.BalloonTipText = "Minimized ALL!";
            notifyIcon1.ShowBalloonTip(3000);
        }
    }
 
}

   



