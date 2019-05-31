using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.ValueObjects;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate
{
    public class Perfil : Entity, IAggregateRoot
    {
        //TODO: Perfis não podem ser deletados se houver permissões registradas.
        //

        private List<Permissao> _permissoes;

        public Identificacao Identifacao { get; private set; }
        public Dictionary<string, IReadOnlyDictionary<string, string>> Erros { get; private set; }
        public IReadOnlyCollection<Permissao> Permissoes => _permissoes;

        protected Perfil()
        {
            Id = Guid.NewGuid();
        }

        public Perfil(Identificacao identificacao) : this()
        {
            Identifacao = identificacao;
            _permissoes = new List<Permissao>();
            Validar();
        }

        private void Validar()
        {
            
        }
    }
}
