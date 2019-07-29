using FluentValidation.Results;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.UsuarioCommands
{
    public abstract class BaseUsuarioCommand<T> : IRequest<CommandResponse> where T : BaseUsuarioCommand<T>
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Sobrenome { get; protected set; }
        public string Sexo { get; protected set; }
        public string Email { get; protected set; }
        public string CPF { get; protected set; }
        public DateTime DataDeNascimento { get; protected set; }
        public Guid PerfilId { get; protected set; }
        public string Telefone { get; protected set; }
        public string Celular { get; protected set; }
        public bool Status { get; protected set; }
        public string Logradouro { get; protected set; }
        public string Numero { get; protected set; }
        public string Complemento { get; protected set; }
        public string Bairro { get; protected set; }
        public string CEP { get; protected set; }
        public string Cidade { get; protected set; }
        public string Estado { get; protected set; }
    }
}
