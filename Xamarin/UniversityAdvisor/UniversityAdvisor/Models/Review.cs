using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityAdvisor.Models
{
    class Review
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string Author { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
