using IdentidadeAcesso.Domain.SeedOfWork;
using System;

namespace IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate
{
    public class PerfilPermissao : Entity
    {
        public Guid PermissaoId { get; private set; }
        public bool Ativo { get; private set; }

        protected PerfilPermissao() { }
        public PerfilPermissao(Guid permissaoId, bool ativo)
        {
            Id = Guid.NewGuid();
            Ativo = ativo;
            PermissaoId = permissaoId;
        }

        public bool EhValido()
        {
            return true;
        }

        public void DesativarPermissao()
        {
            Ativo = false;
        }

        public void AtivarPermissao()
        {
            Ativo = true;
        }

        public PerfilPermissao Clone()
        {
            return (PerfilPermissao) this.MemberwiseClone();
        }
    }
}