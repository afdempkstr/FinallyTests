﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Finally
{
    public class Student : IEnumerable<Lesson>
    {
        private int _age;
        private Dictionary<string, byte> _grades;

        public string Name { get; }

        public int Age
        {
            get => _age;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The age must be greater than 0");
                }
                _age = value;
            }
        }

        public byte this[string lesson]
        {
            get
            {
                if (!_grades.ContainsKey(lesson))
                {
                    throw new StudentNotEnrolledException(lesson, this);
                }
                return _grades[lesson];
            }
            set
            {
                if (value > 10)
                {
                    throw new ArgumentOutOfRangeException("grade", "The grade must be between 0 and 10");
                }
                _grades[lesson] = value;
            }
        }

        public Student(string name, int age)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }
            Name = name;
            Age = age;
            _grades = new Dictionary<string, byte>();
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

        public IEnumerable<Lesson> Lessons
        {
            get
            {
                foreach (var lesson in _grades)
                {
                    yield return new Lesson(lesson.Key, lesson.Value);
                }
            }
        }

        public IEnumerator<Lesson> GetEnumerator()
        {
            //return new StudentLessonEnumerator(_grades);

            //List<Lesson> lessons = new List<Lesson>();
            //foreach (KeyValuePair<string, byte> item in _grades)
            //{
            //    lessons.Add(new Lesson(item.Key, item.Value));
            //}
            //return lessons.GetEnumerator();

            //return _grades
            //    .Select(item => new Lesson(item.Key, item.Value))
            //    .ToList()
            //    .GetEnumerator();

            return Lessons.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

