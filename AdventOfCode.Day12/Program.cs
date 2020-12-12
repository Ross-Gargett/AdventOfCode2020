using AdventOfCode.Classes;
using AdventOfCode.Classes.Services;
using AdventOfCode.Day12.Services;
using System;

namespace AdventOfCode.Day12
{
    class Program : AdventOfCodeProgram
    {
        private static ProblemSolverDay12 _problemSolver;
        public static int DayNum { get; } = 12;

        static void Main(string[] args)
        {
            _problemSolver = new ProblemSolverDay12();

            OutputWelcomeMessage(DayNum);

            OutputPartOne(_problemSolver);
            OutputPartTwo(_problemSolver);

            OutputGoodbyeMessage();
        }
    }
}
