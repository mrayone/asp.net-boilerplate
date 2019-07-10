using IdentidadeAcesso.API.Application.Commands.CommandHandler;
using IdentidadeAcesso.API.Application.Extensions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Repository;
using IdentidadeAcesso.Domain.Events.UsuarioEvents;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.UsuarioCommands.Handlers
{
    public class NovoUsuarioCommandHandler : BaseCommandHandler, IRequestHandler<NovoUsuarioCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _service;

        public NovoUsuarioCommandHandler(IMediator mediator, IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IUsuarioService service,
            IDomainNotificationHandler<DomainNotification> notifications) : base(mediator, unitOfWork, notifications)
        {
            _mediator = mediator;
            _usuarioRepository = usuarioRepository;
            _service = service;
        }

        public async Task<bool> Handle(NovoUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarCommand(request)) return await Task.FromResult(false);

            var DisponivelEmailECpf = await _service.DisponivelEmailECpfAsync(request.Email, request.CPF);
            if (!DisponivelEmailECpf)
            {
                await _mediator.Publish(new DomainNotification(GetType().Name, "Usuário já cadastrado, verifique 'E-mail' e/ou 'CPF'"));
                return await Task.FromResult(DisponivelEmailECpf);
            };

            var usuario = this.DefinirUsuario(request);
            var vinculouPerfil = await _service.VincularAoPerfilAsync(request.PerfilId, usuario);

            if (!vinculouPerfil) return await Task.FromResult(false);

            _usuarioRepository.Adicionar(usuario);

            if(await Commit())
            {
                await _mediator.Publish(new UsuarioCriadoEvent(usuario));
            }

            return await Task.FromResult(true);
        }
    }
}
