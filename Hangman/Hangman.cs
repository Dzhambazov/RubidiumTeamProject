using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangMan
{

    /// <summary>
    /// Премахвам ненужните празни редове и добавям празни редове, където са нужни.
    /// Преименувам някой променливи с по-подходящи имена.(scoreBoard -> scoreBoardCurrentPosition, методите съм преименувал да започват с главна буква)
    /// </summary>
    class Hangman
    {

       ScoreBoardPosition[] scoreBoardCurrentPosition = new ScoreBoardPosition[5];
      // private string[] words = {"debugger"};
       private string[] words = {"computer", "programmer", "software", "debugger", "compiler", 
                                         "developer", "algorithm", "array", "method", "variable"};
        private string wordToGuess;
        private char[] playersWord;
        private bool cheated;
        int mistakes;
        int lettersLeft;

        public Hangman()
        {

        }
        
        /// <summary>
        /// Method for generating word, functionality extracted from the constructor
        /// </summary>
        private void GenerateWord()
        {
            int wordNumber = RandomGenerator.randomGenerator.Next(0, words.Count());
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

        public void Play()
        {
            Restart();
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

        //added get input method
        private static string GetInput()
        {
            Print.EnterLetterOrCommand();
            string input = Console.ReadLine();
            return input;
        }

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
                        Restart();
                        break;
                    }
                default:
                    {
                        Print.InvalidCommand();
                        break;
                    }
            }
        }

        public void PrintWord()
        {
            Print.WordIs();
            foreach (var letter in playersWord)
            {
                Console.Write(letter + " ");
            }
            Console.WriteLine();
        }

        // help bug fixed
        public void Help()
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

        public bool Guess(char letter)
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

        public void End()
        {
            Print.GuessedWord();
            if (!this.cheated)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (scoreBoardCurrentPosition[i].PlayerName == string.Empty ||
                        this.mistakes < scoreBoardCurrentPosition[i].MistakesCount)
                    {
                        Print.MadeAScoreboard();
                        string playerName = Console.ReadLine();

                        if (scoreBoardCurrentPosition[i].PlayerName == string.Empty)
                        {
                            scoreBoardCurrentPosition[i].PlayerName = playerName;
                            scoreBoardCurrentPosition[i].MistakesCount = this.mistakes;
                        }
                        else
                        {
                            scoreBoardCurrentPosition[4].PlayerName = playerName;
                            scoreBoardCurrentPosition[4].MistakesCount = this.mistakes;
                        }

                        Array.Sort(scoreBoardCurrentPosition);
                        break;
                    }
                }
            }
            else
            {
                Print.Cheated();
            }
            Restart();
        }

        public void ShowScoreboard()
        {
            Console.WriteLine();

            for (int i = 0; i < scoreBoardCurrentPosition.Length; i++)
            {
                if (scoreBoardCurrentPosition[i] != default(ScoreBoardPosition))
                {
                    Console.WriteLine("{0} --> {1} - {2} mistakes", i + 1, scoreBoardCurrentPosition[i].PlayerName, scoreBoardCurrentPosition[i].MistakesCount);
                }
            }

            Console.WriteLine();
        }

        public void Restart()
        {
            //get random word bug fixed
            GenerateWord();
            GeneratePlayersWord();

            this.cheated = false;
            this.mistakes = 0;
            this.lettersLeft = playersWord.Length;

            for (int i = 0; i < 5; i++)
            {
                scoreBoardCurrentPosition[i] = new ScoreBoardPosition(string.Empty, 999);
            }
        }
    }
}
