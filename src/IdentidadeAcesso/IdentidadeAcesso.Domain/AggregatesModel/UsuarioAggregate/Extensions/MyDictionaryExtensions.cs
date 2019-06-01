using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate
{
    public static class MyDictionaryExtensions
    {
        public static void AddIfNotNullOrEmpty<T, U>(this Dictionary<T, U> dic, T key, U value) where U : IReadOnlyDictionary<string, string>
        {
            if (value == null || value.Count == 0) return;
            if (dic.ContainsKey(key)) return;

            dic.Add(key, value);
        }
    }
}
