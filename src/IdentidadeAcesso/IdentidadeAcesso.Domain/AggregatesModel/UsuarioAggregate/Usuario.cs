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
        public DateTime? DeletadoEm { get; private set; }
        public Guid PerfilId { get; private set; }
        protected Usuario()
        {

            Status = Status.Ativo;
        }

        public Usuario(NomeCompleto nome, Sexo sexo, Email email, CPF cpf,
            DataDeNascimento dataDeNascimento, Guid perfilId)
            : this()
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Sexo = sexo;
            Email = email;
            CPF = cpf;
            DataDeNascimento = dataDeNascimento;
            PerfilId = perfilId;
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }

        public void AdicionarTelefone(Telefone telefone)
        {
            Telefone = telefone;
        }

        public void AdicionarCelular(Celular celular)
        {
            Celular = celular;
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

        public static class UsuarioFactory
        {
            public static Usuario CriarUsuario(Guid? id, NomeCompleto nome, Sexo sexo, Email email,
                CPF cpf, DataDeNascimento dataDeNascimento,
                Guid perfilId, Celular celular, Telefone telefone, Endereco endereco)
            {
                var usuario = new Usuario
                {
                    Nome = nome,
                    Sexo = sexo,
                    DataDeNascimento = dataDeNascimento,
                    Email = email,
                    CPF = cpf,
                    PerfilId = perfilId,
                    Id = id.HasValue ? id.Value : Guid.NewGuid()
                };

                usuario.AdicionarCelular(celular);

                if(telefone != null) usuario.AdicionarTelefone(telefone);
                if(endereco != null) usuario.AdicionarEndereco(endereco);


                return usuario;
            }
        }
    }
}