using AdventOfCode.Classes;
using AdventOfCode.Classes.Services;
using AdventOfCode.Day2.Services;
using System;

namespace AdventOfCode.Day2
{
    class Program : AdventOfCodeProgram
    {
        private static ProblemSolverDayTwo _problemSolver;
        public static int DayNum { get; } = 2;

        static void Main(string[] args)
        {
            _problemSolver = new ProblemSolverDayTwo();

            OutputWelcomeMessage(DayNum);

            OutputPartOne(_problemSolver);
            OutputPartTwo(_problemSolver);

            OutputGoodbyeMessage();
        }
    }
}
