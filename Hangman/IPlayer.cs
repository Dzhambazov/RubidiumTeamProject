//-----------------------------------------------------------------------
// <copyright file="IPlayer.cs" company="Telerik Academy">
//  Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// <author>Team "Rubidium"</author>
//-----------------------------------------------------------------------
namespace HangMan
{
    /// <summary>
    /// Interface for Player
    /// </summary>
    public interface IPlayer
    {
         string Name { get; }

         int Mistakes { get; }
    }
}