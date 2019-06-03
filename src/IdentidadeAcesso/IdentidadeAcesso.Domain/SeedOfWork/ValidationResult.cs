using System.Collections.Generic;
using System.Linq;

namespace IdentidadeAcesso.Domain.SeedOfWork
{
    public sealed class ValidationResult
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

        public ValidationResult()
        {
            _erros = new List<string>();
        }

        public void AdicionarErro(string mensagem)
        {
            _erros.Add(mensagem);
        }
    }
}