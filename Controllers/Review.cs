
namespace University_advisor.Controllers
{
    public class Review
    {
        // laukai public, kad galėtų serialize
        public Subject subject { get; }
        public string author { get; }
        public string comment { get; }
        public int rating { get; }
        public int id { get; }
        private static int idNr = 0;
        // čia kol kas labai negerai padaryti id, nes kiekvieną kartą iš naujo paleidus programą nusiresetina

        public Review(Subject subject, string author, string comment, int rating)
        {
            this.subject = subject;
            this.author = author;
            this.comment = comment;
            this.rating = rating;
            //id = Serializer.deserialize().id + 1;
            id = idNr++;
            subject.addReview(this);
        }
    }
}