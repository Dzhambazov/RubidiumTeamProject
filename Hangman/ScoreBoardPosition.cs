using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangMan
{
    class ScoreBoardPosition : IComparable<ScoreBoardPosition>
    {
        /// <summary>
        /// Премахвам ненужните празни редове и добавям празни редове, където са нужни.
        /// </summary>
        private string playerName;
        private int mistakesCount;

        public ScoreBoardPosition(string name, int mistakes)
        {
            this.playerName = name;
            this.mistakesCount = mistakes;
        }

        public string PlayerName
        {
            get
            {
                return playerName;
            }

            set
            {
                if (value != null || value != "")
                {
                    this.playerName = value;
                }
                else
                {
                    throw new ArgumentException("Player name cannot be null or empty string!");
                }
            }
        }

        public int MistakesCount
        {
            get
            {
                return mistakesCount;
            }

            set
            {
                if (value >= 0)
                {
                    this.mistakesCount = value;
                }
                else
                {
                    throw new ArgumentException("Mistakes count cannot be a negative number !");
                }
            }
        }

        // мисля, че е ненужно - задължително трябва да има име и точки !
        //public ScoreBoardPosition()
        //    : this(string.Empty, 0)
        //{

        //}

        public int CompareTo(ScoreBoardPosition other)
        {
            return this.MistakesCount.CompareTo(other.MistakesCount);
        }
    }
}
