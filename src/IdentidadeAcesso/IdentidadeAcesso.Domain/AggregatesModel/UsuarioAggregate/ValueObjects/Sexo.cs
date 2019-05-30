using System;
using IdentidadeAcesso.Domain.SeedOfWork;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects
{
    public class Sexo : Enumeration
    {
        public static Sexo Masculino = new Sexo("M", nameof(Masculino).ToLowerInvariant());
        public static Sexo Feminino = new Sexo("F", nameof(Feminino).ToLowerInvariant());

        public ValidationResult ValidationResult { get; private set; }
        public Sexo(string id, string nome ) : base(id, nome)
        {
            ValidationResult = new ValidationResult();

            Validar();
        }

        private void Validar()
        {
            if (ValidarMasculino())
            {
                return;
            }

            if (ValidarFeminino())
            {
                return;
            }

            if (!ValidarMasculino() || !ValidarFeminino())
            {
                ValidationResult.AdicionarErro("Valor Inválido", "O sexo deve ser definido como 'Masculino' ou 'Feminino'.");
                return;
            }
        }

        private bool ValidarMasculino()
        {
            return (Id.Equals("M") && Nome.Equals(nameof(Masculino).ToLowerInvariant()));
        }

        private bool ValidarFeminino()
        {
            return (Id.Equals("F") && Nome.Equals(nameof(Feminino).ToLowerInvariant()));
        }


    }
}