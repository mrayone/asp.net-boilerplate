using IdentidadeAcesso.API.Application.Commands.CommandHandler;
using IdentidadeAcesso.API.Application.Extensions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Repository;
using IdentidadeAcesso.Domain.Events.UsuarioEvents;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Commands.UsuarioCommands.Handlers
{
    public class AtualizarUsuarioCommandHandler : BaseCommandHandler, IRequestHandler<AtualizarUsuarioCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _service;

        public AtualizarUsuarioCommandHandler(IMediator mediator, IUnitOfWork unitOfWork, IUsuarioRepository usuarioRepository, IUsuarioService service,
            IDomainNotificationHandler<DomainNotification> notifications) : base(mediator, unitOfWork, notifications)
        {
            _mediator = mediator;
            _usuarioRepository = usuarioRepository;
            _service = service;
        }
        public async Task<bool> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
        {

            var podeAtualizar = await ValidarOperacao(request);

            if (!podeAtualizar) return await Task.FromResult(false);

            var usuario = this.DefinirUsuario(request);
            var vinculouPerfil = await _service.VincularAoPerfilAsync(request.PerfilId, usuario);
            if (!vinculouPerfil) return await Task.FromResult(false);

            _usuarioRepository.Atualizar(usuario);

            if (await Commit())
            {
                await _mediator.Publish(new UsuarioAtualizadoEvent(usuario));
            }

            return await Task.FromResult(true);
        }

        private async Task<bool> ValidarOperacao(AtualizarUsuarioCommand request)
        {
            var encontrarUsuario = await _usuarioRepository.ObterPorId(request.Id);
            if (encontrarUsuario == null)
            {
                await _mediator.Publish(new DomainNotification(request.GetType().Name, "Não existe o usuario que você esta tentando modificar."));
                return await Task.FromResult(false);
            }

            var DisponivelEmailECpf = await _service.DisponivelEmailECpfAsync(request.Email, request.CPF, request.PerfilId);
            if (!DisponivelEmailECpf)
            {
                await _mediator.Publish(new DomainNotification(GetType().Name, "Usuário já cadastrado, verifique 'E-mail' e/ou 'CPF'"));
                return await Task.FromResult(DisponivelEmailECpf);
            };

            return await Task.FromResult(true);
        }
    }
}
