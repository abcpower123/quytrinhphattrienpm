using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Healthy_Care.Healthy_Food_Menu
{
    [Serializable]
    public class Food
    {
        
        public string ten { get; set; }
        public string nhom { get; set; }
        public float tinhbot { get; set; }
        public float dam { get; set; }
        public float beo { get; set; }
        public float xo { get; set; }

        public Food(string ten, string nhom, float tinhbot, float dam, float beo, float xo)
        {
            this.ten = ten;
            this.nhom = nhom;
            this.tinhbot = tinhbot;
            this.dam = dam;
            this.beo = beo;
            this.xo = xo;
        }

        public Food()
        {
        }

        public void setvaluefromFood(Food a)
        {
            this.ten = a.ten;
            this.nhom = a.nhom;
            this.tinhbot = a.tinhbot;
            this.dam = a.dam;
            this.beo = a.beo;
            this.xo = a.xo;
        }

 
        public static void SaveJson(List<Food> foods)
        {
            string data = JsonConvert.SerializeObject(foods);
            if (!Directory.Exists("data")) Directory.CreateDirectory("data");

            File.WriteAllText(Application.StartupPath + "/data/Data.json", data);
        }
        public static List<Food> LoadJson()
        {
            if (!File.Exists(Application.StartupPath + "/data/Data.json"))
            {
                return null;
            }
            string data = File.ReadAllText(Application.StartupPath + "/data/Data.json");
            return JsonConvert.DeserializeObject<List<Food>>(data);
        }
    }
}
