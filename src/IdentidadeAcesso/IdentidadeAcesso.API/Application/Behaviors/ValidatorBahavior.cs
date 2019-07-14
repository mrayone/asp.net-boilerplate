using FluentValidation;
using FluentValidation.Results;
using IdentidadeAcesso.API.Application.DomainEventHandlers.DomainNotifications;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Behaviors
{
    public class ValidatorBahavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<IRequest>> _validators;

        public ValidatorBahavior(IEnumerable<IValidator<IRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, 
            RequestHandlerDelegate<TResponse> next)
        {
            var falhas = _validators.Select(v => v.Validate(request))
                            .SelectMany(result => result.Errors)
                            .Where(f => f != null);


            return await next();
        }
    }
}
