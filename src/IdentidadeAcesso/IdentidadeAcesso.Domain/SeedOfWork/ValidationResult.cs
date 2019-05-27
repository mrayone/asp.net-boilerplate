using System.Collections.Generic;
using System.Linq;

namespace IdentidadeAcesso.Domain.SeedOfWork
{
    public sealed class ValidationResult
    {
        private Dictionary<string, string> _erros;
        public IReadOnlyDictionary<string, string> Erros => _erros;

        public bool IsValid
        {
            get
            {
                return !_erros.Any();
            }
        }

        public ValidationResult()
        {
            _erros = new Dictionary<string, string>();
        }

        public void AdicionarErro(string erro, string mensagem)
        {
            _erros.Add(erro, mensagem);
        }
    }
}