using System;
using System.Collections;
using System.Collections.Generic;

namespace University_advisor
{
    public class SubjectEnum : IEnumerator<Subject>
    {
        public Subject[] subjects;

        int position = -1;

        public SubjectEnum(Subject[] subjects)
        {
           this.subjects = subjects;
        }

        public bool MoveNext()
        {
            position++;
            return (position < subjects.Length);
        }

        public void Reset()
        {
            position = -1;
        }


        public void Dispose()
        {
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Subject Current
        {
            get
            {
                try
                {
                    return subjects[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
