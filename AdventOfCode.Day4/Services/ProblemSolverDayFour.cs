using AdventOfCode.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Day4.Models;

namespace AdventOfCode.Day4.Services
{
    class ProblemSolverDayFour : IProblemSolver<string>
    {
        public IEnumerable<string> InputLines { get; set; }

        public void ReadInputFile()
        {
            var passportBatch = File.ReadAllText("Input.txt");
            InputLines = passportBatch.Split("\r\n\r\n");
        }

        public void SolvePartOne()
        {
            ReadInputFile();

            Console.WriteLine(string.Format(DayFourConstants.DayFourPartOneAnswer, 
                                            InputLines.Count(CheckPassportForRequiredFields)));
        }

        public void SolvePartTwo()
        {
            ReadInputFile();

            Console.WriteLine(string.Format(DayFourConstants.DayFourPartTwoAnswer, 
                              CountPassportThatPassValidation()));
        }
        
        private static bool CheckPassportForRequiredFields(string passport)
        {
            return passport.Contains("byr") && passport.Contains("iyr")
                && passport.Contains("eyr") && passport.Contains("hgt")
                && passport.Contains("hcl") && passport.Contains("ecl")
                && passport.Contains("pid");
        }

        private int CountPassportThatPassValidation()
        {
            int validCount = 0;

            foreach (var passportStr in InputLines)
            {
                var passport = new Passport(passportStr);

                if (passport.IsPassportValid())
                {
                    validCount++;
                }
            }

            return validCount;
        }
    }
}
