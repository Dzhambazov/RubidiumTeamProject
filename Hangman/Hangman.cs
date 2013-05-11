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
       private Random random = new Random();
       private string[] words = {"computer", "programmer", "software", "debugger", "compiler", 
                                         "developer", "algorithm", "array", "method", "variable"};
        private string wordToGuess;
        private char[] playersWord;
        private bool cheated;
        int mistakes;
        int lettersLeft;

        public Hangman()
        {
            //get random word bug fixed
            int wordNumber = random.Next(0, words.Count());

            this.wordToGuess = words[wordNumber];
            this.playersWord = new char[wordToGuess.Length];

            for (int i = 0; i < playersWord.Length; i++)
            {
                playersWord[i] = '_';
            }

            this.cheated = false;
            this.mistakes = 0;
            this.lettersLeft = playersWord.Length;

            for (int i = 0; i < 5; i++)
            {
                scoreBoardCurrentPosition[i] = new ScoreBoardPosition(string.Empty, 999);
            }
        }

        public void PrintWord()
        {
            Console.WriteLine();
            Console.Write("The secret word is:");

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
        }

        public bool Guess(char letter)
        {
            int guessedLettersCount = 0;

            if (IsCharGuessed(letter))
            {
                guessedLettersCount++;
            }

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
                Console.WriteLine("letter not found");
                this.mistakes++;
            }

            return false;
        }

        /// <summary>
        /// Checks if the secred word contains the character we guessed
        /// </summary>
        /// <param name="letter">Character represented our guess letter</param>
        /// <returns>Returns true if character has been fond in the word on blank space</returns>
        private bool IsCharGuessed(char letter)
        {
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (wordToGuess[i] == letter && playersWord[i] == '_')
                {
                    playersWord[i] = letter;
                    return true;
                }
            }
            return false;
        }

        public void End()
        {
            Console.WriteLine("Congratulations! You guessed the word");

            if (!this.cheated)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (scoreBoardCurrentPosition[i].PlayerName == string.Empty ||
                        this.mistakes < scoreBoardCurrentPosition[i].MistakesCount)
                    {
                        Console.WriteLine("Congratulations! You made the scoreboard");
                        Console.Write("Enter your name: ");

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
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("You cheated");
            }
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
            int wordNumber = random.Next(0, words.Count());

            this.wordToGuess = words[wordNumber];
            this.playersWord = new char[wordToGuess.Length];

            for (int i = 0; i < playersWord.Length; i++)
            {
                playersWord[i] = '_';
            }

            this.cheated = false;
            this.mistakes = 0;
            this.lettersLeft = playersWord.Length;
        }
    }
}
