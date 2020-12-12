using System.Linq;
using AdventOfCode.Classes.Services;

namespace AdventOfCode.Day12.Models
{
    public class Instruction
    {
        public Instruction(string inst)
        {
            InstructionType = MapCharToInstructionType(inst.First());
            Value = inst.Substring(1).ToInt();
        }

        public InstructionType InstructionType { get; set; }
        public int Value { get; set; }

        private InstructionType MapCharToInstructionType(char instType)
        {
            return instType switch
            {
                'F' => InstructionType.Forward,
                'L' => InstructionType.Left,
                'R' => InstructionType.Right,
                'N' => InstructionType.North,
                'E' => InstructionType.East,
                'S' => InstructionType.South,
                'W' => InstructionType.West,
                _ => throw new System.NotImplementedException()
            };
        }
    }

    public enum InstructionType
    {
        Forward = 0,
        Left,
        Right,
        North,
        East,
        South,
        West
    }
}