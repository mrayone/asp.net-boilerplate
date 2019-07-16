using IdentidadeAcesso.API.Application.Behaviors;
using IdentidadeAcesso.API.Application.Commands.PermissaoCommands;
using IdentidadeAcesso.API.Application.Commands.PermissaoCommands.Handlers;
using IdentidadeAcesso.Domain.SeedOfWork;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Infrastrucuture.IoC
{
    public static class ApplicationHandlers
    {
        public static IServiceCollection AddApplicationHandlers(this IServiceCollection services)
        {
            //Permissão Handlers
            services.TryAddScoped<IRequestHandler<CriarPermissaoCommand, CommandResponse>, CriarPermissaoCommandHandler>();
            services.TryAddScoped<IRequestHandler<AtualizarPermissaoCommand, CommandResponse>, AtualizarPermissaoCommandHandler>();
            services.TryAddScoped<IRequestHandler<ExcluirPermissaoCommand, CommandResponse>, ExcluirPermissaoCommandHandler>();

            return services;
        }
    }
}
