using Microsoft.AspNetCore.Authorization;

namespace IdentidadeAcesso.CrossCutting.Identity.Policy.Requeriment
{
    public class PermissaoPolicyRequeriment : IAuthorizationRequirement
    {
        public string ValorPermitido { get; }

        public PermissaoPolicyRequeriment(string valorPermitido)
        {
            ValorPermitido = valorPermitido;
        }
    }
}