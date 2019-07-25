using IdentidadeAcesso.CrossCutting.Identity.Configuration;
using IdentidadeAcesso.CrossCutting.Identity.Policy.Requirement;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.Repository;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeAcesso.CrossCutting.Identity.Policy.Handler
{
    public class PermissaoPolicyHandler : AuthorizationHandler<PermissaoPolicyRequeriment>
    {
        private readonly IPermissaoRepository permissaoRepository;
        private readonly IPerfilRepository perfilRepository;

        public PermissaoPolicyHandler(IPermissaoRepository permissaoRepository, IPerfilRepository perfilRepository)
        {
            this.permissaoRepository = permissaoRepository;
            this.perfilRepository = perfilRepository;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissaoPolicyRequeriment requirement)
        {
            //TODO: validar se usuário contém perfil com permissão.

            var usuario = context.User;

            context.Succeed(requirement);

            //TODO: Use the following if targeting a version of
            //.NET Framework older than 4.6:
            //      return Task.FromResult(0);
            return Task.CompletedTask;
        }
    }
}
