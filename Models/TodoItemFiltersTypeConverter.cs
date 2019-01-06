using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Primitives;
using MvcMovie.TypeConverts;

namespace MvcMovie.Models
{
    public class TodoItemFiltersTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return typeof(string) == sourceType || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (!(value is string toConvert)) return new TodoItemFilter();

            var todoItemFilters = toConvert.Split(",");
            return new TodoItemFilters(todoItemFilters.Select(f => new TodoItemFilter(f))
                .ToList());
        }
    }
}