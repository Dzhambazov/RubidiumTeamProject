//-----------------------------------------------------------------------
// <copyright file="RandomGenerator.cs" company="Telerik Academy">
//  Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// <author>Team "Rubidium"</author>
//-----------------------------------------------------------------------
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