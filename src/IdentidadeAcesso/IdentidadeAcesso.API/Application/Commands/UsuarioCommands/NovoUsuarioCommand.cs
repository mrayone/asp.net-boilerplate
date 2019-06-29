using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.UsuarioCommands
{
    public class NovoUsuarioCommand : BaseUsuarioCommand<NovoUsuarioCommand>
    {
        public NovoUsuarioCommand(string nome, string sobrenome, string sexo, string email, string cPF, DateTime dateDeNascimento, string telefone, 
            string celular, bool status, AdicionarEnderecoCommand endereco)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Sexo = sexo;
            Email = email;
            CPF = cPF;
            DateDeNascimento = dateDeNascimento;
            Telefone = telefone;
            Celular = celular;
            Status = status;
            Endereco = endereco;
        }

        public AdicionarEnderecoCommand Endereco { get; private set; }

        public override bool isValid()
        {
            return false;
        }
    }
}
