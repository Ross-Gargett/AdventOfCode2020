using System;
using System.Collections.Generic;
using System.Text;

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
            catch (Exception e)
            {
                return Int32.MinValue;
            }
        }

        #endregion
    }
}
