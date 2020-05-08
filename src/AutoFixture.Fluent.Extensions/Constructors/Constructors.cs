using Ardalis.GuardClauses;
using System;
using System.Reflection;

namespace Fluent.Idioms.Constructors
{
    public static class ConstructorExtensions
    {
        public static ConstructorInfo[] Constructors(this Type type)
        {
            Guard.Against.Null(type, nameof(type));

            var constructors = type.GetConstructors();

            Guard.Against.Null(constructors, nameof(constructors));

            return constructors;
        }
    }
}
