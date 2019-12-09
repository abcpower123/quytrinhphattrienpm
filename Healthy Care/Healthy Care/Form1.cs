using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Healthy_Care
{

    public partial class Form1 : Form
    {
        const int MaxNumTips = 2;
        int tipNum=1;

        List<Time_Management.Work> works;
        Application_Setting.ApplicationSetting setting;
        int taskTime = 0;
        int drinkTime = 0;
        int breakTime = 0;

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
            loadALL();
            taskTime = setting.notiStatus.taskTime;
            drinkTime = setting.notiStatus.drinkTime;
            breakTime = setting.notiStatus.breakTime;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Healthy_Food_Menu.FmMainFoodMenu a = new Healthy_Food_Menu.FmMainFoodMenu();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Time_Management.MainTodo f = new Time_Management.MainTodo();
            f.Show();
        }

        private void timerTip_Tick(object sender, EventArgs e)
        {
            tipNum++;
            if (tipNum > MaxNumTips) tipNum = 1;
            pcTip.ImageLocation = string.Format(@"tips/tip{0}.jpg", tipNum);
        }

        private void eyecare_Click(object sender, EventArgs e)
        {
            EyeCare ec = new EyeCare();
            ec.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Healthy_Sleep hs = new Healthy_Sleep();
            hs.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            loadALL();
            taskTime--;
            drinkTime--;
            breakTime--;
            
            bool check = false;
            if (taskTime <= 0&&setting.notiStatus.taskE)
            {
                showTaskNoti();
                check = true;
                taskTime = setting.notiStatus.taskTime;
            }

            if (drinkTime <= 0 && setting.notiStatus.drinkE)
            {
                showDrinkNoti();
                check = true;
                drinkTime = setting.notiStatus.drinkTime;
            }
            if (breakTime <= 0 && setting.notiStatus.BreakE)
            {
                showBreakNoti();
                check = true;
                breakTime = setting.notiStatus.breakTime;
            }
            if (check) minimizeALL();
        }

        private void minimizeALL()
        {
            IntPtr lHwnd = FindWindow("Shell_TrayWnd", null);
            SendMessage(lHwnd, WM_COMMAND, (IntPtr)MIN_ALL, IntPtr.Zero);
            //System.Threading.Thread.Sleep(2000);
            //SendMessage(lHwnd, WM_COMMAND, (IntPtr)MIN_ALL_UNDO, IntPtr.Zero);
        }

        private void loadALL()
        {
            works = Time_Management.Work.LoadJson();
            if (works == null) works = new List<Time_Management.Work>();
            setting = Application_Setting.ApplicationSetting.LoadSetting();
            if (setting == null) setting = new Application_Setting.ApplicationSetting();
        }

        bool isEqualDate(DateTime dateA, DateTime dateB)
        {
            return dateA.Year == dateB.Year && dateA.Month == dateB.Month && dateA.Day == dateB.Day;
        }
        private void showBreakNoti()
        {
            notifyIcon1.BalloonTipTitle = "Break Time!!!";
            notifyIcon1.BalloonTipText = "Hãy rời mắt khỏi màn hình và giải lao!";

           
            if (!string.IsNullOrEmpty(notifyIcon1.BalloonTipText))
            {
                notifyIcon1.ShowBalloonTip(3000);
            }
        }

        private void showDrinkNoti()
        {
            notifyIcon1.BalloonTipTitle = "Drink Time!!!";
            notifyIcon1.BalloonTipText = "Hãy uống một ngụm nước để refresh lại cơ thể!";


            if (!string.IsNullOrEmpty(notifyIcon1.BalloonTipText))
            {
                notifyIcon1.ShowBalloonTip(3000);
            }
        }

        private void showTaskNoti()
        {
            notifyIcon1.BalloonTipTitle = "Memory care";
            notifyIcon1.BalloonTipText = "";
            
            var today = works.Where(p => p.Important != "Đã hoàn thành" && isEqualDate(DateTime.Now, p.Date)).ToList();
            bool check = false;
            foreach (var item in today)
            {

                if (item.Date < DateTime.Now && item.Recurrence == "1 lần")
                {
                    item.Important = "Đã hoàn thành";

                    check = true;
                }
            }


            if (check)
            {
                Time_Management.Work.SaveJson(works);
            }

            var listtoday = today.Where(p => p.Important != "Đã hoàn thành" && p.IsNoti && p.Date >= DateTime.Now).OrderBy(p => p.Date).ToList();
            var listfeauture = works.Where(p => p.Important != "Đã hoàn thành" && p.Date > DateTime.Now && p.IsNoti && p.TimeNotify != "Trong ngày" && !string.IsNullOrEmpty(p.TimeNotify) && p.early(DateTime.Now)).ToList();

            if (listtoday.Count > 0)
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

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SettingApp settingApp = new SettingApp();
            settingApp.ShowDialog();
            loadALL();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
