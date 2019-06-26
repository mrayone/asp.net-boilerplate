using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;

namespace IdentidadeAcesso.Domain.UnitTests.Builders.UsuarioBuilders
{
    public class EnderecoBuilder
    {
        public static Endereco ObterEnderecoInvalido()
        {
            return new Endereco("asdsad","123x","wwwe", "adwdw", "111558778", "asdsadw");
        }

        public static Endereco ObterEnderecoValido()
        {
            return new Endereco("Rua Não Sei", "18879x", "centro", "19785400", "Seilandia", "SP");
        }
    }
}