using AdventOfCode.Classes;
using System;
using System.Collections.Generic;
using AdventOfCode.Day15.Models;

namespace AdventOfCode.Day15.Services
{
    class ProblemSolverDay15 : IProblemSolver<int>
    {
        public IEnumerable<int> InputLines { get; set; }

        public void ReadInputFile()
        {
            InputLines = new List<int>() { 0, 14, 1, 3, 7, 9 };
        }

        public void SolvePartOne()
        {
            ReadInputFile();
            var elfSim = new ElfMemoryGameSimulator(InputLines);
            var number = elfSim.SimulateElfGame(targetTurn: 2020);

            Console.WriteLine(string.Format(Day15Constants.Day15PartOneAnswer,
                2020, number));
        }

        public void SolvePartTwo()
        {
            ReadInputFile();
            var elfSim = new ElfMemoryGameSimulator(InputLines);
            var number = elfSim.SimulateElfGame(targetTurn: 30000000);

            Console.WriteLine(string.Format(Day15Constants.Day15PartOneAnswer,
                2020, number));
        }
    }
}
