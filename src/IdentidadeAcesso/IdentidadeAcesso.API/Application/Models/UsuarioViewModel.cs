using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace IdentidadeAcesso.API.Application.Models
{
    public class UsuarioViewModel
    {
        [BindNever]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Nome deve ser informado.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O sobrenome deve ser informado.")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "O sexo deve ser informado.")]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "O e-mail deve ser informado.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O CPF deve ser informado.")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "A data de nascimento deve ser informada.")]
        public DateTime DateDeNascimento { get; set; }
        [Required]

        public Guid PerfilId { get; set; }
        [Required(ErrorMessage = "Um número de celular deve ser fornecido.")]
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public bool Status { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

    }
}