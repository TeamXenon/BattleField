namespace BattleField.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ExplosionTests
    {
        [TestMethod]
        public void IsInsideField_ShouldReturnFalseXIsNegative()
        {
            char[,] field = new char[5,5];
            bool isInside = Explosion.IsInsideField(field, -5, 2);
            Assert.AreEqual(false, isInside);
        }
    }
}
