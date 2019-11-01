using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthy_Food_Menu
{
    public class Menu
    {
        public List<MenuItem> menu { get; set; }

        public Menu()
        {
            menu = new List<MenuItem>();
        }
    }
}
