using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Time_Management
{
    [Serializable]
    public class Appsetting
    {
        public int numerricValue { get; set; }
        public int indexComboboxValue { get; set; }
        public bool isAutoStart { get; set; }
        public bool noty { get; set; }
    }
}
