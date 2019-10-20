using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace University_advisor.Controllers
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
            
        public Review(Subject Subject, string Author, string Comment, int Rating)
        {
            this.Subject = Subject;
            this.Author = Author;
            this.Comment = Comment;
            this.Rating = Rating;
            Review r = Serializer.deserialize();
            if (r == null)
            {
                Id = 0;
            }
            else
            {
                Id = r.Id + 1;
            }
            //Subject.addReview(this);
        }

        public static List<Review> getReviewList(Subject Subject)
        {
            var allReviews = new List<Review>();
            var filteredReviews = new List<Review>();
            using (StreamReader sr = new StreamReader(@"..\..\Resources\Reviews.txt"))
            {
                while (!sr.EndOfStream)
                {
                    allReviews.Add(JsonConvert.DeserializeObject<Review>(sr.ReadLine()));
                }
            }
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