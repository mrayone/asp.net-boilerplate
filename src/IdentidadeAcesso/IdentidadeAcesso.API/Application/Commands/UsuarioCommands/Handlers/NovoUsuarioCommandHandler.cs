using IdentidadeAcesso.API.Application.Commands.CommandHandler;
using IdentidadeAcesso.API.Application.Extensions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Repository;
using IdentidadeAcesso.Domain.Events.UsuarioEvents;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.UsuarioCommands.Handlers
{
    public class NovoUsuarioCommandHandler : BaseCommandHandler, IRequestHandler<NovoUsuarioCommand, CommandResponse>
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

        public async Task<CommandResponse> Handle(NovoUsuarioCommand request, CancellationToken cancellationToken)
        {
            var DisponivelEmailECpf = await _service.DisponivelEmailECpfAsync(request.Email, request.CPF);
            if (!DisponivelEmailECpf)
            {
                await _mediator.Publish(new DomainNotification(GetType().Name, "Usuário já cadastrado, verifique 'E-mail' e/ou 'CPF'"));
                return await Task.FromResult(CommandResponse.Fail);
            };

            var usuario = this.DefinirUsuario(request);
            var vinculouPerfil = await _service.VincularAoPerfilAsync(request.PerfilId, usuario);

            if (!vinculouPerfil) return await Task.FromResult(CommandResponse.Fail);

            _usuarioRepository.Adicionar(usuario);

            if(await Commit())
            {
                await _mediator.Publish(new UsuarioCriadoEvent(usuario));
            }

            return await Task.FromResult(CommandResponse.Ok);
        }
    }
}
