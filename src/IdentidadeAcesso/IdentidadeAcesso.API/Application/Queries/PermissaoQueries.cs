using Dapper;
using IdentidadeAcesso.API.Application.Models;
using Knowledge.IO.Infra.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IdentidadeAcesso.API.Application.Queries
{
    public class PermissaoQueries : IRequestHandler<BuscarPorId<PermissaoViewModel>, PermissaoViewModel>,
        IRequestHandler<BuscarTodos<PermissaoViewModel>, IEnumerable<PermissaoViewModel>>, IDisposable
    {
        private readonly IdentidadeAcessoDbContext _context;

        public PermissaoQueries(IdentidadeAcessoDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<PermissaoViewModel> Handle(BuscarPorId<PermissaoViewModel> request, CancellationToken cancellationToken)
        {
            using (var connection = _context.Database.GetDbConnection())
            {
                var sql = @"SELECT [Id]
                              ,[Atribuicao_Valor] as Valor
                              ,[Atribuicao_Tipo] as Tipo
                FROM [permissoes] WHERE [Id] = @uid AND [DeletadoEm] IS NULL";
                var result = await connection.QueryFirstOrDefaultAsync<PermissaoViewModel>(sql, new { uid = request.Id });

                if (result == null)
                    throw new KeyNotFoundException("Permissão não encontrada");


                return result;
            }
        }

        public async Task<IEnumerable<PermissaoViewModel>> Handle(BuscarTodos<PermissaoViewModel> request, CancellationToken cancellationToken)
        {
            using (var connection = _context.Database.GetDbConnection())
            {
                var sql = @"SELECT [Id]
                              ,[Atribuicao_Valor] as Valor
                              ,[Atribuicao_Tipo] as Tipo
                FROM [permissoes] WHERE [DeletadoEm] IS NULL";
                var result = await connection.QueryAsync<PermissaoViewModel>(sql);

                return result;
            }
        }
    }
}
