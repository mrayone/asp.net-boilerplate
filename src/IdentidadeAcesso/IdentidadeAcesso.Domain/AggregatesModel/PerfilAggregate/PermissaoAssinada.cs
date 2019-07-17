using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.ValueObjects;
using System;

namespace IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate
{
    public class PermissaoAssinada : Entity
    {
        public Status Status { get; private set; }
        public Guid PermissaoId { get; private set; }

        protected PermissaoAssinada()
        {
            Id = Guid.NewGuid();
        }

        public PermissaoAssinada(Guid permissaoId) : this()
        {
            Status = Status.Ativo;
            PermissaoId = permissaoId;
        }

        public void DesativarAssinatura()
        {
            Status = Status.Inativo;
        }

        public void AtivarAssinatura()
        {
            Status = Status.Ativo;
        }

        public static class PermissaoAssinadaFactory
        {
            public static PermissaoAssinada GerarPermissaoAssinada(Guid? id, Guid permissaoId)
            {
                return new PermissaoAssinada()
                {
                    Id = id.HasValue ? id.Value : Guid.NewGuid(),
                    PermissaoId = permissaoId,
                    Status = Status.Ativo
                };
            }
        }
    }
}
