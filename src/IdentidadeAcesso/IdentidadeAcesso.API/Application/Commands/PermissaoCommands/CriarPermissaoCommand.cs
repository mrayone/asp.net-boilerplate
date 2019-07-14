using IdentidadeAcesso.API.Application.Behaviors;
using IdentidadeAcesso.API.Application.Validations.Permissao;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PermissaoCommands
{
    public class CriarPermissaoCommand : BasePermissaoCommand<CriarPermissaoCommand>
    {
        public CriarPermissaoCommand(string tipo, string valor)
        {
            Tipo = tipo;
            Valor = valor;
        }
    }
}
