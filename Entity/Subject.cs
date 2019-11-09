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

        public Subject(string name, double Rating, int count)
        {
            Id = idNr++;
            Name = name;
            this.Rating = Rating;
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

        public static Subject ConvertToMySubject(SubjectWS.Subject s)
        {
            return new Subject() { Id = s.Id, Name = s.Name, Rating = s.Rating };
        }

        public University_advisor.SubjectWS.Subject ConvertToWSSubject(Subject s)
        {
            return new University_advisor.SubjectWS.Subject() { Id = s.Id, Name = s.Name, Rating = s.Rating};
        }
    }
}