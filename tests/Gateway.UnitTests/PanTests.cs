using Gateway.Domain;

namespace Gateway.UnitTests;

public class PanTests
{
    [Fact]
    public void IsLuhnValid_ValidCardNumber_ReturnsTrue()
    {
        Assert.True(Pan.IsLuhnValid("4111111111111111"));
    }

    [Fact]
    public void IsLuhnValid_InvalidCardNumber_ReturnsFalse()
    {
        Assert.False(Pan.IsLuhnValid("4111111111121111"));
    }

    [Theory]
    [InlineData("4111111111111111", CardBrand.Visa)]
    [InlineData("4012888888881881", CardBrand.Visa)]
    [InlineData("5555555555554444", CardBrand.Mastercard)]
    [InlineData("5105105105105100", CardBrand.Mastercard)]
    [InlineData("2223003122003222", CardBrand.Mastercard)]
    [InlineData("378282246310005", CardBrand.Amex)]
    [InlineData("371449635398431", CardBrand.Amex)]
    [InlineData("6011111111111117", CardBrand.Discover)]
    [InlineData("6511111111111119", CardBrand.Discover)]
    [InlineData("9999999999999995", CardBrand.Unknown)]
    public void DetectBrand_KnownPrefix_ReturnsExpectedBrand(string pan, CardBrand expected) =>
    Assert.Equal(expected, Pan.DetectBrand(pan));

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("41111")]                      // too short
    [InlineData("41111111111111111111")]       // too long
    [InlineData("4111-1111-1111-1111")]        // separators
    [InlineData("4111a11111111111")]           // letters
    [InlineData("４１１１１１１１１１１１１１１１")]  // full-width digits
    public void DetectBrand_ImplausiblePan_ReturnsUnknown(string? pan) =>
        Assert.Equal(CardBrand.Unknown, Pan.DetectBrand(pan!));

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("41111")]
    [InlineData("41111111111111111111")]
    [InlineData("4111-1111-1111-1111")]
    [InlineData("4111a11111111111")]
    [InlineData("４１１１１１１１１１１１１１１１")]
    public void IsLuhnValid_ImplausiblePan_ReturnsFalse(string? pan) =>
        Assert.False(Pan.IsLuhnValid(pan!));
}