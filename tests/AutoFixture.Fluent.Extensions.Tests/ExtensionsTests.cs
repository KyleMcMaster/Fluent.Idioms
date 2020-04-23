using AutoFixture.Idioms.Fluent.Extensions.Constructors;
using AutoFixture.Idioms.Fluent.Extensions.Methods;
using Xunit;

namespace AutoFixture.Idioms.Fluent.Extensions.Tests
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
