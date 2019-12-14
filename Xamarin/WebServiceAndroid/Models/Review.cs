using System;

namespace WebService.Models
{
    [Serializable]
    public class Review
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string Author { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}