using System;
using IdentidadeAcesso.Domain.SeedOfWork;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects
{
    public class Sexo : Enumeration
    {
        public static readonly Sexo Masculino = new Sexo("M", nameof(Masculino).ToLowerInvariant());
        public static readonly Sexo Feminino = new Sexo("F", nameof(Feminino).ToLowerInvariant());

        public ValidationResult ValidationResult { get; private set; }
        public Sexo(string id, string nome) : base(id, nome)
        {
            ValidationResult = new ValidationResult();

            Validar();
        }

        private void Validar()
        {
            if(!Equals(Sexo.Masculino) || !Equals(Sexo.Feminino))
            {
                ValidationResult.AdicionarErro("Valor Inválido", "O sexo deve ser definido como 'Masculino' ou 'Feminino'.");
            }
        }
    }
}