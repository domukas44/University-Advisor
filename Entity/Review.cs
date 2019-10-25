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
            
        public Review(Subject Subject, string Author, int Rating, string Comment = "[Vartotojas atsisak? pakomentuoti vertinim?]") // Optional argument usage
        {
            this.Subject = Subject;
            this.Author = Author;
            this.Comment = Comment;
            this.Rating = Rating;
            Review r = Deserializer<Review>.deserializeLine(@"..\..\Resources\LastReview.txt");
            if (r == null)
            {
                Id = 0;
            }
            else
            {
                Id = r.Id + 1;
            }
        }

        public static List<Review> getReviewList(Subject Subject)
        {
            var allReviews = new List<Review>();
            var filteredReviews = new List<Review>();
            allReviews = Deserializer<Review>.deserializeFile(@"..\..\Resources\Reviews.txt");
            var query = from Review r in allReviews
                        where r.Subject.Id == Subject.Id
                        select r;
            foreach (Review r in query)
            {
                filteredReviews.Add(r);
            }
            return filteredReviews;
        }
    }
}