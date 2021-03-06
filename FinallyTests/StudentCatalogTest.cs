﻿using System;
using System.Collections.Generic;
using Finally;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinallyTests
{
    [TestClass]
    public class StudentCatalogTest
    {
        [TestMethod]
        public void CatalogShouldBeEmptyAfterConstruction()
        {
            var catalog = new StudentCatalog();
            Assert.AreEqual(0, catalog.Count);
        }

        [TestMethod]
        public void AddShouldIncrementTheCatalogCount()
        {
            var catalog = new StudentCatalog();
            catalog.Add(new Student("test", 123));
            Assert.AreEqual(1, catalog.Count);
            catalog.Add(new Student("test", 123));
            Assert.AreEqual(2, catalog.Count);
        }

        [TestMethod]
        public void RemoveShouldDecrementTheCatalogCount()
        {
            var catalog = new StudentCatalog();
            catalog.Add(new Student("test", 123));
            catalog.Remove(new Student("test", 123));
            Assert.AreEqual(0, catalog.Count);
            var student = new Student("test", 123);
            catalog.Add(student);
            catalog.Remove(student);
            Assert.AreEqual(0, catalog.Count);
        }

        [TestMethod]
        public void TestStudentCatalogEnumeration()
        {
            var catalog = new StudentCatalog();
            var test = new Student("test", 123);
            var mary = new Student("mary", 45);
            catalog.Add(test);
            catalog.Add(mary);

            var expected = new List<Student>();
            expected.Add(test);
            expected.Add(mary);

            foreach (var student in catalog)
            {
                Assert.IsTrue(expected.Remove(student));
            }

            Assert.Equals(0, expected.Count);
        }
    }
}
