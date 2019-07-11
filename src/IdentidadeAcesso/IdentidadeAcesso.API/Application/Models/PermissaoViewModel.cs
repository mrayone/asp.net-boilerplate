using System;
using System.ComponentModel.DataAnnotations;

namespace IdentidadeAcesso.API.Application.Models
{
    public class PermissaoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public string Valor { get; set; }
    }
}