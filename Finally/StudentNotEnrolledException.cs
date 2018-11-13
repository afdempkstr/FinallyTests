using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finally
{
    public class StudentNotEnrolledException : ApplicationException
    {
        public Student Student { get; }

        public string Lesson { get; }

        public StudentNotEnrolledException(string lesson, Student student)
        {
            Lesson = lesson;
            Student = student;
        }

        public StudentNotEnrolledException() : this("", null)
        { }
    }
}
