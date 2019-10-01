using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace University_advisor
{
    public class Subjects : IEnumerable<Subject>
    {
        public Subject[] arr;

        public Subjects()
        {
            arr = new Subject[100];        // temp size, change later
        }

        public void createSubjects()
        {
            // reikės iš kažkur ištraukti duomenis ar ranka visus surašyt?
           
            // dar pridėti kategorijas (pasirenkamieji, jų grupės, BUS'ai)
            int counter = 0;
            string line;

            System.IO.StreamReader file =
            new System.IO.StreamReader(@"C:\Users\dojo5745\Downloads\projektas\University-Advisor\info.txt"); 

            arr = new Subject[5];
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(' ');
                arr[counter] = new Subject(words[0], float.Parse(words[1]));
                counter++;
            }  

           
        }

        IEnumerator<Subject> IEnumerable<Subject>.GetEnumerator()
        {
            return GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public SubjectEnum GetEnumerator()
        {
            return new SubjectEnum(arr);
        }

    }
}
