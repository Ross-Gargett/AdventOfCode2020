using AdventOfCode.Classes;
using AdventOfCode.Classes.Services;
using AdventOfCode.Day14.Services;
using System;

namespace AdventOfCode.Day14
{
    class Program : AdventOfCodeProgram
    {
        private static ProblemSolverDay14 _problemSolver;
        public static int DayNum { get; } = 14;

        static void Main(string[] args)
        {
            _problemSolver = new ProblemSolverDay14();

            OutputWelcomeMessage(DayNum);

            OutputPartOne(_problemSolver);
            OutputPartTwo(_problemSolver);

            OutputGoodbyeMessage();
        }
    }
}
