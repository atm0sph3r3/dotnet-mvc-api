using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using MvcMovie.TypeConverts;

namespace MvcMovie.Models
{
    [TypeConverter(typeof(TodoItemFiltersTypeConverter))]
    public class TodoItemFilters
    {
        public IEnumerable<TodoItemFilter> Filters { get; }
        
        public TodoItemFilters(IEnumerable<TodoItemFilter> filters)
        {
            Filters = filters;
        }

        public override string ToString()
        {
            var filters = Filters.Select(f => $"{f.Id}:{f.Name}:{f.IsComplete}")
                .ToList();

            return string.Join(", ", filters);
        }
    }
}