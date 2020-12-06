using System;
using System.Collections.Generic;
using AdventOfCode.Classes.Services;

namespace AdventOfCode.Day4.Models
{
    public class YearField : ValidationField
    {
        public YearField(string fieldName, string fieldValue) : base(fieldName, fieldValue)
        {   
        }

        public override bool IsValid()
        {
            return IsNumberInRange(FieldValue.ToInt(), _fieldNameToYearMap[FieldName]);
        }

        #region Privates for Validation

        private static bool IsNumberInRange(int year, (int Min, int Max) range)
        {
            return year >= range.Min && year <= range.Max; ;
        }

        private readonly Dictionary<string, (int Min, int Max)> _fieldNameToYearMap = new Dictionary<string, (int Min, int Max)> {
            { "byr", (1920, 2002) },
            { "iyr", (2010, 2020) },
            { "eyr", (2020, 2030) }
        };

        #endregion
    }
}