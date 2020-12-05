
namespace AdventOfCode.Day2
{
    class DayTwoConstants
    {
        #region Day X Constants

        public const string FormatRegex = @"^\d+-\d+\s[a-z]:\s\w*$";
        public const string MinNumRegex = @"^\d+";
        public const string MaxNumRegex = @"(?!-)\d+(?=\s)";
        public const string CharRegex = @"\w*$";

        public const string DayTwoPartOneAnswer = "Part 1:\n" +
                                                  "According to the first policy there are {0} valid passwords\n\n";
        public const string DayTwoPartTwoAnswer = "Part 2:\n" +
                                                  "According to the second policy there are {0} valid passwords\n\n";

        #endregion
    }
}
