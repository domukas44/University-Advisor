using System;

namespace University_advisor
{
    public class Subject
    {
        private string name;
        public string Name{
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        private float? rating;
        public float? Rating {
            get
            {
                return rating;
            }
            set
            {
                if (value >= 1 && value <= 10)
                {
                    rating = value;
                }
                else
                {
                    rating = null;
                }
            }
        }

        public Subject(string name)
        {
            Name = name;
            Rating = null;
        }
        public Subject(string name, float rating)
        {
            Name = name;
            Rating = rating;
        }
    }
}
