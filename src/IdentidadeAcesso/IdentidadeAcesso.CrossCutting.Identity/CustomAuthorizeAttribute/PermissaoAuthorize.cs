using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.CrossCutting.Identity.CustomAuthorizeAttribute
{
    public class PermissaoAuthorize : AuthorizeAttribute
    {
        const string POLICY_PREFIX = "PermissaoPolicy";

        public PermissaoAuthorize(string valor) => Valor = valor;
        public string Valor
        {
            get
            {
                return Policy.Substring(POLICY_PREFIX.Length);
            }

            private set
            {
                Policy = $"{POLICY_PREFIX}{value}";
            }
        }
    }
}
