using System.Text.RegularExpressions;

namespace AdventOfCode.Day4.Models
{
    public class HexColorField : ValidationField
    {
        public HexColorField(string fieldName, string fieldValue) : base(fieldName, fieldValue)
        {   
        }

        public override bool IsValid()
        {
            return _hexColorRegex.IsMatch(FieldValue);
        }

        #region Privates for Validation

        private readonly Regex _hexColorRegex = new Regex(@"^#[0-9a-f]{6}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        #endregion
    }
}