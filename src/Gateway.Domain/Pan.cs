namespace Gateway.Domain;

public static class Pan
{
    private const int MinLength = 12;
    private const int MaxLength = 19;

    public static CardBrand DetectBrand(string pan)
    {
        if (!IsPlausible(pan))
            return CardBrand.Unknown;

        var p2 = Prefix(pan, 2);
        var p3 = Prefix(pan, 3);
        var p4 = Prefix(pan, 4);
        var p6 = Prefix(pan, 6);

        if (pan[0] == '4')
            return CardBrand.Visa;

        if (p2 is >= 51 and <= 55 || p4 is >= 2221 and <= 2720)
            return CardBrand.Mastercard;

        if (p2 is 34 or 37)
            return CardBrand.Amex;

        if (p4 is 6011 || p2 is 65 || p3 is >= 644 and <= 649 || p6 is >= 622126 and <= 622925)
            return CardBrand.Discover;

        return CardBrand.Unknown;
    }

    public static bool IsLuhnValid(string pan)
    {
        if (!IsPlausible(pan)) return false;

        int sum = 0;
        bool doubleThis = false;

        for (int i = pan.Length - 1; i >= 0; i--)
        {
            int digit = pan[i] - '0';

            if (doubleThis)
            {
                digit *= 2;
                if (digit > 9) digit -= 9;
            }

            sum += digit;
            doubleThis = !doubleThis;
        }

        return sum % 10 == 0;
    }

    private static bool IsPlausible(string pan) =>
        !string.IsNullOrEmpty(pan)
        && pan.Length is >= MinLength and <= MaxLength
        && pan.All(char.IsAsciiDigit);

    private static int Prefix(string pan, int length) =>
        int.Parse(pan.AsSpan(0, length));
}