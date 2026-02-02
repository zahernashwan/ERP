using ERP.Domain.Setup.Exceptions;

namespace ERP.Domain.Setup.System.ChartOfAccounts.Account;

public sealed class Account : Entity<AccountId>
{
    private Account(
        AccountId id,
        AccountNumber number,
        AccountName name,
        AccountType type,
        AccountId? parentAccountId,
        bool isActive)
        : base(id)
    {
        Number = number;
        Name = name;
        Type = type;
        ParentAccountId = parentAccountId;
        IsActive = isActive;
    }

    public AccountNumber Number { get; private set; }
    public AccountName Name { get; private set; }
    public AccountType Type { get; private set; }

    public AccountId? ParentAccountId { get; private set; }

    public bool IsActive { get; private set; }

    public static Account Create(
        AccountId id,
        AccountNumber number,
        AccountName name,
        AccountType type,
        AccountId? parentAccountId = null)
    {
        ArgumentNullException.ThrowIfNull(id);
        ArgumentNullException.ThrowIfNull(number);
        ArgumentNullException.ThrowIfNull(name);

        if (parentAccountId is not null && parentAccountId.Equals(id))
            throw new InvalidAccountException("Account cannot be its own parent.");

        return new Account(id, number, name, type, parentAccountId, isActive: true);
    }

    public void Rename(AccountName name)
    {
        EnsureActive();
        ArgumentNullException.ThrowIfNull(name);
        Name = name;
    }

    public void ChangeNumber(AccountNumber number)
    {
        EnsureActive();
        ArgumentNullException.ThrowIfNull(number);
        Number = number;
    }

    public void Deactivate(bool hasChildren)
    {
        EnsureActive();

        if (hasChildren)
            throw new InvalidAccountException("Account cannot be deactivated while it has child accounts.");

        IsActive = false;
    }

    public void Activate(bool isParentActive)
    {
        if (!isParentActive)
            throw new InvalidAccountException("Account cannot be activated when its parent is inactive.");

        IsActive = true;
    }

    public void EnsureCanPost(bool isLeaf)
    {
        if (!isLeaf)
            throw new InvalidAccountException("Posting is not allowed on a parent account.");

        if (!IsActive)
            throw new InvalidAccountException("Posting is not allowed on an inactive account.");
    }

    private void EnsureActive()
    {
        if (!IsActive)
            throw new InvalidAccountException("Inactive account cannot be modified.");
    }
}
