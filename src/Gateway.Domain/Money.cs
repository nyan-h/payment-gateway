namespace Gateway.Domain;

public record Money(long AmountMinor, string Currency)
{
    public long AmountMinor { get; init; } = AmountMinor >= 0
        ? AmountMinor
        : throw new ArgumentOutOfRangeException(nameof(AmountMinor), "Amount cannot be negative.");

    public string Currency { get; init; } = ValidateCurrency(Currency);

    private static string ValidateCurrency(string currency)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(currency);

        if (!Currencies.IsSupported(currency))
            throw new ArgumentException($"Currency '{currency}' is not supported.", nameof(currency));

        return currency;
    }
}