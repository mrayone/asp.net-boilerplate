using IdentidadeAcesso.CrossCutting.Identity.Policy.Requirement;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeAcesso.CrossCutting.Identity.Policy
{
    public class PermissaoPolicyProvider : IAuthorizationPolicyProvider
    {
        const string POLICY_PREFIX = "PermissaoPolicy";
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => Task.FromResult(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build());

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            if (policyName.StartsWith(POLICY_PREFIX, StringComparison.OrdinalIgnoreCase))
            {
                var policy = new AuthorizationPolicyBuilder();
                var valor = policyName.Substring(POLICY_PREFIX.Length);
                policy.AddRequirements(new PermissaoPolicyRequeriment(valor));
                return Task.FromResult(policy.Build());
            }

            return Task.FromResult<AuthorizationPolicy>(null);
        }
    }
}
