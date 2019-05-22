using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate
{
    public class Usuario : Entity, IAggregateRoot
    {
        public Nome Nome { get; private set; }
        public Sexo Sexo { get; private set; }
        public Email Email { get; private set; }
        public Cpf Cpf { get; private set; }
        public Telefone Telefone { get; private set; }
        public Celular Celular { get; private set; }
        public bool Ativo { get; private set; }

        public Usuario()
        {
            Id = Guid.NewGuid();
        }
    }
}
