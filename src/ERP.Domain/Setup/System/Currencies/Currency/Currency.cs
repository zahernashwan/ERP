using ERP.Domain.Setup.Exceptions;

namespace ERP.Domain.Setup.System.Currencies.Currency;

public sealed class Currency : Entity<CurrencyId>
{
    private Currency(CurrencyId id, string isoCode, string name, int minorUnit, bool isActive, bool isBaseCurrency)
        : base(id)
    {
        IsoCode = isoCode;
        Name = name;
        MinorUnit = minorUnit;
        IsActive = isActive;
        IsBaseCurrency = isBaseCurrency;
    }

    public string IsoCode { get; private set; }
    public string Name { get; private set; }

    /// <summary>
    /// Number of decimal places (minor units) used by this currency (e.g. 2 for USD, 0 for JPY).
    /// </summary>
    public int MinorUnit { get; private set; }

    public bool IsActive { get; private set; }

    /// <summary>
    /// Indicates whether this currency is the system base currency.
    /// </summary>
    public bool IsBaseCurrency { get; private set; }

    public static Currency Create(CurrencyId id, string isoCode, string name, int minorUnit, bool isBaseCurrency = false)
    {
        ArgumentNullException.ThrowIfNull(id);

        isoCode = NormalizeIsoCode(isoCode);
        name = NormalizeName(name);

        if (minorUnit < 0 || minorUnit > 6)
            throw new InvalidCurrencyException("Minor unit must be between 0 and 6.");

        return new Currency(id, isoCode, name, minorUnit, isActive: true, isBaseCurrency: isBaseCurrency);
    }

    public void Rename(string name)
    {
        EnsureActive(IsActive);
        Name = NormalizeName(name);
    }

    public void Deactivate()
    {
        if (IsBaseCurrency)
            throw new InvalidCurrencyException("Base currency cannot be deactivated.");

        IsActive = false;
    }

    public void Activate() => IsActive = true;

    public void MarkAsBaseCurrency()
    {
        EnsureActive(IsActive);
        IsBaseCurrency = true;
    }

    public static void UnmarkAsBaseCurrency()
    {
        throw new InvalidCurrencyException("Base currency can only be changed via system policy.");
    }

    private static string NormalizeIsoCode(string isoCode)
    {
        if (string.IsNullOrWhiteSpace(isoCode))
            throw new InvalidCurrencyException("Currency ISO code is required.");

        var normalized = isoCode.Trim().ToUpperInvariant();
        if (normalized.Length != 3)
            throw new InvalidCurrencyException("Currency ISO code must be a 3-letter code.");

        for (var i = 0; i < normalized.Length; i++)
        {
            if (!char.IsLetter(normalized[i]))
                throw new InvalidCurrencyException("Currency ISO code must contain letters only.");
        }

        return normalized;
    }

    private static string NormalizeName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidCurrencyException("Currency name is required.");

        var normalized = name.Trim();
        if (normalized.Length > 80)
            throw new InvalidCurrencyException("Currency name is too long.");

        return normalized;
    }

    private static void EnsureActive(bool isActive)
    {
        if (!isActive)
            throw new InvalidCurrencyException("Inactive currency cannot be modified.");
    }
}
