using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.System.Company;

namespace ERP.Domain.Setup.System.CostCenters.CostCenter;

public sealed class CostCenter : Entity<CostCenterId>
{
    private CostCenter(CostCenterId id, CompanyId companyId, CostCenterCode code, CostCenterName name, bool isActive)
        : base(id)
    {
        CompanyId = companyId;
        Code = code;
        Name = name;
        IsActive = isActive;
    }

    public CompanyId CompanyId { get; }
    public CostCenterCode Code { get; private set; }
    public CostCenterName Name { get; private set; }
    public bool IsActive { get; private set; }

    public static CostCenter Create(CostCenterId id, CompanyId companyId, CostCenterCode code, CostCenterName name)
    {
        ArgumentNullException.ThrowIfNull(id);
        ArgumentNullException.ThrowIfNull(companyId);
        ArgumentNullException.ThrowIfNull(code);
        ArgumentNullException.ThrowIfNull(name);

        return new CostCenter(id, companyId, code, name, isActive: true);
    }

    public void Rename(CostCenterName name)
    {
        EnsureActive();
        ArgumentNullException.ThrowIfNull(name);
        Name = name;
    }

    public void ChangeCode(CostCenterCode code, bool isUsed)
    {
        EnsureActive();
        ArgumentNullException.ThrowIfNull(code);

        if (isUsed)
            throw new InvalidCostCenterException("Cost center code cannot be changed when it is used in the system.");

        Code = code;
    }

    public void Deactivate(bool isUsed)
    {
        EnsureActive();

        if (isUsed)
            throw new InvalidCostCenterException("Cost center cannot be deactivated when it is used in the system.");

        IsActive = false;
    }

    public void Activate() => IsActive = true;

    private void EnsureActive()
    {
        if (!IsActive)
            throw new InvalidCostCenterException("Inactive cost center cannot be modified.");
    }
}
