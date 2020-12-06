using System;
using System.Collections.Generic;
using AdventOfCode.Classes.Services;

namespace AdventOfCode.Day4.Models
{
    public class HeightField : ValidationField
    {
        public HeightField(string fieldName, string fieldValue) : base(fieldName, fieldValue)
        {   
        }

        public override bool IsValid()
        {
            string height = FieldValue.Substring(0, FieldValue.Length - 2),
                   unit = FieldValue.Substring(FieldValue.Length - 2);

            return _unitToRangeMap.ContainsKey(unit) && IsNumberInRange(height.ToInt(), _unitToRangeMap[unit]);
        }

        #region Privates for Validation

        private static bool IsNumberInRange(int height, (int Min, int Max) range)
        {
            return height >= range.Min && height <= range.Max; ;
        }

        private readonly Dictionary<string, (int Min, int Max)> _unitToRangeMap = new Dictionary<string, (int Min, int Max)> {
            { "cm", (150, 193) },
            { "in", (59, 76) }
        };

        #endregion
    }
}