using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentidadeAcesso.API.Application.Queries
{
    public class PerfilViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }
        public bool Status { get; set; }
        public IList<PermissaoAssinadaDTO> PermissoesAssinadas { get; set; }
    }
}