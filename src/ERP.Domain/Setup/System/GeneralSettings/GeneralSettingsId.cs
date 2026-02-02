namespace ERP.Domain.Setup.System.GeneralSettings;

public sealed class GeneralSettingsId : ValueObject
{
    public Guid Value { get; }

    private GeneralSettingsId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("General settings id cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public static GeneralSettingsId New() => new(Guid.NewGuid());

    public static GeneralSettingsId FromGuid(Guid value) => new(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value.ToString();
}
