using ERP.Domain.Setup.Exceptions;

namespace ERP.Domain.Setup.Inventory.TransferType;

public sealed class TransferType : Entity<TransferTypeId>
{
    private TransferType(TransferTypeId id, TransferTypeCode code, TransferTypeName name, bool isActive)
        : base(id)
    {
        Code = code;
        Name = name;
        IsActive = isActive;
    }

    public TransferTypeCode Code { get; private set; }
    public TransferTypeName Name { get; private set; }
    public bool IsActive { get; private set; }

    public static TransferType Create(TransferTypeId id, TransferTypeCode code, TransferTypeName name)
    {
        ArgumentNullException.ThrowIfNull(id);
        ArgumentNullException.ThrowIfNull(code);
        ArgumentNullException.ThrowIfNull(name);

        return new TransferType(id, code, name, isActive: true);
    }

    public void Rename(TransferTypeName name)
    {
        EnsureActive();
        ArgumentNullException.ThrowIfNull(name);
        Name = name;
    }

    public void ChangeCode(TransferTypeCode code, bool isUsed)
    {
        EnsureActive();
        ArgumentNullException.ThrowIfNull(code);

        if (isUsed)
            throw new InvalidTransferTypeException("Transfer type code cannot be changed when it is used in the system.");

        Code = code;
    }

    public void Deactivate(bool isUsed)
    {
        EnsureActive();

        if (isUsed)
            throw new InvalidTransferTypeException("Transfer type cannot be deactivated when it is used in the system.");

        IsActive = false;
    }

    public void Activate() => IsActive = true;

    private void EnsureActive()
    {
        if (!IsActive)
            throw new InvalidTransferTypeException("Inactive transfer type cannot be modified.");
    }
}
