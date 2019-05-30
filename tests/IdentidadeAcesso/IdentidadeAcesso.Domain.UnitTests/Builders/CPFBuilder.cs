using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using System;

namespace IdentidadeAcesso.Domain.UnitTests.Builders
{
    public class CPFBuilder
    {
        public static CPF ObterCPFInvalido()
        {
            return new CPF("334.445.668-13");
        }

        public static CPF ObterCPFValido()
        {
            return new CPF("50103965050");
        }
    }
}