using AdventOfCode.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Day3.Models;

namespace AdventOfCode.Day3.Services
{
    class ProblemSolverDayThree : IProblemSolver<string>
    {
        public IEnumerable<string> InputLines { get; set; }

        public void ReadInputFile()
        {
            InputLines = File.ReadAllLines("Input.txt");
        }

        public void SolvePartOne()
        {
            ReadInputFile();
            var singleSlope = new Slope(3, 1);
            var numTrees = CountTreesGivenSlope(singleSlope);
            Console.WriteLine(string.Format(DayThreeConstants.DayThreePartOneAnswer, 
                                            singleSlope.Right, 
                                            singleSlope.Down, 
                                            numTrees));
        }

        public void SolvePartTwo()
        {
            ReadInputFile();

            var slopeOne = new Slope(1, 1);
            var slopeOneTrees = CountTreesGivenSlope(slopeOne);

            var slopeTwo = new Slope(3, 1);
            var slopeTwoTrees = CountTreesGivenSlope(slopeTwo);

            var slopeThree = new Slope(5, 1);
            var slopeThreeTrees = CountTreesGivenSlope(slopeThree);

            var slopeFour = new Slope(7, 1);
            var slopeFourTrees = CountTreesGivenSlope(slopeFour);

            var slopeFive = new Slope(1, 2);
            var slopeFiveTrees = CountTreesGivenSlope(slopeFive);

            var treeMultiple = (long) slopeOneTrees * slopeTwoTrees *
                               slopeThreeTrees * slopeFourTrees *
                               slopeFiveTrees;

            Console.WriteLine(string.Format(DayThreeConstants.DayThreePartTwoAnswer,
                                            slopeOne.Right, slopeOne.Down, slopeOneTrees,
                                            slopeTwo.Right, slopeTwo.Down, slopeTwoTrees,
                                            slopeThree.Right, slopeThree.Down, slopeThreeTrees,
                                            slopeFour.Right, slopeFour.Down, slopeFourTrees,
                                            slopeFive.Right, slopeFive.Down, slopeFiveTrees,
                                            treeMultiple.ToString("##,###")));
        }

        private int CountTreesGivenSlope(Slope slope)
        {
            int horizontalPosition = 0,
                verticalPosition = 0,
                treeCount = 0;

            if (!InputLines.Any()) return treeCount;

            var mapWidth = InputLines.ElementAt(0).Length;
            var mapLength = InputLines.Count();

            while (verticalPosition < mapLength)
            {
                if (InputLines.ElementAt(verticalPosition)[horizontalPosition].Equals('#')) treeCount++;

                horizontalPosition = (horizontalPosition + slope.Right) % mapWidth;
                verticalPosition += slope.Down;
            }

            return treeCount;
        }
    }
}
