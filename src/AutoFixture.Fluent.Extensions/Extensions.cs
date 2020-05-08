using Ardalis.GuardClauses;
using AutoFixture;
using AutoFixture.Idioms;
using Fluent.Idioms.Fixtures;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Fluent.Idioms.Extensions
{
    public static class Extensions
    {
        private static readonly Fixture DomainFixture = new DomainFixture();
        private static readonly GuardClauseAssertion guardClauseAssertion = new GuardClauseAssertion(DomainFixture);
        private static readonly WritablePropertyAssertion writablePropertyAssertion = new WritablePropertyAssertion(DomainFixture);

        public static void ShouldGuardAgainstNullParameters(this IEnumerable<ConstructorInfo> constructors)
        {
            Guard.Against.NullOrEmpty(constructors, nameof(constructors));

            guardClauseAssertion.Verify(constructors);
        }

        public static void ShouldGuardAgainstNullParameters(this IEnumerable<MethodInfo> methods)
        {
            Guard.Against.NullOrEmpty(methods, nameof(methods));

            guardClauseAssertion.Verify(methods);
        }

        public static void PublicPropertiesNotAreReadonly(this IEnumerable<PropertyInfo> properties)
        {
            Guard.Against.NullOrEmpty(properties, nameof(properties));

            var publicWriteableProperties = properties
                .Where(prop => prop.PropertyType.IsPublic);

            writablePropertyAssertion.Verify(properties);
        }
    }
}