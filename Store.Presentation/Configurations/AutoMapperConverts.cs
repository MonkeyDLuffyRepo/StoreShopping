using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Presentation.Configurations
{
    public interface ITypeConverter<in TSource, TDestination>
    {
        TDestination Convert(TSource source, TDestination destination, ResolutionContext context);
    }

    public class DateTimeTypeConverter : ITypeConverter<string, DateTime?>
    {
        public DateTime? Convert(string source, DateTime? destination, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source)) return null;

            return System.Convert.ToDateTime(source);
        }
    }

    public class DateTimeTypeToStringConverter : ITypeConverter<DateTime?, string>
    {
        public string Convert(DateTime? source, string destination, ResolutionContext context)
        {
            if (source.HasValue) return source.Value.ToString("yyyy-MM-dd HH:mm:ss");

            return string.Empty;
        }
    }

    public class CurrencyFormatter : IValueConverter<decimal, string>
    {
        public string Convert(decimal sourceMember, ResolutionContext context)
        {
            throw new NotImplementedException();
        }
    }

    public class DateTimeParser : IValueConverter<string, DateTime?>
    {
        public DateTime? Convert(string sourceMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(sourceMember)) return null;
            return System.Convert.ToDateTime(sourceMember);
        }
    }

    public class DateTimeToStringFormatter : IValueConverter<DateTime?, string>
    {
        public string Convert(DateTime? sourceMember, ResolutionContext context)
        {
            if (sourceMember.HasValue) return sourceMember.Value.ToString("yyyy-MM-dd");
            return string.Empty;
        }
    }
}
