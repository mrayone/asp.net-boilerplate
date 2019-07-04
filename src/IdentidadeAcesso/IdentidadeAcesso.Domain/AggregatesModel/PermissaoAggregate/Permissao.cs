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

        public DateTime? DeletadoEm { get; private set; }

        protected Permissao()
        {
            Id = Guid.NewGuid();
        }
        public Permissao (Atribuicao atribuicao) : this()
        {
            Atribuicao = atribuicao;
        }

        public void DefinirAtribuicao(Atribuicao atribuicao)
        {
            Atribuicao = atribuicao;
        }

        public void Deletar()
        {
            DeletadoEm = DateTime.Now;
        } 


        public abstract class PermissaoFactory
        {
            public static Permissao CriarPermissao(Guid? id, Atribuicao atr)
            {
                return new Permissao()
                {
                    Id = id.HasValue ? id.Value : Guid.NewGuid(),
                    Atribuicao = atr
                };
            }
        }
    }
}
