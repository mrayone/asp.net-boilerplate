using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.ValueObjects;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate
{
    public class Perfil : Entity, IAggregateRoot
    {
        private List<PermissaoAssinada> _permissoesAssinadas;
        public Identificacao Identifacao { get; private set; }
        public IReadOnlyCollection<PermissaoAssinada> PermissoesAssinadas => _permissoesAssinadas;
        public DateTime? DeletadoEm { get; private set; }

        protected Perfil()
        {
            Id = Guid.NewGuid();
            _permissoesAssinadas = new List<PermissaoAssinada>();
        }

        public Perfil(Identificacao identificacao) : this()
        {
            Identifacao = identificacao;
        }

        internal void AssinarPermissao(Guid permissaoId)
        {
            var permissaoExistente = EncontrarPermissao(permissaoId);
            if (permissaoExistente != null)
            {
                permissaoExistente.AtivarAssinatura();
            }
            else
            {
                var permissaoAssinada = new PermissaoAssinada(permissaoId);
                _permissoesAssinadas.Add(permissaoAssinada);
            }
        }

        internal void CancelarPermissao(Guid permissaoId)
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


        public class PerfilFactory
        {
            public static Perfil NovoPerfil(Guid? id, string nome, string descricao)
            {
                return new Perfil()
                {
                    Id = id.HasValue ? id.Value : Guid.NewGuid(),
                    Identifacao = new Identificacao(nome, descricao)
                };
            }

            public static Perfil NovoPerfilComAssinatura(Guid? id, string nome, string descricao, Guid permissaoId)
            {
                var perfil = new Perfil()
                {
                    Id = id.HasValue ? id.Value : Guid.NewGuid(),
                    Identifacao = new Identificacao(nome, descricao)
                };

                perfil.AssinarPermissao(permissaoId);

                return perfil;
            }
        }
    }
}
