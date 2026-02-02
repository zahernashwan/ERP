using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.Inventory.Policies;
using ERP.Domain.Setup.Inventory.SupplyType;
using Xunit;

namespace ERP.Domain.Tests.Setup.Inventory.Policies;

public sealed class SupplyTypeCodeUniquenessPolicyTests
{
    [Fact]
    public void EnsureUnique_WhenDuplicate_Throws()
    {
        var candidate = SupplyTypeCode.From("IN");
        IReadOnlyCollection<SupplyTypeCode> existing = [SupplyTypeCode.From("IN")];

        Assert.Throws<InvalidSupplyTypeException>((Action)(() =>
            SupplyTypeCodeUniquenessPolicy.EnsureUnique(candidate, existing)));
    }

    [Fact]
    public void EnsureUnique_WhenUnique_DoesNotThrow()
    {
        var candidate = SupplyTypeCode.From("OUT");
        IReadOnlyCollection<SupplyTypeCode> existing = [SupplyTypeCode.From("IN")];

        SupplyTypeCodeUniquenessPolicy.EnsureUnique(candidate, existing);
    }
}
