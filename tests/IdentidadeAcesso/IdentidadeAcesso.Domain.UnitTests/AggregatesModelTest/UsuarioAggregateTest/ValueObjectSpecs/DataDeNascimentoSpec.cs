using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.UsuarioAggregateTest.ValueObjectSpecs
{
    public class DataDeNascimentoSpec
    {
        [Trait("Value Object", "Data de Nascimento")]
        [Fact(DisplayName = "Deve manter igualdade entre dois objetos com os mesmos valores")]
        public void deve_manter_igualdade_entre_dois_objetos_com_os_mesmos_valores()
        {
            //arr
            var data = new DataDeNascimento(22, 7, 1993);
            var data2 = new DataDeNascimento(22, 7, 1993);

            data.Should().Be(data2);
        }

        [Trait("Value Object", "Data de Nascimento")]
        [Fact(DisplayName = "Deve retornar erro se data zerada for setada")]
        public void deve_retornar_erro_se_data_zerada_for_setada()
        {
            //arr
            var data = new DataDeNascimento(0, 0, 0);
            var dict = new Dictionary<string, string>()
            {
                ["Data de Nascimento Inválida"] = "Os valores fornecidos representam uma data não representável."
            };

            data.ValidationResult.IsValid.Should().BeFalse();
            data.ValidationResult.Erros.Should().Contain(dict);
        }

        [Trait("Value Object", "Data de Nascimento")]
        [Fact(DisplayName = "Deve retornar erro se idade não for superior a mínima de quatorze anos")]
        public void deve_retornar_erro_se_idade_nao_for_a_minima_de_quatorze_anos()
        {
            //arr
            var idadeMin = DataDeNascimento.IdadeMin;
            var data = new DataDeNascimento(22, 7, 2007);
            var dict = new Dictionary<string, string>()
            {
                ["Data de Nascimento Inválida"] = String.Format("A idade mínima requerida é de {0} anos.", idadeMin)
            };

            data.ValidationResult.IsValid.Should().BeFalse();
            data.ValidationResult.Erros.Should().Contain(dict);
        }

        [Trait("Value Object", "Data de Nascimento")]
        [Fact(DisplayName = "Deve validar o estado se data estiver correta")]
        public void deve_validar_estado_se_data_estiver_correta()
        {
            //arr
            var data = new DataDeNascimento(22, 5, 2005);

            data.ValidationResult.IsValid.Should().BeTrue();
        }
    }
}
