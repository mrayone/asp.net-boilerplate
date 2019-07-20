using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.ValueObjects;
using System;

namespace IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate
{
    public class PermissaoAssinada : Entity
    {
        public bool Status { get; private set; }
        public Guid PermissaoId { get; private set; }

        protected PermissaoAssinada()
        {
            Id = Guid.NewGuid();
        }

        public PermissaoAssinada(Guid permissaoId) : this()
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
            public static PermissaoAssinada GerarPermissaoAssinada(Guid? id, Guid permissaoId)
            {
                return new PermissaoAssinada()
                {
                    Id = id.HasValue ? id.Value : Guid.NewGuid(),
                    PermissaoId = permissaoId,
                    Status = true
                };
            }
        }
    }
}
