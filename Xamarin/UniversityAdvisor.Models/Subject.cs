using SQLite;

namespace UniversityAdvisor.Models
{
    public class Subject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }

    }
}
