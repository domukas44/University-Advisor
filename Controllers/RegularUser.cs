using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_advisor.Controllers
{
    class RegularUser : User
    {
        public RegularUser(string name, string email, string password) : base(name, email, password)
        {

        }

        public RegularUser(string email, string password) : base(email, password)
        {

        }
    }
}
