using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.ValueObjects;
using IdentidadeAcesso.Domain.SeedOfWork;
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

        protected Permissao(){ }
        public Permissao (Atribuicao atribuicao)
        {
            Id = Guid.NewGuid();
            Atribuicao = atribuicao;
        }
    }
}
