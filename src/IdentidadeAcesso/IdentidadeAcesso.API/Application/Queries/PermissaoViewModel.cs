using System;
using System.ComponentModel.DataAnnotations;

namespace IdentidadeAcesso.API.Application.Queries
{
    public class PermissaoViewModel
    {
        [Key]
        public Guid Id { get;  set; }
        [Required]
        public string Tipo { get;  set; }
        [Required]
        public string Valor { get; set; }
    }
}