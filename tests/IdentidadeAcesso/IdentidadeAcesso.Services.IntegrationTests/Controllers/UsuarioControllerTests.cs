using FluentAssertions;
using IdentidadeAcesso.API.Application.Models;
using IdentidadeAcesso.Services.IntegrationTests.WebService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IdentidadeAcesso.Services.IntegrationTests.Controllers
{
    public class UsuarioControllerTests : 
        IClassFixture<WebServiceCustomizadoFactory<IdentidadeAcesso.API.Startup>>
    {
        private readonly HttpClient _client;

        public UsuarioControllerTests(WebServiceCustomizadoFactory<IdentidadeAcesso.API.Startup> factory)
        {
            _client = factory.CreateDefaultClient();
        }

        [Fact(DisplayName = "Deve retornar todos os usuários ativos.")]
        [Trait("Testes de Integração", "UsuarioControllerTests")]
        public async Task Deve_Retornar_Todos_UsuariosAtivos()
        {
            //arrange

            //act
            var result = await _client.GetAsync("api/v1/usuarios/obter-todos");
            var usuarios = JsonConvert.DeserializeObject<List<UsuarioViewModel>>(await result.Content.ReadAsStringAsync());
            //assert
            result.EnsureSuccessStatusCode();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            usuarios.Should().NotBeEmpty();
        }
    }
}
