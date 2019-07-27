using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace IdentidadeAcesso.API.Application.Models
{
    public class PermissaoViewModel : IQueryModel
    {
        [BindNever]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O Tipo deve ser preenchido")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "O Valor deve ser preenchido")]
        public string Valor { get; set; }
    }
}