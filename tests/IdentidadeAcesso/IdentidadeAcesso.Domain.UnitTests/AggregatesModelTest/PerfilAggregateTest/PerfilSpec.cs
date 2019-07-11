using FluentAssertions;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.ValueObjects;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;
using IdentidadeAcesso.Domain.Exceptions;
using IdentidadeAcesso.Domain.SeedOfWork.ValueObjects;
using IdentidadeAcesso.Domain.UnitTests.Builders.PerfilBuilders;
using IdentidadeAcesso.Domain.UnitTests.Builders.PermissaoBuilders;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace IdentidadeAcesso.Domain.UnitTests.AggregatesModelTest.PerfilAggregateTest
{
    public class PerfilSpec
    {
        [Fact(DisplayName = "Deve conter uma função que assina uma permissão e a mantenha ativa.")]
        [Trait("Raiz de Agregação", "Perfil")]
        public void deve_conter_uma_funcao_que_assine_uma_permissao_e_a_mantenha_ativa()
        {
            //arrange
            var permissao = new Permissao(AtribuicaoBuilder.ObterAtribuicaoValida());
            var perfil = PerfilBuilder.ObterPerfil();

            //act
            perfil.AssinarPermissao(permissao.Id);

            var permissaoAssinada = perfil.PermissoesAssinadas.FirstOrDefault();

            permissaoAssinada.PermissaoId.Should().Be(permissao.Id);
            permissaoAssinada.Status.Should().Be(Status.Ativo);
        }
    }
}
