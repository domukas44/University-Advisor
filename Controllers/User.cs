using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_advisor.Controllers
{
    class User : IAccount
    {
        public string name { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public bool checkIfExists(string name, string email, string password)
        {
            if ((this.name == name) && (this.email == email) && (this.password == password)) return true;
            else return false;
        }
    }
}
