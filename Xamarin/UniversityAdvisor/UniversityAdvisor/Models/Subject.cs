using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityAdvisor.Models
{
    public class Subject
    {
        //private static int idNr = 0;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }

        public Subject(string name, double rating)
        {
            //Id = idNr++;
            Name = name;
            Rating = rating;
        }
    }
}
