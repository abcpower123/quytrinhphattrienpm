using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Healthy_Care.Time_Management
{
    [Serializable]
    public class Appsetting
    {
        public int numerricValue { get; set; } //Thời gian ngắn nhất giữa 2 lần thông báo
        public int indexComboboxValue { get; set; } // 0: giờ, 1:phút,2: giây
        public bool isAutoStart { get; set; } //register app in registry
        public bool noty { get; set; } // on/off noti
    }
}
