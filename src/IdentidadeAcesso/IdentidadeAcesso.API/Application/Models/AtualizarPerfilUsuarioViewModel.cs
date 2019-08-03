using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Models
{
    public class AtualizarPerfilUsuarioViewModel
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
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
