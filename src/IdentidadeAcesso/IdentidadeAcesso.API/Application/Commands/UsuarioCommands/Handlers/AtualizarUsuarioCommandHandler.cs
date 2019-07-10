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
            if (!ValidarCommand(request)) return await Task.FromResult(false);

            var podeAtualizar = await ValidarOperacao(request);
            if (!podeAtualizar)
            {
                return await Task.FromResult(podeAtualizar);
            }
            var usuario = this.DefinirUsuario(request);

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

            var usuarioBusca = await _usuarioRepository.Buscar(u => u.Email.Endereco.Equals(request.Email) &&
                                                               u.CPF.Digitos.Equals(request.CPF) && u.Id != request.Id);
            if (usuarioBusca.Any())
            {
                await _mediator.Publish(new DomainNotification(request.GetType().Name, "Um usuário já esta usando esse CPF e E-mail."));
                return await Task.FromResult(false);
            }

            var perfilExiste = await _service.VerificarPerfilExistenteAsync(request.PerfilId);
            if (!perfilExiste)
            {
                await _mediator.Publish(new DomainNotification(request.GetType().Name, "O perfil que você esta tentando vincular ao usuário não existe!"));
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
