using IdentidadeAcesso.CrossCutting.Identity.CredentialsValidator;
using IdentidadeAcesso.CrossCutting.Identity.Policy;
using IdentidadeAcesso.CrossCutting.Identity.Policy.Handler;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.CrossCutting.Identity.Configuration
{
    public static class AppIdentityConfig
    {
        public static IServiceCollection AddIdentityConfig(this IServiceCollection services)
        {
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients());

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication( options => 
                {
                    options.Authority = "http://localhost:5001";
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "api";
                });

            services.AddAuthorization(options => 
            {
                options.AddPolicy("PerfilPolicy", policy => 
                {
                    policy.Requirements.Add(new PerfilPolicy("Perfil", "Visualizar Perfis"));
                });
            });

            services.AddScoped<IAuthorizationHandler, PerfilPolicyHandler>();
            services.AddTransient<IResourceOwnerPasswordValidator, CredentialsValidate>();

            return services;
        }
    }
}
