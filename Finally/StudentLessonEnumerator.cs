using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finally
{
    public class StudentLessonEnumerator : IEnumerator<Lesson>
    {
        private Dictionary<string, byte> _items;
        private int _count;
        private int _current;
        private Lesson _currentLesson;

        public StudentLessonEnumerator(Dictionary<string, byte> items)
        {
            _items = items;
            _count = _items.Count;
        }

        public Lesson Current => _currentLesson;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_current < _count)
            {
                var item = _items.ElementAt(_current);
                _currentLesson = new Lesson(item.Key, item.Value);
                _current++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _current = 0;
        }
    }
}
