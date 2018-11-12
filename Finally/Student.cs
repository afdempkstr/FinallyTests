using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finally
{
    public class Student
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Student(string name, int age)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }
            Name = name;
            
            if (age <= 0)
            {
                throw new ArgumentOutOfRangeException("age", "The age must be greater than 0");
            }
            Age = age;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (object.ReferenceEquals(obj, this))
            {
                return true;
            }

            if (!(obj is Student))
            {
                return false;
            }

            var other = (Student)obj;
            return (this.Name == other.Name && this.Age == other.Age);
        }
    }
}

