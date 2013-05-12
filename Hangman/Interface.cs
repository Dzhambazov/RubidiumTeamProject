using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangMan
{
    /// <summary>
    /// Премахвам ненужните празни редове и добавям празни редове, където са нужни.
    /// </summary>
    class Interface
    {
        Random random = new Random();

        static void Main()
        {
            Hangman game = new Hangman();

            Console.WriteLine("Welcome to Hangman");
            PrintGameGuide();
            game.PrintWord();
            Console.Write("enter a letter or command: ");
            string input = Console.ReadLine();

            while (input != "exit")
            {
                if (input.Length == 1)
                {
                    bool wordGuessed = false;
                    wordGuessed = game.Guess(input[0]);

                    if (wordGuessed)
                    {
                        game.End();
                        game.Restart();
                    }
                }
                else
                {
                    switch (input)
                    {
                        case "top":
                            {
                                game.ShowScoreboard();
                                break;
                            }
                        case "help":
                            {
                                game.Help();
                                break;
                            }
                        case "restart":
                            {
                                game.Restart();
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("invalid command");
                                break;
                            }
                    }
                }

                PrintGameGuide();
                 
                game.PrintWord();
                Console.Write("enter a letter or command: ");
                input = Console.ReadLine();
            }
            Console.WriteLine("Goodby");
        }

        /// <summary>
        /// Generate a new method cause of code repeate
        /// </summary>
        public static void PrintGameGuide()
        {
            Console.WriteLine("Use 'top' to view the top scoreboard," +
                                  "'restart' to start a new game, \n'help' to cheat and 'exit' to quit the game.");
        }

    }
}
