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

            OutputPartOne();
            OutputPartTwo();

            OutputGoodbyeMessage();
        }

        private static void OutputPartOne()
        {
            try
            {
                Console.WriteLine(String.Format(Constants.SolvingMessage, "Part 1"));
                _problemSolver.SolvePartOne();
            }
            catch (Exception)
            {
                Console.WriteLine(String.Format(Constants.NoSolutionError, "Part 1"));
            }
        }

        private static void OutputPartTwo()
        {
            try
            {
                Console.WriteLine(String.Format(Constants.SolvingMessage, "Part 2"));
                _problemSolver.SolvePartTwo();
            }
            catch (Exception)
            {
                Console.WriteLine(String.Format(Constants.NoSolutionError, "Part 2"));
            }
        }
    }
}
