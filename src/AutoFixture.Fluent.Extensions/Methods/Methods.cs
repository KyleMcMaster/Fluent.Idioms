using Ardalis.GuardClauses;
using System;
using System.Reflection;

namespace AutoFixture.Idioms.Fluent.Extensions.Methods
{
    public static class MethodExtensions
    {
        public static MethodInfo[] Methods(this Type type)
        {
            Guard.Against.Null(type, nameof(type));

            var methods = type.GetMethods();

            Guard.Against.NullOrEmpty(methods, nameof(methods));

            return methods;
        }
    }
}
