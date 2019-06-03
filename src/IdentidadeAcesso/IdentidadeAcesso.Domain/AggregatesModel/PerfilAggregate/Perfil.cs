using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.ValueObjects;
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
        //TODO: Perfis não podem ser deletados quando houver: 
        // permissões registradas[x]
        // usuários vinculados - Vou precisar de um serviço de Dominio para verificar isso.
        //

        private List<PerfilPermissao> _permissoes;
        private Dictionary<string, IReadOnlyDictionary<string, string>> _erros;

        public Identificacao Identifacao { get; private set; }
        public IReadOnlyCollection<PerfilPermissao> Permissoes => _permissoes;
        public IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> Erros => _erros;

        public Status Status { get; private set; }

        protected Perfil()
        {
            Id = Guid.NewGuid();
        }

        public Perfil(Identificacao identificacao) : this()
        {
            Identifacao = identificacao;
            _permissoes = new List<PerfilPermissao>();
            _erros = new Dictionary<string, IReadOnlyDictionary<string, string>>();
            Validar();
        }

        private void Validar()
        {
            _erros.AddIfNotNullOrEmpty("Identificacao", Identifacao.ValidationResult.Erros);
        }

        public bool EhValido()
        {
            Validar();
            return !_erros.Any();
        }

        public void AdicionarPermissao(PerfilPermissao permissao)
        {
            if (_permissoes.Contains(permissao))
            {
                var index = _permissoes.IndexOf(permissao);
                _permissoes[index] = permissao;
                return;
            }

            _permissoes.Add(permissao);
        }

        public void DeletarPerfil()
        {
            if (_permissoes.Any()) throw new IdentidadeAcessoDomainException(nameof(DeletarPerfil));

            Status = Status.Inativo;
        }
    }
}
