using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthy_Food_Menu
{
    public class MenuItem
    {
        public Food food { get; set; }
        public double qty { get; set; }

        public MenuItem(Food food, double qty)
        {
            this.food = food;
            this.qty = qty;
        }

        public MenuItem()
        {
        }
    }
}
