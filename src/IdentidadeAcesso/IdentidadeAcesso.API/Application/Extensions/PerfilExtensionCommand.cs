using IdentidadeAcesso.API.Application.Commands.CommandHandler;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Extensions
{
    public static class PerfilExtensionCommand
    {
        public static Perfil DefinirPerfil<T>(this BaseCommandHandler command, BasePerfilCommand<T> request) where T : BasePerfilCommand<T>
        {
            var perfil = Perfil.PerfilFactory.NovoPerfil(request.Id, request.Nome, request.Descricao);

            return perfil;
        }

        public static async Task<bool> BuscarPerfil(this BaseCommandHandler command, System.Guid id, IPerfilRepository repository)
        {
            var perfil = repository.ObterPorId(id);
            if (perfil != null) return await Task.FromResult(true);

            return await Task.FromResult(false);
        }
    }
}
