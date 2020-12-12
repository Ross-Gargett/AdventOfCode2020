using AdventOfCode.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Day11.Models;

namespace AdventOfCode.Day11.Services
{
    class ProblemSolverDay11 : IProblemSolver<string>
    {
        public IEnumerable<string> InputLines { get; set; }

        private FerrySeatingLayout ferryLayout;

        public void ReadInputFile()
        {
            InputLines = File.ReadAllLines("Input.txt");
            ferryLayout = new FerrySeatingLayout(InputLines.Select(row => row.ToCharArray()).ToArray());
        }

        public void SolvePartOne()
        {
            ReadInputFile();
            FerryRuleResult result;
            
            do
            {
                result = ferryLayout.ApplyRulesToAllSeats();
                ferryLayout = result.NewLayout;
            } while (result.TotalChanges > 0);

            Console.WriteLine(string.Format(Day11Constants.Day11PartOneAnswer,
                ferryLayout.CountOccupiedSeats()));
        }

        public void SolvePartTwo()
        {
            ReadInputFile();
            FerryRuleResult result;

            do
            {
                result = ferryLayout.ApplyRuleTwoToAllSeats();
                ferryLayout = result.NewLayout;
            } while (result.TotalChanges > 0);

            Console.WriteLine(string.Format(Day11Constants.Day11PartTwoAnswer,
                ferryLayout.CountOccupiedSeats()));
        }
    }
}
