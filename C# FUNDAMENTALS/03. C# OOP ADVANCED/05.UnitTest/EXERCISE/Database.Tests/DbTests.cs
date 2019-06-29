using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Database.Tests
{
    [TestFixture]
    public class DbTests
    {
        [Test]
        public void EmptyCtorShouldInitArrayWithExpectedSize()
        {

            Type type = typeof(Database);

            var instance = Activator.CreateInstance(type);

            var field = (int[])type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(f => f.Name == "data").GetValue(instance);

            var actualSize = field.Length;
            var expectedSize = 16;

            Assert.AreEqual(expectedSize, actualSize);
        }

        [Test]
        public void CtorShouldThrowExceptionIfDataIsLonger()
        {
            int[] longArr = new int[17];

            Database db;

            Assert.Throws<InvalidOperationException>(() => db = new Database(longArr));
        }

        [Test]
        public void CtorWithParamsShouldFillArray()
        {
            int expectedSize = 12;
            int[] arr = new int[expectedSize];

            Type type = typeof(Database);

            var instance = Activator.CreateInstance(type,arr);

            int actualSize = (int)type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(f => f.Name == "index").GetValue(instance) + 1;
            
            Assert.AreEqual(expectedSize,actualSize);
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfDatabaseIsFull()
        {
            Database db = new Database();

            for (int i = 1; i <= 16; i++)
            {
                db.Add(i);
            }

            Assert.Throws<InvalidOperationException>((() => db.Add(17)));
        }

        [Test]
        public void AddMethodShouldAddNumberAtLastFreeSpace()
        {
            int[] arr = new int[3] { 1, 2, 3 };

            Database db = new Database(arr);

            int expected = 4;
            db.Add(expected);

            int actual = db.Fetch().Last();

            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfDatabaseIsEmpty()
        {
            Database db = new Database();

            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        public void RemoveMethodShouldRemoveLastElement()
        {
            int[] arr = new int[3] {1,2,3};

            Database db = new Database(arr);

            db.Remove();

            int[] dbData = db.Fetch();

            int lastNumber = dbData[dbData.Length - 1];
            int expectedNumber = 2;

            Assert.AreEqual(expectedNumber,lastNumber);
        }

        [Test]
        public void FetchMethodShouldReturnTheElementsAsArray()
        {
            int[] expectedArray = new int[3] {1, 2, 3};

            Database db = new Database(expectedArray);

            var actualArray = db.Fetch();

            Assert.AreEqual(expectedArray,actualArray);
        }
    }
}