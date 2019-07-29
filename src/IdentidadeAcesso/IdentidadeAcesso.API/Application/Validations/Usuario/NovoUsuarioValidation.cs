using FluentValidation;
using IdentidadeAcesso.API.Application.Commands.UsuarioCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Validations.Usuario
{
    public class NovoUsuarioValidation : ValidacaoUsuario<NovoUsuarioCommand>
    {
        public NovoUsuarioValidation() : base()
        {

        }
    }
}
