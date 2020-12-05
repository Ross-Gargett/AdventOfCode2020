using System;

namespace AdventOfCode.Classes.Services
{
    public class AdventOfCodeProgram
    {
        public static void OutputWelcomeMessage(int dayNum)
        {
            Console.WriteLine(String.Format(Constants.WelcomeMessage, dayNum));
        }

        public static void OutputGoodbyeMessage()
        {
            Console.WriteLine(String.Format(Constants.GoodbyeMessage));
            Console.ReadLine();
        }

        public static void OutputPartOne<T>(IProblemSolver<T> problemSolver)
        {
            try
            {
                Console.WriteLine(String.Format(Constants.SolvingMessage, "Part 1"));
                problemSolver.SolvePartOne();
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format(Constants.NoSolutionError, "Part 1"));
            }
        }

        public static void OutputPartTwo<T>(IProblemSolver<T> problemSolver)
        {
            try
            {
                Console.WriteLine(String.Format(Constants.SolvingMessage, "Part 2"));
                problemSolver.SolvePartTwo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format(Constants.NoSolutionError, "Part 2"));
            }
        }
    }
}
