using IdentidadeAcesso.API.Application.Commands.CommandHandler;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Repository;
using IdentidadeAcesso.Domain.Events.UsuarioEvents;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.UsuarioCommands.Handlers
{
    public class ExcluirUsuarioCommandHandler : BaseCommandHandler, IRequestHandler<ExcluirUsuarioCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _service;
        public ExcluirUsuarioCommandHandler(IMediator mediator, IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IUsuarioService service,
            INotificationHandler<DomainNotification> notifications) : base(mediator, unitOfWork, notifications)
        {
            _mediator = mediator;
            _usuarioRepository = usuarioRepository;
            _service = service;
        }

        public async Task<bool> Handle(ExcluirUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarCommand(request)) return await Task.FromResult(false);

            var usuario = await _usuarioRepository.ObterPorId(request.Id);
            if (usuario == null)
            {
                await _mediator.Publish(new DomainNotification(request.GetType().Name, "Usuário não encontrado."));
                return await Task.FromResult(false);
            }

            var usuarioDeletado = await _service.DeletarUsuarioAsync(request.Id);

            if(await Commit())
            {
                await _mediator.Publish(new UsuarioDeletadoEvent(usuarioDeletado));
            }

            return await Task.FromResult(true);
        }
    }
}
