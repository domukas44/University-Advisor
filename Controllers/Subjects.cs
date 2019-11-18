using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
            LogWriter lw = new LogWriter();
            subjectList = new List<Subject>();
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"..\..\Resources\Data.txt");

                foreach (var s in client.ReadData())
                {
                     subjectList.Add(Converter.ConvertToMySubject(s));
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                lw.logMessage(ex.Message);
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                lw.logMessage(ex.Message);
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                lw.logMessage(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Subject subject in subjectList)
                yield return subject;
        }
    }
}
