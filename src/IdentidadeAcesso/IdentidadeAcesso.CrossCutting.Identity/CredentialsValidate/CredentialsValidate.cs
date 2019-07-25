using IdentidadeAcesso.Domain.AggregatesModel.UsuarioAggregate.Repository;
using IdentityServer4.Validation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IdentityModel.OidcConstants;

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
            var usuarioBusca = await _usuarioRepository.Buscar(c => c.Email.Endereco.Equals(context.UserName) && c.Senha.ValidarSenha(context.Password));

            if(usuarioBusca.Any())
            {
                var user = usuarioBusca.SingleOrDefault();
                var subject = JsonConvert.SerializeObject(new
                {
                    Permissoes = new object[] 
                    {
                        new { Tipo = "Perfil", Valor = "Visualizar Perfil" }
                    }
                }); // TODO: passar dados do usuário e permissões.
               context.Result = new GrantValidationResult(subject, authenticationMethod: "custom");
            }
        }
    }
}
