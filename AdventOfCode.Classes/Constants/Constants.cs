using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Classes
{
    public static class Constants
    {
        #region Progress string

        public const string WelcomeMessage = "Welcome to the solution for Advent of Code Day {0}\n" +
                                             "--------------------------------------------------\n",
                            SolvingMessage = "Now solving part {0}...\n",
                            GoodbyeMessage = "Press ENTER to close the program...";


        #endregion

        #region Error Messages

        public const string NoSolutionError = "No Valid Solution for {0}! :(\n\n";

        #endregion
    }
}
