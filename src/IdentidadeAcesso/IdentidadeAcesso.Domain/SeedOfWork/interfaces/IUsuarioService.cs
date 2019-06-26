using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeAcesso.Domain.SeedOfWork.interfaces
{
    public interface IUsuarioService
    {
        Task<bool> DeletarUsuario(Guid usuarioId);
        Task<Usuario> DesativarUsuario(Guid usuarioId);
        Task<Usuario> AssociarPerfil(Usuario usuario, Guid perfilId);
    }
}
