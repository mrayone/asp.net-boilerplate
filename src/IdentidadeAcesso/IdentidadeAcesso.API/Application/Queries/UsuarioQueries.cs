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
    public class UsuarioQueries : IUsuarioQueries
    {
        private readonly IdentidadeAcessoDbContext _context;

        public UsuarioQueries(IdentidadeAcessoDbContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<UsuarioViewModel> ObterPorIdAsync(Guid id)
        {
            using (var connection = _context.Database.GetDbConnection())
            {
                var sql = @"SELECT
                               [Id]
                              ,[PrimeiroNome] AS Nome
                              ,[Sobrenome]
                              ,[Sexo]
                              ,[Email]
                              ,[CPF_Digitos] AS CPF
                              ,[DataDeNascimento_Data] AS DataDeNascimento
                              ,[Celular]
                              ,[Status]
                              ,[DeletadoEm]
                              ,[PerfilId]
                              ,[Telefone]
	                          ,[Logradouro]
                              ,[Numero]
                              ,[Complemento]
                              ,[Bairro]
                              ,[Cep] AS CEP
                              ,[Cidade]
                              ,[Estado]
                          FROM [usuarios] LEFT JOIN [usuario_endereco] ON [usuario_endereco].[UsuarioId] = [Id] WHERE [Id] = @uid AND [DeletadoEm] IS NULL";

                var query = await connection.QuerySingleOrDefaultAsync<UsuarioViewModel>(sql, new { uid = id});

                return query;
            }
        }

        public async Task<IEnumerable<UsuarioViewModel>> ObterTodosAsync()
        {
            using (var connection = _context.Database.GetDbConnection())
            {
                var sql = @"SELECT
                               [Id]
                              ,[PrimeiroNome] AS Nome
                              ,[Sobrenome]
                              ,[Sexo]
                              ,[Email]
                              ,[CPF_Digitos] AS CPF
                              ,[DataDeNascimento_Data] as DataDeNascimento
                              ,[Celular]
                              ,[Telefone]
                              ,[Status]
                              ,[DeletadoEm]
                              ,[PerfilId]
                          FROM [usuarios] WHERE [DeletadoEm] IS NULL";

                var query = await connection.QueryAsync<UsuarioViewModel>(sql);

                return query;
            }
        }
    }
}
