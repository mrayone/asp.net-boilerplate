using IdentidadeAcesso.API.Application.Commands.CommandHandler;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Repository;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
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
    public class DefinirNovaSenhaPorTokenCommandHandler : BaseCommandHandler, IRequestHandler<DefinirNovaSenhaPorTokenCommand, CommandResponse>
    {
        private readonly IMediator _mediator;
        private readonly IUsuarioRepository _repository;

        public DefinirNovaSenhaPorTokenCommandHandler(IMediator mediator, IUnitOfWork unitOfWork, IUsuarioRepository repository,
           INotificationHandler<DomainNotification> notifications) : base(mediator, unitOfWork, notifications)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<CommandResponse> Handle(DefinirNovaSenhaPorTokenCommand request, CancellationToken cancellationToken)
        {
            var busca = await _repository.Buscar(u => u.Email.Endereco.Equals(request.Email));
            if (!busca.Any())
            {
                await _mediator.Publish(new DomainNotification(this.GetType().Name, "O e-mail fornecido não possui nenhum registro."));
                return await Task.FromResult(CommandResponse.Fail);
            }
            
            var token = await ValidarTokenAsync(request);
            if (token == null)
            {
                return await Task.FromResult(CommandResponse.Fail);
            }

            var usuario = busca.FirstOrDefault();
            var senha = Senha.GerarSenha(request.Senha);
            usuario.DefinirSenha(senha);

            _repository.Atualizar(usuario);

            if (await Commit())
            {
               /* await _mediator.Publish(new NovaSenhaSolicitadaEvent(usuario.Nome.PrimeiroNome, usuario.Email.Endereco, token.Token)) */;
            }

            return await Task.FromResult(CommandResponse.Ok);
        }

        public async Task<TokenRedefinicaoSenha> ValidarTokenAsync(DefinirNovaSenhaPorTokenCommand request)
        {
            var buscaToken = await _repository.ObterTokenUsuarioAsync(request.Email);
            if (!buscaToken.Any())
            {
                await _mediator.Publish(new DomainNotification(this.GetType().Name, "Nenhuma solicitação de redefinição de senha encontrada."));
                return null;
            }

            var token = buscaToken.FirstOrDefault();

            if(!token.TokenValido() || !token.Token.Equals(request.Token))
            {
                await _mediator.Publish(new DomainNotification(this.GetType().Name, "Token expirado ou inválido, porfavor solicite uma nova redefinição."));
                return null;
            }

            return token;
        }
    }
}
