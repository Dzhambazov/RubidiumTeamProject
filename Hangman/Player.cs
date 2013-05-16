//-----------------------------------------------------------------------
// <copyright file="Player.cs" company="Telerik Academy">
//  Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// <author>Team "Rubidium"</author>
//-----------------------------------------------------------------------
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
                    this.name = "Unknown";
                }
                else if (value.Length > 2)
                {
                    this.name = value;
                }
                else
                {
                    this.name = "Unknown";
                }
            }
        }

        public int Mistakes
        {
            get
            {
                return this.mistakes;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Mistakes cannot be a negative number!");
                }
                if (value >= int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("Mistakes cannot be a so big number!");
                }
                else
                {
                    this.mistakes = value;
                }
            }
        }
    }
}