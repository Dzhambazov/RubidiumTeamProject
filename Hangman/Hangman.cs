namespace HangMan
{
    using System;
    using System.IO;
    using System.Linq;

    class Hangman
    {
        private string[] words;
        private string wordToGuess;
        private char[] playersWord;
        private bool cheated;
        private int mistakes;
        private int lettersLeft;

        public Hangman()
        {

        }

        /// <summary>
        /// Gets words from words.txt and push em all to array words
        /// </summary>
        public void GetWordsFromFile()
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

#region public methods

        /// <summary>
        /// Game Engine that calls all the methods it needs
        /// </summary>
        public void Play()
        {
            GetWordsFromFile();
            InitialiseNewGame();
            Print.Welcome();
            Print.GameGuide();
            PrintWord();
            string input = GetInput();

            while (input != "exit")
            {
                CheckInput(input);
                Print.GameGuide();
                PrintWord();
                input = GetInput();
            }
            Print.GoodBye();
        }

#endregion

#region Private methods

        #region Initialise

        private void InitialiseNewGame()
        {
            //get random word bug fixed
            GenerateWord();
            GeneratePlayersWord();

            this.cheated = false;
            this.mistakes = 0;
            this.lettersLeft = playersWord.Length;
        }

        /// <summary>
        /// Method for generating word, functionality extracted from the constructor
        /// </summary>
        private void GenerateWord()
        {
            int wordNumber = RandomGenerator.Generator.Next(0, words.Count());
            this.wordToGuess = words[wordNumber];
        }

        /// <summary>
        /// Method for generating players word, functionality extracted from the constructor
        /// </summary>
        private void GeneratePlayersWord()
        {
            this.playersWord = new char[wordToGuess.Length];

            for (int i = 0; i < playersWord.Length; i++)
            {
                playersWord[i] = '_';
            }
        }

    #endregion


        #region CheckInput

        /// <summary>
        /// check for letter in searched word and execute commands
        /// </summary>
        /// <param name="input">Get input from console representing letter to check or execute command</param>
        private void CheckInput(string input)
        {
            if (input.Length == 1)
            {
                bool wordGuessed = false;
                wordGuessed = Guess(input[0]);

                if (wordGuessed)
                {
                    End();
                }
            }
            else
            {
                ExecuteCommand(input);
            }
        }

        /// <summary>
        /// Prints what the player should do and gets player's input
        /// </summary>
        /// <returns>String representing player's input</returns>
        private static string GetInput()
        {
            Print.EnterLetterOrCommand();
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
                case "top":
                    {
                        ShowScoreboard();
                        break;
                    }
                case "help":
                    {
                        Help();
                        break;
                    }
                case "restart":
                    {
                        InitialiseNewGame();
                        break;
                    }
                case "addword":
                    {
                        AddWord();
                        break;
                    }
                default:
                    {
                        Print.InvalidCommand();
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
            guessedLettersCount += CharsGuessed(letter);

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
                Print.LetterNotFound();
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
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (wordToGuess[i] == letter && playersWord[i] == '_')
                {
                    playersWord[i] = letter;
                    counter++;
                }
            }
            return counter;
        }

    #endregion  

        private void AddWord()
        {
            Print.AddWord();
            string word = Console.ReadLine();
            if (word != "")
            {
                if(word.Length > 4)
                {
                    using (StreamWriter writer = new StreamWriter(@"..\..\external files\Words.txt", true))
                    {
                        writer.WriteLine(word);
                    }
                }
            }
        }

        private void PrintWord()
        {
            Print.WordIs();
            foreach (var letter in playersWord)
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
            int toBeRevealed = Array.IndexOf(playersWord, '_');
            playersWord[toBeRevealed] = wordToGuess[toBeRevealed];
            this.cheated = true;
            this.lettersLeft--;
            if (this.lettersLeft == 0)
            {
                End();
            }
        }

        /// <summary>
        /// Call this method if the word is guessed
        /// Checks if the player have cheated
        /// Calls ScoreBoard methods
        /// Reset initialise of all fields
        /// </summary>
        private void End()
        {
            Print.GuessedWord();
            if (!this.cheated)
            {
                Print.MadeAScoreboard();
                string playerName = Console.ReadLine();
                Player player = new Player(playerName, mistakes);
                ScoreBoard.AddScore(player);
            }
            else
            {
                Print.Cheated();
            }
            InitialiseNewGame();
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