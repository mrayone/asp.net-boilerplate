using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands
{
    public class AssinarPermissaoPerfilCommand
    {
        public AssinarPermissaoPerfilCommand(Guid permissaoId, bool ativa)
        {
            PermissaoId = permissaoId;
            Ativa = ativa;
        }

        public Guid PermissaoId { get; private set; }
        public bool Ativa { get; private set; }
    }
}
