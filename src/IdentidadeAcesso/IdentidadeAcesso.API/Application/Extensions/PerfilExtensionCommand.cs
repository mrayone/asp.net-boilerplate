using IdentidadeAcesso.API.Application.Commands.CommandHandler;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;

namespace IdentidadeAcesso.API.Application.Extensions
{
    public static class PerfilExtensionCommand
    {
        public static Perfil DefinirPerfil<T>(this BaseCommandHandler command, BasePerfilCommand<T> request) where T : BasePerfilCommand<T>
        {
            var perfil = Perfil.PerfilFactory.NovoPerfil(request.Id, request.Nome, request.Descricao);

            return perfil;
        }
    }
}
