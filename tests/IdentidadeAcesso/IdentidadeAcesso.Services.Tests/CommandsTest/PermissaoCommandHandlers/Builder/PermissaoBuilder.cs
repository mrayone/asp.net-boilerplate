using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Services.UnitTests.CommandsTest.PermissaoCommandHandlers.Builder
{
    public static class PermissaoBuilder
    {
        public static Permissao CriarPermissaoFake()
        {
            var atribuicao = new Atribuicao("Usuário","Criar");
            return new Permissao(atribuicao);
        }
    }
}
