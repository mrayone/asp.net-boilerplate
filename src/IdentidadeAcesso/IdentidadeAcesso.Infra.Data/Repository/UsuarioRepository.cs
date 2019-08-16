using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Repository;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using Knowledge.IO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Knowledge.IO.Infra.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly DbConnection _dapper;
        public UsuarioRepository(IdentidadeAcessoDbContext context) : base(context)
        {
            _dapper = context.Database.GetDbConnection();
        }

        public async Task<IEnumerable<Usuario>> ObterUsuarioPorEmailAsync(string email)
        {
            var sql = @"SELECT * FROM [usuarios]" +
                     "LEFT JOIN [usuario_redefinicao_senha] ON" +
                     "[usuario_redefinicao_senha].[UsuarioId] = [usuarios].[Id] " +
                     "WHERE [usuarios].[Email] = @key";

            var usuario = await _dapper.QueryAsync<Usuario>(sql, new { key = email });

            return usuario;
        }
    }
}
