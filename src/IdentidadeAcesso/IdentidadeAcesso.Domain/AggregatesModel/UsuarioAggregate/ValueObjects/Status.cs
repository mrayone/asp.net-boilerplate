using IdentidadeAcesso.Domain.SeedOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects
{
    public class Status : Enumeration
    {
        public static readonly Status Ativo = new Status("A", nameof(Ativo).ToLowerInvariant());
        public static readonly Status Inativo = new Status("I", nameof(Inativo).ToLowerInvariant());

        public ValidationResult ValidationResult { get; private set; }
        public Status(string id, string name) : base(id, name)
        {
            ValidationResult = new ValidationResult();

            Validar();
        }

        private void Validar()
        {
            if (!Equals(Status.Ativo) || !Equals(Status.Inativo))
            {
                ValidationResult.AdicionarErro("Valor Inválido", "O status só pode ser definido como 'Ativo' ou 'Inativo'.");
            }
        }
    }
}
