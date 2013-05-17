namespace HangMan
{
    using System;

    public static class Print
    {
        public static void GameGuideMessage()
        {
            Console.WriteLine(new string('-', 20) + Environment.NewLine + "Game commands:" + 
                Environment.NewLine + new string('-', 79));
            Console.WriteLine("Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' to" +
                "\ncheat, 'addword' to add new word in game generator and 'exit' to quit the game." + 
                Environment.NewLine + new string('-', 79));
        }

        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Hangman");
        }

        public static void GoodByeMessage()
        {
            Console.WriteLine("GoodBye");
        }

        public static void EnterLetterOrCommandMessage()
        {
            Console.Write("Enter letter or command: ");
        }

        public static void InvalidCommandMessage()
        {
            Console.WriteLine("Invalid Command!");
        }

        public static void WordIsMessage()
        {
            Console.WriteLine();
            Console.Write("The secret word is:");
        }

        public static void GuessedWordMessage()
        {
            Console.WriteLine("Congratulations! You guessed the word");
        }

        public static void MadeAScoreboardMessage()
        {
            Console.WriteLine("Congratulations! You made the scoreboard");
            Console.Write("Enter your name: ");
        }

        public static void CheatedMessage()
        {
            Console.WriteLine("You cheated !!!");
        }

        public static void LetterNotFoundMessage()
        {
            Console.WriteLine("Invalid symbol. Please type only latin letters.");
        }

        public static void AddWordMessage()
        {
            Console.Write("Please enter your word: ");
        }
    }
}
