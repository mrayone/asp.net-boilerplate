using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.ValueObjects;
using System;

namespace IdentidadeAcesso.Domain.UnitTests.Builders.PerfilBuilders
{
    public class IdentificacaoBuilder
    {
        public static Identificacao ObterValido()
        {
            return new Identificacao("RH 1", "Usuários de Recursos Humanos com nível 1 de acesso.");
        }
    }
}