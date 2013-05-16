namespace HangMan
{
    using System;

    public class Player : IPlayer
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
            get
            {
                return this.name;
            }

            private set
            {
                if (value == null)
                {
                    this.name = "Player";
                }
                else if (value.Length > 2)
                {
                    this.name = value;
                }
                else
                {
                    this.name = "Player";
                }
            }
        }

        public int Mistakes
        {
            get
            {
                return this.mistakes; 
            }

            set
            {
                if (value != null)
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Mistakes cannot be a negative number !");
                    }
                    else
                    {
                        this.mistakes = value;
                    }
                }
                else
                {
                    throw new ArgumentNullException("Mistakes count cannot be null.");
                }
            }
        }
    }
}