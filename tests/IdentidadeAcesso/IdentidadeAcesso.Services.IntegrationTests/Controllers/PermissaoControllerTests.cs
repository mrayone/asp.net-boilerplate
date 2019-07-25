using FluentAssertions;
using IdentidadeAcesso.API;
using IdentidadeAcesso.API.Application.Models;
using IdentidadeAcesso.Services.IntegrationTests.WebService;
using IdentidadeAcesso.Services.IntegrationTests.WebService.Extension;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace IdentidadeAcesso.Services.IntegrationTests.Controllers
{
    public class PermissaoControllerTests :
        IClassFixture<WebServiceCustomizadoFactory<IdentidadeAcesso.API.Startup>>
    {
        private readonly HttpClient _client;

        public PermissaoControllerTests(WebServiceCustomizadoFactory<IdentidadeAcesso.API.Startup> factory)
        {
            _client = factory.ComNovoDb().CreateDefaultClient();
        }

        [Theory(DisplayName = "Deve Retornar erros ao enviar comando post invalido de permissão.")]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData("a", "w")]
        [Trait("Testes de Integração", "PermissaoControllerTests")]
        public async Task Deve_Retornar_Erro_Ao_Enviar_Comando_Post_Invalido_De_Permissao(string tipo, string valor)
        {
            //arrange

            var content = new StringContent(JsonConvert.SerializeObject(new
            {
                Tipo = tipo,
                Valor = valor
            }));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //act
            var response = await _client.PostAsync("api/v1/permissoes", content);
            var value = await response.Content.ReadAsStringAsync();
            //assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            value.Should().NotBeEmpty();
        }

        [Theory(DisplayName = "Deve retornar erro ao cadastrar permissão que já exista.")]
        [InlineData("Perfil", "Visualizar Perfis")]
        [InlineData("Usuário", "Remover")]
        [InlineData("Usuário", "Visualizar Cadastro")]
        [Trait("Testes de Integração", "PermissaoControllerTests")]
        public async Task Deve_Retornar_Erro_Ao_Cadastrar_Permissao_Que_Ja_Exista(string tipo, string valor)
        {
            //arrange
            var content = new StringContent(JsonConvert.SerializeObject(new
            {
                Tipo = tipo,
                Valor = valor
            }));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //act
            var response = await _client.PostAsync("api/v1/permissoes", content);
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

            var content = new StringContent(JsonConvert.SerializeObject(new
            {
                Tipo = "Perfil",
                Valor = "Criar Perfil"
            }));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //act
            var response = await _client.PostAsync("api/v1/permissoes", content);
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
            //act
            var response = await _client.GetAsync($"api/v1/permissoes/7E5CA36F-9278-4FAD-D6E0-08D7095CC9E4");
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
            //act
            var response = await _client.GetAsync($"api/v1/permissoes/obter-todas");
            var value = await response.Content.ReadAsStringAsync();
            var permissoes = JsonConvert.DeserializeObject(value) as IList;
            //assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            permissoes.Should().NotBeEmpty();
            
        }

        [Fact(DisplayName = "Deve atualizar permissão com sucesso.")]
        [Trait("Testes de Integração", "PermissaoControllerTests")]
        public async Task Deve_Atualizar_Permissao_ComSucesso()
        {
            //arrange

            var content = new StringContent(JsonConvert.SerializeObject(new
            {
                Id = new Guid("7E5CA36F-9278-4FAD-D6E0-08D7095CC9E4"),
                Tipo = "Perfil",
                Valor = "Pode atribuir permissão a perfil."
            }));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //act
            var response = await _client.PutAsync("api/v1/permissoes", content);
            var result = await _client.GetAsync($"api/v1/permissoes/7E5CA36F-9278-4FAD-D6E0-08D7095CC9E4");
            var value = await result.Content.ReadAsStringAsync();
            var permissao = JsonConvert.DeserializeObject<PermissaoViewModel>(value);

            //assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            permissao.Tipo.Should().Be("Perfil");
            permissao.Valor.Should().Be("Pode atribuir permissão a perfil.");
            permissao.Id.Should().Be("7E5CA36F-9278-4FAD-D6E0-08D7095CC9E4");
        }

        [Fact(DisplayName = "Deve excluir permissão com sucesso.")]
        [Trait("Testes de Integração", "PermissaoControllerTests")]
        public async Task Deve_Excluir_Permissao_ComSucesso()
        {
            //arrange

            //act
            var response = await _client.DeleteAsync("api/v1/permissoes/7E5CA36F-9278-4FAD-D6E0-08D7095CC9E4");
            //assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        
        [Fact(DisplayName = "Deve retornar bad request e erro ao excluir permissão em uso.")]
        [Trait("Testes de Integração", "PermissaoControllerTests")]
        public async Task Deve_RetornarBadRequest_E_Erro_Ao_Excluir_Permissao_Em_Uso()
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
            var assinar = await _client.PutAsync("api/v1/perfis/assinar-permissao", content);
            //act
            var delete = await _client.DeleteAsync("api/v1/permissoes/7E5CA36F-9278-4FAD-D6E0-08D7095CC9E4");
            var result = await delete.Content.ReadAsStringAsync();
            //assert
            delete.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            result.Should().NotBeEmpty();
        }
    }
}
