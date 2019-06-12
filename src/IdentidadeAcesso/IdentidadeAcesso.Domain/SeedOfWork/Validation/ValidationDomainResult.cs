using System.Collections.Generic;
using System.Linq;

namespace IdentidadeAcesso.Domain.SeedOfWork.Validation
{
    public sealed class ValidationDomainResult
    {
        private List<string> _erros;
        public IReadOnlyList<string> Erros => _erros;

        public bool IsValid
        {
            get
            {
                return !_erros.Any();
            }
        }

        public ValidationDomainResult()
        {
            _erros = new List<string>();
        }

        public void AdicionarErro(string mensagem)
        {
            _erros.Add(mensagem);
        }
    }
}