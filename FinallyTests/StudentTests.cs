using System;
using Finally;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinallyTests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void AgeMustNotAcceptNegativeValues()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => 
            {
                var student = new Student("test", -5);
            });

            try
            {
                var student = new Student("test", 3);
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.Fail();
            }

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                var student = new Student("test", 5);
                student.Age = -1;
            });

            try
            {
                var student = new Student("test", 1);
                student.Age = 3;
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void AgeGetterReturnsTheCurrentAge()
        {
            var student = new Student("test", 77);
            Assert.AreEqual(77, student.Age);

            student.Age = 45;
            Assert.AreEqual(45, student.Age);
        }

        [TestMethod]
        public void SetStudentGrade()
        {
            var student = new Student("test", 10);
            student["Mathematics"] = 9;

            Assert.AreEqual(9, student["Mathematics"]);
        }

        [TestMethod]
        public void GetGradeThrowsExceptionIfLessonNotFound()
        {
            var student = new Student("test", 1);
            Assert.ThrowsException<StudentNotEnrolledException>(() =>
            {
                var grade = student["C#"];
            });
        }
    }
}
