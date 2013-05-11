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
    class Besenka
    {
        static ScoreBoardPosition[] scoreBoardCurrentPosition = new ScoreBoardPosition[5];
        static private Random random = new Random();
        static private string[] words = {"computer", "programmer", "software", "debugger", "compiler", 
                                         "developer", "algorithm", "array", "method", "variable"};
        private string currentWord;
        private char[] playersWord;
        private bool cheated;

        int mistakes;
        int lettersLeft;

        public Besenka()
        {
            int wordNumber = random.Next(0, 10);

            this.currentWord = words[wordNumber];
            this.playersWord = new char[currentWord.Length];

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

        public void Help()
        {
            int toBeRevealed = Array.IndexOf(playersWord, '_');
            playersWord[toBeRevealed] = currentWord[toBeRevealed];

            this.cheated = true;
        }

        public bool Guess(char letter)
        {
            int guessed = 0;

            for (int i = 0; i < currentWord.Length; i++)
            {
                if (currentWord[i] == letter && playersWord[i] == '_')
                {
                    guessed++;
                    playersWord[i] = letter;
                }
            }

            if (guessed > 0)
            {
                this.lettersLeft = this.lettersLeft - guessed;

                Console.WriteLine("you guessed {0} letters", guessed);

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

        public void End()
        {
            Console.WriteLine("Congratulations! You guessed the word");

            if (this.cheated == false)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (scoreBoardCurrentPosition[i].Name == string.Empty ||
                        this.mistakes < scoreBoardCurrentPosition[i].Mistakes)
                    {
                        Console.WriteLine("Congratulations! You made the scoreboard");
                        Console.Write("Enter your name: ");

                        string playersName = Console.ReadLine();

                        if (scoreBoardCurrentPosition[i].Name == string.Empty)
                        {
                            scoreBoardCurrentPosition[i].Name = playersName;
                            scoreBoardCurrentPosition[i].Mistakes = this.mistakes;
                        }
                        else
                        {
                            scoreBoardCurrentPosition[4].Name = playersName;
                            scoreBoardCurrentPosition[4].Mistakes = this.mistakes;
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
                    Console.WriteLine("{0} --> {1} - {2} mistakes", i + 1, scoreBoardCurrentPosition[i].Name, scoreBoardCurrentPosition[i].Mistakes);
                }
            }

            Console.WriteLine();
        }

        public void Restart()
        {
            int wordNumber = random.Next(0, 11);

            this.currentWord = words[wordNumber];
            this.playersWord = new char[currentWord.Length];

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
