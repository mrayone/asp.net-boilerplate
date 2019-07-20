using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.ValueObjects;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using System;

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
            Atribuicao = atribuicao ?? throw new ArgumentNullException("Não é possível definir uma atribuição nula.");
        }

        public void Deletar()
        {
            DeletadoEm = DateTime.Now;
        } 

        public abstract class PermissaoFactory
        {
            public static Permissao CriarPermissao(Guid? id, string tipo, string valor)
            {
                return new Permissao()
                {
                    Id = id.HasValue ? id.Value : Guid.NewGuid(),
                    Atribuicao = new Atribuicao(tipo, valor)
                };
            }
        }
    }
}
