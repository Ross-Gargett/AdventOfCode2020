using System;

namespace AdventOfCode.Day5.Models
{
    public class SeatingArea
    {
        public int LowestRow { get; set; }
        public int HighestRow { get; set; }
        public int LowestColumn { get; set; }
        public int HighestColumn { get; set; }

        internal void ShiftArea(SeatInstruction instruction)
        {
            int mid;

            switch (instruction)
            {
                case SeatInstruction.LowerHalfRow:
                    mid = (LowestRow + HighestRow) / 2;
                    HighestRow = mid;
                    break;
                case SeatInstruction.UpperHalfRow:
                    mid = (LowestRow + HighestRow) / 2;
                    LowestRow = mid + 1;
                    break;
                case SeatInstruction.LowerHalfColumn:
                    mid = (LowestColumn + HighestColumn) / 2;
                    HighestColumn = mid;
                    break;
                case SeatInstruction.UpperHalfColumn:
                    mid = (LowestColumn + HighestColumn) / 2;
                    LowestColumn = mid + 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(instruction), instruction, null);
            }
        }
    }
}
