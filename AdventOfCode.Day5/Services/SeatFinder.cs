using AdventOfCode.Day5.Models;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Day5.Services
{
    class SeatFinder
    {
        private readonly string _seatCode;

        public PlaneDimension PlaneSize { get; set; }
        public SeatingArea PossibleSeatingArea { get; set; }

        public SeatFinder(string encodedSeat, PlaneDimension planeSize)
        {
            _seatCode = encodedSeat;
            PlaneSize = planeSize;
            PossibleSeatingArea = PlaneSize.GetTotalSeatingArea();
        }

        internal Seat FindSeat()
        {
            foreach (var instruction in _seatCode.ToCharArray())
            {
                PossibleSeatingArea.ShiftArea(MapCharToInstruction(instruction));
            }

            return new Seat(PossibleSeatingArea.HighestRow, PossibleSeatingArea.HighestColumn, _seatCode);
        }

        private SeatInstruction MapCharToInstruction(char instruction)
        {
            return charToInstructionMap[char.ToUpper(instruction)];
        }

        private readonly Dictionary<char, SeatInstruction> charToInstructionMap = new Dictionary<char, SeatInstruction> {
            { 'F', SeatInstruction.LowerHalfRow },
            { 'B', SeatInstruction.UpperHalfRow },
            { 'L', SeatInstruction.LowerHalfColumn },
            { 'R', SeatInstruction.UpperHalfColumn }
        };

    }
}
