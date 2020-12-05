namespace AdventOfCode.Day5.Models
{
    public class Seat
    {
        public Seat()
        {
            Row = 0;
            Column = 0;
            SeatCode = string.Empty;
        }

        public Seat(int row, int column, string seatCode)
        {
            Row = row;
            Column = column;
            SeatCode = seatCode;
        }

        public string SeatCode { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public long GetSeatId()
        {
            return (long)Row * 8 + Column;
        }
    }
}
