using IdentidadeAcesso.API.Application.Commands.CommandHandler;
using IdentidadeAcesso.API.Application.Models;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Repository;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using IdentidadeAcesso.Domain.Events.UsuarioEvents;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.UsuarioCommands.Handlers
{
    public class SolicitarNovaSenhaCommandHandler : BaseCommandHandler, IRequestHandler<SolicitarNovaSenhaCommand, CommandResponse>
    {

        private readonly IMediator _mediator;
        private readonly IUsuarioRepository _repository;
        public SolicitarNovaSenhaCommandHandler(IMediator mediator, IUnitOfWork unitOfWork, IUsuarioRepository repository, 
            INotificationHandler<DomainNotification> notifications) : base(mediator, unitOfWork, notifications)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<CommandResponse> Handle(SolicitarNovaSenhaCommand request, CancellationToken cancellationToken)
        {
            var busca = await _repository.Buscar(u => u.Email.Endereco.Equals(request.Email));
            if(!busca.Any())
            {
                await _mediator.Publish(new DomainNotification(this.GetType().Name, "O e-mail fornecido não possui nenhum registro."));
                return await Task.FromResult(CommandResponse.Fail);
            }

            var usuario = busca.FirstOrDefault();

            _repository.Atualizar(usuario);

            if(await Commit())
            {
                await _mediator.Publish(new NovaSenhaSolicitadaEvent(usuario));
            }

            return await Task.FromResult(CommandResponse.Ok);
        }
    }
}
