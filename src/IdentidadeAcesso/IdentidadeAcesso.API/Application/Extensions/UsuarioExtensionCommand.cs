using IdentidadeAcesso.API.Application.Commands.CommandHandler;
using IdentidadeAcesso.API.Application.Commands.UsuarioCommands;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.ValueObjects;

namespace IdentidadeAcesso.API.Application.Extensions
{
    public static class UsuarioExtensionCommand
    {
        public static Usuario DefinirUsuario<T>(this BaseCommandHandler command, BaseUsuarioCommand<T> request) where T : BaseUsuarioCommand<T>
        {
            var endereco = new Endereco(request.Logradouro, request.Numero, request.Bairro, request.CEP, request.Cidade, request.Estado, request.Complemento);
            var usuario = Usuario.UsuarioFactory.CriarUsuario(request.Id, request.Nome, request.Sobrenome, request.Sexo, request.Email, request.CPF,
                request.DateDeNascimento, request.Celular, request.Telefone, endereco, request.PerfilId);

            return usuario;
        }
    }
}
