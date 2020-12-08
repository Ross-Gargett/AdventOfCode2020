using AdventOfCode.Classes;
using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day8.Services
{
    class ProblemSolverDayEight : IProblemSolver<string>
    {
        public IEnumerable<string> InputLines { get; set; }

        public void ReadInputFile()
        {
            InputLines = File.ReadAllLines("Input.txt");
        }

        public void SolvePartOne()
        {
            ReadInputFile();

            var bootService = new BootService(InputLines);

            var accumulatorWhenLoopOccurs = bootService.FindAccumulatorForInfiniteLoop();
            Console.WriteLine(string.Format(DayEightConstants.DayEightPartOneAnswer,
                accumulatorWhenLoopOccurs));
        }

        public void SolvePartTwo()
        {
            ReadInputFile();

            var bootService = new BootService(InputLines);

            var accumulatorUponTermination = bootService.FindAndRepairInfiniteLoop();
            Console.WriteLine(string.Format(DayEightConstants.DayEightPartTwoAnswer,
                accumulatorUponTermination));
        }
    }
}
