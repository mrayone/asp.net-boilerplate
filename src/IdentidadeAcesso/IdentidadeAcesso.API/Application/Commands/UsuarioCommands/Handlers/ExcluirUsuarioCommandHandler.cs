using IdentidadeAcesso.API.Application.Commands.CommandHandler;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Repository;
using IdentidadeAcesso.Domain.Events.UsuarioEvents;
using IdentidadeAcesso.Domain.SeedOfWork;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.UsuarioCommands.Handlers
{
    public class ExcluirUsuarioCommandHandler : BaseCommandHandler, IRequestHandler<ExcluirUsuarioCommand, CommandResponse>
    {
        private readonly IMediator _mediator;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _service;
        public ExcluirUsuarioCommandHandler(IMediator mediator, IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IUsuarioService service,
            IDomainNotificationHandler<DomainNotification> notifications) : base(mediator, unitOfWork, notifications)
        {
            _mediator = mediator;
            _usuarioRepository = usuarioRepository;
            _service = service;
        }

        public async Task<CommandResponse> Handle(ExcluirUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.ObterPorId(request.Id);
            if (usuario == null)
            {
                await _mediator.Publish(new DomainNotification(request.GetType().Name, "Usuário não encontrado."));
                return await Task.FromResult(CommandResponse.Fail);
            }

            var usuarioDeletado = await _service.DeletarUsuarioAsync(request.Id);

            if(await Commit())
            {
                await _mediator.Publish(new UsuarioDeletadoEvent(usuarioDeletado));
            }

            return await Task.FromResult(CommandResponse.Fail);
        }
    }
}
