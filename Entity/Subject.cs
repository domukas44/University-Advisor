using Newtonsoft.Json;

namespace University_advisor.Entity
{
    public class Subject
    { 
        int RatingsCount = 0;
        double TotalRatings = 0;
        public int Id { get; set; }
        private static int idNr = 0;
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
            RatingsCount = count;
        }

        public void AddRating(int NewRating)
        {
            RatingsCount++;
            TotalRatings += NewRating;
            Rating = TotalRatings / RatingsCount;
        }
    }
}