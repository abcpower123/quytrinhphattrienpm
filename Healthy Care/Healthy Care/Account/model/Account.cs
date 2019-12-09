using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Healthy_Care.Account.model
{
    [Serializable]
    class Account
    {
        public string name { get; set; }
        public int age { get; set; }
        public int height { get; set; }
        public int weight { get; set; }

        public static void SaveProfile(Account a)
        {
            string data = JsonConvert.SerializeObject(a);
            if (!Directory.Exists("data")) Directory.CreateDirectory("data");

            File.WriteAllText(Application.StartupPath + "/data/profile.json", data);
        }
        public static Account LoadProfile()
        {
            Account a = null;
            if (!File.Exists(Application.StartupPath + "/data/profile.json"))
            {
                return a;
            }

            string data = File.ReadAllText(Application.StartupPath + "/data/profile.json");
            a = JsonConvert.DeserializeObject<Account>(data);
            return a;
        }

    }
}
