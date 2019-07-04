using IdentidadeAcesso.API.Application.Commands.PermissaoCommands;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.ValueObjects;
using IdentidadeAcesso.Domain.SeedOfWork.Commands.CommandHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Extensions
{
    public static class PermissaoExtensionsCommand
    {
        public static Permissao DefinirPermissao<T>(this CommandHandler command, BasePermissaoCommand<T> request) where T : BasePermissaoCommand<T>
        {
            var atribuicao = new Atribuicao(request.Tipo, request.Valor);
            return Permissao.PermissaoFactory.CriarPermissao(request.Id, atribuicao);
        }
    }
}
