using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.ValueObjects;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Extensions;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate
{
    public class Permissao : Entity, IAggregateRoot
    {
        public Atribuicao Atribuicao { get; private set; }

        public Dictionary<string, IReadOnlyDictionary<string, string>> _erros;

        public IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> Erros => _erros;

        public Permissao (Atribuicao atribuicao)
        {
            Id = Guid.NewGuid();
            _erros = new Dictionary<string, IReadOnlyDictionary<string, string>>();
            Atribuicao = atribuicao;
        }

        public bool EhValido()
        {
            Validar();
            return !_erros.Any();
        }

        private void Validar()
        {
            _erros.AddIfNotNullOrEmpty("Atribuição", Atribuicao.ValidationResult.Erros);
        }
    }
}
