using AdventOfCode.Classes;
using AdventOfCode.Classes.Services;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Day9.Models;
using System;

namespace AdventOfCode.Day9.Services
{
    class ProblemSolverDay9 : IProblemSolver<long>
    {
        public IEnumerable<long> InputLines { get; set; }

        public void ReadInputFile()
        {
            InputLines = File.ReadAllLines("input.txt").Select(l => l.ToBigInt()).Where(l => l!= int.MinValue).ToList();
        }

        public void SolvePartOne()
        {
            ReadInputFile();
            var firstThatFails = FindFirstThatFails();

            Console.WriteLine(string.Format(Day9Constants.Day9PartOneAnswer,
                        firstThatFails));
        }
        
        public void SolvePartTwo()
        {
            ReadInputFile();
            var firstThatFails = FindFirstThatFails();
            var encryptionWeakness = FindEncryptionWeakness(firstThatFails);

            Console.WriteLine(string.Format(Day9Constants.Day9PartTwoAnswer,
                firstThatFails, encryptionWeakness));
            Console.ReadLine();
        }

        private long FindFirstThatFails()
        {
            var firstThatFails = (long)int.MinValue;
            var rollingList = new RollingList(Day9Constants.Day9PartOneWindowSize);

            for (var i = 0; i < InputLines.Count(); i++)
            {
                var nextNum = InputLines.ElementAt(i);

                if (DoesNumberFail(i, rollingList, nextNum))
                {
                    firstThatFails = nextNum;
                    break;
                }

                rollingList.AddNewEntry(nextNum);
            }

            if (firstThatFails == (long)int.MinValue)
                throw new Exception("No valid solution");

            return firstThatFails;
        }

        private static bool DoesNumberFail(int i, RollingList rollingList, long nextNum)
        {
            return i > Day9Constants.Day9PartOneWindowSize &&
                   !rollingList.HasPairThatTotalNum(nextNum);
        }

        private long FindEncryptionWeakness(long target)
        {
            var indexOfFailure = ((List<long>) InputLines).IndexOf(target) - 1;

            for (var i = 0; i < indexOfFailure; i++)
            {
                for (var j = i + 1; j < indexOfFailure; j++)
                {
                    var runningTotal = InputLines.Skip(i).Take(j - i).Sum(); //Inefficient to recount all of this again but time is of the essence!

                    if (runningTotal == target)
                    {
                        var currentWindow = InputLines.Skip(i).Take(j - i).ToList();
                        return currentWindow.Min() + currentWindow.Max();
                    }

                    if (runningTotal > target)
                        break;
                }
            }
            
            throw new Exception("No valid solution");
        }
    }
}
