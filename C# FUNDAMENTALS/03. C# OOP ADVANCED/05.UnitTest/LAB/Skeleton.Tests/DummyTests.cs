using System;
using NUnit.Framework;

namespace Tests
{
    public class DummyTests
    {
        [Test]
        public void LosesHealthIfDummyIsAttacked()
        {
            //Arrange
            Dummy dummy = new Dummy(10,10);

            //Act
            dummy.TakeAttack(5);

            //Assert
            int actual = dummy.Health;
            int expected = 5;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            Dummy dummy = new Dummy(0,0);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(1));
        }

        [Test]
        public void DeathDummyCanGiveXP()
        {
            Dummy dummy = new Dummy(0,10);

            int actual = dummy.GiveExperience();
            int expected = 10;

            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void AliveDummyCanGiveXP()
        {
            Dummy dummy = new Dummy(10,10);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }

    }
}