using AdventOfCode.Classes;
using AdventOfCode.Classes.Services;
using AdventOfCode.Day15.Services;
using System;

namespace AdventOfCode.Day15
{
    class Program : AdventOfCodeProgram
    {
        private static ProblemSolverDay15 _problemSolver;
        public static int DayNum { get; } = 15;

        static void Main(string[] args)
        {
            _problemSolver = new ProblemSolverDay15();

            OutputWelcomeMessage(DayNum);

            OutputPartOne(_problemSolver);
            OutputPartTwo(_problemSolver);

            OutputGoodbyeMessage();
        }
    }
}
