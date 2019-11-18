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


            LogWriter lw = new LogWriter();
            subjectList = new List<Subject>();
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"..\..\Resources\TestData.txt");

                foreach (string line in lines)
                {
                     string[] linesSplit = line.Split('\t');
                     subjectList.Add(new Subject(linesSplit[0], Convert.ToDouble(linesSplit[1]), Convert.ToInt32(linesSplit[2])));  
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
