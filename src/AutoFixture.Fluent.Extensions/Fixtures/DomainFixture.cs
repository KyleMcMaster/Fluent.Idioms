using AutoFixture;
using AutoFixture.AutoNSubstitute;

namespace Fluent.Idioms.Fixtures
{
    internal class DomainFixture : Fixture
    {
        public DomainFixture() : base() =>
            Customize(new AutoNSubstituteCustomization());
    }
}
