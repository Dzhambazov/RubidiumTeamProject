namespace HangMan
{
    using System;

    public static class Print
    {
        public static void GameGuide()
        {
            Console.WriteLine(new string('-', 20) + Environment.NewLine + "Game commands:" + 
                Environment.NewLine + new string('-', 79));
            Console.WriteLine("Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' to" +
                "\ncheat, 'addword' to add new word in game generator and 'exit' to quit the game." + 
                Environment.NewLine + new string('-', 79));
        }

        public static void Welcome()
        {
            Console.WriteLine("Welcome to Hangman");
        }

        public static void GoodBye()
        {
            Console.WriteLine("GoodBye");
        }

        public static void EnterLetterOrCommand()
        {
            Console.Write("Enter letter or command: ");
        }

        public static void InvalidCommand()
        {
            Console.WriteLine("Invalid Command!");
        }

        public static void WordIs()
        {
            Console.WriteLine();
            Console.Write("The secret word is:");
        }

        public static void GuessedWord()
        {
            Console.WriteLine("Congratulations! You guessed the word");
        }

        public static void MadeAScoreboard()
        {
            Console.WriteLine("Congratulations! You made the scoreboard");
            Console.Write("Enter your name: ");
        }
        public static void Cheated()
        {
            Console.WriteLine("You cheated !!!");
        }

        public static void LetterNotFound()
        {
            Console.WriteLine("Letter Not Found");
        }

        public static void AddWord()
        {
            Console.Write("Please enter your word: ");
        }
    }
}
