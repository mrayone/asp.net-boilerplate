using IdentidadeAcesso.API.Application.Behaviors;
using IdentidadeAcesso.API.Application.Validations.Permissao;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PermissaoCommands
{
    public class AtualizarPermissaoCommand : BasePermissaoCommand<AtualizarPermissaoCommand>
    {
        public AtualizarPermissaoCommand(Guid id, string tipo, string valor)
        {
            Valor = valor;
            Tipo = tipo;
            Id = id;
        }
    }
}
