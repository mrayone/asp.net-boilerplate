using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.UsuarioCommands
{
    public class AtualizarPerfilUsuarioCommand : BaseUsuarioCommand<AtualizarPerfilUsuarioCommand>
    {
        public AtualizarPerfilUsuarioCommand(Guid id, string nome, string sobrenome, string sexo, string email, string cpf, DateTime dateDeNascimento, string telefone, string celular,
                string logradouro, string numero, string complemento, string bairro, string cep, string cidade, string estado)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Sexo = sexo;
            Email = email;
            CPF = cpf;
            DataDeNascimento = dateDeNascimento;
            Telefone = telefone;
            Celular = celular;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            CEP = cep;
            Cidade = cidade;
            Estado = estado;
            Id = id;
        }
    }
}
