using System;
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
        private readonly IdentidadeAcessoDbContext _context;
        public UsuarioRepository(IdentidadeAcessoDbContext context) : base(context)
        {
            _context = context;
        }

        public void AdicionarTokenDeRedefinicao(TokenRedefinicaoSenha token)
        {
            _context.TokensRedefinicaoSenha.Add(token);
        }

        public async Task<IEnumerable<TokenRedefinicaoSenha>> ObterTokenUsuarioAsync(string email)
        {
            var conn = _context.Database.GetDbConnection();

            var sql = @"SELECT [Id]
                          ,[Token]
                          ,[Email]
                          ,[CriadoEm]
                          ,[UsuarioId]
                      FROM [tokens_de_redefinicao] WHERE [Email] = @key ORDER BY [CriadoEm] DESC;";

            var query = await conn.QueryAsync<TokenRedefinicaoSenha>(sql, new { key = email });

            return query;

        }

        public void RemoverTokenUtilizado(TokenRedefinicaoSenha token)
        {
            _context.Set<TokenRedefinicaoSenha>().Remove(token);
        }
    }
}
