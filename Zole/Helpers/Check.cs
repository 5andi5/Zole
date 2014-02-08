using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Zole.Helpers
{
    internal static class Check
    {
        internal static void NotNull(object value, string name)
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        internal static void NotNullOrEmpty(string value, string name)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}