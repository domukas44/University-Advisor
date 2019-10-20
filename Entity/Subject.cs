using Newtonsoft.Json;

namespace University_advisor.Controller
{
    public class Subject
    {
        //changes by Dominykas
        int RatingsCount = 0;
        double TotalRatings = 0;
        public int Id { get; set; }
        private static int idNr = 0;
        public string Name { get; set; }

        [JsonIgnore]     // review serialization shouldn't include the subject's total Rating 
        public double Rating { get; set; }

       /* [JsonIgnore]
        public List<Review> reviewList { get; }*/

        public Subject()
        {

        }

        public Subject(string name, double Rating, int count)
        {
            Id = idNr++;
            Name = name;
            Rating = Rating;
            TotalRatings = Rating * count;
            RatingsCount = count;
            //reviewList = new List<Review>();
        }

        public void AddRating(int NewRating)
        {
            RatingsCount++;
            TotalRatings += NewRating;
            Rating = TotalRatings / RatingsCount;
        }

       /* public void addReview(Review review)
        {
            reviewList.Add(review);
        }*/
    }
}