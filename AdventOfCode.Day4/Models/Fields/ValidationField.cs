namespace AdventOfCode.Day4.Models
{
    public abstract class ValidationField
    {
        readonly string _valueMatch = @":#?\w+(?=\s)?";

        private string _fieldValue;

        protected ValidationField(string fieldName, string fieldValue)
        {
            FieldName = fieldName;
            FieldValue = fieldValue;
        }

        public string FieldName { get; set; }
        public string FieldValue { get; set; }

        public abstract bool IsValid();
    }
}