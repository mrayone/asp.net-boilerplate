using FluentAssertions;
using IdentidadeAcesso.API;
using IdentidadeAcesso.Services.IntegrationTests.WebService;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IdentidadeAcesso.Services.IntegrationTests.Controllers
{
    public class PerfilControllerTests : IClassFixture<WebServiceCustomizadoFactory<IdentidadeAcesso.API.Startup>>
    {
        private readonly HttpClient _client;

        public PerfilControllerTests(WebServiceCustomizadoFactory<IdentidadeAcesso.API.Startup> factory)
        {
            _client = factory.CreateDefaultClient();
        }

        [Fact(DisplayName = "Deve retornar todos os perfis cadastrados.")]
        [Trait("Testes de Integração", "PerfilControllerTests")]
        public async Task Deve_Retornar_todas_Os_Perfis_Cadastrados()
        {
            //act
            var response = await _client.GetAsync($"api/v1/perfis/obter-todos");
            var value = await response.Content.ReadAsStringAsync();
            //assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            value.Should().NotBeEmpty();
        }
    }
}
