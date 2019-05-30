using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;

namespace IdentidadeAcesso.Domain.UnitTests.Builders
{
    public class EnderecoBuilder
    {
        public static Endereco ObterEnderecoInvalido()
        {
            return new Endereco("","123x","", null, "", null);
        }

        public static Endereco ObterEnderecoValido()
        {
            return new Endereco("Rua Não Sei", "18879x", "centro", "19785400", "Seilandia", "SP");
        }
    }
}