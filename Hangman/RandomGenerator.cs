using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangMan
{
    public static class RandomGenerator
    {
        public static readonly Random randomGenerator;
        static RandomGenerator()
        {
            randomGenerator = new Random();
        }
    }
}
