using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Zole.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (T element in list)
            {
                action(element);
            }
            return list;
        }
    }
}