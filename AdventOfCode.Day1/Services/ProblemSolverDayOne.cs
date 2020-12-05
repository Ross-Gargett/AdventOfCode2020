using AdventOfCode.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Classes.Services;

namespace AdventOfCode.Day1.Services
{
    class ProblemSolverDayOne : IProblemSolver<int>
    {
        public IEnumerable<int> InputLines { get; set; }

        public void ReadInputFile()
        {
            var lines = File.ReadAllLines("Input.txt");
            InputLines = lines.Select(l => l.ToInt()).ToList();
        }

        public void SolvePartOne()
        {
            ReadInputFile();
            var solution = PartOneFindPair();

            Console.WriteLine(string.Format(DayOneConstants.DayOnePartOneAnswer, 
                                DayOneConstants.DayOneTarget, 
                                solution.First, 
                                solution.Second, 
                                solution.First * solution.Second));
        }

        public void SolvePartTwo()
        {
            ReadInputFile();
            var solution = PartOneFindTrio();

            Console.WriteLine(string.Format(DayOneConstants.DayOnePartTwoAnswer,
                DayOneConstants.DayOneTarget,
                solution.First,
                solution.Second,
                solution.Third,
                (long)solution.First * solution.Second * solution.Third));
        }

        private (int First, int Second) PartOneFindPair()
        {
            HashSet<int> hashSet = new HashSet<int>();

            foreach (var currentVal in InputLines)
            {
                var difference = DayOneConstants.DayOneTarget - currentVal;

                if (hashSet.Contains(difference))
                {
                    return (currentVal, difference);
                }

                hashSet.Add(currentVal);
            }

            throw new Exception("No valid solution");
        }

        private (int First, int Second, int Third) PartOneFindTrio()
        {
            for (var i = 0; i < InputLines.Count() - 2; i++)
            {
                for (var j = 0; j < InputLines.Count() - 1; j++)
                {
                    for (var k = 0; k < InputLines.Count(); k++)
                    {
                        if (InputLines.ElementAt(i) + InputLines.ElementAt(j) + InputLines.ElementAt(k) != DayOneConstants.DayOneTarget) continue;
                        return (InputLines.ElementAt(i), InputLines.ElementAt(j), InputLines.ElementAt(k));
                    }
                }
            }

            throw new Exception("No valid solution");
        }
    }
}
