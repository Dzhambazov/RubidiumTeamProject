//-----------------------------------------------------------------------
// <copyright file="Hangman.cs" company="Telerik Academy">
//  Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// <author>Team "Rubidium"</author>
//-----------------------------------------------------------------------
namespace HangMan
{
    using System;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Includes engine for the game Hangman
    /// </summary>
    public class Hangman
    {


        const string Top = "top";
        const string Hint = "help";
        const string Restart = "restart";
        const string Addword = "addword";

        #region Fields
        /// <summary>
        /// An array containing all the words in the game Hangman
        /// </summary>
        private string[] words;

        /// <summary>
        /// Represent the current word on the playing field
        /// </summary>
        private string wordToGuess;

        /// <summary>
        /// Represent the players trys to guess the word on the playing field
        /// </summary>
        private char[] playersWord;

        /// <summary>
        /// Represent if the player was try to cheat
        /// </summary>
        private bool cheated;

        /// <summary>
        /// Represents the number of player mistakes
        /// </summary>
        private int mistakes;

        /// <summary>
        /// Represents remaining letter to be guessed
        /// </summary>
        private int lettersLeft;
        #endregion

        public Hangman()
        {
        }


        #region public methods

        /// <summary>
        /// Game Engine that calls all the methods it needs
        /// </summary>
        public void Play()
        {
            this.GetWordsFromFile();
            this.InitialiseNewGame();
            Print.Writer(Print.WelcomeMessage());
            Print.GameGuideMessage();
            this.PrintWord();
            string input = this.GetInput();

            while (input != "exit")
            {
                this.CheckInput(input);
                Print.GameGuideMessage();
                this.PrintWord();
                input = this.GetInput();
            }
            Print.Writer(Print.GoodByeMessage());
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Gets words from words.txt and push them all to array words
        /// </summary>
        private void GetWordsFromFile()
        {
            using (StreamReader reader = new StreamReader(@"..\..\external files\Words.txt", true))
            {
                string words = reader.ReadToEnd().Trim();
                this.words = words.Split('\r');
            }

            for (int i = 0; i < this.words.Length; i++)
            {
                this.words[i] = this.words[i].Trim();
            }
        }

        #region Initialise
        /// <summary>
        /// Initialise new game, by setting everything at default state.
        /// </summary>
        private void InitialiseNewGame()
        {
            Console.Clear();
            this.GenerateWord();
            this.GeneratePlayersWord();

            this.cheated = false;
            this.mistakes = 0;
            this.lettersLeft = this.playersWord.Length;
        }

        /// <summary>
        /// Method for generating word, functionality extracted from the constructor
        /// </summary>
        private void GenerateWord()
        {
            int wordNumber = RandomGenerator.Generator.Next(0, this.words.Count());
            this.wordToGuess = this.words[wordNumber];
        }

        /// <summary>
        /// Method for generating players word, functionality extracted from the constructor
        /// </summary>
        private void GeneratePlayersWord()
        {
            this.playersWord = new char[this.wordToGuess.Length];

            for (int i = 0; i < this.playersWord.Length; i++)
            {
                this.playersWord[i] = '_';
            }
        }

        #endregion

        #region CheckInput

        /// <summary>
        /// Check for letter in searched word and execute commands
        /// </summary>
        /// <param name="input">Get input from console representing letter to check or execute command</param>
        private void CheckInput(string input)
        {
            if (input.Length == 1)
            {
                bool wordGuessed = false;
                wordGuessed = this.Guess(input[0]);

                if (wordGuessed)
                {
                    this.End();
                }
            }
            else
            {
                this.ExecuteCommand(input);
            }
        }

        /// <summary>
        /// Prints what the player should do and gets player's input
        /// </summary>
        /// <returns>String representing player's input</returns>
        private string GetInput()
        {
            Print.Writer(Print.EnterLetterOrCommandMessage());
            string input = Console.ReadLine();
            return input;
        }

        /// <summary>
        /// Execute a command from the list or prints "Invalid command"
        /// </summary>
        /// <param name="input">String representing player's input</param>
        private void ExecuteCommand(string input)
        {
            switch (input)
            {
                case Top:
                    {
                        this.ShowScoreboard();
                        break;
                    }

                case Hint:
                    {
                        this.Help();
                        break;
                    }

                case Restart:
                    {
                        this.InitialiseNewGame();
                        break;
                    }

                case Addword:
                    {
                        this.AddWord();
                        break;
                    }

                default:
                    {
                        Print.Writer(Print.InvalidCommandMessage());
                        break;
                    }
            }
        }

        /// <summary>
        /// Checks if the word contains the letter that player guessed
        /// </summary>
        /// <param name="letter">Char representing the letter that player guess</param>
        /// <returns>Returns boolean value is the letter guessed</returns>
        private bool Guess(char letter)
        {
            int guessedLettersCount = 0;
            guessedLettersCount += this.CharsGuessed(letter);

            if (guessedLettersCount > 0)
            {
                this.lettersLeft -= guessedLettersCount;

                Console.WriteLine("you guessed {0} letters", guessedLettersCount);

                if (this.lettersLeft == 0)
                {
                    return true;
                }
            }
            else
            {
                Print.Writer(Print.LetterNotFoundMessage());
                this.mistakes++;
            }

            return false;
        }

        /// <summary>
        /// Checks if the secred word contains the character we guessed
        /// </summary>
        /// <param name="letter">Character represented our guess letter</param>
        /// <returns>Returns true if character has been fond in the word on blank space</returns>/
        /// bug fixed - before: show the first found letter only,  after: show all found letters
        private int CharsGuessed(char letter)
        {
            int counter = 0;
            for (int i = 0; i < this.wordToGuess.Length; i++)
            {
                if (this.wordToGuess[i] == letter && this.playersWord[i] == '_')
                {
                    this.playersWord[i] = letter;
                    counter++;
                }
            }

            return counter;
        }

        #endregion

        /// <summary>
        /// Add word by player choice in game word generator
        /// </summary>
        private void AddWord()
        {
            Print.Writer(Print.AddWordMessage());
            string word = Console.ReadLine();
            if (word != string.Empty)
            {
                if (word.Length > 4)
                {
                    using (StreamWriter writer = new StreamWriter(@"..\..\external files\Words.txt", true))
                    {
                        writer.WriteLine(word);
                    }
                }
            }
        }

        /// <summary>
        /// Print players trys to guess current word
        /// </summary>
        private void PrintWord()
        {
            Print.WordIsMessage();
            foreach (var letter in this.playersWord)
            {
                Console.Write(letter + " ");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Used as a hint in the game
        /// Can call End() method
        /// </summary>
        private void Help()
        {
            int toBeRevealed = Array.IndexOf(this.playersWord, '_');
            this.playersWord[toBeRevealed] = this.wordToGuess[toBeRevealed];
            this.cheated = true;
            this.lettersLeft--;
            if (this.lettersLeft == 0)
            {
                this.End();
            }
        }

        /// <summary>
        /// Call this method if the word is guessed
        /// Checks if the player have cheated
        /// Calls ScoreBoard methods
        /// Reset initialises of all fields
        /// </summary>
        private void End()
        {
            Print.GuessedWordMessage();
            Print.Writer(Print.GuessedWordMessage());
            if (!this.cheated)
            {
                Print.MadeAScoreboardMessage();
                string playerName = Console.ReadLine();
                Player player = new Player(playerName, this.mistakes);
                ScoreBoard.AddScore(player);
            }
            else
            {
                Print.CheatedMessage();
                Print.Writer(Print.CheatedMessage());
            }

            this.InitialiseNewGame();
        }

        /// <summary>
        /// Prints top players on the console
        /// </summary>
        private void ShowScoreboard()
        {
            ScoreBoard.PrintTopRecords();
        }

        #endregion
    }
}