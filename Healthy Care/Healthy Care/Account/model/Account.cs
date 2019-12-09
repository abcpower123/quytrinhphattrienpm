using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Healthy_Care.Account.model
{
    [Serializable]
    class Account
    {
        public string userName { get; set; }
        public string password { get; set; }
        public int age { get; set; }
        public int height { get; set; }
        public int weight { get; set; }


    }
}
