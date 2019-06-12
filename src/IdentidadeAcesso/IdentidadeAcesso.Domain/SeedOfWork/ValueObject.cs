using IdentidadeAcesso.Domain.SeedOfWork.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentidadeAcesso.Domain.SeedOfWork
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {

        public ValidationDomainResult ValidationResult { get; protected set; }

        public ValueObject()
        {
            ValidationResult = new ValidationDomainResult();
        }

        public bool EhValido()
        {
            return ValidationResult.IsValid;
        }

        public override bool Equals(object obj)
        {
            var valueObject = obj as T;

            if (ReferenceEquals(valueObject, null))
                return false;

            return EqualsCore(valueObject);
        }

        protected abstract bool EqualsCore(T other);

        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        protected abstract int GetHashCodeCore();

        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }
    }
}
