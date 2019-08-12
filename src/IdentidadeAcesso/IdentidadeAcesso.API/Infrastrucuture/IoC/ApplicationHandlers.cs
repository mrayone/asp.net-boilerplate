using IdentidadeAcesso.API.Application.Behaviors;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands.Handlers;
using IdentidadeAcesso.API.Application.Commands.PermissaoCommands;
using IdentidadeAcesso.API.Application.Commands.PermissaoCommands.Handlers;
using IdentidadeAcesso.API.Application.Commands.UsuarioCommands;
using IdentidadeAcesso.API.Application.Commands.UsuarioCommands.Handlers;
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


            //Perfil Handlers
            services.TryAddScoped<IRequestHandler<AtribuirPermissaoCommand, CommandResponse>, AtribuirPermissaoCommandHandler>();
            services.TryAddScoped<IRequestHandler<CriarPerfilCommand, CommandResponse>, CriarPerfilCommandHandler>();
            services.TryAddScoped<IRequestHandler<AtualizarPerfilCommand, CommandResponse>, AtualizarPerfilCommandHandler>();
            services.TryAddScoped<IRequestHandler<ExcluirPerfilCommand, CommandResponse>, ExcluirPerfilCommandHandler>();

            //Usuario Handlers
            services.TryAddScoped<IRequestHandler<NovoUsuarioCommand, CommandResponse>, NovoUsuarioCommandHandler>();
            services.TryAddScoped<IRequestHandler<AtualizarPerfilUsuarioCommand, CommandResponse>, AtualizarPerfilUsuarioCommandHandler>();
            services.TryAddScoped<IRequestHandler<AtualizarUsuarioCommand, CommandResponse>, AtualizarUsuarioCommandHandler>();
            services.TryAddScoped<IRequestHandler<ExcluirUsuarioCommand, CommandResponse>, ExcluirUsuarioCommandHandler>();

            return services;
        }
    }
}
