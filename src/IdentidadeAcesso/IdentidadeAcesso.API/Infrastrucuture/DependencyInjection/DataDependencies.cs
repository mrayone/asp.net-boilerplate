using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.Repository;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Repository;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using Knowledge.IO.Infra.Data.Context;
using Knowledge.IO.Infra.Data.Repository;
using Knowledge.IO.Infra.Data.UoW;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Infrastrucuture.DependencyInjection
{
    public static class DataDependencies
    {
        public static IServiceCollection AddDataDependencies(this IServiceCollection services)
        {
            services.TryAddScoped<IUsuarioRepository, UsuarioRepository>();
            services.TryAddScoped<IPerfilRepository, PerfilRepository>();
            services.TryAddScoped<IPermissaoRepository, PermissaoRepository>();
            services.TryAddScoped<IUnitOfWork, UnitOfWork>();
            services.TryAddScoped<IdentidadeAcessoContext>();

            return services;
        }
    }
}
