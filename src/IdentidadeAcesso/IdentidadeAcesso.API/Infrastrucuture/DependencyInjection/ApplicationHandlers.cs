using IdentidadeAcesso.API.Application.Commands.PermissaoCommands;
using IdentidadeAcesso.API.Application.Commands.PermissaoCommands.Handlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Infrastrucuture.DependencyInjection
{
    public static class ApplicationHandlers
    {
        public static IServiceCollection AddApplicationHandlers(this IServiceCollection services)
        {
            services.TryAddScoped<IRequestHandler<CriarPermissaoCommand, bool>, CriarPermissaoCommandHandler>();

            return services;
        }
    }
}
