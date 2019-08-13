using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace IdentidadeAcesso.CrossCutting.Identity.Configuration
{
    internal class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource("api", "Api Knowledge Identidade e Acesso.")
                {
                    ApiSecrets = new List<Secret>
                    {
                        new Secret("hello".Sha256())
                    },
                    Scopes=
                    {
                        new Scope("validate_token")
                    }
                },
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client
                {
                    ClientId = "spa.client",
                    ClientName = "Meu SPA",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    RequireClientSecret =  false,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api", IdentityServerConstants.StandardScopes.OfflineAccess },
                    AllowOfflineAccess =  true,
                    UpdateAccessTokenClaimsOnRefresh = true,
                }
            };
        }

        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "maycon",
                    Password = "123456",
                    Claims = new []
                    {
                        new Claim("name", "Maycon"),
                        new Claim("website", "https://mayconrayone.com")
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "pereira",
                    Password = "123456"
                }
            };
        }
    }
}
