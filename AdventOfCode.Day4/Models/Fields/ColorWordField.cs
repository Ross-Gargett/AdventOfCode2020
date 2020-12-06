using System.Collections.Generic;

namespace AdventOfCode.Day4.Models
{
    public class ColorWordField : ValidationField
    {
        public ColorWordField(string fieldName, string fieldValue) : base(fieldName, fieldValue)
        {   
        }

        public override bool IsValid()
        {
            return _eyeColors.Contains(FieldValue);
        }

        #region Privates for Validation

        private readonly HashSet<string> _eyeColors = new HashSet<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

        #endregion
    }
}