using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Healthy_Care.Notification
{
    [Serializable]
    class NotiStatus
    {
        //time between 2 - noti (by minute)
        public int drinkTime { get; set; }
        public int taskTime { get; set; }
        public int breakTime { get; set; }
        //enable status
        public bool drinkE { get; set; }
        public bool taskE { get; set; }
        public bool BreakE { get; set; }

        public NotiStatus()
        {
            drinkTime = 30;
            taskTime = 1;
            breakTime = 60;
            drinkE = true;
            taskE = true;
            BreakE = true;
        }
    }
}
