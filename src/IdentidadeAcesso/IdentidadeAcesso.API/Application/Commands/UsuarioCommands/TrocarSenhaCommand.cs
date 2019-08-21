using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using IdentidadeAcesso.Domain.SeedOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.UsuarioCommands
{
    public class TrocarSenhaCommand : IRequest<CommandResponse>
    {
        public TrocarSenhaCommand(Guid usuarioId, string senhaAtual, string senha, string confirmaSenha)
        {
            UsuarioId = usuarioId;
            SenhaAtual = senhaAtual;
            Senha = senha;
            ConfirmaSenha = confirmaSenha;
        }

        public Guid UsuarioId { get; }
        public string SenhaAtual { get; set; }
        public string Senha { get; }
        public string ConfirmaSenha { get; }
    }
}
