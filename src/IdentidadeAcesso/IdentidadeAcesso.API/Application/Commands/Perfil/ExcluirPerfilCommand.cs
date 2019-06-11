using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.Perfil
{
    public class ExcluirPerfilCommand : BasePerfilCommand<ExcluirPerfilCommand>
    {
        public ExcluirPerfilCommand(Guid id)
        {
            Id = id;
        }

        public override bool isValid()
        {
            return true;
        }
    }
}
