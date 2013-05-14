namespace HangMan
{
    using System;

    public static class RandomGenerator
    {
        public static readonly Random Generator;
        static RandomGenerator()
        {
            Generator = new Random();
        }
    }
}