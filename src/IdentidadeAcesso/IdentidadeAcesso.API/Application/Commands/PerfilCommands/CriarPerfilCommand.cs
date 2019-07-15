using IdentidadeAcesso.API.Application.Validations.Perfil;
using MediatR;
using System;
using System.Collections.Generic;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands
{
    public class CriarPerfilCommand : BasePerfilCommand<CriarPerfilCommand>
    {
        public CriarPerfilCommand(string nome, string descricao, bool status)
        {
            Nome = nome;
            Descricao = descricao;
            Status = status;
        }
    }
}
