using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.ValueObjects;
using System;

namespace IdentidadeAcesso.Domain.UnitTests.Builders.PerfilBuilders
{
    public class IdentificacaoBuilder
    {
        public static Identificacao ObterNulo()
        {
            return new Identificacao(null, null);
        }
        public static Identificacao ObterComNomeNulo()
        {
            return new Identificacao(null, "Usuários de Recursos Humanos com nível 1 de acesso.");
        }

        public static Identificacao ObterComDescricaoNula()
        {
            return new Identificacao("RH 1", null);
        }

        public static Identificacao ObterComNomeEmBranco()
        {
            return new Identificacao("", "Usuários de Recursos Humanos com nível 1 de acesso.");
        }

        public static Identificacao ObterComDescricaoEmBranco()
        {
            return new Identificacao("RH 1", "");
        }

        public static Identificacao ObterBranco()
        {
            return new Identificacao("", "");
        }

        public static Identificacao ObterValido()
        {
            return new Identificacao("RH 1", "Usuários de Recursos Humanos com nível 1 de acesso.");
        }
    }
}