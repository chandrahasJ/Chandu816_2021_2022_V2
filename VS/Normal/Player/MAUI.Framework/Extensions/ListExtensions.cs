using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIApp.Framework.Extensions
{
    public static class ListExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (var item in enumeration)
            {
                action(item);
            }
        }

        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
        {
            Random random = new();
            return source.OrderBy<T, int>(item => random.Next());
        }

        public static void AddRange<T>(this ObservableCollection<T> collection, 
                                            IEnumerable<T> newItems, 
                                            bool clearFirst = false)
        {
            if (clearFirst)
            {
                collection.Clear();
            }

            newItems.ForEach(newItem => collection.Add(newItem));
        }
    }
}
