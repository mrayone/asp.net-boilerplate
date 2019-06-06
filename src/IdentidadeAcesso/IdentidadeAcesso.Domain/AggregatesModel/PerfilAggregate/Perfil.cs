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
        private List<Permissao> _permissoes;

        public Identificacao Identifacao { get; private set; }
        public IReadOnlyCollection<Permissao> Permissoes => _permissoes;

        public DateTime DeletadoEm { get; private set; }

        public Status Status { get; private set; }

        protected Perfil()
        {
            Id = Guid.NewGuid();
        }

        public Perfil(Identificacao identificacao) : this()
        {
            Identifacao = identificacao;
            _permissoes = new List<Permissao>();
        }

        public void AdicionarPermissao(Permissao permissao)
        {
            if(EncontrarPermissao(permissao) == null)
            {
                _permissoes.Add(permissao);
                return;
            }

            _erros.AddIfNotExits($"A permissão [{permissao.Atribuicao.Tipo} {permissao.Atribuicao.Valor}] já existe.");
        }

        private Permissao EncontrarPermissao(Permissao permissao)
        {
            var existePermissao = _permissoes.Where(p => p == permissao).FirstOrDefault() ?? null;

            return existePermissao;
        }

        public void DeletarPerfil()
        {
            if (_permissoes.Where(p => p.Status == Status.Ativo).Any())
            {
                _erros.AddIfNotExits("Este perfil não pode ser deletado pois possui permissões ativas.");
                return;
            }

            Status = Status.Inativo;
        }

        public void DesativarPermissao(Permissao permissao)
        {
            var permissaoParaDesativar = EncontrarPermissao(permissao);
            if(permissaoParaDesativar != null)
            {
                permissaoParaDesativar.Desativar();
                return;
            }
            _erros.AddIfNotExits($"A permissão [{permissao.Atribuicao.Tipo} {permissao.Atribuicao.Valor}] não foi vinculada.");
        }
    }
}
