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
            var sql = @"SELECT [perfis].[Id]
                              ,[Nome]
                              ,[Descricao]
                              ,[DeletadoEm]
                              ,[permissoes_assinadas].[Id] as IdAssinatura
                              ,[permissoes_assinadas].[Status_Valor] as Status
                              ,[permissoes_assinadas].[PermissaoId]
                          FROM [perfis] LEFT JOIN [permissoes_assinadas] ON [permissoes_assinadas].[PerfilId] = [perfis].[Id]
                          WHERE [perfis].[Id] = @uid";

                var result = await _dapper.QueryAsync<PerfilViewModel, PermissaoAssinadaViewModel,
                    PerfilViewModel>(sql, (p, a) =>
                {
                    if(a != null)
                    {
                        p.PermissoesAssinadas.Add(a);
                    }

                    return p;
                }, new { uid = id}, splitOn:"Status");

                return result.FirstOrDefault();
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
