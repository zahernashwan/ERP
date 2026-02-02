using ERP.Domain.Setup.Exceptions;

namespace ERP.Domain.Setup.System.Company;

public sealed class Company : Entity<CompanyId>
{
    private Company(CompanyId id, CompanyName name, TaxRegistrationNumber? taxRegistrationNumber, bool isActive)
        : base(id)
    {
        Name = name;
        TaxRegistrationNumber = taxRegistrationNumber;
        IsActive = isActive;
    }

    public CompanyName Name { get; private set; }
    public TaxRegistrationNumber? TaxRegistrationNumber { get; private set; }
    public bool IsActive { get; private set; }

    public static Company Create(CompanyId id, CompanyName name, TaxRegistrationNumber? taxRegistrationNumber = null)
    {
        ArgumentNullException.ThrowIfNull(id);
        ArgumentNullException.ThrowIfNull(name);

        return new Company(id, name, taxRegistrationNumber, isActive: true);
    }

    public void Rename(CompanyName name)
    {
        EnsureActive();
        ArgumentNullException.ThrowIfNull(name);
        Name = name;
    }

    public void SetTaxRegistrationNumber(TaxRegistrationNumber? taxRegistrationNumber)
    {
        EnsureActive();
        TaxRegistrationNumber = taxRegistrationNumber;
    }

    public void Deactivate(string reason)
    {
        if (string.IsNullOrWhiteSpace(reason))
            throw new InvalidCompanyException("Deactivation reason is required.");

        if (!IsActive)
            throw new InvalidCompanyException("Company is already inactive.");

        IsActive = false;
    }

    public void Activate()
    {
        if (IsActive)
            return;

        IsActive = true;
    }

    private void EnsureActive()
    {
        if (!IsActive)
            throw new InvalidCompanyException("Inactive company cannot be modified.");
    }
}
