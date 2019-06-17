using System.Collections.Generic;
using System.Linq;

namespace IdentidadeAcesso.Domain.SeedOfWork.Validation
{
    public sealed class ValidationDomainResult
    {
        private List<ValidationError> _erros;
        public IReadOnlyList<ValidationError> Erros => _erros;

        public bool IsValid
        {
            get
            {
                return !_erros.Any();
            }
        }

        public ValidationDomainResult()
        {
            _erros = new List<ValidationError>();
        }

        public void AddError(string property, string message)
        {
            _erros.Add(new ValidationError(property, message));
        }
    }

    public class ValidationError
    {
        public ValidationError(string property, string messageError)
        {
            Property = property;
            MessageError = messageError;
        }

        public string Property { get; private set; }
        public string MessageError { get; private set; }
        
    }
}