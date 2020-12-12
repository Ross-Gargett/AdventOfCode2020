using System;
using AdventOfCode.Classes.Services;

namespace AdventOfCode.Day12.Models
{
    public class Navigator
    {
        public Navigator()
        {
            FacingDirection = Direction.East;
            GeoPosition = new Position();
        }

        public Direction FacingDirection { get; set; }
        public Position GeoPosition { get; set; }

        public void FollowInstruction(Instruction instruction)
        {
            switch (instruction.InstructionType)
            {
                case InstructionType.Left:
                    FacingDirection = (Direction)((FacingDirection.ToInt() - instruction.Value + 360) % 360);
                    break;
                case InstructionType.Right:
                    FacingDirection = (Direction)((FacingDirection.ToInt() + instruction.Value) % 360);
                    break;
                case InstructionType.Forward:
                case InstructionType.North:
                case InstructionType.East:
                case InstructionType.South:
                case InstructionType.West:
                    GeoPosition.AdjustPosition(MapInstructionToDirection(instruction.InstructionType), instruction.Value);
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
                InstructionType.Forward => FacingDirection,
                InstructionType.North => Direction.North,
                InstructionType.East => Direction.East,
                InstructionType.South => Direction.South,
                InstructionType.West => Direction.West,
                _ => throw new NotImplementedException(),
            };
        }
    }

    public enum Direction
    {
        North = 0, 
        East = 90,
        South = 180,
        West = 270
    }
}