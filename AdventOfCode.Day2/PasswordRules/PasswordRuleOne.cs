using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AdventOfCode.Classes.Services;

namespace AdventOfCode.Day2.PasswordRules
{
    public class PasswordRuleOne : IPasswordRule
    {
        public PasswordRuleOne(string rulePrefix)
        {
            MinCount = Regex.Match(rulePrefix, DayTwoConstants.MinNumRegex).ToString().ToInt();
            MaxCount = Regex.Match(rulePrefix, DayTwoConstants.MaxNumRegex).ToString().ToInt();
            Letter = Regex.Match(rulePrefix, DayTwoConstants.CharRegex).ToString().ToCharArray()?.First() ?? '!';
        }

        public int MinCount { get; set; }
        public int MaxCount { get; set; }
        public char Letter { get; set; }

        public bool IsValid()
        {
            return Letter != '!' && Char.IsLetter(Letter) && MinCount >= 0 && MaxCount >= 0 && MinCount <= MaxCount;
        }
    }
}
