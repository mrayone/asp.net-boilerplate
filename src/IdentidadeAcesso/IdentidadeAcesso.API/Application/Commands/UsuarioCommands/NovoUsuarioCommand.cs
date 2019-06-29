using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.UsuarioCommands
{
    public class NovoUsuarioCommand : BaseUsuarioCommand<NovoUsuarioCommand>
    {
        public NovoUsuarioCommand(string nome, string sobrenome, string sexo, string email, string cpf, DateTime dateDeNascimento, string telefone, string celular, 
            bool status, string logradouro, string numero, string complemento, string bairro, string cep, string cidade, string estado)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Sexo = sexo;
            Email = email;
            CPF = cpf;
            DateDeNascimento = dateDeNascimento;
            Telefone = telefone;
            Celular = celular;
            Status = status;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;
        }

        public override bool isValid()
        {
            return false;
        }
    }
}
