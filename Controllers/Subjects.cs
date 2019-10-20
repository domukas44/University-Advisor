using System;
using System.Collections;
using System.Collections.Generic;

namespace University_advisor.Controllers
{
    public class Subjects : IEnumerable
    {
        private List<Subject> subjectList;

        public Subjects()
        {
            PopulateData();
        }

        private void PopulateData()
        {
            subjectList = new List<Subject>();
            string[] lines = System.IO.File.ReadAllLines(@"..\..\Resources\TestData.txt");

            foreach (string line in lines)
            {
                string[] linesSplit = line.Split('\t');
                subjectList.Add(new Subject(linesSplit[0], Convert.ToDouble(linesSplit[1]), Convert.ToInt32(linesSplit[2])));
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Subject subject in subjectList)
                yield return subject;
        }
    }
}
