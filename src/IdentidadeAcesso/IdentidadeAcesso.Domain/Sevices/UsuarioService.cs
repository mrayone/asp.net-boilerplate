using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeAcesso.Domain.Sevices
{
    public class UsuarioService : IUsuarioService
    {
        public Task<bool> DeletarUsuario(Guid usuarioId)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> DesativarUsuario(Guid usuarioId)
        {
            throw new NotImplementedException();
        }
    }
}
