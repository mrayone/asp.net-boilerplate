using System;
using System.Collections.Generic;
using System.Linq;

namespace IdentidadeAcesso.Domain.SeedOfWork
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        protected List<string> _erros;
        public IReadOnlyCollection<string> Erros => _erros;

        public Entity()
        {
            _erros = new List<string>();
        }


        public virtual bool EhValido()
        {
            return !_erros.Any();
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }

    }
}