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
    ///  Testing class for  methods functionality from Print class
    /// </summary>
    [TestClass]
    public class PrintTests
    {
        /// <summary>
        /// Testing methods functionality from Print class
        /// </summary>
        [TestMethod]
        public void PrintTestWelcomeMessage()
        {
            string stringFromMethod = Print.WelcomeMessage();
            string expected = "Welcome to Hangman";
            Assert.AreEqual(stringFromMethod, expected);
        }

        [TestMethod]
        public void PrintTestGoodbyeMessage()
        {
            string stringFromMethod = Print.GoodByeMessage();
            string expected = "GoodBye";
            Assert.AreEqual(stringFromMethod, expected);
        }


        [TestMethod]
        public void PrintTestEnterLetterOrCommandMessage()
        {
            string stringFromMethod = Print.EnterLetterOrCommandMessage();
            string expected = "Enter letter or command: ";
            Assert.AreEqual(stringFromMethod, expected);
        }

        [TestMethod]
        public void PrintTestGuessedWordMessage()
        {
            string stringFromMethod = Print.GuessedWordMessage();
            string expected = "Congratulations! You guessed the word!";
            Assert.AreEqual(stringFromMethod, expected);
        }


        [TestMethod]
        public void PrintTestInvalidCommandMessage()
        {
            string stringFromMethod = Print.InvalidCommandMessage();
            string expected = "Invalid Command!";
            Assert.AreEqual(stringFromMethod, expected);
        }

        [TestMethod]
        public void PrintTestCheatedMessage()
        {
            string stringFromMethod = Print.CheatedMessage();
            string expected = "You cheated !!!";
            Assert.AreEqual(stringFromMethod, expected);
        }

        [TestMethod]
        public void PrintTestLetterNotFoundMessage()
        {
            string stringFromMethod = Print.LetterNotFoundMessage();
            string expected = "Invalid symbol. Please type only latin letters.";
            Assert.AreEqual(stringFromMethod, expected);
        }

        [TestMethod]
        public void PrintTestAddWordMessage()
        {
            string stringFromMethod = Print.AddWordMessage();
            string expected = "Please enter your word: ";
            Assert.AreEqual(stringFromMethod, expected);
        }
        
    }
}