using System.Collections.Generic;

namespace AdventOfCode.Day4.Models
{
    public class OptionalField : ValidationField
    {
        public OptionalField(string fieldName, string fieldValue) : base(fieldName, fieldValue)
        {   
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}