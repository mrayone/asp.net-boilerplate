﻿using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.ValueObjects;
using System;

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
        public DateTime? DeletadoEm { get; private set; }
        public Guid PerfilId { get; private set; }
        protected Usuario()
        {
            Id = Guid.NewGuid();
            Status = Status.Ativo;
        }

        public Usuario(NomeCompleto nome, Sexo sexo, Email email, CPF cpf,
            DataDeNascimento dataDeNascimento)
            : this()
        {
            Nome = nome;
            Sexo = sexo;
            Email = email;
            CPF = cpf;
            DataDeNascimento = dataDeNascimento;
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            Endereco = endereco ?? throw new ArgumentNullException("Não é possível atribuir um endereço nulo.");
        }

        public void AdicionarTelefone(Telefone telefone)
        {
            Telefone = telefone ?? throw new ArgumentNullException("Não é possível atribuir um telefone nulo.");
        }

        public void AdicionarCelular(Celular celular)
        {
            Celular = celular ?? throw new ArgumentNullException("Não é possível atribuir um celular nulo.");
        }

        public void Deletar()
        {
            DeletadoEm = DateTime.Now;
        }

        public void DesativarUsuario ()
        {
             Status = Status.Inativo;
        }

        public void AtivarUsuario()
        {
            Status = Status.Ativo;
        }

        internal void SetarPerfil(Guid? perfilId)
        {
            PerfilId = perfilId.HasValue ? perfilId.Value : throw new ArgumentNullException("Não é possível setar um perfil nulo.");
        }

        public static class UsuarioFactory
        {
            public static Usuario CriarUsuario(Guid? id, string nome, string sobrenome, Sexo sexo, string email,
                string cpf, DateTime dataDeNascimento, Celular celular, Telefone telefone, Endereco endereco)
            {
                var usuario = new Usuario
                {
                    Nome = new NomeCompleto(nome, sobrenome),
                    Sexo = sexo,
                    DataDeNascimento = new DataDeNascimento(dataDeNascimento),
                    Email = new Email(email),
                    CPF = new CPF(cpf),
                    Id = id.HasValue ? id.Value : Guid.NewGuid()
                };

                usuario.AdicionarCelular(celular);

               // if(telefone != null) usuario.AdicionarTelefone(telefone);
                if(endereco != null) usuario.AdicionarEndereco(endereco);


                return usuario;
            }
        }
    }
}