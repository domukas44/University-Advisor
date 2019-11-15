using System;
using Newtonsoft.Json;
using University_advisor.SubjectWS;

namespace University_advisor.Entity
{
    [Serializable]
    public class Subject
    { 
        public int Id { get; set; }
        private static int idNr = 0;
        private string v1;
        private string v2;

        public string Name { get; set; }

        [JsonIgnore]     // review serialization shouldn't include the subject's total rating
        public double Rating { get; set; }

        public Subject()
        {

        }

        public Subject(string name, double rating)
        {
            Id = idNr++;
            Name = name;
            Rating = rating;
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

        public static implicit operator Subject(string v)
        {
            throw new NotImplementedException();
        }
    }
}