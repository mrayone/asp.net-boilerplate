using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
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
        public NumerosContato NumerosContato { get; private set; }
        public bool Status { get; private set; }
        public Endereco Endereco { get; private set; }
        public Senha Senha { get; private set; }
        public DateTime? DeletadoEm { get; private set; }
        public Guid? PerfilId { get; private set; }
        protected Usuario()
        {
            Id = Guid.NewGuid();
            Status = true;
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

        public void DefinirSenha(Senha senha)
        {
            Senha = senha;
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            Endereco = endereco ?? throw new ArgumentNullException("Não é possível atribuir um endereço nulo.");
        }

        public void AdicionarCelular(NumerosContato numeros)
        {
            NumerosContato = numeros ?? throw new ArgumentNullException("Não é possível atribuir numeros de contato nulo.");
        }

        public void Deletar()
        {
            DeletadoEm = DateTime.Now;
        }

        public void DesativarUsuario ()
        {
            Status = false;
        }

        public void AtivarUsuario()
        {
            Status = false;
        }

        internal void SetarPerfil(Guid? perfilId)
        {
            PerfilId = perfilId;
        }

        public static class UsuarioFactory
        {
            public static Usuario CriarUsuario(Guid? id, string nome, string sobrenome, string sexo, string email,
                CPF cpf, DateTime dataDeNascimento, string celular, string telefone, Endereco endereco, Guid? perfilId, Senha senha)
            {
                var usuario = new Usuario
                {
                    Nome = new NomeCompleto(nome, sobrenome),
                    Sexo = sexo.Equals("F") ? Sexo.Feminino : Sexo.Masculino,
                    DataDeNascimento = new DataDeNascimento(dataDeNascimento),
                    Email = new Email(email),
                    CPF = cpf,
                    Id = id.HasValue ? id.Value : Guid.NewGuid(),
                    PerfilId = perfilId.Value
                };

                usuario.AdicionarCelular(new NumerosContato(celular, telefone));
                usuario.DefinirSenha(senha);

                if(endereco != null) usuario.AdicionarEndereco(endereco);

                return usuario;
            }
        }
    }
}