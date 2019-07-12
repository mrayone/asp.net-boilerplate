using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeAcesso.Domain.SeedOfWork.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> DesativarUsuarioAsync(Guid usuarioId);
        Task<Usuario> DeletarUsuarioAsync(Guid usuarioId);
        Task<bool> VincularAoPerfilAsync(Guid perfilId, Usuario usuario);
        Task<bool> DisponivelEmailECpfAsync(string email, string cpf, Guid? usuarioId = null);
    }
}
