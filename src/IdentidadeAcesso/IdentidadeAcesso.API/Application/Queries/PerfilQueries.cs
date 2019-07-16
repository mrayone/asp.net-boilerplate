using Dapper;
using IdentidadeAcesso.API.Application.Models;
using Knowledge.IO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Queries
{
    public class PerfilQueries : IPerfilQueries
    {
        private readonly DbConnection _dapper;

        public PerfilQueries(IdentidadeAcessoDbContext context)
        {
            _dapper = context.Database.GetDbConnection();
        }

        public async Task<PerfilViewModel> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PerfilViewModel>> ObterTodasAsync()
        {
            var sql = @"SELECT [Id]
                              ,[Nome]
                              ,[Descricao]
                              ,[DeletadoEm]
                          FROM [perfis]";

            var perfis = await _dapper.QueryAsync<PerfilViewModel>(sql);

            return perfis;
        }
    }
}
