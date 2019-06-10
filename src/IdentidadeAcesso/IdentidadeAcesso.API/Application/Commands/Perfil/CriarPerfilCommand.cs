using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.Perfil
{
    public class CriarPerfilCommand : BasePerfilCommand<CriarPerfilCommand>
    {
        public CriarPerfilCommand(Guid id, string nome, string descricao, string status,
            IList<PermissaoAssinadaDTO> permissoesAssinadas)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Status = status;
            PermissoesAssinadas = permissoesAssinadas;
        }

    }
}
