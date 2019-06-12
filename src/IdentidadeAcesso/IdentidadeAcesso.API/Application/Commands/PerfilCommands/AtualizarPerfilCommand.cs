using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands
{
    public class AtualizarPerfilCommand : BasePerfilCommand<AtualizarPerfilCommand>
    {
        public AtualizarPerfilCommand(Guid id, string nome, string descricao, bool status,
            IList<PermissaoAssinadaDTO> permissoesAssinadas)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Status = status;
            PermissoesAssinadas = permissoesAssinadas;
        }

        public override bool isValid()
        {
            return true;
        }
    }
}
