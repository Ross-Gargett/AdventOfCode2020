using AdventOfCode.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Classes.Services;
using AdventOfCode.Day13.Models;

namespace AdventOfCode.Day13.Services
{
    class ProblemSolverDay13 : IProblemSolver<int>
    {
        private int earliestTime;
        public IEnumerable<int> InputLines { get; set; }
        public IEnumerable<string> InputLinesTwo { get; set; }

        public void ReadInputFile()
        {
            var lines = File.ReadAllLines("Input.txt");
            earliestTime = lines[0].ToInt();
            InputLines = lines[1].Split(',').Where(s => s != "x").Select(s => s.ToInt()).ToList(); 
            ((List<int>)InputLines).Sort();
                
        }

        public void ReadInputFileTwo()
        {
            InputLinesTwo = File.ReadAllLines("Input.txt")[1].Split(',').ToList();
        }

        public void SolvePartOne()
        {
            ReadInputFile();

            var minRemainder = int.MaxValue;
            var closestBusId = 0;

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
            ReadInputFileTwo();

            var firstTimestamp = GetFirstTimestampMatchingPattern();

            Console.WriteLine(string.Format(Day13Constants.Day13PartTwoAnswer,
                firstTimestamp));
        }

        private ulong GetFirstTimestampMatchingPattern()
        {
            var allBusIds = new List<BusModel>();
            var i = 0;

            foreach (var bus in InputLinesTwo)
            {
                if (bus != "x")
                {
                    allBusIds.Add(new BusModel { BusId = bus.ToInt(), Index = i });
                }

                i++;
            }
            
            ulong jump = 1;
            ulong timeStamp = 0;

            for (i = 0; i < allBusIds.Count() - 1; i++)
            {
                var nextBus = (ulong)allBusIds[i + 1].BusId;
                var index = (ulong)allBusIds[i + 1].Index;
                jump *= (ulong)allBusIds[i].BusId;

                while ((timeStamp + index) % nextBus != 0)
                {
                    timeStamp += (ulong)jump;
                }
            }

            return timeStamp;
        }
    }
}
