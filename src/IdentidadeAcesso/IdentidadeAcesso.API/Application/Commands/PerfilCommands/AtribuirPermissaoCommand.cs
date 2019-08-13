using IdentidadeAcesso.API.Application.Validations.Perfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands
{
    public class AtribuirPermissaoCommand : BasePermissaoPerfil<AtribuirPermissaoCommand>
    {
        public AtribuirPermissaoCommand(Guid perfilId, IList<AtribuicaoDTO> atribuicoes)
        {
            Atribuicoes = atribuicoes;
            PerfilId = perfilId;
        }

    }

    public class AtribuicaoDTO
    {
        public Guid PermissaoId { get; set; }
        public bool Ativo { get; set; }
    }
}
