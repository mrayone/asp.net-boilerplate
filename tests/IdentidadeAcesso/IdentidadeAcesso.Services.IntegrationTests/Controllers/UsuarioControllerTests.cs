using FluentAssertions;
using IdentidadeAcesso.API;
using IdentidadeAcesso.API.Application.Models;
using IdentidadeAcesso.Services.IntegrationTests.WebService;
using IdentidadeAcesso.Services.IntegrationTests.WebService.Extension;
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
        private const string API = "api/v1/usuarios";

        public UsuarioControllerTests(WebServiceCustomizadoFactory<IdentidadeAcesso.API.Startup> factory)
        {
            _client = factory.ComNovoDb().CreateDefaultClient();
        }

        [Fact(DisplayName = "Deve retornar todos os usuários ativos.")]
        [Trait("Testes de Integração", "UsuarioControllerTests")]
        public async Task Deve_Retornar_Todos_UsuariosAtivos()
        {
            //arrange
            //act
            var result = await _client.GetAsync($"{API}/obter-todos");
            var usuarios = JsonConvert.DeserializeObject<List<UsuarioViewModel>>(await result.Content.ReadAsStringAsync());
            //assert
            result.EnsureSuccessStatusCode();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            usuarios.Should().NotBeEmpty();
        }

        [Fact(DisplayName = "Deve retornar o usuário com id 50d4a981-48d3-42e6-9c6e-9602184afca7.")]
        [Trait("Testes de Integração", "UsuarioControllerTests")]
        public async Task Deve_Retornar_Usario_Por_Id_Async()
        {
            //arrange

            //act
            var result = await _client.GetAsync($"{API}/50d4a981-48d3-42e6-9c6e-9602184afca7");
            var usuario = JsonConvert.DeserializeObject<UsuarioViewModel>(await result.Content.ReadAsStringAsync());
            //assert
            result.EnsureSuccessStatusCode();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            usuario.Should().NotBeNull();
        }

        [Fact(DisplayName = "Deve retornar o usuário com sucesso.")]
        [Trait("Testes de Integração", "UsuarioControllerTests")]
        public async Task Deve_Cadastrar_Usuario_ComSucesso()
        {
            //arrange
            var usuario = new
            {
                Nome = "Daenerys",
                Sobrenome = "Targaryen",
                Sexo = "F",
                DateDeNascimento = DateTime.Now.AddYears(-18),
                CPF = "440.156.500-26",
                Email = "dany.targ@gmail.com",
                PerfilId = Guid.Parse("8cd6c8ca-7db7-4551-b6c5-f7a724286709"),
                Celular = "+5518996113325"
            };
            var content = GerarContent(usuario);
            //act
            var post = await _client.PostAsync($"{API}", content);
            var result = await post.Content.ReadAsStringAsync();
            //assert
            post.EnsureSuccessStatusCode();
            post.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEmpty();
        }

        [Fact(DisplayName = "Deve retornar o usuário completo com sucesso.")]
        [Trait("Testes de Integração", "UsuarioControllerTests")]
        public async Task Deve_Cadastrar_UsuarioCompleto_ComSucesso()
        {
            //arrange
            var usuario = new
            {
                Nome = "Daenerys",
                Sobrenome = "Targaryen",
                Sexo = "F",
                DateDeNascimento = DateTime.Now.AddYears(-16),
                CPF = "440.156.500-26",
                Email = "dany.targ@gmail.com",
                PerfilId = Guid.Parse("8cd6c8ca-7db7-4551-b6c5-f7a724286709"),
                Celular = "+5518996113325",
                Logradouro = "Rua Winterfall",
                Numero = "VW97X",
                Bairro = "Game of Thrones",
                CEP = "19778500",
                Cidade = "North",
                Estado = "HBO"
            };
            var content = GerarContent(usuario);
            //act
            var post = await _client.PostAsync($"{API}", content);
            var result = await post.Content.ReadAsStringAsync();
            //assert
            post.EnsureSuccessStatusCode();
            post.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEmpty();
        }

        private StringContent GerarContent(object objeto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(objeto));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return content;
        }
    }
}
