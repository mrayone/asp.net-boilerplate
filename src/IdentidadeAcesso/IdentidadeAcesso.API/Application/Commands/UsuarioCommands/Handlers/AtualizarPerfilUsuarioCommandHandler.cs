using IdentidadeAcesso.API.Application.Commands.CommandHandler;
using IdentidadeAcesso.API.Application.Extensions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Repository;
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
    public class AtualizarPerfilUsuarioCommandHandler : BaseCommandHandler, IRequestHandler<AtualizarPerfilUsuarioCommand, CommandResponse>
    {

        private readonly IMediator _mediator;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _service;

        public AtualizarPerfilUsuarioCommandHandler(IMediator mediator, IUsuarioRepository usuarioRepository, IUsuarioService service,
            IUnitOfWork unitOfWork, INotificationHandler<DomainNotification> notifications) : base(mediator, unitOfWork, notifications)
        {
            _mediator = mediator;
            _usuarioRepository = usuarioRepository;
            _service = service;
        }

        public async Task<CommandResponse> Handle(AtualizarPerfilUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuarioEncontrado = await _usuarioRepository.ObterPorIdAsync(request.Id);
            if (usuarioEncontrado == null)
            {
                await _mediator.Publish(new DomainNotification(request.GetType().Name, "Não existe o usuario que você esta tentando modificar."));
                return await Task.FromResult(CommandResponse.Fail);
            }

            var podeAtualizar = await ValidarOperacao(request);

            if (!podeAtualizar) return await Task.FromResult(CommandResponse.Fail);

            var usuario = this.DefinirUsuario(request);
            var vinculouPerfil = await _service.VincularAoPerfilAsync(usuarioEncontrado.PerfilId.Value, usuario);
            if (!vinculouPerfil) return await Task.FromResult(CommandResponse.Fail);

            _usuarioRepository.Atualizar(usuario);

            if (await Commit())
            {
                await _mediator.Publish(new UsuarioAtualizadoEvent(usuario));
            }

            return await Task.FromResult(CommandResponse.Ok);
        }

        private async Task<bool> ValidarOperacao(AtualizarPerfilUsuarioCommand request)
        {
            var DisponivelEmailECpf = await _service.DisponivelEmailECpfAsync(request.Email, request.CPF, request.Id);
            if (!DisponivelEmailECpf)
            {
                await _mediator.Publish(new DomainNotification(GetType().Name, "Usuário já cadastrado, verifique 'E-mail' e/ou 'CPF'"));
                return await Task.FromResult(DisponivelEmailECpf);
            }

            return await Task.FromResult(true);
        }
    }
}
