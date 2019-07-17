using IdentidadeAcesso.API.Application.Validations.Perfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands
{
    public class AssinarPermissaoCommand : BasePermissaoPerfil<AssinarPermissaoCommand>
    {
        public AssinarPermissaoCommand(Guid perfilId, IList<AssinaturaDTO> assinaturas)
        {
            Assinaturas = assinaturas;
            PerfilId = perfilId;
        }

    }

    public class AssinaturaDTO
    {
        public Guid PermissaoId { get; set; }
    }
}
