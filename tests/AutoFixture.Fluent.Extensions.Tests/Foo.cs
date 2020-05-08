namespace Fluent.Idioms.Tests
{
    internal class Foo
    {
        public string Bar { get; set; }

        public Foo(string bar) => Bar = bar;

        public void SetBar(string newBar) => Bar = newBar;
    }
}
