using FluentAssertions;
using IdentidadeAcesso.API;
using IdentidadeAcesso.API.Application.Models;
using IdentidadeAcesso.Services.IntegrationTests.WebService;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace IdentidadeAcesso.Services.IntegrationTests.Controllers
{
    public class PermissaoControllerTests :
        IClassFixture<WebServiceCustomizadoFactory<IdentidadeAcesso.API.Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public PermissaoControllerTests(WebServiceCustomizadoFactory<IdentidadeAcesso.API.Startup> factory)
        {
            _factory = factory;
        }

        [Theory(DisplayName = "Deve Retornar erros ao enviar comando post invalido de permissão.")]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData("a", "w")]
        [Trait("Testes de Integração", "PermissaoControllerTests")]
        public async Task Deve_Retornar_Erro_Ao_Enviar_Comando_Post_Invalido_De_Permissao(string tipo, string valor)
        {
            //arrange
            var client = _factory.CreateDefaultClient();

            var content = new StringContent(JsonConvert.SerializeObject(new PermissaoViewModel()
            {
                Tipo = tipo,
                Valor = valor
            }));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //act
            var response = await client.PostAsync("api/v1/permissoes", content);
            var value = await response.Content.ReadAsStringAsync();
            //assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            value.Should().NotBeEmpty();
        }

        [Theory(DisplayName = "Deve retornar erro ao cadastrar permissão que já exista.")]
        [InlineData("Usuário", "Cadastrar")]
        [InlineData("Usuário", "Remover")]
        [InlineData("Usuário", "Visualizar Cadastro")]
        [Trait("Testes de Integração", "PermissaoControllerTests")]
        public async Task Deve_Retornar_Erro_Ao_Cadastrar_Permissao_Que_Ja_Exista(string tipo, string valor)
        {
            //arrange
            var client = _factory.CreateDefaultClient();

            var content = new StringContent(JsonConvert.SerializeObject(new PermissaoViewModel()
            {
                Tipo = tipo,
                Valor = valor
            }));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //act
            var response = await client.PostAsync("api/v1/permissoes", content);
            var value = await response.Content.ReadAsStringAsync();
            //assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            value.Should().NotBeEmpty();
        }

        [Fact(DisplayName = "Deve retornar ok ao cadastrar permissão")]
        [Trait("Testes de Integração", "PermissaoControllerTests")]
        public async Task Deve_RetornarOk_Ao_CadastrarPermissao()
        {
            //arrange
            var client = _factory.CreateDefaultClient();

            var content = new StringContent(JsonConvert.SerializeObject(new PermissaoViewModel()
            {
                Tipo = "Perfil",
                Valor = "Criar Perfil"
            }));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //act
            var response = await client.PostAsync("api/v1/permissoes", content);
            var value = await response.Content.ReadAsStringAsync();
            //assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact(DisplayName = "Deve retornar viewmodel ao consultar por id.")]
        [Trait("Testes de Integração", "PermissaoControllerTests")]
        public async Task Deve_Retonar_ViewModel_Ao_Consultar_PorId()
        {
            //arrange
            var client = _factory.CreateDefaultClient();
            //act
            var response = await client.GetAsync($"api/v1/permissoes/7E5CA36F-9278-4FAD-D6E0-08D7095CC9E4");
            var value = await response.Content.ReadAsStringAsync();
            //assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact(DisplayName = "Deve retornar Todas as Permissões.")]
        [Trait("Testes de Integração", "PermissaoControllerTests")]
        public async Task Deve_Retornar_Todas_As_Permissoes()
        {
            //arrange
            var client = _factory.CreateDefaultClient();
            //act
            var response = await client.GetAsync($"api/v1/permissoes/obter-todas");
            var value = await response.Content.ReadAsStringAsync();
            //assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact(DisplayName = "Deve atualizar permissão com sucesso.")]
        [Trait("Testes de Integração", "PermissaoControllerTests")]
        public async Task Deve_Atualizar_Permissao_ComSucesso()
        {
            //arrange
            var client = _factory.CreateDefaultClient();

            var content = new StringContent(JsonConvert.SerializeObject(new PermissaoViewModel()
            {
                Id = new Guid("7E5CA36F-9278-4FAD-D6E0-08D7095CC9E4"),
                Tipo = "Perfil",
                Valor = "Pode atribuir permissão a perfil."
            }));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //act
            var response = await client.PutAsync("api/v1/permissoes", content);
            var todos = await client.GetAsync($"api/v1/permissoes/obter-todas");
            var value = await response.Content.ReadAsStringAsync();
            //assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact(DisplayName = "Deve excluir permissão com sucesso.")]
        [Trait("Testes de Integração", "PermissaoControllerTests")]
        public async Task Deve_Excluir_Permissao_ComSucesso()
        {
            //arrange
            var client = _factory.CreateDefaultClient();

            //act
            var response = await client.DeleteAsync("api/v1/permissoes/7E5CA36F-9278-4FAD-D6E0-08D7095CC9E4");
            var todos = await client.GetAsync($"api/v1/permissoes/obter-todas");
            var value = await todos.Content.ReadAsStringAsync();

            //assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        //[Fact(DisplayName = "Deve gerar erro ao excluir permissão em uso.")]
        //[Trait("Testes de Integração", "PermissaoControllerTests")]
        //public async Task Deve_Gerar_Erro_Ao_Excluir_Permissao_Em_Uso()
        //{
        //}
    }
}
