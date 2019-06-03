using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdentidadeAcesso.Domain.SeedOfWork.Extensions
{
    public static class MyExtensionMethods
    {
        public static void AddRangeIfNotEmpty<T>(this List<T> lista, IEnumerable<T> collection)
        {
            if (!collection.Any()) return;

            lista.AddRange(collection);
        }
    }
}
