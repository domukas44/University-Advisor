using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_advisor.Controllers
{
    public interface IAccount
    {
        string name { get; set; }
        string email { get; set; }
        string password { get; set; }
        bool checkIfExists();
        bool matchEmailAndPassword();
        void saveAccountToFile();
    }
}
