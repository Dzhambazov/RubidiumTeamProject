namespace HangMan
{
    using System;

    public static class Print
    {

        public static void Writer(string str)
        {
            Console.WriteLine(str);
        }

        public static void GameGuideMessage()
        {
            Console.WriteLine(new string('-', 20) + Environment.NewLine + "Game commands:" + 
                Environment.NewLine + new string('-', 79));
            Console.WriteLine("Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' to" +
                "\ncheat, 'addword' to add new word in game generator and 'exit' to quit the game." + 
                Environment.NewLine + new string('-', 79));
        }

        public static string WelcomeMessage()
        {
            string message = "Welcome to Hangman";
            return message;
        }

        public static string GoodByeMessage()
        {
            string message= "GoodBye";
            return message;
        }

        public static string EnterLetterOrCommandMessage()
        {
            string message = "Enter letter or command: ";
            return message;
        }

        public static string InvalidCommandMessage()
        {
            string message = "Invalid Command!";
            return message;
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
