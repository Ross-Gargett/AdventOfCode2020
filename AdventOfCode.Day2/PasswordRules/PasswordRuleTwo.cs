using System;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Classes.Services;

namespace AdventOfCode.Day2.PasswordRules
{
    public class PasswordRuleTwo : IPasswordRule
    {
        public PasswordRuleTwo(string rulePrefix)
        {
            FirstPosition = Regex.Match(rulePrefix, DayTwoConstants.MinNumRegex).ToString().ToInt();
            SecondPosition = Regex.Match(rulePrefix, DayTwoConstants.MaxNumRegex).ToString().ToInt();
            Letter = Regex.Match(rulePrefix, DayTwoConstants.CharRegex).ToString().ToCharArray()?.First() ?? '!';
        }

        public int FirstPosition { get; set; }
        public int SecondPosition { get; set; }
        public char Letter { get; set; }

        public bool IsValid()
        {
            return Letter != '!' && Char.IsLetter(Letter) && FirstPosition >= 1 && SecondPosition >= 2 && FirstPosition != SecondPosition;
        }
    }
}
