using AdventOfCode.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Day5.Models;

namespace AdventOfCode.Day5.Services
{
    class ProblemSolverDayFive : IProblemSolver<string>
    {
        public IEnumerable<string> InputLines { get; set; }

        public void ReadInputFile()
        {
            InputLines = File.ReadAllLines("Input.txt");
        }

        public void SolvePartOne()
        {
            ReadInputFile();

            var maxSeat = new Seat();

            foreach (var seatCode in InputLines)
            {
                var seatFinder = new SeatFinder(seatCode, new PlaneDimension(DayFiveConstants.PlaneRows, DayFiveConstants.PlaneCols));
                var seat = seatFinder.FindSeat();

                maxSeat = seat.GetSeatId() > maxSeat.GetSeatId() ? seat : maxSeat;
            }

            Console.WriteLine(string.Format(DayFiveConstants.DayFivePartOneAnswer,
                maxSeat.SeatCode,
                maxSeat.Row,
                maxSeat.Column,
                maxSeat.GetSeatId()));
        }

        public void SolvePartTwo()
        {
            ReadInputFile();

            var allSeatsWithBoardingPasses = new List<long>();

            foreach (var seatCode in InputLines)
            {
                var seatFinder = new SeatFinder(seatCode, new PlaneDimension(DayFiveConstants.PlaneRows, DayFiveConstants.PlaneCols));
                allSeatsWithBoardingPasses.Add(seatFinder.FindSeat().GetSeatId());
            }

            allSeatsWithBoardingPasses.Sort();

            Console.WriteLine(string.Format(DayFiveConstants.DayFivePartTwoAnswer,
                                FindMissingSeat(allSeatsWithBoardingPasses)));
        }

        static long FindMissingSeat(List<long> seatIds)
        {
            long firstSeat = seatIds.First(),
                 lastSeat  = seatIds.Last();

            //Using the formula for sum of an array of contiguous numbers
            // Sum = (first number + last number) * (half of the array size)
            long expectedSum = (firstSeat + lastSeat) * (seatIds.Count() + 1) / 2,
                 actualSum   = seatIds.Sum();

            return expectedSum - actualSum;
        }
    }
}
