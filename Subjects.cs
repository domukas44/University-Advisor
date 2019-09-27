using System;
using System.Collections;

namespace University_advisor
{
    public class Subjects : IEnumerable
    {
        public Subject[] arr;

        public Subjects()
        {
            //
            // reikės iš kažkur ištraukti duomenis ar ranka visus surašyt?
            // dar pridėti kategorijas (pasirenkamieji, jų grupės, BUS'ai)
            arr = new Subject[]
            {
                new Subject("Bioinformatika", 5),
                new Subject("Buhalterinė apskaita", 8),
                new Subject("Informatikos teisė", 4),
            };
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }

        public SubjectEnum GetEnumerator()
        {
            return new SubjectEnum(arr);
        }
    }
}
