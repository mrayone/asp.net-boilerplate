using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentidadeAcesso.API.Application.Models
{
    public class PerfilViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome deve ser informado.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição deve ser informada.")]
        public string Descricao { get; set; }
        public bool Status { get; set; }
        public IList<PermissaoAssinadaDTO> PermissoesAssinadas { get; set; }
    }
}