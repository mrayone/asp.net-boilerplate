using FluentValidation;
using IdentidadeAcesso.API.Application.Behaviors;
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
            const string applicationAssemblyName = "IdentidadeAcesso.API.Application";
            var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);

            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(validator => services.TryAddScoped(validator.InterfaceType, validator.ValidatorType));

            services.TryAddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBahavior<,>));

            return services;
        }
    }
}
