using System;
using Newtonsoft.Json;

namespace University_advisor.Entity
{
    public class Subject
    { 
        int RatingsCount = 0;
        double TotalRatings = 0;
        int TotalRatingsInt = 0;
        public int Id { get; set; }
        private static int idNr = 0;
        private string v1;
        private string v2;

        public string Name { get; set; }

        [JsonIgnore]     // review serialization shouldn't include the subject's total rating
        public double Rating { get; set; }

        public Subject()
        {

        }

        public Subject(string name, double Rating, int count)
        {
            Id = idNr++;
            Name = name;
            this.Rating = Rating;
            TotalRatings = Rating * count;
            if ((TotalRatings == 10) || (TotalRatings == 0))
                TotalRatingsInt = (int)TotalRatings;
            RatingsCount = count;
        }

        public Subject(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public void AddRating(int NewRating)
        {
            RatingsCount++;
            TotalRatings += NewRating;
            Rating = TotalRatings / RatingsCount;
        }

        public static implicit operator Subject(string v)
        {
            throw new NotImplementedException();
        }
    }
}