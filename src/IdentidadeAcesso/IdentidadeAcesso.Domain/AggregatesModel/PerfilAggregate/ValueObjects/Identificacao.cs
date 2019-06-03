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
            if (string.IsNullOrEmpty(Descricao))
            {
                ValidationResult.AdicionarErro("Descrição Nulo/Vazio", "A descrição precisa ser preenchida.");
                return;
            }
        }

        private void ValidarNome()
        {
            if (string.IsNullOrEmpty(Nome))
            {
                ValidationResult.AdicionarErro("Nome Nulo/Vazio", "O nome precisa ser preenchido.");
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