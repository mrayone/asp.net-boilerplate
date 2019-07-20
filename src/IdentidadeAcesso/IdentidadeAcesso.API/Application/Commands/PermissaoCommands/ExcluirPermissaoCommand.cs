using IdentidadeAcesso.API.Application.Validations.Permissao;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PermissaoCommands
{
    public class ExcluirPermissaoCommand : BasePermissaoCommand<ExcluirPermissaoCommand>
    {
        public ExcluirPermissaoCommand(Guid permissaoId)
        {
            PermissaoId = permissaoId;
        }

        public Guid PermissaoId { get; private set; }
    }
}
