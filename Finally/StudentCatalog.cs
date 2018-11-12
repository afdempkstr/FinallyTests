using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finally
{
    public class StudentCatalog : ICatalog<Student>
    {
        private List<Student> _students;
        public string Name { get; set; }

        public int Count => _students.Count;

        public void Add(Student item)
        {
            _students.Add(item);
        }

        public void Remove(Student item)
        {
            _students.Remove(item);
        }

        public StudentCatalog()
        {
            _students = new List<Student>();
        }
    }
}
