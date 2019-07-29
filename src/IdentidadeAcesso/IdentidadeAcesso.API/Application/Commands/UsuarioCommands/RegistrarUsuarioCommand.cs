using IdentidadeAcesso.Domain.SeedOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.UsuarioCommands
{
    public class RegistrarUsuarioCommand : IRequest<CommandResponse>
    {
        public RegistrarUsuarioCommand(string nome, string sobrenome, DateTime dataDeNascimento, string email, string sexo, 
            string senha, string confirmacaoSenha)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            DataDeNascimento = dataDeNascimento;
            Email = email;
            Sexo = sexo;
            Senha = senha;
            ConfirmacaoSenha = confirmacaoSenha;
        }

        public string Nome { get; }
        public string Sobrenome { get; }
        public DateTime DataDeNascimento { get; }
        public string Email { get; }
        public string Sexo { get; }
        public string Senha { get; }
        public string ConfirmacaoSenha { get; }
    }
}
