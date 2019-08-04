using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.Repository;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeAcesso.CrossCutting.Identity.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IPerfilRepository _perfilRepository;
        private readonly IPermissaoRepository _permissaoRepository;

        public ProfileService(IPerfilRepository perfilRepository, IPermissaoRepository permissaoRepository)
        {
            _perfilRepository = perfilRepository;
            _permissaoRepository = permissaoRepository;
        }
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            //Extend here for custom data  and claims like email from user database

            var identities = context.Subject.Identities.FirstOrDefault();
            var perfilId = identities.Claims.Where(c => c.Type == "perfilId").FirstOrDefault();
            var nome = identities.Claims.Where(c => c.Type == "nome").FirstOrDefault();
            var sobrenome = identities.Claims.Where(c => c.Type == "sobrenome").FirstOrDefault();
            var email = identities.Claims.Where(c => c.Type == "email").FirstOrDefault();

            var perfil = await _perfilRepository.ObterComPermissoesAsync(Guid.Parse(perfilId.Value));

            if(perfil != null)
            {
                foreach (var item in perfil.Atribuicoes)
                {
                    var permissao = await _permissaoRepository.ObterPorIdAsync(item.PermissaoId);
                    context.IssuedClaims.Add(new Claim("permissions", permissao.Atribuicao.Valor));
                }
            }
            context.IssuedClaims.AddRange(new List<Claim>()
            {
                nome,
                sobrenome,
                email
            });
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.FromResult(context.IsActive);
        }
    }
}
