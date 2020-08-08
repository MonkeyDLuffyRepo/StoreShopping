using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store.API.Infrastructures
{
    public static class Extentions
    {
        public static ICollection<TTo> InjectFrom<TFrom, TTo>(this ICollection<TTo> to, IEnumerable<TFrom> from) where TTo : new()
        {
            foreach (var source in from)
            {
                var target = new TTo();
                target.InjectFrom(source);
                to.Add(target);
            }
            return to;
        }

        public static bool Contains(this List<string> list, params string[] parameter)
        {
            return list.Any(t => parameter.Contains(t));
        }

        public static string GetPosition(this int number)
        {
            return (number < 10) ? "0" + number : number + "";
        }

        public static bool ValueNotZero(this double? number)
        {
            return number.HasValue && Math.Abs(number.Value) > 0;
        }

        public static bool NotNullOrEmpty(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        public static bool In(this string str, params string[] parameter)
        {
            return parameter.Any(t => t == str);
        }

        public static bool In(this double? d, params double[] parameter)
        {
            return d.HasValue && parameter.Any(t => t == d);
        }
    }
}
