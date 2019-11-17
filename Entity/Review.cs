using System.Collections.Generic;
using System.Linq;
using University_advisor.Controllers;

namespace University_advisor.Entity
{
    public class Review
    {
        // fields are public so that serialization is possible
        public Subject Subject { get; set; }
        public string Author { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public int Id { get; set; }

        public Review()
        {

        }
            
        public Review(Subject subject, string author, int rating, string comment = "[Vartotojas atsisak? pakomentuoti vertinim?]") // Optional argument usage
        {
            Subject = subject;
            Author = author;
            Comment = comment;
            Rating = rating;
            Review r = Deserializer<Review>.DeserializeLine(@"..\..\Resources\LastReview.txt");
            if (r == null)
            {
                Id = 0;
            }
            else
            {
                Id = r.Id + 1;
            }
        }

        public static List<Review> GetReviewList(int Id)
        {
            var allReviews = new List<Review>();
            var filteredReviews = new List<Review>();
            allReviews = Deserializer<Review>.DeserializeFile(@"..\..\Resources\Reviews.txt");
            var query = from Review r in allReviews
                        where r.Subject.Id == Id
                        select r;
            foreach (Review r in query)
            {
                filteredReviews.Add(r);
            }
            return filteredReviews;
        }
    }
}