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
        public void MineConstrustor_CreateNewMine()
        {
            Mine invalidMine = new Mine(2, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMineCoordinatesException))]
        public void MineConstrustor_MustThrowExceptionXIsNegative()
        {
            Mine invalidMine = new Mine(-2, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMineCoordinatesException))]
        public void MineConstrustor_MustThrowExceptionYIsNegative()
        {
            Mine invalidMine = new Mine(5, -7);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMineCoordinatesException))]
        public void MineConstrustor_MustThrowExceptionYIsBiggerThan10()
        {
            Mine invalidMine = new Mine(5, 12);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMineCoordinatesException))]
        public void MineConstrustor_MustThrowExceptionXIsBiggerThan10()
        {
            Mine invalidMine = new Mine(15, 2);
        }
    }
}
