namespace Gateway.Domain;

public static class Currencies
{
	private static readonly Dictionary<string, int> SupportedCurrencies = new(StringComparer.Ordinal)
	{
		["USD"] = 2,
		["EUR"] = 2,
		["GBP"] = 2,
		["JPY"] = 0,
		["KWD"] = 3
	};

	public static bool IsSupported(string code) =>
		SupportedCurrencies.ContainsKey(code);

	public static int GetExponent(string code)
	{
		if (!SupportedCurrencies.TryGetValue(code, out int exponent))
			throw new ArgumentException($"Currency code '{code}' is not supported.", nameof(code));

		return exponent;
	}
}