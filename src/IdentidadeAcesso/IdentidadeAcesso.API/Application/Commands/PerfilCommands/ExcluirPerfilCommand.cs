using IdentidadeAcesso.API.Application.Validations.Perfil;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands
{
    public class ExcluirPerfilCommand : BasePerfilCommand<ExcluirPerfilCommand>
    {
        public ExcluirPerfilCommand(Guid id)
        {
            Id = id;
        }
    }
}
