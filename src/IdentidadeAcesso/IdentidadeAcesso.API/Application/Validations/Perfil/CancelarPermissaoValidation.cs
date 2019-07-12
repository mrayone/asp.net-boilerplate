using FluentValidation;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Validations.Perfil
{
    public class CancelarPermissaoValidation : ValidacaoPermissaoPerfil<CancelarPermissaoPerfilCommand>
    {
        public CancelarPermissaoValidation() : base()
        {
        }
    }
}
