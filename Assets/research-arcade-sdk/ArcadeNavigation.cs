using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ResearchArcade
{
    /// <summary>
    /// A class dealing with navigation methods for the research arcade, such as exiting a game.
    /// </summary>
    public class Navigation
    {
        private const string RESEARCH_ARCADE_REDIRECT_URL = @"https://lncn.ac/rarcade";

        /// <summary>
        /// Returns the game to the main menu of the Research Arcade.
        /// </summary>
        public static void ExitGame()
        {
            //Open the URL
            Application.OpenURL(RESEARCH_ARCADE_REDIRECT_URL);

            //As a fallback, somehow, if this is running in desktop mode
            Application.Quit(-1);
        }
    }
}