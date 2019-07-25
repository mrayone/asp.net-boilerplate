using IdentidadeAcesso.CrossCutting.Identity.CredentialsValidator;
using IdentidadeAcesso.CrossCutting.Identity.Policy;
using IdentidadeAcesso.CrossCutting.Identity.Policy.Handler;
using IdentidadeAcesso.CrossCutting.Identity.Policy.Requirement;
using IdentidadeAcesso.CrossCutting.Identity.Services;
using IdentityServer4.Services;
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

            services.AddScoped<IAuthorizationHandler, PermissaoPolicyHandler>();
            services.AddScoped<IProfileService, ProfileService>();

            services.AddSingleton<IAuthorizationPolicyProvider, PermissaoPolicyProvider>();
            services.AddTransient<IResourceOwnerPasswordValidator, CredentialsValidate>();

            return services;
        }
    }
}
