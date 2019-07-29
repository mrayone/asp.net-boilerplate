using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Repository;
using IdentidadeAcesso.Domain.SeedOfWork.Interfaces;
using IdentidadeAcesso.Domain.SeedOfWork.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<bool> VincularAoPerfilAsync(Guid perfilId, Usuario usuario)
        {
            var perfil = await _perfilRepository.ObterPorIdAsync(perfilId);

            if (perfil != null)
            {
                usuario.SetarPerfil(perfil.Id);
                return true;
            }
            await _mediator.Publish(new DomainNotification(GetType().Name, "O Perfil fornecido para definir ao usuário não foi encontrado."));

            return false;
        }

        public async Task<Usuario> DeletarUsuarioAsync(Guid usuarioId)
        {
            var usuario = await _repository.ObterPorIdAsync(usuarioId);

            if (usuario == null)
            {
                await _mediator.Publish(new DomainNotification(GetType().Name, "Não foi possível localizar este usuário."));
                return null;
            }

            usuario.Deletar();

            _repository.Atualizar(usuario);

            return await Task.FromResult(usuario);
        }

        public async Task<Usuario> DesativarUsuarioAsync(Guid usuarioId)
        {
            var usuario = await _repository.ObterPorIdAsync(usuarioId);

            if(usuario == null)
            {
                await _mediator.Publish(new DomainNotification(GetType().Name, "Não foi possível localizar este usuário."));
                return null;
            }

            usuario.DesativarUsuario();

            return await Task.FromResult(usuario);
        }

        public async Task<bool> DisponivelEmailECpfAsync(string email, string cpf, Guid? usuarioId)
        {
            IEnumerable<Usuario> usuarioBusca;
            if(usuarioId.HasValue)
            {
                usuarioBusca = await _repository.Buscar(u => (u.Email.Endereco.Equals(email) || u.CPF.Digitos.Equals(cpf)) && u.Id != usuarioId.Value);
            } else
            {
                usuarioBusca = await _repository.Buscar(u => u.Email.Endereco.Equals(email) || u.CPF.Digitos.Equals(cpf));
            }

            if (usuarioBusca.Any()) return false;

            return true;
        }

        public async Task<bool> VincularPerfilDeVisitante(Usuario usuario)
        {
            var perfis = await _perfilRepository.Buscar(p => p.Identifacao.Nome.Equals("Visitante"));

            if (perfis.Any())
            {
                var perfil = perfis.SingleOrDefault();
                usuario.SetarPerfil(perfil.Id);
                return true;
            }
            await _mediator.Publish(new DomainNotification(GetType().Name, "O Perfil de visitante não foi encontrado."));

            return false;
        }
    }
}
