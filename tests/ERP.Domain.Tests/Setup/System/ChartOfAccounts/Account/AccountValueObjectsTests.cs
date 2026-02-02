using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.System.ChartOfAccounts.Account;
using Xunit;

namespace ERP.Domain.Tests.Setup.System.ChartOfAccounts.Account;

public sealed class AccountValueObjectsTests
{
    [Fact]
    public void AccountNumber_From_WhenInvalidChar_Throws()
    {
        Assert.Throws<InvalidAccountException>(() => AccountNumber.From("1A"));
    }

    [Fact]
    public void AccountName_From_WhenWhitespace_Throws()
    {
        Assert.Throws<InvalidAccountException>(() => AccountName.From(" "));
    }
}
