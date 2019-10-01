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

            // fullpathname nuskaito failo patha
            string fullPathName= System.Reflection.Assembly.GetEntryAssembly().Location;

            fullPathName = fullPathName.Substring(0, fullPathName.Length-32);
            fullPathName+="info.txt";
            //baigiamas patho sukurimas

            // duomenu nuskaitymas is info.txt failo
            System.IO.StreamReader file =
            new System.IO.StreamReader(fullPathName); 

            arr = new Subject[5];
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(' ');
                arr[counter] = new Subject(words[0], float.Parse(words[1]));
                counter++;
            }  

            //nuskaitymo pabaiga
           

           
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
