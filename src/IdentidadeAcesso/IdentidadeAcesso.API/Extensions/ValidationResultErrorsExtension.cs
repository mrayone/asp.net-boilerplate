using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Extensions
{
    public static class ValidationResultErrorsExtension
    {
        public static void AddRangeIfNotEmpty(this IList<ValidationFailure> lista, IEnumerable<ValidationFailure> collection)
        {
            if (!collection.Any()) return;

            foreach (var item in collection)
            {
                lista.AddIfNotExits(item);
            }
        }

        public static void AddIfNotExits(this IList<ValidationFailure> lista, ValidationFailure value)
        {
            foreach (var item in lista)
            {
                if(item.ErrorMessage == value.ErrorMessage)
                {
                    return;
                }
            }
            

            lista.Add(value);
        }
    }
}
