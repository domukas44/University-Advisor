namespace University_advisor.Controllers
{
    public class Review
    {
        // laukai public, kad galėtų serialize
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
            subject.addReview(this);
        }
    }
}