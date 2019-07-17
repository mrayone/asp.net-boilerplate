using FluentAssertions;
using IdentidadeAcesso.API;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
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
    public class PerfilControllerTests : IClassFixture<WebServiceCustomizadoFactory<IdentidadeAcesso.API.Startup>>
    {
        private readonly HttpClient _client;

        public PerfilControllerTests(WebServiceCustomizadoFactory<IdentidadeAcesso.API.Startup> factory)
        {
            _client = factory.CreateDefaultClient();
        }

        [Fact(DisplayName = "Deve retornar todos os perfis cadastrados.")]
        [Trait("Testes de Integração", "PerfilControllerTests")]
        public async Task Deve_Retornar_Todos_Os_Perfis_Cadastrados()
        {
            //act
            var response = await _client.GetAsync($"api/v1/perfis/obter-todos");
            var value = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            //assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            value.Should().NotBeEmpty();
        }

        [Fact(DisplayName = "Deve retornar perfil por Id.")]
        [Trait("Testes de Integração", "PerfilControllerTests")]
        public async Task Deve_Retornar_Perfil_Por_Id()
        {
            //arrange
            var id = "8cd6c8ca-7db7-4551-b6c5-f7a724286709";

            //act 
            var response = await _client.GetAsync($"api/v1/perfis/{id}");
            var value = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            //assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            value.Should().NotBeEmpty();
        }

        [Fact(DisplayName = "Deve assinar permissão e retornar ok.")]
        [Trait("Testes de Integração", "PerfilControllerTests")]
        public async Task Deve_Assinar_Permissao_E_Retornar_Ok()
        {
            //arrange
            var perfilId = "8cd6c8ca-7db7-4551-b6c5-f7a724286709";
            var permissaoId = "7E5CA36F-9278-4FAD-D6E0-08D7095CC9E4";
            var assinatura = new
            {
                PerfilId = perfilId,
                Assinaturas = new object[] 
                {
                   new { PermissaoId = permissaoId, Status =  true }
                }
            };
            var content = new StringContent(JsonConvert.SerializeObject(assinatura));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //act
            var response = await _client.PutAsync("api/v1/perfis/assinar-permissao", content);
            //assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact(DisplayName = "Deve assinar muitas permissões e retornar ok.")]
        [Trait("Testes de Integração", "PerfilControllerTests")]
        public async Task Deve_Assinar_MuitasPermissoes_E_Retornar_Ok()
        {
            //arrange
            var perfilId = "8cd6c8ca-7db7-4551-b6c5-f7a724286709";
            var permissaoId = "7E5CA36F-9278-4FAD-D6E0-08D7095CC9E4";
            var permissao2 = "4cf679e7-ef92-49e4-b677-2ec8d4e91453";
            var assinatura = new
            {
                PerfilId = perfilId,
                Assinaturas = new object[]
                {
                   new { PermissaoId = permissaoId },
                   new { PermissaoId = permissao2 }
                }
            };
            var content = new StringContent(JsonConvert.SerializeObject(assinatura));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //act
            var response = await _client.PutAsync("api/v1/perfis/assinar-permissao", content);
            //assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact(DisplayName = "Deve cancelar permissões e retornar ok.")]
        [Trait("Testes de Integração", "PerfilControllerTests")]
        public async Task Deve_Cancelar_Permissoes_e_Retornar_Ok()
        {
            //arrange
            var perfilId = "8cd6c8ca-7db7-4551-b6c5-f7a724286709";
            var permissaoId = "7E5CA36F-9278-4FAD-D6E0-08D7095CC9E4";
            var assinatura = new
            {
                PerfilId = perfilId,
                Assinaturas = new object[]
                {
                   new { PermissaoId = permissaoId }
                }
            };

            var content = new StringContent(JsonConvert.SerializeObject(assinatura));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            //act
            var response = await _client.PutAsync("api/v1/perfis/cancelar-permissao", content);
            //assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        [Fact(DisplayName = "Deve cadastrar perfil e retornar Ok.")]
        [Trait("Testes de Integração", "PerfilControllerTests")]
        public async Task Deve_Cadastrar_Perfil_E_Retornar_Ok()
        {
            //arrange
            var perfil = new
            {
                Nome = "Vendas 002",
                Descricao = "Perfil para vendedores gerenciar suas vendas"
            };

            var content = new StringContent(JsonConvert.SerializeObject(perfil));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //act
            var result = await _client.PostAsync("api/v1/perfis", content);
            var response = await _client.GetAsync($"api/v1/perfis/obter-todos");
            var value = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            //assert
            result.StatusCode.Should().NotBe(HttpStatusCode.NotFound);
            result.StatusCode.Should().NotBe(HttpStatusCode.BadRequest);
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact(DisplayName = "Deve atualizar perfil e retornar Ok.")]
        [Trait("Testes de Integração", "PerfilControllerTests")]
        public async Task Deve_Atualizar_Perfil_E_Retornar_Ok()
        {
            //arrange
            var perfil = new
            {
                Id = "8cd6c8ca-7db7-4551-b6c5-f7a724286709",
                Nome = "Vendas 003",
                Descricao = "Perfil para vendedores gerenciar suas vendas"
            };

            var content = new StringContent(JsonConvert.SerializeObject(perfil));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //act
            var result = await _client.PutAsync("api/v1/perfis", content);
            var response = await _client.GetAsync($"api/v1/perfis/obter-todos");
            var value = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            //assert
            result.StatusCode.Should().NotBe(HttpStatusCode.NotFound);
            result.StatusCode.Should().NotBe(HttpStatusCode.BadRequest);
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
