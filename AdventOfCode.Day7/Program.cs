using AdventOfCode.Classes;
using AdventOfCode.Classes.Services;
using AdventOfCode.Day7.Services;
using System;

namespace AdventOfCode.Day7
{
    class Program : AdventOfCodeProgram
    {
        private static ProblemSolverDaySeven _problemSolver;
        public static int DayNum { get; } = -1;

        static void Main(string[] args)
        {
            _problemSolver = new ProblemSolverDaySeven();

            OutputWelcomeMessage(DayNum);

            OutputPartOne(_problemSolver);
            OutputPartTwo(_problemSolver);

            OutputGoodbyeMessage();
        }
    }
}
