using IdentidadeAcesso.API.Application.Validations.Perfil;
using MediatR;
using System;
using System.Collections.Generic;

namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands
{
    public class CriarPerfilCommand : BasePerfilCommand<CriarPerfilCommand>
    {
        public CriarPerfilCommand(string nome, string descricao, List<AtribuicaoDTO> atribuicoes)
        {
            Nome = nome;
            Descricao = descricao;
            Atribuicoes = atribuicoes;
        }
    }
}
