using System.Text.RegularExpressions;

namespace AdventOfCode.Day4.Models
{
    public class PasswordIdField : ValidationField
    {
        public PasswordIdField(string fieldName, string fieldValue) : base(fieldName, fieldValue)
        {   
        }

        public override bool IsValid()
        {
            return _pidRegex.IsMatch(FieldValue);
        }

        #region Privates for Validation

        readonly Regex _pidRegex = new Regex(@"^([0-9]{9})$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        #endregion
    }
}