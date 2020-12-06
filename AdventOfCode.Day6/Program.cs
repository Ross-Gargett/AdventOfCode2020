using AdventOfCode.Classes;
using AdventOfCode.Classes.Services;
using AdventOfCode.Day6.Services;
using System;

namespace AdventOfCode.Day6
{
    class Program : AdventOfCodeProgram
    {
        private static ProblemSolverDaySix _problemSolver;
        public static int DayNum { get; } = 6;

        static void Main(string[] args)
        {
            _problemSolver = new ProblemSolverDaySix();

            OutputWelcomeMessage(DayNum);

            OutputPartOne(_problemSolver);
            OutputPartTwo(_problemSolver);

            OutputGoodbyeMessage();
        }
    }
}
