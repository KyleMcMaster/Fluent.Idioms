namespace AutoFixture.Idioms.Fluent.Extensions.Tests
{
    internal class Foo
    {
        private string Bar { get; set; }

        public Foo(string bar) => Bar = bar;

        public void SetBar(string newBar) => Bar = newBar;
    }
}
