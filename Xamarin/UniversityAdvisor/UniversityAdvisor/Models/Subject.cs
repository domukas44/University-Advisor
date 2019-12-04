using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityAdvisor.Models
{
    class Subject
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
    }
}
