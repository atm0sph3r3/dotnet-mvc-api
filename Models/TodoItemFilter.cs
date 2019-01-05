using System;
using System.ComponentModel;
using MvcMovie.Models;

namespace MvcMovie.TypeConverts
{
    [TypeConverter(typeof(TodoItemFilterTypeConverter))]
    public class TodoItemFilter
    {
        public string Id { get; }
        public string Name { get; }
        public string IsComplete { get; }

        public TodoItemFilter(string id, string name, string isComplete)
        {
            Id = id;
            Name = name;
            IsComplete = isComplete;
        }

        public TodoItemFilter()
        {
        }
    }
}