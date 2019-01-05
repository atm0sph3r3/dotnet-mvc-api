using System;
using System.ComponentModel;
using System.Globalization;
using Microsoft.Extensions.Primitives;
using MvcMovie.TypeConverts;

namespace MvcMovie.Models
{
    public class TodoItemFilterTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return typeof(string) == sourceType || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string toConvert)
            {
                string[] toConvertPieces = toConvert.Split(",");
                if (toConvertPieces.Length < 2)
                {
                    return new TodoItemFilter();
                }

                var id = toConvertPieces[0];
                var name = toConvertPieces[1];

                if (toConvertPieces.Length == 3)
                {
                    return new TodoItemFilter(id, name, toConvertPieces[2]);
                }
                
                return new TodoItemFilter(id, name, string.Empty);
            }

            return new TodoItemFilter();
        }
    }
}