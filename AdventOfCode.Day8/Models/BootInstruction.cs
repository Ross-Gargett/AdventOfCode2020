using System;

namespace AdventOfCode.Day8.Models
{
    public class BootInstruction
    {
        public OperationType Operation { get; set; }
        public int Argument { get; set; }
        
        internal void SwapToNop()
        {
            Operation = OperationType.Nop;
        }

        internal bool IsNegativeOrZeroJump()
        {
            return Operation == OperationType.Jmp && Argument <= 0;
        }

        internal void Revert()
        {
            Operation = OperationType.Jmp;
        }
    }
}