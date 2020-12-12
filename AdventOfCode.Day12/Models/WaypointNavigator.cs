using System;
using AdventOfCode.Classes.Services;

namespace AdventOfCode.Day12.Models
{
    public class WaypointNavigator
    {
        public WaypointNavigator()
        {
            GeoPosition = new Position();
            WaypointRelativePosition = new Position {Latitude = 10, Longitude = 1};
        }

        public Position GeoPosition { get; set; }
        public Position WaypointRelativePosition { get; set; }

        public void FollowInstruction(Instruction instruction)
        {
            switch (instruction.InstructionType)
            {
                case InstructionType.Left:
                    WaypointRelativePosition.RotateRelativeLeft(instruction.Value);
                    break;
                case InstructionType.Right:
                    WaypointRelativePosition.RotateRelativeRight(instruction.Value);
                    break;
                case InstructionType.Forward:
                    GeoPosition.AdjustPosition(WaypointRelativePosition, instruction.Value);
                    break;
                case InstructionType.North:
                case InstructionType.East:
                case InstructionType.South:
                case InstructionType.West:
                    WaypointRelativePosition.AdjustPosition(MapInstructionToDirection(instruction.InstructionType), instruction.Value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        internal ManhattanDistance GetManhattanDistance()
        {
            return new ManhattanDistance
            {
                AbsoluteLatitude = Math.Abs(GeoPosition.Latitude),
                AbsoluteLongitude = Math.Abs(GeoPosition.Longitude)
            };
        }

        private Direction MapInstructionToDirection(InstructionType instructionType)
        {
            return instructionType switch
            {
                InstructionType.North => Direction.North,
                InstructionType.East => Direction.East,
                InstructionType.South => Direction.South,
                InstructionType.West => Direction.West,
                _ => throw new NotImplementedException(),
            };
        }
    }
}