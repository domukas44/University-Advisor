using System.Collections;
using System.Collections.Generic;
using University_advisor.Entity;

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
            SubjectWS.SubjectWebService client = new SubjectWS.SubjectWebService();
            subjectList = new List<Subject>();
            foreach (var s in client.ReadData())
            {
                subjectList.Add(Converter.ConvertToMySubject(s));
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Subject subject in subjectList)
                yield return subject;
        }
    }
}
