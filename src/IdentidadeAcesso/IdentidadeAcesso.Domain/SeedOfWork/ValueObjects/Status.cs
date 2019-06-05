using IdentidadeAcesso.Domain.SeedOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Domain.SeedOfWork.ValueObjects
{
    public class Status : ValueObject<Status>
    {
        public static readonly Status Ativo = new Status { Valor = true };
        public static readonly Status Inativo = new Status { Valor = false };

        public bool Valor { get; private set; }

        public Status()
        {

        }

        protected override bool EqualsCore(Status other)
        {
            return Valor == other.Valor;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                var hash = (Valor.GetHashCode() * 907) ^ Valor.GetHashCode();

                return hash;
            }
        }
    }
}
