using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_advisor.Entity;

namespace University_advisor.Controllers
{
    public class LoginEventArgs : EventArgs
    {
        public LoginEventArgs(RegularUser user)
        {
            User = user;
        }
        public RegularUser User { get; set; }
    }
}
