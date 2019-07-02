﻿using FluentValidation.Results;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.UsuarioCommands
{
    public abstract class BaseUsuarioCommand<T> : ICommand, IRequest<bool> where T : BaseUsuarioCommand<T>
    {
        public string Nome { get; protected set; }
        public string Sobrenome { get; protected set; }
        public string Sexo { get; protected set; }
        public string Email { get; protected set; }
        public string CPF { get; protected set; }
        public DateTime DateDeNascimento { get; protected set; }
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

        public ValidationResult ValidationResult { get; protected set; }

        public abstract bool isValid();
    }
}
