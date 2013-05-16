//-----------------------------------------------------------------------
// <copyright file="PlayerTests.cs" company="Telerik Academy">
//  Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// <author>Team "Rubidium"</author>
//-----------------------------------------------------------------------
namespace HangMan.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test class for testing player class.
    /// </summary>
    [TestClass]
    public class PlayerTests
    {
        /// <summary>
        /// Testing instances of player with correct values
        /// </summary>
        [TestMethod]
        public void PlayerTestCorrectNameAndMistakes()
        {
            Player player = new Player("Pesho", 20);
            string result = player.Name + " " + player.Mistakes;
            string expected = "Pesho 20";
            Assert.AreEqual(result, expected, true);
        }

        /// <summary>
        /// Testing instances of player with missing name value
        /// </summary>
        [TestMethod]
        public void PlayerTestFailNullName()
        {
            Player player = new Player(null, 20);
            string expectedName = "Unknown";
            Assert.AreEqual(expectedName, player.Name);
        }

        /// <summary>
        /// Testing instances of player with empty name value
        /// </summary>
        [TestMethod]
        public void PlayerTestFailEmptyName()
        {
            Player player = new Player(string.Empty, 20);
            string expectedName = "Unknown";
            Assert.AreEqual(expectedName, player.Name);
        }

        /// <summary>
        /// Testing instances of player with less than required name length
        /// </summary>
        [TestMethod]
        public void PlayerTestFailShortName()
        {
            Player player = new Player("Lo", 20);
            string expectedName = "Unknown";
            Assert.AreEqual(expectedName, player.Name);
        }

        /// <summary>
        /// Testing instances of player with less than possible mistake value
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerTestFailMistakesNegativeNum()
        {
            Player player = new Player("Gosho", -2);
        }

        /// <summary>
        /// Testing instances of player with more than possible mistake value
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PlayerTestFailBigNumberOfMisakes()
        {
            Player player = new Player("Gosho", int.MaxValue);
        }
    }
}