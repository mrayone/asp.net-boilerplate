using Dapper;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
using IdentidadeAcesso.API.Application.Models;
using Knowledge.IO.Infra.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Queries
{
    public class PerfilQueries : 
        IRequestHandler<BuscarPorId<PerfilViewModel>, PerfilViewModel>,
        IRequestHandler<BuscarTodos<IEnumerable<PerfilViewModel>>, IEnumerable<PerfilViewModel>>, IDisposable  
    {
        private readonly IdentidadeAcessoDbContext _context;

        public PerfilQueries(IdentidadeAcessoDbContext context)
        {
            _context = context;
        }

        private PerfilViewModel MapResult(List<PerfilViewModel> result)
        {
            using (var connection = _context.Database.GetDbConnection())
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
        }


        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<PerfilViewModel> Handle(BuscarPorId<PerfilViewModel> request, CancellationToken cancellationToken)
        {
            using (var connection = _context.Database.GetDbConnection())
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

                var result = await connection.QueryAsync<PerfilViewModel, AssinaturaDTO,
                    PerfilViewModel>(sql, (p, a) =>
                    {
                        if (a != null)
                        {
                            p.PermissoesAssinadas.Add(a);
                        }

                        return p;
                    }, new { uid = request.Id }, splitOn: "AssinaturaId");


                return MapResult(result.ToList());
            }
        }

        public async Task<IEnumerable<PerfilViewModel>> Handle(BuscarTodos<IEnumerable<PerfilViewModel>> request, CancellationToken cancellationToken)
        {
            using (var connection = _context.Database.GetDbConnection())
            {
                var sql = @"SELECT [Id]
                              ,[Nome]
                              ,[Descricao]
                              ,[DeletadoEm]
                          FROM [perfis] WHERE [DeletadoEm] IS NULL";

                var perfis = await connection.QueryAsync<PerfilViewModel>(sql);

                return perfis;
            }
        }
    }
}
