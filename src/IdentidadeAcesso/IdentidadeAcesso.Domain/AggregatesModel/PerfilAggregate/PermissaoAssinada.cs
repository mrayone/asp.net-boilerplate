using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.ValueObjects;
using System;

namespace IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate
{
    public class PermissaoAssinada : Entity
    {
        public Status Status { get; private set; }
        public Guid PermissaoId { get; private set; }
        
        protected PermissaoAssinada() { }

        public PermissaoAssinada(Guid permissaoId)
        {
            Id = Guid.NewGuid();
            Status = Status.Inativo;
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
            public static PermissaoAssinada GerarPermissaoAssinada(Guid id, Guid permissaoId)
            {
                return new PermissaoAssinada()
                {
                    Id = id,
                    PermissaoId = permissaoId,
                    Status = Status.Ativo
                };
            }
        }
    }
}
