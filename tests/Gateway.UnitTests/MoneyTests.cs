using Gateway.Domain;

namespace Gateway.UnitTests;

public class MoneyTests
{
    [Fact]
    public void Constructor_ZeroAmount_IsAllowed()
    {
        var money = new Money(0, "USD");
        Assert.Equal(0, money.AmountMinor);
    }

    [Fact]
    public void Constructor_NegativeAmount_IsNotAllowed()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Money(-10, "USD"));
    }

    [Fact]
    public void Constructor_NullCurrency_IsNotAllowed()
    {
        Assert.Throws<ArgumentNullException>(() => new Money(10, null!));
    }

    [Theory]
    [InlineData(" ")]
    [InlineData("MMK")]
    public void Constructor_InvalidCurrency_IsNotAllowed(string currency)
    {
        Assert.Throws<ArgumentException>(() => new Money(10, currency));
    }

    [Fact]
    public void Constructor_SameAmountDifferentCurrency_IsNotTheSame()
    {
        var usd = new Money(100, "USD");
        var eur = new Money(100, "EUR");

        Assert.NotEqual(usd, eur);
    }

    [Theory]
    [InlineData("USD", 2)]
    [InlineData("EUR", 2)]
    [InlineData("JPY", 0)]
    [InlineData("KWD", 3)]
    public void GetExponent_DifferentCurrencies_ReturnsCorrectExponent(string currency, int exponent)
    {
        Assert.Equal(exponent, Currencies.GetExponent(currency));
    }

    [Fact]
    public void GetExponent_InvalidCurrency_IsNotValid()
    {
        Assert.Throws<ArgumentException>(() => Currencies.GetExponent("N/A"));
    }
}