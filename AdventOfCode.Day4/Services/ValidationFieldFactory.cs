using System.Runtime.InteropServices.WindowsRuntime;
using AdventOfCode.Day4.Models;

namespace AdventOfCode.Day4.Services
{
    public class ValidationFieldFactory
    {
        public ValidationField CreateValidationField(string field)
        {
            var splitField = field.Split(':');

            return splitField[0] switch
            {
                "byr" => new YearField(splitField[0], splitField[1]),
                "iyr" => new YearField(splitField[0], splitField[1]),
                "eyr" => new YearField(splitField[0], splitField[1]),
                "hgt" => new HeightField(splitField[0], splitField[1]),
                "hcl" => new HexColorField(splitField[0], splitField[1]),
                "ecl" => new ColorWordField(splitField[0], splitField[1]),
                "pid" => new PasswordIdField(splitField[0], splitField[1]),
                _ => new OptionalField(splitField[0], splitField[1])
            };
        }
    }
}