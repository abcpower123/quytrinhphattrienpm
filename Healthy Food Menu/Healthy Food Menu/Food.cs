using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthy_Food_Menu
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
    }
}
