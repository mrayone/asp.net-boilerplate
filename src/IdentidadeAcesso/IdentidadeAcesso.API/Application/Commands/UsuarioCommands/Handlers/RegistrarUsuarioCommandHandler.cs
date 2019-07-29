using IdentidadeAcesso.API.Application.Commands.CommandHandler;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
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
    public class RegistrarUsuarioCommandHandler : BaseCommandHandler, IRequestHandler<RegistrarUsuarioCommand, CommandResponse>
    {
        private readonly IMediator _mediator;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _service;

        public RegistrarUsuarioCommandHandler(IMediator mediator, IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IUsuarioService service,
            INotificationHandler<DomainNotification> notifications) : base(mediator, unitOfWork, notifications)
        {
            _mediator = mediator;
            _usuarioRepository = usuarioRepository;
            _service = service;
        }

        public async Task<CommandResponse> Handle(RegistrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var EmailDisponivel = await _usuarioRepository.Buscar(u => u.Email.Endereco.Equals(request.Email));
            if (EmailDisponivel.Any())
            {
                await _mediator.Publish(new DomainNotification(GetType().Name, "E-mail já cadastrado, porfavor informe um outro."));
                return await Task.FromResult(CommandResponse.Fail);
            };

            var usuario = Usuario.UsuarioFactory.RegistroRapidoDeUsuario(request.Nome, request.Sobrenome, request.DataDeNascimento, request.Email,
                request.Sexo, request.Senha);

            var vinculouPerfil = await _service.VincularPerfilDeVisitante(usuario);

            if (!vinculouPerfil) return await Task.FromResult(CommandResponse.Fail);

            _usuarioRepository.Adicionar(usuario);

            if (await Commit())
            {
                await _mediator.Publish(new UsuarioCriadoEvent(usuario));
            }

            return await Task.FromResult(CommandResponse.Ok);
        }
    }
}
