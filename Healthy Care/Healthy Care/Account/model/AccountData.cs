using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Healthy_Care.Account.model
{
    [Serializable]
    class AccountData
    {
        public Account accountInformation { get; set; }
        public List<Time_Management.Work> taskList { get; set; }
        public Application_Setting.ApplicationSetting applicationSetting { get; set; }
        public List<Healthy_Food_Menu.Food> foodList { get; set; }

        public string toJSon()
        {
            string data = JsonConvert.SerializeObject(this);
            return data;
        }
        public static AccountData LoadData(string jsonData)
        {
            AccountData data = null;
           

            data = JsonConvert.DeserializeObject<AccountData>(jsonData);
            return data;
        }
    }
}
