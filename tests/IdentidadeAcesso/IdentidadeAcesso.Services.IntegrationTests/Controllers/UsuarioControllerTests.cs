using FluentAssertions;
using IdentidadeAcesso.API;
using IdentidadeAcesso.API.Application.Models;
using IdentidadeAcesso.Services.IntegrationTests.WebService;
using IdentidadeAcesso.Services.IntegrationTests.WebService.Extension;
using Newtonsoft.Json;
using System;
using System.Collections;
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
                Celular = "+5518996113325",
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
                Estado = "HBO",
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

        [Fact(DisplayName = "Deve atualizar o usuário de ID 50d4a981-48d3-42e6-9c6e-9602184afca7.")]
        [Trait("Testes de Integração", "UsuarioControllerTests")]
        public async Task Deve_Atualizar_UsuarioComSucesso()
        {
            //arrange
            var usuario = new
            {
                Id = "50d4a981-48d3-42e6-9c6e-9602184afca7",
                Nome = "Aegon I",
                Sobrenome = "Targaryen",
                Sexo = "M",
                DateDeNascimento = DateTime.Now.AddYears(-16),
                CPF = "44015650026",
                Email = "fakedoi_2@gmail.com",
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
            var post = await _client.PutAsync($"{API}", content);
            var result = await post.Content.ReadAsStringAsync();
            //assert
            post.EnsureSuccessStatusCode();
            post.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEmpty();
        }

        [Fact(DisplayName = "Deve excluir o usuário com sucesso.")]
        [Trait("Testes de Integração", "UsuarioControllerTests")]
        public async Task Deve_Excluir_UsuarioComSucesso()
        {
            //arrange

            //act
            var delete = await _client.DeleteAsync($"{API}/50d4a981-48d3-42e6-9c6e-9602184afca7");
            var response = await delete.Content.ReadAsStringAsync();

            //assert
            delete.EnsureSuccessStatusCode();
            delete.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Should().BeEmpty();

        }

        [Theory(DisplayName = "Deve retornar erro em commands inválidos.")]
        [ClassData(typeof(CommandsFails))]
        [Trait("Testes de Integração", "UsuarioControllerTests")]
        public async Task Deve_Retornar_Erro_CommandInvalidos(string nome, string sobrenome, string sexo,
            string email, string cpf, DateTime dateDeNascimento, string celular)
        {
            //arrange
            var usuario = new
            {
                Nome = nome,
                Sobrenome = sobrenome,
                Sexo = sexo,
                DateDeNascimento = dateDeNascimento,
                CPF = cpf,
                Email = email,
                PerfilId = Guid.Parse("8cd6c8ca-7db7-4551-b6c5-f7a724286709"),
                Celular = celular
            };

            var content = GerarContent(usuario);
            //act
            var post = await _client.PostAsync($"{API}", content);
            var result = await post.Content.ReadAsStringAsync();
            //assert
            post.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            result.Should().NotBeEmpty();
        }

        [Fact(DisplayName = "Deve registrar usuário visitante com sucesso.")]
        [Trait("Testes de Integração", "UsuarioControllerTests")]
        public async Task Deve_RegistrarNovoUsuarioVisitante_ComSucesso()
        {
            var usuario = new
            {
                nome = "Fake",
                sobrenome = "Silva Mendez",
                dataDeNascimento = "2000-07-29",
                email = "fakemail@outlook.com" ,
                sexo = "M",
                senha = "124578Mak",
                confirmacaoSenha = "124578Mak" ,
            };

            var content = GerarContent(usuario);
            //act
            var post = await _client.PostAsync($"{API}/registrar-se", content);
            var result = await post.Content.ReadAsStringAsync();
            //assert
            post.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().BeEmpty();
        }

        public class CommandsFails : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    "",
                    "",
                    "" ,
                    "",
                    "",
                    DateTime.Now,
                    ""
                };
                yield return new object[]
                {
                    "Maae", //nome
                    "a", //sobrenome
                    "g",// sexo
                    "mkisdi2gmaicl.com", // email
                    "45577899852266", // cpf
                    DateTime.Now, // data de nascimento
                    "329989878877487", // celular
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        private StringContent GerarContent(object objeto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(objeto));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return content;
        }
    }
}
