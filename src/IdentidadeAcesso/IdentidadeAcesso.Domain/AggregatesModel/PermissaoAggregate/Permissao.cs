using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.ValueObjects;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate
{
    public class Permissao : Entity, IAggregateRoot
    {
        public Atribuicao Atribuicao { get; private set; }
        public Status Status { get; private set; }

        protected Permissao()
        {
            Id = Guid.NewGuid();
            Status = Status.Ativo;
        }
        public Permissao (Atribuicao atribuicao) : this()
        {
            Atribuicao = atribuicao;
        }

        public void Desativar()
        {
            Status = Status.Inativo;
        }
    }
}
