using AdventOfCode.Classes;
using AdventOfCode.Classes.Services;
using AdventOfCode.Day11.Services;
using System;

namespace AdventOfCode.Day11
{
    class Program : AdventOfCodeProgram
    {
        private static ProblemSolverDay11 _problemSolver;
        public static int DayNum { get; } = 11;

        static void Main(string[] args)
        {
            _problemSolver = new ProblemSolverDay11();

            OutputWelcomeMessage(DayNum);

            OutputPartOne(_problemSolver);
            OutputPartTwo(_problemSolver);

            OutputGoodbyeMessage();
        }
    }
}
