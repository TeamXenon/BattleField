namespace BattleField.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ExplosionTests
    {
        [TestMethod]
        public void IsInsideField_ShouldReturnTrue()
        {
            char[,] field = new char[6, 6];
            bool isInside = Explosion.IsInsideField(field, 3, 3);
            Assert.AreEqual(true, isInside);
        }

        [TestMethod]
        public void IsInsideField_ShouldReturnFalseXIsNegative()
        {
            char[,] field = new char[5,5];
            bool isInside = Explosion.IsInsideField(field, -5, 2);
            Assert.AreEqual(false, isInside);
        }

        [TestMethod]
        public void IsInsideField_ShouldReturnFalseXIsBiggerThanSize()
        {
            char[,] field = new char[4, 4];
            bool isInside = Explosion.IsInsideField(field, 5, 2);
            Assert.AreEqual(false, isInside);
        }

        [TestMethod]
        public void IsInsideField_ShouldReturnFalseXIsEqualToSize()
        {
            char[,] field = new char[2, 2];
            bool isInside = Explosion.IsInsideField(field, 2, 1);
            Assert.AreEqual(false, isInside);
        }

        [TestMethod]
        public void IsInsideField_ShouldReturnFalseYIsEqualToSize()
        {
            char[,] field = new char[9, 9];
            bool isInside = Explosion.IsInsideField(field, 2, 9);
            Assert.AreEqual(false, isInside);
        }

        [TestMethod]
        public void IsInsideField_ShouldReturnFalseYIsBiggerThanSize()
        {
            char[,] field = new char[7, 7];
            bool isInside = Explosion.IsInsideField(field, 5, 9);
            Assert.AreEqual(false, isInside);
        }

        [TestMethod]
        public void IsInsideField_ShouldReturnFalseYIsNegative()
        {
            char[,] field = new char[5, 5];
            bool isInside = Explosion.IsInsideField(field, 1, -1);
            Assert.AreEqual(false, isInside);
        }

        [TestMethod]
        public void Explode_ExplosionOneMineInTheMiddle()
        {
            char[,] field = 
            { 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '1', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' } 
            };
            char[,] expectedResult = 
            { 
                { '-', '-', '-', '-', '-', '-' }, 
                { 'X', '-', 'X', '-', '-', '-' }, 
                { '-', 'X', '-', '-', '-', '-' }, 
                { 'X', '-', 'X', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' } 
            };
            Explosion.Explode(field, new Mine(2, 1));
            CollectionAssert.AreEqual(expectedResult, field);
        }

        [TestMethod]
        public void Explode_ExplosionOneMineInCorner()
        {
            char[,] field = 
            { 
                { '1', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' } 
            };
            char[,] expectedResult = 
            { 
                { 'X', '-', '-', '-', '-', '-' }, 
                { '-', 'X', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' } 
            };
            Explosion.Explode(field, new Mine(0, 0));
            CollectionAssert.AreEqual(expectedResult, field);
        }

        [TestMethod]
        public void Explode_ExplosionTwoMineInTheMiddle()
        {
            char[,] field = 
            { 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '2', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' } 
            };
            char[,] expectedResult = 
            { 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', 'X', 'X', 'X', '-', '-' }, 
                { '-', 'X', 'X', 'X', '-', '-' }, 
                { '-', 'X', 'X', 'X', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' } 
            };
            Explosion.Explode(field, new Mine(2, 2));
            CollectionAssert.AreEqual(expectedResult, field);
        }

        [TestMethod]
        public void Explode_ExplosionTwoMineInTheRightSide()
        {
            char[,] field = 
            { 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '2' }, 
                { '-', '-', '-', '-', '-', '-' } 
            };
            char[,] expectedResult = 
            { 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', 'X', 'X', }, 
                { '-', '-', '-', '-', 'X', 'X' }, 
                { '-', '-', '-', '-', 'X', 'X', } 
            };
            Explosion.Explode(field, new Mine(4, 5));
            CollectionAssert.AreEqual(expectedResult, field);
        }

        [TestMethod]
        public void Explode_ExplosionThreeMineInTheMiddle()
        {
            char[,] field = 
            { 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '2', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' } 
            };
            char[,] expectedResult = 
            { 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', 'X', 'X', 'X', '-', '-' }, 
                { '-', 'X', 'X', 'X', '-', '-' }, 
                { '-', 'X', 'X', 'X', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' }, 
                { '-', '-', '-', '-', '-', '-' } 
            };
            Explosion.Explode(field, new Mine(2, 2));
            CollectionAssert.AreEqual(expectedResult, field);
        }   
    }
}
