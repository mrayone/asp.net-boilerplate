﻿using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentidadeAcesso.API.Application.Models
{
    public class PerfilViewModel
    {
        public PerfilViewModel()
        {
            PermissoesAssinadas = new List<AssinaturaDTO>();
        }

        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O nome deve ser informado.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A descrição deve ser informada.")]
        public string Descricao { get; set; }
        public IList<AssinaturaDTO> PermissoesAssinadas { get; set; }
    }

    public class PermissaoAssinadaViewModel
    {
        public Guid PerfilId { get; set; }
        public IList<AssinaturaDTO> Permissoes { get; set; }
    }
}