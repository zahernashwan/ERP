using ERP.Domain.Setup.Exceptions;

namespace ERP.Domain.Setup.Inventory.SupplyType;

public sealed class SupplyType : Entity<SupplyTypeId>
{
    private SupplyType(SupplyTypeId id, SupplyTypeCode code, SupplyTypeName name, bool isActive)
        : base(id)
    {
        Code = code;
        Name = name;
        IsActive = isActive;
    }

    public SupplyTypeCode Code { get; private set; }
    public SupplyTypeName Name { get; private set; }
    public bool IsActive { get; private set; }

    public static SupplyType Create(SupplyTypeId id, SupplyTypeCode code, SupplyTypeName name)
    {
        ArgumentNullException.ThrowIfNull(id);
        ArgumentNullException.ThrowIfNull(code);
        ArgumentNullException.ThrowIfNull(name);

        return new SupplyType(id, code, name, isActive: true);
    }

    public void Rename(SupplyTypeName name)
    {
        EnsureActive();
        ArgumentNullException.ThrowIfNull(name);
        Name = name;
    }

    public void ChangeCode(SupplyTypeCode code, bool isUsed)
    {
        EnsureActive();
        ArgumentNullException.ThrowIfNull(code);

        if (isUsed)
            throw new InvalidSupplyTypeException("Supply type code cannot be changed when it is used in the system.");

        Code = code;
    }

    public void Deactivate(bool isUsed)
    {
        EnsureActive();

        if (isUsed)
            throw new InvalidSupplyTypeException("Supply type cannot be deactivated when it is used in the system.");

        IsActive = false;
    }

    public void Activate() => IsActive = true;

    private void EnsureActive()
    {
        if (!IsActive)
            throw new InvalidSupplyTypeException("Inactive supply type cannot be modified.");
    }
}
