using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.ValueObjects;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate
{
    public class Permissao : Entity, IAggregateRoot
    {
        
        public Atribuicao Atributo { get; private set; }

        public Dictionary<string, IReadOnlyDictionary<string, string>> _erros;

        public IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> Erros => _erros;

        public Permissao ()
        {
            Id = Guid.NewGuid();
            _erros = new Dictionary<string, IReadOnlyDictionary<string, string>>();
        }

        private Permissao(Atribuicao atribuicao) : this() { }

        public Permissao CriarPermissao(Atribuicao atribuicao)
        {
            //TODO: Lógica de Validação

            return new Permissao(atribuicao);
        }
    }
}
