using IdentidadeAcesso.API.Application.Commands.CommandHandler;
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
    public class TrocarSenhaCommandHandler : BaseCommandHandler, IRequestHandler<TrocarSenhaCommand, CommandResponse>
    {
        private readonly IMediator _mediator;
        private readonly IUsuarioRepository _repository;

        public TrocarSenhaCommandHandler(IMediator mediator, IUsuarioRepository repository, IUnitOfWork unitOfWork, 
            INotificationHandler<DomainNotification> notifications) : base(mediator, unitOfWork, notifications)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<CommandResponse> Handle(TrocarSenhaCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _repository.ObterPorIdAsync(request.UsuarioId);
            if (usuario == null)
            {
                await _mediator.Publish(new DomainNotification(this.GetType().Name, "Usuário não encontrado."));
                return await Task.FromResult(CommandResponse.Fail);
            }

            if (!usuario.Senha.ValidarSenha(request.SenhaAtual))
            {
                await _mediator.Publish(new DomainNotification(this.GetType().Name, "A senha atual fornecida não corresponde com a cadastrada."));
                return await Task.FromResult(CommandResponse.Fail);
            } 

            var senha = Senha.GerarSenha(request.Senha);
            usuario.DefinirSenha(senha);

            _repository.Atualizar(usuario);

            if (await Commit())
            {
                await _mediator.Publish(new UsuarioAtualizadoEvent(usuario));
            }

            return await Task.FromResult(CommandResponse.Ok);
        }
    }
}
