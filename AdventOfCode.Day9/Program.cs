using AdventOfCode.Classes.Services;
using AdventOfCode.Day9.Services;

namespace AdventOfCode.Day9
{
    class Program : AdventOfCodeProgram
    {
        private static ProblemSolverDay9 _problemSolver;
        public static int DayNum { get; } = 9;

        static void Main(string[] args)
        {
            _problemSolver = new ProblemSolverDay9();

            OutputWelcomeMessage(DayNum);

            OutputPartOne(_problemSolver);
            OutputPartTwo(_problemSolver);

            OutputGoodbyeMessage();
        }
    }
}
