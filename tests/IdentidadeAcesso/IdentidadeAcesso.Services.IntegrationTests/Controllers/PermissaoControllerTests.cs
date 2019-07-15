using FluentAssertions;
using IdentidadeAcesso.API;
using IdentidadeAcesso.API.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
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
    public class PermissaoControllerTests :
        IClassFixture<WebApplicationFactory<IdentidadeAcesso.API.Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public PermissaoControllerTests(WebApplicationFactory<IdentidadeAcesso.API.Startup> factory)
        {
            _factory = factory;
        }

        [Fact(DisplayName = "Deve Retornar erros ao enviar comando post invalido de permissão.")]
        [Trait("Testes de Integração", "PermissaoControllerTests")]
        public async Task Deve_Retornar_Erro_Ao_Enviar_Comando_Post_Invalido_De_Permissao()
        {
            //arrange
            var client = _factory.CreateDefaultClient();
            var model = JsonConvert.SerializeObject(
                new PermissaoViewModel()
                {
                    Tipo = "a",
                    Valor = "a"
                });

            var content = new StringContent(model);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //act
            var response = await client.PostAsync("api/v1/permissoes", content);
            var value = await response.Content.ReadAsStringAsync();
            //assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            value.Should().NotBeEmpty();
        }
    }
}
