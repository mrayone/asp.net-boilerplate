using IdentidadeAcesso.API.Application.Validations.Perfil;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace IdentidadeAcesso.API.Application.Commands.PerfilCommands
{
    public class AtualizarPerfilCommand : BasePerfilCommand<AtualizarPerfilCommand>
    {
        public AtualizarPerfilCommand(Guid id, string nome, string descricao, List<AtribuicaoDTO> atribuicoes)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Atribuicoes = atribuicoes;
        }
    }
}
