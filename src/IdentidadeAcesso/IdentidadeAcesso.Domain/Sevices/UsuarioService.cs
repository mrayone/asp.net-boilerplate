using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Repository;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeAcesso.Domain.Sevices
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IPerfilRepository _perfilRepository;
        private readonly IUsuarioRepository _repository;
        private readonly IMediator _mediator;

        public UsuarioService(IUsuarioRepository repository, IPerfilRepository perfilRepository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
            _perfilRepository = perfilRepository;
        }

        public async Task<Usuario> DesativarUsuarioAsync(Guid usuarioId)
        {
            var usuario = await _repository.ObterPorId(usuarioId);

            if(usuario == null)
            {
                await _mediator.Publish(new DomainNotification(GetType().Name, "Não foi possível localizar este usuário."));
                return null;
            }

            usuario.DesativarUsuario();

            return await Task.FromResult(usuario);
        }

        public async Task<bool> VerificarPerfilExistenteAsync(Guid perfilId)
        {
            var perfil = await _perfilRepository.ObterPorId(perfilId);
            return await Task.FromResult(perfil != null);
        }
    }
}
