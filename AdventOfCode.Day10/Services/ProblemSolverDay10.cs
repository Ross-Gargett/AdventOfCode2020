using AdventOfCode.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using AdventOfCode.Classes.Services;
using AdventOfCode.Day10.Models;

namespace AdventOfCode.Day10.Services
{
    class ProblemSolverDay10 : IProblemSolver<int>
    {
        public IEnumerable<int> InputLines { get; set; }

        public void ReadInputFile()
        {
            InputLines = File.ReadAllLines("Input.txt").Select(l => l.ToInt()).ToList();
            ((List<int>)InputLines).Sort();
        }

        public void SolvePartOne()
        {
            ReadInputFile();

            var result = ChainTogetherAdapters();

            Console.WriteLine(string.Format(Day10Constants.Day10PartOneAnswer,
                result.Diff1Count, result.Diff3Count, result.GetMultipliedTotal()));
        }
        public void SolvePartTwo()
        {
            ReadInputFile();
        }

        private JoltageResult ChainTogetherAdapters()
        {
            var result = new JoltageResult();
            var lastAdapter = 0;


            for (var i = 0; i < InputLines.Count(); i++)
            {
                var diff = InputLines.ElementAt(i) - lastAdapter;
                
                if (!Enumerable.Range(1, 3).Contains(diff))
                    throw new Exception("No workable chain.");

                result.UpdateDifferences(diff);
                lastAdapter = InputLines.ElementAt(i);
            }

            result.UpdateDifferences(3); //The devices built-in adapter is always 3 higher than the highest adapter

            return result;
        }
    }
}
