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
        where TRequest : IRequest<TRequest> where TResponse : Response
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

            return await (falhas.Any() ? AdicionarErros(falhas) : next());
        }

        private Task<TResponse> AdicionarErros(IEnumerable<ValidationFailure> falhas)
        {
            var response = new Response();

            foreach (var falha in falhas)
            {
                response.AddError(falha.ErrorMessage);
            }

            return Task.FromResult(response as TResponse);
        }
    }
}
