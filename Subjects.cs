using System;
using System.Collections;
using System.Collections.Generic;

namespace University_advisor
{
    public class Subjects : IEnumerable<Subject>
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
