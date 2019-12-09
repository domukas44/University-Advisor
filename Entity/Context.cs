using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_advisor.Entity
{
    public class Context : DbContext
    {
        public Context()
            : base()
        {
        }

        public DbSet<RegularUser> RegularUsers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
