using AdventOfCode.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Day12.Models;

namespace AdventOfCode.Day12.Services
{
    class ProblemSolverDay12 : IProblemSolver<Instruction>
    {
        public IEnumerable<Instruction> InputLines { get; set; }

        public void ReadInputFile()
        {
            InputLines = ParseInstructions(File.ReadAllLines("Input.txt"));
        }

        public void SolvePartOne()
        {
            ReadInputFile();

            var navigator = new Navigator();

            foreach (var instruction in InputLines)
            {
                navigator.FollowInstruction(instruction);
            }

            var manhattanDistance = navigator.GetManhattanDistance();

            Console.WriteLine(string.Format(Day12Constants.Day12PartOneAnswer,
                manhattanDistance.AbsoluteLatitude, manhattanDistance.AbsoluteLongitude, manhattanDistance.GetSumPosition()));
        }

        public void SolvePartTwo()
        {
            ReadInputFile();

            var navigator = new WaypointNavigator();

            foreach (var instruction in InputLines)
            {
                navigator.FollowInstruction(instruction);
            }

            var manhattanDistance = navigator.GetManhattanDistance();

            Console.WriteLine(string.Format(Day12Constants.Day12PartTwoAnswer,
                manhattanDistance.AbsoluteLatitude, manhattanDistance.AbsoluteLongitude, manhattanDistance.GetSumPosition()));
        }

        private IEnumerable<Instruction> ParseInstructions(string[] instrStr)
        {
            return instrStr.Select(inst => new Instruction(inst)).ToList();
        }
    }
}
