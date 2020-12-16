using AdventOfCode.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Classes.Services;

namespace AdventOfCode.Day14.Services
{
    class ProblemSolverDay14 : IProblemSolver<string>
    {
        public IEnumerable<string> InputLines { get; set; }

        private ulong andMask = 0,
                      orMask = 0;

        public void ReadInputFile()
        {
            InputLines = File.ReadAllLines("input.txt");
        }

        public void SolvePartOne()
        {
            ReadInputFile();

            var mem = new Dictionary<long, ulong>();

            foreach (var instruction in InputLines)
            {
                if (Regex.IsMatch(instruction, Day14Constants.MaskPattern))
                {
                    ParseMasks(instruction);
                    continue;
                }

                var memValue = instruction.Split('=');
                var memAddress = Convert.ToInt64(Regex.Match(memValue[0], Day14Constants.MemNumberPattern).ToString());
                var value = Convert.ToUInt64(memValue[1].Trim());

                value &= andMask;
                value |= orMask;
                mem[memAddress] = value;
            }

            var memSum = 0ul;

            foreach (var memVal in mem)
            {
                memSum += memVal.Value;
            }

            Console.WriteLine(string.Format(Day14Constants.Day14PartOneAnswer,
                memSum));
        }

        public void SolvePartTwo()
        {
            ReadInputFile();
        }

        private void ParseMasks(string instruction)
        {
            var originalMask = instruction.Split('=')[1].Trim();

            var andMaskStr = originalMask.Replace('X', '1');
            var orMaskStr = originalMask.Replace('X', '0');

            andMask = Convert.ToUInt64(andMaskStr, 2);
            orMask = Convert.ToUInt64(orMaskStr, 2);
        }
    }
}
