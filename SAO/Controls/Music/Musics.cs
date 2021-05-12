﻿
namespace SAO.Controls.Music
{
    /// <summary>
    /// The Musics.
    /// </summary>
    public enum Musics : uint
    {
        /// <summary>
        /// When the player signed up to the game for his first time.
        /// </summary>
        FirstGameEnterMusic = 0,
        /// <summary>
        /// When the player entering the church for his first time.
        /// </summary>
        FirstChurchMusic    = 1,
        /// <summary>
        /// Story of the past music for playing in the
        /// main menu (<see cref="MainForm"/>).
        /// </summary>
        StoryOfThePast      = 2,
        /// <summary>
        /// To The Grand Line Music, used for
        /// The first menu of the game. (<see cref="MainForm"/>)
        /// </summary>
        ToTheGrandLine      = 3,
    }
}