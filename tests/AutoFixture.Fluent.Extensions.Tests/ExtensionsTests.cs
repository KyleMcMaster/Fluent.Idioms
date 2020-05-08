using AutoFixture.Idioms;
using Fluent.Idioms.Constructors;
using Fluent.Idioms.Extensions;
using Fluent.Idioms.Methods;
using Xunit;

namespace Fluent.Idioms.Tests
{
    public class ExtensionsTests
    {
        [Fact]
        public void ConstructorWithValidationWillGuardAgainstNullParameters()
        {
            typeof(GuardedFoo)
                .Constructors()
                .ShouldGuardAgainstNullParameters();
        }

        [Fact]
        public void MethodWithValidationWillGuardAgainstNullParameters()
        {
            typeof(GuardedFoo)
                .Methods()
                .ShouldGuardAgainstNullParameters();
        }

        [Fact]
        public void ConstructorWithoutValidationWillAllowNullParameter()
        {
            Assert.Throws<GuardClauseException>(() =>
                typeof(Foo)
                .Constructors()
                .ShouldGuardAgainstNullParameters());
        }

        [Fact]
        public void MethodWithoutValidationWillAllowNullParameter()
        {
            Assert.Throws<GuardClauseException>(() =>
                typeof(Foo)
                .Methods()
                .ShouldGuardAgainstNullParameters());
        }
    }
}
