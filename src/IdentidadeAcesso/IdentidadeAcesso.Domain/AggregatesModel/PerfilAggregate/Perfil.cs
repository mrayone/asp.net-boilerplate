using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.ValueObjects;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate;
using IdentidadeAcesso.Domain.Exceptions;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Extensions;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate
{
    public class Perfil : Entity, IAggregateRoot
    {
        private List<PermissaoAssinada> _permissoesAssinadas;
        public Identificacao Identifacao { get; private set; }
        public IReadOnlyCollection<PermissaoAssinada> PermissoesAssinadas => _permissoesAssinadas;
        public DateTime? DeletadoEm { get; private set; }

        public Status Status { get; private set; }

        protected Perfil()
        {
            Id = Guid.NewGuid();
        }

        public Perfil(Identificacao identificacao) : this()
        {
            Identifacao = identificacao;
            _permissoesAssinadas = new List<PermissaoAssinada>();
        }

        public void AssinarPermissao(Guid permissaoId)
        {
            var permissaoExistente = EncontrarPermissao(permissaoId);
            if (permissaoExistente != null)
            {
                permissaoExistente.AtivarAssinatura();
            }
            else
            {
                var permissaoAssinada = new PermissaoAssinada(permissaoId);
                permissaoAssinada.AtivarAssinatura();
                _permissoesAssinadas.Add(permissaoAssinada);
            }
        }

        public void CancelarPermissao(Guid permissaoId)
        {
            var permissaoExistente = EncontrarPermissao(permissaoId);
            if (permissaoExistente == null)
            {
                return;
            }
            permissaoExistente.DesativarAssinatura();
        }

        public void Deletar()
        {
            DeletadoEm = DateTime.Now;
        }

        private PermissaoAssinada EncontrarPermissao(Guid permissaoId)
        {
            var permissaoEncontrada = _permissoesAssinadas.Where(p => p.PermissaoId == permissaoId).FirstOrDefault();

            return permissaoEncontrada;
        }
    }
}
