using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_advisor.Entity;

namespace University_advisor.Data
{
    public struct Subs
    {
        Subject Subject;
        string Type; 

        public Subs(Subject subject, string type)
        {
            Subject = subject;
            Type = type;
        }
    }
}
