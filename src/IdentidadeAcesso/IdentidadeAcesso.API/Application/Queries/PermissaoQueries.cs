using Dapper;
using IdentidadeAcesso.API.Application.Models;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.ValueObjects;
using Knowledge.IO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Queries
{
    public class PermissaoQueries : IPermissaoQueries
    {
        private readonly DbConnection _dapper;
        public PermissaoQueries(IdentidadeAcessoDbContext context)
        {
            _dapper = context.Database.GetDbConnection();
        }

        public async Task<PermissaoViewModel> ObterPorIdAsync(Guid id)
        {
            var sql = @"SELECT [Id]
                              ,[Atribuicao_Valor] as Valor
                              ,[Atribuicao_Tipo] as Tipo
                FROM [permissoes] WHERE [Id] = @uid AND [DeletadoEm] IS NULL";
            var result = await _dapper.QuerySingleAsync<PermissaoViewModel>(sql, new { uid = id });

            return result;
        }

        public async Task<IEnumerable<PermissaoViewModel>> ObterTodasAsync()
        {
            var sql = @"SELECT [Id]
                              ,[Atribuicao_Valor] as Valor
                              ,[Atribuicao_Tipo] as Tipo
                FROM [permissoes] WHERE [DeletadoEm] IS NULL";
            var result = await _dapper.QueryAsync<PermissaoViewModel>(sql);

            return result;
        }
    }
}
