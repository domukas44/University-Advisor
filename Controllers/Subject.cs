using Newtonsoft.Json;

namespace University_advisor
{
    public class Subject
    {
        public int id { get; set; }
        private static int idNr = 0;
        public string Name { get; set; }

        [JsonIgnore]     // review serialization shouldn't include the subject's total rating 
        public double Rating { get; set; }

       /* [JsonIgnore]
        public List<Review> reviewList { get; }*/

        public Subject()
        {

        }

        public Subject(string name, double rating)
        {
            id = idNr++;
            Name = name;
            Rating = rating;
            //reviewList = new List<Review>();
        }

       /* public void addReview(Review review)
        {
            reviewList.Add(review);
        }*/
    }
}