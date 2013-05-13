using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangMan
{
    public class Player:IPlayer
    {
        private string name;
        private int mistakes;

        public Player(string name, int mistakes)
        {
            this.Name = name;
            this.Mistakes = mistakes;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
            }
        }

        public int Mistakes
        {
            get { return this.mistakes; }
            set
            {
                this.mistakes = value;
            }
        }
    }
}
