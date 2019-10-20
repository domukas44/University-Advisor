using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_advisor.Controllers
{
    interface IAccount
    {
        string name { get; set; }
        string email { get; set; }
        string password { get; set; }
        bool checkIfExists(string name, string email, string password);
    }
}
