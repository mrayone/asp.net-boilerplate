using IdentidadeAcesso.API.Application.Models;
using IdentidadeAcesso.API.Application.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Collections.Generic;

namespace IdentidadeAcesso.API.Infrastrucuture.IoC
{
    public static class ApplicationQueries
    {
        public static IServiceCollection AddApplicationQueries(this IServiceCollection services)
        {
            services.TryAddScoped<IRequestHandler<BuscarPorId<PermissaoViewModel>, PermissaoViewModel>, PermissaoQueries>();
            services.TryAddScoped<IRequestHandler<BuscarTodos<IEnumerable<PermissaoViewModel>>, IEnumerable<PermissaoViewModel>>, PermissaoQueries>();

            services.TryAddScoped<IRequestHandler<BuscarPorId<PerfilViewModel>, PerfilViewModel>, PerfilQueries>();
            services.TryAddScoped<IRequestHandler<BuscarTodos<IEnumerable<PerfilViewModel>>, IEnumerable<PerfilViewModel>>, PerfilQueries>();

            services.TryAddScoped<IRequestHandler<BuscarPorId<UsuarioViewModel>, UsuarioViewModel>, UsuarioQueries>();
            services.TryAddScoped<IRequestHandler<BuscarTodos<IEnumerable<UsuarioViewModel>>, IEnumerable<UsuarioViewModel>>, UsuarioQueries>();

            return services;
        }
    }
}
