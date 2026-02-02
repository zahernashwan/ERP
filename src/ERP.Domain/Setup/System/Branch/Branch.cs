using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.System.Company;

namespace ERP.Domain.Setup.System.Branch;

public sealed class Branch : Entity<BranchId>
{
    private Branch(BranchId id, CompanyId companyId, BranchCode code, BranchName name, bool isActive)
        : base(id)
    {
        CompanyId = companyId;
        Code = code;
        Name = name;
        IsActive = isActive;
    }

    public CompanyId CompanyId { get; }
    public BranchCode Code { get; private set; }
    public BranchName Name { get; private set; }
    public bool IsActive { get; private set; }

    public static Branch Create(BranchId id, CompanyId companyId, BranchCode code, BranchName name)
    {
        ArgumentNullException.ThrowIfNull(id);
        ArgumentNullException.ThrowIfNull(companyId);
        ArgumentNullException.ThrowIfNull(code);
        ArgumentNullException.ThrowIfNull(name);

        return new Branch(id, companyId, code, name, isActive: true);
    }

    public void Rename(BranchName name)
    {
        EnsureActive();
        ArgumentNullException.ThrowIfNull(name);
        Name = name;
    }

    public void ChangeCode(BranchCode code)
    {
        EnsureActive();
        ArgumentNullException.ThrowIfNull(code);
        Code = code;
    }

    public void Deactivate(bool canDeactivate)
    {
        EnsureActive();

        if (!canDeactivate)
            throw new InvalidBranchException("Branch cannot be deactivated due to existing system movements.");

        IsActive = false;
    }

    public void Activate() => IsActive = true;

    private void EnsureActive()
    {
        if (!IsActive)
            throw new InvalidBranchException("Inactive branch cannot be modified.");
    }
}
