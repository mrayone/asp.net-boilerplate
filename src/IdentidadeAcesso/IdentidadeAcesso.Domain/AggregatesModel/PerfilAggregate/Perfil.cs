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
        private List<AtribuicaoPerfil> _atribuicoes;
        public Identificacao Identifacao { get; private set; }
        public IReadOnlyCollection<AtribuicaoPerfil> Atribuicoes => _atribuicoes;
        public DateTime? DeletadoEm { get; private set; }

        protected Perfil()
        {
            Id = Guid.NewGuid();
            _atribuicoes = new List<AtribuicaoPerfil>();
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
                var permissaoAssinada = new AtribuicaoPerfil(permissaoId);
                _atribuicoes.Add(permissaoAssinada);
            }
        }

        internal void CancelarPermissao(Guid permissaoId)
        {
            var permissaoExistente = EncontrarPermissao(permissaoId);
            if (permissaoExistente == null)
            {
                var permissaoAssinada = new AtribuicaoPerfil(permissaoId);
                permissaoAssinada.DesativarAssinatura();
                _atribuicoes.Add(permissaoAssinada);
            }
            else
            {
                permissaoExistente.DesativarAssinatura();
            }
        }

        public void Deletar()
        {
            DeletadoEm = DateTime.Now;
        }

        private AtribuicaoPerfil EncontrarPermissao(Guid permissaoId)
        {
            var permissaoEncontrada = _atribuicoes.Where(p => p.PermissaoId == permissaoId).FirstOrDefault();

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
