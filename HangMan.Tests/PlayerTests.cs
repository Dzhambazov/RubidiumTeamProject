using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangMan.Tests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void PlayerTestCorrectNameAndMistakes()
        {
            Player player = new Player("Pesho", 20);
            string result = player.Name + " " + player.Mistakes;
            string expected = "Pesho 20";
            Assert.AreEqual(result, expected, true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlayerTestFailNullName()
        {
            Player player = new Player(null, 20);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlayerTestFailEmptyName()
        {
            Player player = new Player("", 20);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerTestFailShortName()
        {
            Player player = new Player("Lo", 20);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerTestFailMistakesNegativeNum()
        {
            Player player = new Player("Gosho", -2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerTestFailBigNumberOfMisakes()
        {
            Player player = new Player("Gosho", int.MaxValue);
        }
    }
}
