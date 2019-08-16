using IdentidadeAcesso.CrossCutting.Identity.CredentialsValidator;
using IdentidadeAcesso.CrossCutting.Identity.Policy;
using IdentidadeAcesso.CrossCutting.Identity.Policy.Handler;
using IdentidadeAcesso.CrossCutting.Identity.Services;
using IdentidadeAcesso.CrossCutting.Identity.Services.Interfaces;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

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

            services.AddScoped<IAuthorizationHandler, PermissaoPolicyHandler>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IEmailSender, MessageService>();

            services.AddSingleton<IAuthorizationPolicyProvider, PermissaoPolicyProvider>();
            services.AddTransient<IResourceOwnerPasswordValidator, CredentialsValidate>();

            services.AddAuthentication("Bearer")
                   .AddIdentityServerAuthentication(options =>
                   {
                       options.Authority = "http://localhost:5001";
                       options.RequireHttpsMetadata = false;
                       options.ApiName = "api";
                   });

            return services;
        }
    }
}
