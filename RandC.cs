using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_advisor
{
    class RandC
    {
        public string email { get; set; }
        public string Comment { get; set; }

        public RandC(string name, string comment)
        {
            email = name;
            Comment = comment;
        }
    }
}