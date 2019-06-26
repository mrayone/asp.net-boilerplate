using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using IdentidadeAcesso.Domain.SeedOfWork.Validation;
using IdentidadeAcesso.Domain.UnitTests.Builders.UsuarioBuilders;
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
            var data = DataDeNascimentoBuilder.ObterDataValida();
            var data2 = DataDeNascimentoBuilder.ObterDataValida();


            data.Should().Be(data2);
        }

        [Trait("Value Object", "Data de Nascimento")]
        [Fact(DisplayName = "Deve retornar erro se idade não for superior a mínima de quatorze anos")]
        public void deve_retornar_erro_se_idade_nao_for_a_minima_de_quatorze_anos()
        {
            //arr
            var idadeMin = DataDeNascimento.IdadeMin;
            var data = DataDeNascimentoBuilder.ObterDataInvalida();
            var dict = new List<ValidationError>()
            {
                new ValidationError("DataDeNascimento",String.Format("A idade mínima requerida é de {0} anos.", idadeMin))
            };

            data.ValidationResult.IsValid.Should().BeFalse();
            data.ValidationResult.Erros.Should().Contain(dict);
        }

        [Trait("Value Object", "Data de Nascimento")]
        [Fact(DisplayName = "Deve validar o estado se data estiver correta")]
        public void deve_validar_estado_se_data_estiver_correta()
        {
            //arr
            var dataNacimento = new DateTime(2005, 5, 22);

            var data = new DataDeNascimento(dataNacimento);

            data.ValidationResult.IsValid.Should().BeTrue();
        }
    }
}
