using AdventOfCode.Classes;
using AdventOfCode.Day2.PasswordRules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day2.Services
{
    class ProblemSolverDayTwo : IProblemSolver<string>
    {
        public IEnumerable<string> InputLines { get; set; }

        public void ReadInputFile()
        {
            InputLines = File.ReadAllLines("Input.txt");
        }

        public void SolvePartOne()
        {
            ReadInputFile();
            var validPasswords = CountValidPasswordsRuleOne();
            Console.WriteLine(string.Format(DayTwoConstants.DayTwoPartOneAnswer,
                                            validPasswords));
        }

        public void SolvePartTwo()
        {
            ReadInputFile();
            var validPasswords = CountValidPasswordsRuleTwo();
            Console.WriteLine(string.Format(DayTwoConstants.DayTwoPartTwoAnswer,
                validPasswords));
        }

        private int CountValidPasswordsRuleOne()
        {
            var validPasswordCount = 0;

            foreach (var passwordAndRule in InputLines)
            {
                if (!Regex.IsMatch(passwordAndRule, DayTwoConstants.FormatRegex)) continue;

                var passPieces = passwordAndRule.Split(": ");
                var rule = new PasswordRuleOne(passPieces[0]);
                var password = passPieces[1];

                if (!rule.IsValid()) continue;

                if (PasswordIsValidRuleOne(password, rule)) validPasswordCount++;
            }

            return validPasswordCount;
        }

        private bool PasswordIsValidRuleOne(string password, PasswordRuleOne rule)
        {
            var occurrenceCount = password.Count(letter => letter.Equals(rule.Letter));
            return rule.MinCount <= occurrenceCount && occurrenceCount <= rule.MaxCount;
        }

        private int CountValidPasswordsRuleTwo()
        {
            int validPasswordCount = 0;

            foreach (var passwordAndRule in InputLines)
            {
                if (!Regex.IsMatch(passwordAndRule, DayTwoConstants.FormatRegex)) continue;

                var passPieces = passwordAndRule.Split(": ");
                var rule = new PasswordRuleTwo(passPieces[0]);
                var password = passPieces[1];

                if (!rule.IsValid()) continue;

                if (PasswordIsValidRuleTwo(password, rule)) validPasswordCount++;
            }

            return validPasswordCount;
        }

        private bool PasswordIsValidRuleTwo(string password, PasswordRuleTwo rule)
        {
            if (password.Length < rule.SecondPosition) return false;
            return password[rule.FirstPosition - 1].Equals(rule.Letter) ^ password[rule.SecondPosition - 1].Equals(rule.Letter);
        }
    }
}
