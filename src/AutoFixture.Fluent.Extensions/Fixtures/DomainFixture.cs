using AutoFixture.AutoNSubstitute;

namespace AutoFixture.Idioms.Fluent.Extensions.Fixtures
{
    internal class DomainFixture : Fixture
    {
        public DomainFixture() : base() =>
            Customize(new AutoNSubstituteCustomization());
    }
}
