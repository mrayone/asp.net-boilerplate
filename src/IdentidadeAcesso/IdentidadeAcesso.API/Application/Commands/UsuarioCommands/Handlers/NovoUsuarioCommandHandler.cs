using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Repository;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using IdentidadeAcesso.Domain.SeedOfWork.Commands.CommandHandler;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IdentidadeAcesso.API.Application.Commands.UsuarioCommands.Extension;
using IdentidadeAcesso.Domain.Events.UsuarioEvents;

namespace IdentidadeAcesso.API.Application.Commands.UsuarioCommands.Handlers
{
    public class NovoUsuarioCommandHandler : CommandHandler, IRequestHandler<NovoUsuarioCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _service;

        public NovoUsuarioCommandHandler(IMediator mediator, IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IUsuarioService service,
            INotificationHandler<DomainNotification> notifications) : base(mediator, unitOfWork, notifications)
        {
            _mediator = mediator;
            _usuarioRepository = usuarioRepository;
            _service = service;
        }

        public async Task<bool> Handle(NovoUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarCommand(request)) return await Task.FromResult(false);

            var usuarioBusca = await _usuarioRepository.Buscar(u => u.Email.Endereco.Equals(request.Email) || u.CPF.Digitos.Equals(request.CPF));
            if(usuarioBusca.Any())
            {
                await _mediator.Publish(new DomainNotification(request.GetType().Name, "Usuário já cadastrado, verifique 'E-mail' e/ou 'CPF'"));
                return await Task.FromResult(false);
            }
            var perfilExiste = await _service.VerificarPerfilExistenteAsync(request.PerfilId);
            if (!perfilExiste)
            {
                await _mediator.Publish(new DomainNotification(request.GetType().Name, "O perfil que você esta tentando vincular ao usuário não existe!"));
                return await Task.FromResult(false);
            }

            var usuario = this.DefinirUsuario(request);
            if(!ValidarEntity(usuario)) return await Task.FromResult(false);

            _usuarioRepository.Adicionar(usuario);

            if(await Commit())
            {
                await _mediator.Publish(new UsuarioCriadoEvent(usuario));
            }

            return await Task.FromResult(true);
        }
    }
}
