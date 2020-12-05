using System;
using AdventOfCode.Classes;
using AdventOfCode.Classes.Services;
using AdventOfCode.Day1.Services;

namespace AdventOfCode.Day1
{
    class Program : AdventOfCodeProgram
    {
        private static ProblemSolverDayOne _problemSolver;
        public static int DayNum { get; } = 1;

        public static void Main(string[] args)
        {
            _problemSolver = new ProblemSolverDayOne();

            OutputWelcomeMessage(DayNum);

            OutputPartOne(_problemSolver);
            OutputPartTwo(_problemSolver);

            OutputGoodbyeMessage();
        }
    }
}
