using ERP.Domain.Setup.Exceptions;

namespace ERP.Domain.Setup.Inventory.UnitOfMeasure;

public sealed class UnitOfMeasure : Entity<UnitOfMeasureId>
{
    private UnitOfMeasure(UnitOfMeasureId id, UnitOfMeasureCode code, UnitOfMeasureName name, bool isActive)
        : base(id)
    {
        Code = code;
        Name = name;
        IsActive = isActive;
    }

    public UnitOfMeasureCode Code { get; private set; }
    public UnitOfMeasureName Name { get; private set; }
    public bool IsActive { get; private set; }

    public static UnitOfMeasure Create(UnitOfMeasureId id, UnitOfMeasureCode code, UnitOfMeasureName name)
    {
        ArgumentNullException.ThrowIfNull(id);
        ArgumentNullException.ThrowIfNull(code);
        ArgumentNullException.ThrowIfNull(name);

        return new UnitOfMeasure(id, code, name, isActive: true);
    }

    public void Rename(UnitOfMeasureName name)
    {
        EnsureActive();
        ArgumentNullException.ThrowIfNull(name);
        Name = name;
    }

    public void ChangeCode(UnitOfMeasureCode code, bool isUsed)
    {
        EnsureActive();
        ArgumentNullException.ThrowIfNull(code);

        if (isUsed)
            throw new InvalidUnitOfMeasureException("Unit of measure code cannot be changed when it is used in the system.");

        Code = code;
    }

    public void Deactivate(bool isUsed)
    {
        EnsureActive();

        if (isUsed)
            throw new InvalidUnitOfMeasureException("Unit of measure cannot be deactivated when it is used in the system.");

        IsActive = false;
    }

    public void Activate() => IsActive = true;

    private void EnsureActive()
    {
        if (!IsActive)
            throw new InvalidUnitOfMeasureException("Inactive unit of measure cannot be modified.");
    }
}
