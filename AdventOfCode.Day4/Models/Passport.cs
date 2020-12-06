using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Day4.Services;

namespace AdventOfCode.Day4.Models
{
    public class Passport
    {
        private readonly Regex _fieldRegex = new Regex(@"[a-z]{3}:#?\w+(?=\s)?", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private readonly string _passport;

        public Passport(string passport)
        {
            _passport = passport;
            PassportFields = new List<ValidationField>();
            ParseOutFields();
        }

        public List<ValidationField> PassportFields { get; set; }

        public bool IsPassportValid()
        {
            return HasAllRequiredFields() && PassportFields.TrueForAll(f => f.IsValid());
        }

        private bool HasAllRequiredFields()
        {
            return _requiredFields.All(requiredField => PassportFields.Any(f => f.FieldName == requiredField));
        }

        private void ParseOutFields()
        {
            var matches = _fieldRegex.Matches(_passport);
            var factory = new ValidationFieldFactory();

            foreach (var match in matches)
            {
                PassportFields.Add(factory.CreateValidationField(match.ToString()));
            }
        }

        private readonly List<string> _requiredFields = new List<string> { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
    }
}
