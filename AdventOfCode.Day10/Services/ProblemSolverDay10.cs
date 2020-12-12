using AdventOfCode.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

            var totalPerms = CountDistinctAdapterPermutations();

            Console.WriteLine(string.Format(Day10Constants.Day10PartTwoAnswer,
                totalPerms));
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

        private long CountDistinctAdapterPermutations()
        {
            long permutations = 0;

            var paths = new Dictionary<int, long> //Collection to store the number of paths to each numbered adapter.
            {
                [InputLines.Last()] = 0 //No paths from the last adapter.
            };

            var counter = 0;

            //Count paths for all valid first adapters (those with joltages 1-3)
            while (InputLines.ElementAt(counter) <= 3)
            {
                permutations += CountPathsFromAdapter(counter, paths);
                permutations += 1; //Account for the path from the outlet
                counter++;
            } 

            return permutations;
        }

        private long CountPathsFromAdapter(int index, Dictionary<int, long> paths)
        {
            var adapter = InputLines.ElementAt(index);

            if (paths.ContainsKey(adapter)) return paths[adapter];

            long pathCount = 0;
            var nextIndex = index + 1;

            //Loop through all adapters that are a valid path from this adapter
            while (nextIndex < InputLines.Count() && InputLines.ElementAt(nextIndex) - adapter <= 3)
            {
                //Calculate the path for the next adapter.
                var otherAdapter = InputLines.ElementAt(nextIndex);
                pathCount += 1 + (paths.ContainsKey(otherAdapter) ? paths[otherAdapter] : CountPathsFromAdapter(nextIndex, paths));
                nextIndex ++;
            }

            paths[adapter] = pathCount - 1;

            return paths[adapter];
        }
    }
}
