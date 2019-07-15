using IdentidadeAcesso.API.Application.Commands.CommandHandler;
using IdentidadeAcesso.API.Application.Commands.PermissaoCommands;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.ValueObjects;

namespace IdentidadeAcesso.API.Application.Extensions
{
    public static class PermissaoExtensionsCommand
    {
        public static Permissao DefinirPermissao<T>(this BaseCommandHandler command, BasePermissaoCommand<T> request) where T : BasePermissaoCommand<T>
        {
            return Permissao.PermissaoFactory.CriarPermissao(request.Id, request.Tipo, request.Valor);
        }
    }
}
