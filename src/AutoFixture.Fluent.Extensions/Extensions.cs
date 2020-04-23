using Ardalis.GuardClauses;
using AutoFixture.Idioms.Fluent.Extensions.Fixtures;
using System.Collections.Generic;
using System.Reflection;

namespace AutoFixture.Idioms.Fluent.Extensions
{
    public static class Extensions
    {
        private static readonly Fixture DomainFixture = new DomainFixture();
        private static readonly GuardClauseAssertion Assertion = new GuardClauseAssertion(DomainFixture);

        public static void ShouldGuardAgainstNullParameters(this IEnumerable<ConstructorInfo> constructors)
        {
            Guard.Against.NullOrEmpty(constructors, nameof(constructors));

            Assertion.Verify(constructors);
        }

        public static void ShouldGuardAgainstNullParameters(this IEnumerable<MethodInfo> methods)
        {
            Guard.Against.NullOrEmpty(methods, nameof(methods));

            Assertion.Verify(methods);
        }
    }
}