//-----------------------------------------------------------------------
// <copyright file="ScoreBoardTests.cs" company="Telerik Academy">
//  Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// <author>Team "Rubidium"</author>
//-----------------------------------------------------------------------
namespace HangMan.Tests
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    /// <summary>
    /// Test class for testing ScoreBoard class methods
    /// </summary>
    [TestClass]
    public class ScoreBoardTests
    {
        /// <summary>
        /// Testing adding score records
        /// </summary>
        [TestMethod]
        public void ScoreBoardTestAddScoreRecordsCount()
        {
            StreamReader reader = new StreamReader(@"..\..\external files\Records.txt", true);
            string allRecordsStr = reader.ReadToEnd();
            string[] allRecordsArr = allRecordsStr.Split('\r');
            int recordsCountBefore = allRecordsArr.Length;
            reader.Close();
             
            Player player = new Player("testPlayer", 999);
            ScoreBoard.AddScore(player);

            reader = new StreamReader(@"..\..\external files\Records.txt", true);
            allRecordsStr = reader.ReadToEnd();
            allRecordsArr = allRecordsStr.Split('\r');
            int recordsCountAfter = allRecordsArr.Length;
            reader.Close();
           
            Assert.AreEqual(recordsCountBefore, recordsCountAfter - 1);

            StreamWriter writer = new StreamWriter(@"..\..\external files\Records.txt");
            writer.Write(string.Empty);
            writer.Close();
        }
        
        /// <summary>
        /// Testing adding null score record
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddScoreInvalidNullInputTest()
        {
            ScoreBoard.AddScore(null);
        }   
    }
}