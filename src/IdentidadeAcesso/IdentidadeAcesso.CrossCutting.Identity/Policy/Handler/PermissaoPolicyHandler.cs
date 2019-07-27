using IdentidadeAcesso.CrossCutting.Identity.Configuration;
using IdentidadeAcesso.CrossCutting.Identity.Policy.Requirement;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.AggregatesModel.PermissaoAggregate.Repository;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeAcesso.CrossCutting.Identity.Policy.Handler
{
    public class PermissaoPolicyHandler : AuthorizationHandler<PermissaoPolicyRequeriment>
    {

        public PermissaoPolicyHandler()
        {
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissaoPolicyRequeriment requirement)
        {
            if (!context.User.HasClaim(c => c.Type.Equals("permissions") && c.Value.Equals(requirement.ValorPermitido)))
            {
                return Task.CompletedTask;
            }

            context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
