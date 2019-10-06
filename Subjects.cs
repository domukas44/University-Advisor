﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace University_advisor
{
    public class Subjects : IEnumerable
    {

        private List<Subject> subjectList;

        public Subjects()
        {
            subjectList = new List<Subject>();
            subjectList.Add(new Subject("Bioinformatika", 0.00));
            subjectList.Add(new Subject("Buhalterinė apskaita", 0.00));
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Subject subject in subjectList)
                yield return subject;
        }
    }
}
