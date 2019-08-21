using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Repository;
using IdentityServer4.Validation;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentidadeAcesso.CrossCutting.Identity.CredentialsValidator
{
    public class CredentialsValidate : IResourceOwnerPasswordValidator
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public CredentialsValidate(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var usuariosBusca = await _usuarioRepository.Buscar(c => c.Email.Endereco.Equals(context.UserName) && c.Senha.ValidarSenha(context.Password));

            if (usuariosBusca.Any())
            {
                var usuario = usuariosBusca.SingleOrDefault();
                var subject = usuario.Id.ToString();

                var claims = new List<Claim>()
                {
                    new Claim("nome", usuario.Nome.PrimeiroNome),
                    new Claim("sobrenome", usuario.Nome.Sobrenome),
                    new Claim("email", usuario.Email.Endereco),
                    new Claim("perfilId", usuario.PerfilId.ToString())
                };

                context.Result = new GrantValidationResult(subject, authenticationMethod: "custom", claims);
            }
        }
    }
}
