using System;
using IdentidadeAcesso.Domain.SeedOfWork;

namespace IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.ValueObjects
{
    public class Identificacao : ValueObject<Identificacao>
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public Identificacao(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;

            Validar();
        }

        private void Validar()
        {
            ValidarNome();
            ValidarDescricao();
        }

        private void ValidarDescricao()
        {
            if (Descricao == null)
            {
                ValidationResult.AdicionarErro("Descrição Nula", "A descrição não pode ser nula.");
                return;
            }

            if (Descricao == String.Empty)
            {
                ValidationResult.AdicionarErro("Descrição Vazia", "A descrição não pode estar em branco.");
                return;
            }
        }

        private void ValidarNome()
        {
            if (Nome == null)
            {
                ValidationResult.AdicionarErro("Nome Nulo", "O nome não pode ser nulo.");
                return;
            }

            if (Nome == String.Empty)
            {
                ValidationResult.AdicionarErro("Nome Vazio", "O nome não pode estar em branco.");
                return;
            }
        }

        protected override bool EqualsCore(Identificacao other)
        {
            return Nome.Equals(other.Nome) && Descricao.Equals(other.Descricao);
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                var hash = Nome.GetHashCode();
                hash += (Descricao.GetHashCode() * 907) ^ Descricao.GetHashCode();

                return hash;
            }
        }
    }
}