using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using University_advisor.Controllers;

namespace University_advisor
{
    public class Subject
    {
        public int id { get; }
        private static int idNr = 0;
        public string Name { get; set; }
           
        [JsonIgnore]     // kad prie kiekvieno review neįrašytų bendro dalyko reitingo
        public double Rating { get; set; }

        // private laukus serializer ignoruoja
        private List<Review> reviewList { get; }

        public Subject(string name, double rating)
        {
            id = idNr++;
            Name = name;
            Rating = rating;
            reviewList = new List<Review>();
        }

        public void addReview(Review review)
        {
            reviewList.Add(review);
        }
    }
}
