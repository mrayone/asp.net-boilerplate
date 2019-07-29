using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.ValueObjects;
using System;

namespace IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate
{
    public class AtribuicaoPerfil : Entity
    {
        public bool Status { get; private set; }
        public Guid PermissaoId { get; private set; }

        protected AtribuicaoPerfil()
        {
            Id = Guid.NewGuid();
        }

        public AtribuicaoPerfil(Guid permissaoId) : this()
        {
            Status = true;
            PermissaoId = permissaoId;
        }

        public void DesativarAssinatura()
        {
            Status = false;
        }

        public void AtivarAssinatura()
        {
            Status = true;
        }

        public static class PermissaoAssinadaFactory
        {
            public static AtribuicaoPerfil GerarAtribuicaoAtiva(Guid? id, Guid permissaoId)
            {
                return new AtribuicaoPerfil()
                {
                    Id = id.HasValue ? id.Value : Guid.NewGuid(),
                    PermissaoId = permissaoId,
                    Status = true
                };
            }
        }
    }
}
