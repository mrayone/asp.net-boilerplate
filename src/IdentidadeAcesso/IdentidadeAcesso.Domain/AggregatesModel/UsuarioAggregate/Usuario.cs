using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate
{
    public class Usuario : Entity, IAggregateRoot
    {
        public Nome Nome { get; private set; }
        public Sexo Sexo { get; private set; }
        public Email Email { get; private set; }
        public CPF CPF { get; private set; }
        public DataDeNascimento DataDeNascimento { get; private set; }
        public Telefone Telefone { get; private set; }
        public Celular Celular { get; private set; }
        public Status Status { get; private set; }
        public Endereco Endereco { get; private set; }
        public Guid PerfilId { get; private set; }

        public Dictionary<string, IReadOnlyDictionary<string, string>> Erros { get; private set; }

        protected Usuario()
        {
            Id = Guid.NewGuid();
            Status = Status.Ativo;
        }

        public Usuario(Nome nome, Sexo sexo, Email email, CPF cpf,
            DataDeNascimento dataDeNascimento, Guid perfilId)
            : this()
        {
            Nome = nome;
            Sexo = sexo;
            Email = email;
            CPF = cpf;
            DataDeNascimento = dataDeNascimento;
            PerfilId = perfilId;

            Erros = new Dictionary<string, IReadOnlyDictionary<string, string>>();

            Validar();
        }

        private void Validar()
        {
            Erros.AddIfNotNullOrEmpty("Nome", Nome.ValidationResult.Erros);
            Erros.AddIfNotNullOrEmpty("Sexo", Sexo.ValidationResult.Erros);
            Erros.AddIfNotNullOrEmpty("Email", Email.ValidationResult.Erros);
            Erros.AddIfNotNullOrEmpty("CPF", CPF.ValidationResult.Erros);
            Erros.AddIfNotNullOrEmpty("DataDeNascimento", DataDeNascimento.ValidationResult.Erros);
        }

        public bool EhValido()
        {
            return !Erros.Any();
        }
    }
}