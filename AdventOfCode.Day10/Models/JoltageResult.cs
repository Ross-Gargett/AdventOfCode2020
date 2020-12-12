using System;

namespace AdventOfCode.Day10.Models
{
    public class JoltageResult
    {
        public int Diff1Count { get; set; }
        public int Diff3Count { get; set; }
        public int GetMultipliedTotal()
        {
            return Diff1Count * Diff3Count;
        }

        internal void UpdateDifferences(int diff)
        {
            switch (diff)
            {
                case 1:
                    Diff1Count++;
                    break;
                case 3:
                    Diff3Count++;
                    break;
            }
        }
    }
}