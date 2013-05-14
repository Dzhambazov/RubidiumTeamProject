using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HangMan
{
    public static class ScoreBoard
    {
        private static  List<KeyValuePair<string, int>> allRecords = new List<KeyValuePair<string, int>>();

        #region Public methods

        /// <summary>
        /// Add record to list
        /// </summary>
        /// <param name="player">An instance of Player</param>
        public static void AddScore(Player player)
        {
            if (!IsPlayerAndScoreExist(player))
            {
                using (StreamWriter writer = new StreamWriter(@"..\..\external files\Records.txt", true))
                {
                    writer.WriteLine("{0} - {1}", player.Name, player.Mistakes);
                    writer.Close();
                }
                SortRecordsInFile();
            }
        }

        /// <summary>
        /// Print top 10 (if 10 records exist or less) on the console
        /// </summary>
        public static void PrintTopRecords()
        {
            GetAllRecords();
            int recordsLength = 10;
            if (allRecords.Count() < 10)
            {
                recordsLength = allRecords.Count();
            }

            for (int i = 0; i < recordsLength; i++)
            {
                Console.WriteLine("{0} - {1}", allRecords[i].Key, allRecords[i].Value);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Checks if the player have had same result before
        /// </summary>
        /// <param name="player">An instance of Player</param>
        /// <returns>True if exists and false if not</returns>
        private static bool IsPlayerAndScoreExist(Player player)
        {
            using (StreamReader reader = new StreamReader(@"..\..\external files\Records.txt", true))
            {
                string allRecordsStr = reader.ReadToEnd();
                string[] lines = allRecordsStr.Split('\r');
                foreach (var line in lines)
                {
                    string playerStr = player.Name+" - "+player.Mistakes;
                    if (line.Trim() == playerStr)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Gets all records from txt file and push em all to List
        /// </summary>
        private static void GetAllRecords()
        {
            allRecords.Clear();
            using (StreamReader reader = new StreamReader(@"..\..\external files\Records.txt", true))
            {
                string allRecordsStr = reader.ReadToEnd();
                string[] lines = allRecordsStr.Split('\r');
                foreach (var line in lines)
                {
                    if (!String.IsNullOrEmpty(line.Trim()))
                    {
                        string[] record = line.Trim().Split(new string[] { " - " }, StringSplitOptions.None);
                        string name = record[0].Trim();
                        int mistakes = int.Parse(record[1].Trim());
                        allRecords.Add(new KeyValuePair<string, int>(name, mistakes));
                    }
                }
                reader.Close();
            }
        }

        /// <summary>
        /// Sort all records in List by result then by name
        /// </summary>
        private static void SortRecords()
        {
            GetAllRecords();
            var sortedRecords = from records in allRecords
                                orderby records.Value, records.Key
                                select records;

            List<KeyValuePair<string, int>> allSortedRecords = new List<KeyValuePair<string, int>>();
            foreach (var record in sortedRecords)
            {
                allSortedRecords.Add(new KeyValuePair<string, int>(record.Key, record.Value));
            }
            allRecords = allSortedRecords;
        }

        /// <summary>
        /// Sort all the records in the file
        /// </summary>
        private static void SortRecordsInFile()
        {
            SortRecords();
            using (StreamWriter writer = new StreamWriter(@"..\..\external files\Records.txt"))
            {
                foreach (var record in allRecords)
                {
                    writer.WriteLine("{0} - {1}",record.Key, record.Value);
                }
                writer.Close();
            }
        }

        #endregion

    }
}
