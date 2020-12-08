using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using AdventOfCode.Classes.Services;
using AdventOfCode.Day8.Models;

namespace AdventOfCode.Day8.Services
{
    public class BootService
    {
        private List<BootInstruction> _instructions = new List<BootInstruction>();

        public int Accumulator { get; set; }


        public BootService(IEnumerable<string> instructions)
        {
            ParseBootCode(instructions);
        }

        internal int FindAccumulatorForInfiniteLoop()
        {
            Accumulator = 0;
            var visitedInstructions = new HashSet<int>();

            for (var i = 0; i < _instructions.Count;)
            {
                if (!visitedInstructions.Add(i))
                    break;

                i = ExecuteInstructionAndUpdatePointer(i, _instructions);
            }
            
            return Accumulator;
        }

        private int FindAccumulatorForWorkingProgram()
        {
            Accumulator = 0;

            for (var i = 0; i < _instructions.Count;)
            {
                i = ExecuteInstructionAndUpdatePointer(i, _instructions);
            }

            return Accumulator;
        }

        internal int FindAndRepairInfiniteLoop()
        {
            var programTerminates = DoesProgramTerminate(_instructions);

            if (programTerminates)
                return FindAccumulatorForWorkingProgram();

            var negativeJumps = GetStackOfLoopCauses();
            
            while (!programTerminates)
            {
                var lastJumpIndex = negativeJumps.Pop();

                _instructions[lastJumpIndex].SwapToNop();

                if (DoesProgramTerminate(_instructions))
                {
                    programTerminates = true;
                }
                else
                {
                    _instructions[lastJumpIndex].Revert();
                }
            }

            return FindAccumulatorForWorkingProgram();
        }
        
        private Stack<int> GetStackOfLoopCauses()
        {
            var visitedInstructions = new HashSet<int>();
            var negativeJumps = new Stack<int>();

            //Find loop to build out stack
            for (var i = 0; i < _instructions.Count;)
            {
                if (!visitedInstructions.Add(i))
                    break;

                if (_instructions[i].IsNegativeOrZeroJump())
                {
                    negativeJumps.Push(i);
                }

                i = ExecuteInstructionAndUpdatePointer(i, _instructions);
            }

            return negativeJumps;
        }

        private bool DoesProgramTerminate(List<BootInstruction> modifiedInstructions)
        {
            var visitedInstructions = new HashSet<int>();

            for (var i = 0; i < modifiedInstructions.Count;)
            {
                if (!visitedInstructions.Add(i))
                    return false;

                i = ExecuteInstructionAndUpdatePointer(i, modifiedInstructions);
            }

            return true;
        }

        private int ExecuteInstructionAndUpdatePointer(int i, List<BootInstruction> instructions)
        {
            switch (instructions[i].Operation)
            {
                case OperationType.Nop:
                    i += 1;
                    break;
                case OperationType.Acc:
                    Accumulator += instructions[i].Argument;
                    i += 1;
                    break;
                case OperationType.Jmp:
                    i += instructions[i].Argument;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return i;
        }

        private void ParseBootCode(IEnumerable<string> instructions)
        {
            foreach (var instruction in instructions)
            {
                var opArgSplit = instruction.Split(' ');
                var operation = opArgSplit[0].Trim();
                var argument = opArgSplit[1].ToInt();

                _instructions.Add(new BootInstruction { Argument = argument, Operation = MapStringToOperationEnum(operation)});
            }
        }

        private static OperationType MapStringToOperationEnum(string operation)
        {
            return operation.ToLower() switch
            {
                "nop" => OperationType.Nop,
                "acc" => OperationType.Acc,
                "jmp" => OperationType.Jmp,
                _ => OperationType.Nop
            };
        }
    }
}