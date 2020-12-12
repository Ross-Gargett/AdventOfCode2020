namespace AdventOfCode.Day12.Models
{
    public class ManhattanDistance
    {
        public int AbsoluteLongitude { get; set; }
        public int AbsoluteLatitude { get; set; }

        public int GetSumPosition()
        {
            return AbsoluteLatitude + AbsoluteLongitude;
        }
    }
}