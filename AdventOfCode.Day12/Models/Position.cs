using System;

namespace AdventOfCode.Day12.Models
{
    public class Position
    {
        public int Latitude { get; set; }
        public int Longitude { get; set; }

        public void AdjustPosition(Direction direction, int units)
        {
            switch (direction)
            {
                case Direction.North:
                    Longitude += units;
                    break;
                case Direction.East:
                    Latitude += units;
                    break;
                case Direction.South:
                    Longitude -= units;
                    break;
                case Direction.West:
                    Latitude -= units;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
    }
}