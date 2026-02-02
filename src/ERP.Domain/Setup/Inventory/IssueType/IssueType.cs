using ERP.Domain.Setup.Exceptions;

namespace ERP.Domain.Setup.Inventory.IssueType;

public sealed class IssueType : Entity<IssueTypeId>
{
    private IssueType(IssueTypeId id, IssueTypeCode code, IssueTypeName name, bool isActive)
        : base(id)
    {
        Code = code;
        Name = name;
        IsActive = isActive;
    }

    public IssueTypeCode Code { get; private set; }
    public IssueTypeName Name { get; private set; }
    public bool IsActive { get; private set; }

    public static IssueType Create(IssueTypeId id, IssueTypeCode code, IssueTypeName name)
    {
        ArgumentNullException.ThrowIfNull(id);
        ArgumentNullException.ThrowIfNull(code);
        ArgumentNullException.ThrowIfNull(name);

        return new IssueType(id, code, name, isActive: true);
    }

    public void Rename(IssueTypeName name)
    {
        EnsureActive();
        ArgumentNullException.ThrowIfNull(name);
        Name = name;
    }

    public void ChangeCode(IssueTypeCode code, bool isUsed)
    {
        EnsureActive();
        ArgumentNullException.ThrowIfNull(code);

        if (isUsed)
            throw new InvalidIssueTypeException("Issue type code cannot be changed when it is used in the system.");

        Code = code;
    }

    public void Deactivate(bool isUsed)
    {
        EnsureActive();

        if (isUsed)
            throw new InvalidIssueTypeException("Issue type cannot be deactivated when it is used in the system.");

        IsActive = false;
    }

    public void Activate() => IsActive = true;

    private void EnsureActive()
    {
        if (!IsActive)
            throw new InvalidIssueTypeException("Inactive issue type cannot be modified.");
    }
}
