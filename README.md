# AutoFixture.Idioms.Fluent.Extensions

A small set of extensions to make fixtures and assertions more fluent! Wow!

## Motivation

This project was motivated by this article [here](https://madstt.dk/verify-your-guards-with-autofixture/). In the article, the author demonstrates a way to verify the use of guarded parameters in constructors and methods by asserting that invalid values throw various types of exceptions. A brief overview of my evolution through what would be my initial code and then a refactoring inspired by this article is demonstrated here:

```csharp
// the Billboard class constructor
public Billboard(string message)
{
    if (message is null)
    {
        throw new ArgumentNullException(nameof(message));
    }

    this.Message = message;
}

// example test
[Fact]
public void ConstructorGuardsAgainstNullParameters()
{
    Action nullMessageAction = () => new Billboard(null);

    // shoutout to FluentAssertions for Should() :)
    nullMessageAction.Should().Throw<ArgumentNullException>();
}
```

Without completely covering the article, this looks fairly simple right? Well let's take a look at how this test grows as we add a class with multiple constructor parameters. We'll add a Painter who will paint the Billboard.

```csharp
// the painter class constructor
public Painter(string firstName, string lastName, string socialSecurityNumber)
{
    if (firstName is null)
    {
        throw new ArgumentNullException(nameof(firstName));
    }

    if (lastName is null)
    {
        throw new ArgumentNullException(nameof(lastName));
    }

    if (socialSecurityNumber is null)
    {
    throw new ArgumentNullException(nameof(socialSecurityNumber));
    }

    FirstName = firstName;
    LastName = lastName;
    SocialSecurityNumber = socialSecurityNumber;
}

// another example test
[Theory]
[InlineData("Foo", "Bar", "123-45-6789")]
public void ConstructorGuardsAgainstNullParameters(string firstName, string lastName, string socialSecurityNumber)
{
    Action nullFirstNameAction = () => new Painter(null, lastName, socialSecurityNumber);

    Action nullLastNameAction = () => new Painter(firstName, null, socialSecurityNumber);

    Action nullSocialSecurityNumberAction = () => new Painter(firstName, lastName, null);

    nullFirstNameAction.Should().Throw<ArgumentNullException>();
    nullLastNameAction.Should().Throw<ArgumentNullException>();
    nullSocialSecurityNumberAction.Should().Throw<ArgumentNullException>();
}
```

See how the above tests grow in complexity with more parameters, the article presents a novel method for solving this issue. Demonstrated for reference in the two tests below.

```csharp
[Fact]
public void BillboardConstructorGuardsAgainstNullParameters()
{
    var fixture = new Fixture();
    var assertion = new GuardClauseAssertion(fixture);
    assertion.Verify(typeof(Billboard).GetConstructors());
}

[Fact]
public void PainterConstructorGuardsAgainstNullParameters()
{
    var fixture = new Fixture();
    var assertion = new GuardClauseAssertion(fixture);
    assertion.Verify(typeof(Painter).GetConstructors());
}
```

While this is a significant improvement over the previous iterations of the tests, I wanted a way to make these tests flow more fluently. This code exercise ultimately lead to a few extension methods demonstrated below.

```csharp
[Fact]
public void BillboardConstructorGuardsAgainstNullParameters() =>
    typeof(Painter)
        .Constructors()
        .ShouldGuardAgainstNullParameters();

[Fact]
public void PainterConstructorGuardsAgainstNullParameters() =>
    typeof(Painter)
        .Constructors()
        .ShouldGuardAgainstNullParameters();
```

So essentially the inner workings of this extension is to wrap a customized fixture in an extension method and using the GuardClauseAssertion Idiom in a more fluent expression format.
