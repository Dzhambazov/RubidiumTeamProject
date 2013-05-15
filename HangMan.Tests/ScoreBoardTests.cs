using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
namespace HangMan.Tests
{
    [TestClass]
    public class ScoreBoardTests
    {
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
           
            Assert.AreEqual(recordsCountBefore, recordsCountAfter-1);

            StreamWriter writer = new StreamWriter(@"..\..\external files\Records.txt");
            writer.Write("");
            writer.Close();
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddScoreInvalidNullInputTest()
        {
            ScoreBoard.AddScore(null);
        }
        

    }
}
