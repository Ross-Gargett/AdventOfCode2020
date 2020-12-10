using AdventOfCode.Classes;
using AdventOfCode.Classes.Services;
using AdventOfCode.Day10.Services;
using System;

namespace AdventOfCode.Day10
{
    class Program : AdventOfCodeProgram
    {
        private static ProblemSolverDay10 _problemSolver;
        public static int DayNum { get; } = 10;

        static void Main(string[] args)
        {
            _problemSolver = new ProblemSolverDay10();

            OutputWelcomeMessage(DayNum);

            OutputPartOne(_problemSolver);
            OutputPartTwo(_problemSolver);

            OutputGoodbyeMessage();
        }
    }
}
