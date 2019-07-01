using FluentValidation;
using IdentidadeAcesso.API.Application.Commands.UsuarioCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Validations.Usuario
{
    public abstract class ValidacaoUsuario<T> : AbstractValidator<T> where T : BaseUsuarioCommand<T>
    {
        public ValidacaoUsuario()
        {
           
        }
    }
}
