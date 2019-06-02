using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Extensions;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate
{
    public class Usuario : Entity, IAggregateRoot
    {
        private Dictionary<string, IReadOnlyDictionary<string, string>> _erros;

        public NomeCompleto Nome { get; private set; }
        public Sexo Sexo { get; private set; }
        public Email Email { get; private set; }
        public CPF CPF { get; private set; }
        public DataDeNascimento DataDeNascimento { get; private set; }
        public Telefone Telefone { get; private set; }
        public Celular Celular { get; private set; }
        public Status Status { get; private set; }
        public Endereco Endereco { get; private set; }
        public Guid PerfilId { get; private set; }

        public IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> Erros => _erros;

        protected Usuario()
        {
            _erros = new Dictionary<string, IReadOnlyDictionary<string, string>>();
        }

        public Usuario(NomeCompleto nome, Sexo sexo, Email email, CPF cpf,
            DataDeNascimento dataDeNascimento, Guid perfilId)
            : this()
        {

            Id = Guid.NewGuid();
            Status = Status.Ativo;

            Nome = nome;
            Sexo = sexo;
            Email = email;
            CPF = cpf;
            DataDeNascimento = dataDeNascimento;
            PerfilId = perfilId;
        }

        private void Validar()
        {
            _erros.AddIfNotNullOrEmpty("Nome", Nome.ValidationResult.Erros);
            _erros.AddIfNotNullOrEmpty("Sexo", Sexo.ValidationResult.Erros);
            _erros.AddIfNotNullOrEmpty("Email", Email.ValidationResult.Erros);
            _erros.AddIfNotNullOrEmpty("CPF", CPF.ValidationResult.Erros);
            _erros.AddIfNotNullOrEmpty("DataDeNascimento", DataDeNascimento.ValidationResult.Erros);
        }

        public bool EhValido()
        {
            Validar();
            return !_erros.Any();
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            _erros.AddIfNotNullOrEmpty("Endereco", endereco.ValidationResult.Erros);

            if (!EhValido()) return;

            Endereco = endereco;
        }

        public void AdicionarTelefone(Telefone telefone)
        {
            _erros.AddIfNotNullOrEmpty("Telefone", telefone.ValidationResult.Erros);
            if (!EhValido()) return;

            Telefone = telefone;
        }

        public void AdicionarCelular(Celular celular)
        {
            _erros.AddIfNotNullOrEmpty("Celular", celular.ValidationResult.Erros);
            if (!EhValido()) return;
            Celular = celular;
        }

        public void Deletar()
        {
            //TODO: Logica para deletar usuário, atualmente será softdelete (update no banco).
            //Apenas sera desativado.
            if (Status.Equals(Status.Ativo))
            {
                Status = Status.Inativo;
            }
        }

        public static class UsuarioFactory
        {
            public static Usuario CriarUsuario(NomeCompleto nome, Sexo sexo, Email email,
                CPF cpf, DataDeNascimento dataDeNascimento,
                Guid perfilId, Celular celular, Telefone telefone, Endereco endereco)
            {
                var usuario = new Usuario(nome, sexo, email, cpf, dataDeNascimento, perfilId);

                usuario.AdicionarTelefone(telefone);
                usuario.AdicionarCelular(celular);
                usuario.AdicionarEndereco(endereco);

                return usuario;
            }
        }
    }
}