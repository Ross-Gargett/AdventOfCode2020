using AdventOfCode.Classes;
using AdventOfCode.Classes.Services;
using AdventOfCode.Day8.Services;
using System;

namespace AdventOfCode.Day8
{
    class Program : AdventOfCodeProgram
    {
        private static ProblemSolverDayEight _problemSolver;
        public static int DayNum { get; } = 8;

        static void Main(string[] args)
        {
            _problemSolver = new ProblemSolverDayEight();

            OutputWelcomeMessage(DayNum);

            OutputPartOne(_problemSolver);
            OutputPartTwo(_problemSolver);

            OutputGoodbyeMessage();
        }
    }
}
