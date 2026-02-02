using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.Inventory.IssueType;
using ERP.Domain.Setup.Inventory.Policies;
using Xunit;

namespace ERP.Domain.Tests.Setup.Inventory.Policies;

public sealed class IssueTypeCodeUniquenessPolicyTests
{
    [Fact]
    public void EnsureUnique_WhenDuplicate_Throws()
    {
        var candidate = IssueTypeCode.From("ISS");
        IReadOnlyCollection<IssueTypeCode> existing = [IssueTypeCode.From("ISS")];

        Assert.Throws<InvalidIssueTypeException>((Action)(() =>
            IssueTypeCodeUniquenessPolicy.EnsureUnique(candidate, existing)));
    }

    [Fact]
    public void EnsureUnique_WhenUnique_DoesNotThrow()
    {
        var candidate = IssueTypeCode.From("ISS2");
        IReadOnlyCollection<IssueTypeCode> existing = [IssueTypeCode.From("ISS")];

        IssueTypeCodeUniquenessPolicy.EnsureUnique(candidate, existing);
    }
}
