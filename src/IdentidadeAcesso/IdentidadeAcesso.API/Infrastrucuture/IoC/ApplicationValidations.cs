using FluentValidation;
using IdentidadeAcesso.API.Application.Behaviors;
using IdentidadeAcesso.API.Application.Validations.Usuario;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Infrastrucuture.IoC
{
    public static class ApplicationValidations
    {
        public static IServiceCollection AddValidationBehavior(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load(typeof(NovoUsuarioValidation).Assembly.FullName);

            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.TryAddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBahavior<,>));

            return services;
        }
    }
}
