using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using University_advisor.Controllers;

namespace University_advisor.Entity
{
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
        public Lazy<List<Review>> Reviews;

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
            Reviews = new Lazy<List<Review>>(GetReviewList);
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