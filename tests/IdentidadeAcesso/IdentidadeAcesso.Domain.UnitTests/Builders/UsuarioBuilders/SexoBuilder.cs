using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using System;

namespace IdentidadeAcesso.Domain.UnitTests.Builders.UsuarioBuilders
{
    public class SexoBuilder
    {
        public static Sexo ObterSexoValido()
        {
            return Sexo.Masculino;
        }
    }
}