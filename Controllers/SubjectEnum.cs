using System;
using System.Collections;
using System.Collections.Generic;

namespace University_advisor.Controllers
{
    public class SubjectEnum : IEnumerator<Subject>
    {
        public List<Subject> subjects;

        int position = -1;

        public SubjectEnum(List<Subject> subjects)
        {
           this.subjects = subjects;
        }

        public bool MoveNext()
        {
            position++;
            return (position < subjects.Count);
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
