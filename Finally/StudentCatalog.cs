using System.Collections;
using System.Collections.Generic;

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

        public IEnumerator<Student> GetEnumerator()
        {
            return _students.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public StudentCatalog()
        {
            _students = new List<Student>();
        }
    }
}
