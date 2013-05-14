using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleField.Tests
{
    [TestClass]
    public class MineTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidMineCoordinatesException))]
        public void MineConstrustor_MustThrowExceptionXIsNegative()
        {
            Mine invalidMine = new Mine(-2, 2);
        }
    }
}
