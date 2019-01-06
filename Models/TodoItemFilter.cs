using System;
using System.ComponentModel;
using System.Linq;
using MvcMovie.Models;

namespace MvcMovie.TypeConverts
{
    public class TodoItemFilter
    {
        public string Id { get; }
        public string Name { get; }
        public string IsComplete { get; }
        public String OriginalInput { get; }

        public TodoItemFilter(string input) : this()
        {
            var filters = input.Split(":")
                .Where(f => f.Length > 1)
                .ToArray();

            if (filters.Length != 2 && filters.Length != 3) return;
            
            Id = filters[0];
            Name = filters[1];
                
            if (filters.Length == 3)
            {
                IsComplete = filters[2];
            }
        }

        public TodoItemFilter()
        {
            Id = string.Empty;
            Name = string.Empty;
            IsComplete = string.Empty;
            
        }
    }
}