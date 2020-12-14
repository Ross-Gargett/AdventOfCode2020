using AdventOfCode.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Classes.Services;

namespace AdventOfCode.Day13.Services
{
    class ProblemSolverDay13 : IProblemSolver<int>
    {
        private int earliestTime;
        public IEnumerable<int> InputLines { get; set; }

        public void ReadInputFile()
        {
            var lines = File.ReadAllLines("Input.txt");
            earliestTime = lines[0].ToInt();
            InputLines = lines[1].Split(',').Where(s => s != "x").Select(s => s.ToInt()).ToList();
            ((List<int>)InputLines).Sort();
        }

        public void SolvePartOne()
        {
            ReadInputFile();

            int minRemainder = Int32.MaxValue;
            int closestBusId = 0;

            foreach (var busId in InputLines)
            {
                if (busId - (earliestTime % busId) < minRemainder)
                {
                    minRemainder = busId - (earliestTime % busId);
                    closestBusId = busId;
                }
            }

            Console.WriteLine(string.Format(Day13Constants.Day13PartOneAnswer,
                minRemainder * closestBusId));
        }

        public void SolvePartTwo()
        {
            ReadInputFile();
        }
    }
}
