using System;
using NUnit.Framework;
using PeopleDatabase;

namespace PeopleDb.Tests
{
    public class DbTests
    {
        [Test]
        public void IfCtorThrowsException()
        {
            Person[] persons = new Person[17];

            Database db;

            Assert.Throws<InvalidOperationException>((() => db = new Database(persons)));

        }

        [Test]
        public void IfCtorFillData()
        {
            Person[] persons = new Person[4] { new Person("Westside", 1), new Person("Pesho", 2), new Person("Gosho", 3), new Person("Ivan", 4) };

            Database db = new Database(persons);

            var actual = db.Fletch();

            Assert.AreEqual(persons, actual);
        }
        [Test]
        public void AddMethodShouldThrowExceptionIfDatabaseIsFull()
        {
            Person[] persons = new Person[16]
            {
                new Person("Username1", 1),
                new Person("Username2", 2),
                new Person("Username3", 3),
                new Person("Username4", 4),
                new Person("Username5", 5),
                new Person("Username6", 6),
                new Person("Username7", 7),
                new Person("Username8", 8),
                new Person("Username9", 9),
                new Person("Username10", 10),
                new Person("Username11", 11),
                new Person("Username12", 12),
                new Person("Username13", 13),
                new Person("Username14", 14),
                new Person("Username15", 15),
                new Person("Username16", 16),

            };

            Database db = new Database(persons);

            Assert.Throws<InvalidOperationException>((() => db.Add(new Person("Username17", 17))));

        }

        [Test]
        public void AddMethodShouldThrowExceptionIfUsernameExist()
        {
            Person[] persons = new Person[1] { new Person("Westside", 1) };

            Database db = new Database(persons);

            Assert.Throws<InvalidOperationException>((() => db.Add(new Person("Westside", 2))));
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfIdExist()
        {
            Person[] persons = new Person[1] { new Person("Westside", 1) };

            Database db = new Database(persons);

            Assert.Throws<InvalidOperationException>((() => db.Add(new Person("Westside", 1))));
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfDbIsEmpty()
        {
            Person[] persons = new Person[0];

            Database db = new Database(persons);

            Assert.Throws<InvalidOperationException>((() => db.Remove()));
        }

        [Test]
        public void RemoveMethodShouldReturnRemovedPerson()
        {
            Person person = new Person("Westisde", 1);

            Database db = new Database(person);

            var removed = db.Remove();

            Assert.AreEqual(person,removed);
        }

    }
}