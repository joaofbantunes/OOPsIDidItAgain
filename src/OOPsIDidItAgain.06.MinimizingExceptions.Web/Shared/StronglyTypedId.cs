using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace OOPsIDidItAgain._06.MinimizingExceptions.Web.Shared
{
    public abstract class StronglyTypedId
    {
        protected StronglyTypedId(Guid id)
        {
            Value = id;
        }

        public Guid Value { get; }

        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();

        public static bool TryParse(string? input, Type stronglyTypedIdType, [MaybeNullWhen(false)] out object result)
        {
            if (Guid.TryParse(input, out var id))
            {
                result = GetConstructor(stronglyTypedIdType)(id);
                return true;
            }

            result = default;
            return false;
        }

        private static Func<Guid, object> GetConstructor(Type stronglyTypedIdType)
        {
            // TODO: cache
            var ctor = stronglyTypedIdType.GetConstructor(new[] {typeof(Guid)});
            var parameter = Expression.Parameter(typeof(Guid));
            var ctorExpression = Expression.New(ctor!, parameter);
            var lambda = Expression.Lambda<Func<Guid, object>>(ctorExpression, parameter);
            return lambda.Compile();
        }
    }

    public abstract class StronglyTypedId<TStronglyTypedId> : StronglyTypedId, IComparable<TStronglyTypedId>,
        IEquatable<TStronglyTypedId>
        where TStronglyTypedId : StronglyTypedId<TStronglyTypedId>
    {
        protected StronglyTypedId(Guid id) : base(id)
        {
        }

        public bool Equals(TStronglyTypedId? other) => other is not null && Value.Equals(other.Value);

        public int CompareTo(TStronglyTypedId? other) => Value.CompareTo(other?.Value);

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is TStronglyTypedId other && Equals(other);
        }

        public override int GetHashCode() => Value.GetHashCode();
    }
}