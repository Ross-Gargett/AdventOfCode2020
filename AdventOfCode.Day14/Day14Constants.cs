
namespace AdventOfCode.Day14
{
    class Day14Constants
    {
        #region Day 14 Constants

        public const string MaskPattern = @"^mask = [X01]{36}$";
        public const string MemNumberPattern = @"(?!mem\[)\d+(?=\])";

        public const string Day14PartOneAnswer = "Part 1:\n" +
                                                 "The sum of all values left in memory after it completes is {0}";
        public const string Day14PartTwoAnswer = "Part 2:\n";

        #endregion
    }
}
