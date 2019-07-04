using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.SeedOfWork.Commands.CommandHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Extensions
{
    public static class PerfilExtensionCommand
    {
        public static Perfil DefinirPerfil<T>(this CommandHandler command, BasePerfilCommand<T> request) where T : BasePerfilCommand<T>
        {
            var perfil = Perfil.PerfilFactory.NovoPerfil(request.Id, request.Nome, request.Descricao);

            foreach (var item in request.PermissoesAssinadas)
            {
                perfil.AssinarPermissao(item.PermissaoId);
            }

            return perfil;
        }
    }
}
