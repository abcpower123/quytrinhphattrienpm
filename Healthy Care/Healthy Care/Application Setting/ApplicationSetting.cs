using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Healthy_Care.Application_Setting
{
    [Serializable]
    class ApplicationSetting
    {
        public Notification.NotiStatus notiStatus { get; set; }
        public bool isAutoStart { get; set; }
        public bool silenceMode { get; set; }

        public static void SaveSeting(ApplicationSetting setting)
        {
            string data = JsonConvert.SerializeObject(setting);
            if (!Directory.Exists("data")) Directory.CreateDirectory("data");

            File.WriteAllText(Application.StartupPath + "/data/setting.json", data);
        }
        public static ApplicationSetting LoadSetting()
        {
            ApplicationSetting setting = null;
            if (!File.Exists(Application.StartupPath + "/data/setting.json"))
            {
                return setting;
            }

            string data = File.ReadAllText(Application.StartupPath + "/data/setting.json");
            setting = JsonConvert.DeserializeObject<ApplicationSetting>(data);
            return setting;
        }
        public ApplicationSetting()
        {
            notiStatus = new Notification.NotiStatus();
        }
    }
}
