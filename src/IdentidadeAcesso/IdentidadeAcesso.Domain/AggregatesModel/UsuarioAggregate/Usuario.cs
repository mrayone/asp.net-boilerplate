using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Extensions;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate
{
    public class Usuario : Entity, IAggregateRoot
    {
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


        protected Usuario()
        {
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

        public override bool EhValido()
        {
            _erros.AddRangeIfNotEmpty(Nome.ValidationResult.Erros);
            _erros.AddRangeIfNotEmpty(Sexo.ValidationResult.Erros);
            _erros.AddRangeIfNotEmpty(Email.ValidationResult.Erros);
            _erros.AddRangeIfNotEmpty(CPF.ValidationResult.Erros);

            return base.EhValido();
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            if (!endereco.EhValido())
            {
                _erros.AddRangeIfNotEmpty(endereco.ValidationResult.Erros);
                return;
            }

            Endereco = endereco;
        }

        public void AdicionarTelefone(Telefone telefone)
        {
            if (!telefone.EhValido())
            {
                _erros.AddRangeIfNotEmpty(telefone.ValidationResult.Erros);
                return;
            }

            Telefone = telefone;
        }

        public void AdicionarCelular(Celular celular)
        {
            if (!celular.EhValido())
            {
                _erros.AddRangeIfNotEmpty(celular.ValidationResult.Erros);
                return;
            }

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