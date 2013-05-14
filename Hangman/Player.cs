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
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Length > 2)
                    {
                        this.name = value;
                    }
                    else
                    {
                        throw new ArgumentException("Name should be at least 3 symbols long ");
                    }
                }
                else
                {
                    throw new ArgumentNullException("Name cannot be null or empty");
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
                if (value <= 0)
                {
                    throw new ArgumentException("Mistakes cannot be a negative number !");                    
                }

                this.mistakes = value;
            }
        }
    }
}