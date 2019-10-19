using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace University_advisor.Controllers
{
    public class Review
    {
        // fields are public so that serialization is possible
        public Subject subject { get; set; }
        public string author { get; set; }
        public string comment { get; set; }
        public int rating { get; set; }
        public int id { get; set; }

        public Review()
        {

        }
            
        public Review(Subject subject, string author, string comment, int rating)
        {
            this.subject = subject;
            this.author = author;
            this.comment = comment;
            this.rating = rating;
            Review r = Serializer.deserialize();
            if (r == null)
            {
                id = 0;
            }
            else
            {
                id = r.id + 1;
            }
            //subject.addReview(this);
        }

        public static List<Review> getReviewList(Subject subject)
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
                        where r.subject.id == subject.id
                        select r;
            foreach (Review r in query)
            {
                filteredReviews.Add(r);
            }
            return filteredReviews;
        }
    }
}