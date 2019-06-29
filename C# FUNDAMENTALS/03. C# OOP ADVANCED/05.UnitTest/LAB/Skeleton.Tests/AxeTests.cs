using System;
using NUnit.Framework;

namespace Tests
{
    public class AxeTests
    {
        [Test]
        public void TestIfWeaponLosesDurability()
        {
            //Arrange
            Axe axe = new Axe(10,10);

            //Act
            axe.Attack(new Dummy(10,10));

            int expected = 9;
            int actual = axe.DurabilityPoints;
            //Assert

            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void TestAttackingWithBrokenWeapon()
        {
            Axe axe = new Axe(10,0);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(new Dummy(10, 10)));

        }
    }
}