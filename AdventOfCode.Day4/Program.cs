using AdventOfCode.Classes;
using AdventOfCode.Classes.Services;
using AdventOfCode.Day4.Services;
using System;

namespace AdventOfCode.Day4
{
    class Program : AdventOfCodeProgram
    {
        private static ProblemSolverDayFour _problemSolver;
        public static int DayNum { get; } = -1;

        static void Main(string[] args)
        {
            _problemSolver = new ProblemSolverDayFour();

            OutputWelcomeMessage(DayNum);

            OutputPartOne(_problemSolver);
            OutputPartTwo(_problemSolver);

            OutputGoodbyeMessage();
        }
    }
}
