using System;

namespace AdventOfCode.Classes.Services
{
    public static class ExtensionMethods
    {
        #region Parsing Methods

        public static int ToInt(this object obj)
        {
            try
            {
                return Convert.ToInt32(obj);
            }
            catch (Exception)
            {
                return int.MinValue;
            }
        }

        public static Int64 ToBigInt(this object obj)
        {
            try
            {
                return Convert.ToInt64(obj);
            }
            catch (Exception)
            {
                return int.MinValue;
            }
        }

        #endregion
    }
}
