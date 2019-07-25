using Microsoft.AspNetCore.Authorization;

namespace IdentidadeAcesso.CrossCutting.Identity.Policy
{
    public class PerfilPolicy : IAuthorizationRequirement
    {
        public string ValorPermitido { get; }
        public string Tipo { get; }

        public PerfilPolicy(string tipo, string valorPermitido)
        {
            ValorPermitido = valorPermitido;
            Tipo = tipo;
        }
    }
}