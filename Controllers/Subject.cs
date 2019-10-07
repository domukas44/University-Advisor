using System;

namespace University_advisor
{
    public class Subject
    {
        private string name;
        private double rating;

        public Subject(string name, double rating)
        {
            this.name = name;
            this.rating = rating;
        }

        public string Name { get { return name; } set { name = value; } }

        public double Rating { get { return rating; } set { rating = value; } }

    }
}
