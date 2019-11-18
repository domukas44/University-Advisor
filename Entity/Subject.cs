using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using University_advisor.Controllers;
using University_advisor.SubjectWS;

namespace University_advisor.Entity
{
    [Serializable]
    public class Subject
    { 
        int RatingsCount = 0;
        double TotalRatings = 0;
        int TotalRatingsInt = 0;
        private static int idNr = 0;
        private string v1;
        private string v2;

        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]     // review serialization shouldn't include the subject's total rating
        public double Rating { get; set; }

        //lazy loading
        [JsonIgnore]
        public Lazy<List<Review>> Reviews;

        public Subject()
        {

        }

        public Subject(string name, double rating)
        {
            Id = idNr++;
            Name = name;
            Rating = rating
            Reviews = new Lazy<List<Review>>(GetReviewList);
        }

        public Subject(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public void AddRating(int newRating)
        {
            Rating = new SubjectWebService().AddRating(newRating, this.Name);       // adds the rating, updates data and returns the new calculated rating
        }

        public static void ResetIdNr()
        {
            idNr = 0;
        }

        public List<Review> GetReviewList()
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

        public void UpdateList()
        {
            Reviews = new Lazy<List<Review>>(GetReviewList);
        }
    }
}
