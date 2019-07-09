using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
using System;
using System.Collections.Generic;

namespace IdentidadeAcesso.API.Application.Queries
{
    public class PerfilViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Status { get; set; }
        public IList<PermissaoAssinadaDTO> PermissoesAssinadas { get; set; }
    }
}