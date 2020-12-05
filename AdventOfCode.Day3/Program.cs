using AdventOfCode.Classes.Services;
using AdventOfCode.Day3.Services;

namespace AdventOfCode.Day3
{
    class Program : AdventOfCodeProgram
    {
        private static ProblemSolverDayThree _problemSolver;
        public static int DayNum { get; } = 3;

        static void Main(string[] args)
        {
            _problemSolver = new ProblemSolverDayThree();

            OutputWelcomeMessage(DayNum);

            OutputPartOne(_problemSolver);
            OutputPartTwo(_problemSolver);

            OutputGoodbyeMessage();
        }
    }
}
