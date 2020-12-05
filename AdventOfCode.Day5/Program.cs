using AdventOfCode.Classes.Services;
using AdventOfCode.Day5.Services;

namespace AdventOfCode.Day5
{
    class Program : AdventOfCodeProgram
    {
        private static ProblemSolverDayFive _problemSolver;
        public static int DayNum { get; } = 5;

        static void Main(string[] args)
        {
            _problemSolver = new ProblemSolverDayFive();

            OutputWelcomeMessage(DayNum);

            OutputPartOne(_problemSolver);
            OutputPartTwo(_problemSolver);

            OutputGoodbyeMessage();
        }
    }
}
