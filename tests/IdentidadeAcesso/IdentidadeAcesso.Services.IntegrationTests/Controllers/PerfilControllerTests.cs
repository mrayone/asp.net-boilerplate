using FluentAssertions;
using IdentidadeAcesso.API.Application.Commands.PerfilCommands;
using IdentidadeAcesso.API.Application.Models;
using IdentidadeAcesso.Services.IntegrationTests.WebService;
using IdentidadeAcesso.Services.IntegrationTests.WebService.Extension;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace IdentidadeAcesso.Services.IntegrationTests.Controllers
{
    public class PerfilControllerTests : IClassFixture<WebServiceCustomizadoFactory<IdentidadeAcesso.API.Startup>>
    {
        private readonly HttpClient _client;

        public PerfilControllerTests(WebServiceCustomizadoFactory<IdentidadeAcesso.API.Startup> factory)
        {

            _client = factory.ComNovoDb().CreateDefaultClient();
        }

        [Fact(DisplayName = "Deve retornar todos os perfis cadastrados.")]
        [Trait("Testes de Integração", "PerfilControllerTests")]
        public async Task Deve_Retornar_Todos_Os_Perfis_Cadastrados()
        {
            //arrange 
            //act
            var response = await _client.GetAsync($"api/v1/perfis/obter-todos");
            var value = await response.Content.ReadAsStringAsync();
            var perfis = JsonConvert.DeserializeObject<IList<PerfilViewModel>>(value);
            //assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            perfis.Should().NotBeEmpty();
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
            var perfil = JsonConvert.DeserializeObject<PerfilViewModel>(value);
            //assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            perfil.Id.Should().Be("8cd6c8ca-7db7-4551-b6c5-f7a724286709");
        }

        [Fact(DisplayName = "Deve retornar NotFound se não encontrar o perfil.")]
        [Trait("Testes de Integração", "PerfilControllerTests")]
        public async Task Deve_RetornarNotFound_Se_Nao_Achar_Perfil()
        {
            //arrange 
            var id = "8cd6c8ca-7db7-4551-b6c5-f7a724286759";
            //act 
            var response = await _client.GetAsync($"api/v1/perfis/{id}");
            //assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact(DisplayName = "Deve atribuir permissão e retornar ok.")]
        [Trait("Testes de Integração", "PerfilControllerTests")]
        public async Task Deve_Atribuir_Permissao_E_Retornar_Ok()
        {
            //arrange
            var perfilId = "8cd6c8ca-7db7-4551-b6c5-f7a724286709";
            var permissaoId = "7E5CA36F-9278-4FAD-D6E0-08D7095CC9E4";
            var atribuicao = new
            {
                PerfilId = perfilId,
                Atribuicoes = new object[] 
                {
                   new { PermissaoId = permissaoId, Status =  true }
                }
            };
            var content = new StringContent(JsonConvert.SerializeObject(atribuicao));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //act
            var response = await _client.PutAsync("api/v1/perfis/atribuir-permissoes", content);

            //assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact(DisplayName = "Deve atribuir muitas permissões e retornar ok.")]
        [Trait("Testes de Integração", "PerfilControllerTests")]
        public async Task Deve_Atribuir_MuitasPermissoes_E_Retornar_Ok()
        {
            //arrange 
            var perfilId = "8cd6c8ca-7db7-4551-b6c5-f7a724286709";
            var permissaoId = "7E5CA36F-9278-4FAD-D6E0-08D7095CC9E4";
            var permissao2 = "4cf679e7-ef92-49e4-b677-2ec8d4e91453";
            var assinatura = new
            {
                PerfilId = perfilId,
                Atribuicoes = new object[]
                {
                   new { PermissaoId = permissaoId },
                   new { PermissaoId = permissao2 }
                }
            };
            var content = new StringContent(JsonConvert.SerializeObject(assinatura));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //act
            var response = await _client.PutAsync("api/v1/perfis/atribuir-permissoes", content);
            //assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact(DisplayName = "Deve revogar permissões e retornar ok.")]
        [Trait("Testes de Integração", "PerfilControllerTests")]
        public async Task Deve_Revogar_Permissoes_e_Retornar_Ok()
        {
            //arrange 
            var perfilId = "8cd6c8ca-7db7-4551-b6c5-f7a724286709";
            var permissaoId = "7E5CA36F-9278-4FAD-D6E0-08D7095CC9E4";
            var assinatura = new
            {
                PerfilId = perfilId,
                Atribuicoes = new object[]
                {
                   new { PermissaoId = permissaoId, Ativa = false }
                }
            };

            var content = new StringContent(JsonConvert.SerializeObject(assinatura));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            //act
            var response = await _client.PutAsync("api/v1/perfis/atribuir-permissoes", content);
            var vr = await response.Content.ReadAsStringAsync();

            var getPerfil = await _client.GetAsync($"api/v1/perfis/{perfilId}");
            var value = await getPerfil.Content.ReadAsStringAsync().ConfigureAwait(false);
            var perfil = JsonConvert.DeserializeObject<PerfilViewModel>(value);

            //assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
         var permissaoAtribuida = perfil.Atribuicoes
                .Where(p => p.PermissaoId.Equals(Guid.Parse(permissaoId))).FirstOrDefault();
            permissaoAtribuida.Should().NotBeNull();
            permissaoAtribuida.Ativo.Should().BeFalse();
        }

        [Fact(DisplayName = "Deve cadastrar perfil e retornar Ok.")]
        [Trait("Testes de Integração", "PerfilControllerTests")]
        public async Task Deve_Cadastrar_Perfil_E_Retornar_Ok()
        {
            //arrange

            var perfil = new
            {
                Nome = "Vendas 002",
                Descricao = "Perfil para vendedores gerenciar suas vendas",
                Atribuicoes = new List<AtribuicaoDTO>()
            };

            var content = new StringContent(JsonConvert.SerializeObject(perfil));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //act
            var result = await _client.PostAsync("api/v1/perfis", content);
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
                Descricao = "Perfil para vendedores gerenciar suas vendas",
                Atribuicoes = new List<AtribuicaoDTO>()
            };

            var content = new StringContent(JsonConvert.SerializeObject(perfil));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //act
            var result = await _client.PutAsync("api/v1/perfis", content);
            //assert
            result.StatusCode.Should().NotBe(HttpStatusCode.NotFound);
            result.StatusCode.Should().NotBe(HttpStatusCode.BadRequest);
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact(DisplayName = "Deve excluir perfil e retornar Ok.")]
        [Trait("Testes de Integração", "PerfilControllerTests")]
        public async Task Deve_Excluir_Perfil_E_Retornar_Ok()
        {
            //arrange 
            //act
            var result = await _client.DeleteAsync("api/v1/perfis/577ba295-0da3-44cd-8cd9-2631de0d3571");
            var response = await result.Content.ReadAsStringAsync();
            //assert
            result.StatusCode.Should().NotBe(HttpStatusCode.NotFound);
            result.StatusCode.Should().NotBe(HttpStatusCode.BadRequest);
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact(DisplayName = "Deve retornar bad request se excluir perfil em uso.")]
        [Trait("Testes de Integração", "PerfilControllerTests")]
        public async Task Deve_Retornar_BadRequest_Se_Excluir_PerfilEmUso()
        {
            //act
            var delete = await _client.DeleteAsync("api/v1/perfis/8cd6c8ca-7db7-4551-b6c5-f7a724286709");
            var response = await delete.Content.ReadAsStringAsync();
            //assert
            delete.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            response.Should().NotBeEmpty();
        }
    }
}
