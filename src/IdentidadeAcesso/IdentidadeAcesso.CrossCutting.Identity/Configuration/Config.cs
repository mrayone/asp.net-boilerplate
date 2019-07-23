﻿using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.CrossCutting.Identity.Configuration
{
    internal class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource("api", "Nossa API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client
                {
                    ClientId = "password.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api" }
                }
            };
        }

        public static List<TestUser> GetTestUsers ()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "maycon",
                    Password = "123456"
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
