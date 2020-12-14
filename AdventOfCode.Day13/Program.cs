using AdventOfCode.Classes;
using AdventOfCode.Classes.Services;
using AdventOfCode.Day13.Services;
using System;

namespace AdventOfCode.Day13
{
    class Program : AdventOfCodeProgram
    {
        private static ProblemSolverDay13 _problemSolver;
        public static int DayNum { get; } = 13;

        static void Main(string[] args)
        {
            _problemSolver = new ProblemSolverDay13();

            OutputWelcomeMessage(DayNum);

            OutputPartOne(_problemSolver);
            OutputPartTwo(_problemSolver);

            OutputGoodbyeMessage();
        }
    }
}
