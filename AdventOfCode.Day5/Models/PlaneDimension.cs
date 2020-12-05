using System;

namespace AdventOfCode.Day5.Models
{
    public class PlaneDimension
    {
        public PlaneDimension(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
        }

        public int ZeroIndexRow => Math.Max(Rows - 1, 0); //Negative rows are not valid
        public int Rows { get; set; }

        public int ZeroIndexColumn => Math.Max(Columns - 1, 0); //Negative columns are not valid
        public int Columns { get; set; }

        public SeatingArea GetTotalSeatingArea()
        {
            return new SeatingArea()
            {
                LowestRow = 0,
                HighestRow = ZeroIndexRow,
                LowestColumn = 0,
                HighestColumn = ZeroIndexColumn
            };
        }
    }
}
