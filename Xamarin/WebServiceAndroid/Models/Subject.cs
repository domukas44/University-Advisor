using System;

namespace WebService.Models
{
    [Serializable]
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public int ReviewCount { get; set; }
    }
}