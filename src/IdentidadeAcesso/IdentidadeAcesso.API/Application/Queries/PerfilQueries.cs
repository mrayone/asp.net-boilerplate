using Dapper;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
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
            var sql = @"SELECT [perfis].[Id]
                              ,[Nome]
                              ,[Descricao]
                              ,[DeletadoEm]
                              ,[permissoes_assinadas].[Id] as AssinaturaId
                              ,[permissoes_assinadas].[Ativo]
                              ,[permissoes_assinadas].[PermissaoId]
                          FROM [perfis] LEFT JOIN [permissoes_assinadas] ON [permissoes_assinadas].[PerfilId] = [perfis].[Id] 
                          AND [permissoes_assinadas].[Ativo] = 1
                          WHERE [perfis].[Id] = @uid AND [DeletadoEm] IS NULL";

            var result = await _dapper.QueryAsync<PerfilViewModel, AssinaturaDTO,
                PerfilViewModel>(sql, (p, a) =>
            {
                if (a != null)
                {
                    p.PermissoesAssinadas.Add(a);
                }

                return p;
            }, new { uid = id }, splitOn: "AssinaturaId");


            return MapResult(result.ToList());
        }

        private PerfilViewModel MapResult(List<PerfilViewModel> result)
        {
            var response = result.FirstOrDefault();

            if (result.Count() > 1)
            {
                result.RemoveAt(0);
                foreach (var item in result)
                {
                    response.PermissoesAssinadas.Add(item.PermissoesAssinadas.FirstOrDefault());
                }
            }

            return response;
        }

        public async Task<IEnumerable<PerfilViewModel>> ObterTodasAsync()
        {
            var sql = @"SELECT [Id]
                              ,[Nome]
                              ,[Descricao]
                              ,[DeletadoEm]
                          FROM [perfis] WHERE [DeletadoEm] IS NULL";

            var perfis = await _dapper.QueryAsync<PerfilViewModel>(sql);

            return perfis;
        }
    }
}
