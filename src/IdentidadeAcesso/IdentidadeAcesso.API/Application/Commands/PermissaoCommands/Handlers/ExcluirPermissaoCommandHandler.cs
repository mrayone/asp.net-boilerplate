using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.Repository;
using IdentidadeAcesso.Domain.SeedOfWork.Commands.CommandHandler;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.PermissaoCommands.Handlers
{
    public class ExcluirPermissaoCommandHandler : CommandHandler, IRequestHandler<ExcluirPermissaoCommand, bool>
    {
        private readonly IPermissaoService _permissaoService;
        private readonly IPermissaoRepository _permissaoRepository;

        public ExcluirPermissaoCommandHandler(IMediator mediator, IUnitOfWork unitOfWork, 
            INotificationHandler<DomainNotification> notifications, IPermissaoRepository permissaoRepository,
            IPermissaoService service) : base(mediator, unitOfWork, notifications)
        {
            _permissaoService = service;
            _permissaoRepository = permissaoRepository;
        }

        public async Task<bool> Handle(ExcluirPermissaoCommand request, CancellationToken cancellationToken)
        {
            var permissao = await _permissaoRepository.ObterPorId(request.PermissaoId);
            await _permissaoService.DeletarPermissaoAsync(permissao);
            return await Task.FromResult(true);
        }
    }
}
