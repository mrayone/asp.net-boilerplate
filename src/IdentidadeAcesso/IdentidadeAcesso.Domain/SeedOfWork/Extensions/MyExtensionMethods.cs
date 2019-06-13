using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdentidadeAcesso.Domain.SeedOfWork.Extensions
{
    public static class MyExtensionMethods
    {
        public static void AddRangeIfNotEmpty<T>(this IList<T> lista, IEnumerable<T> collection)
        {
            if (!collection.Any()) return;

            foreach(var item in collection)
            {
                lista.AddIfNotExits(item);
            }
        }

        public static void AddIfNotExits<T>(this IList<T> lista, T value)
        {
            if (lista.Contains(value)) return;

            lista.Add(value);
        }
    }
}
