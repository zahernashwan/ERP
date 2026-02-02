using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.Inventory.Policies;
using ERP.Domain.Setup.Inventory.UnitOfMeasure;
using Xunit;

namespace ERP.Domain.Tests.Setup.Inventory.Policies;

public sealed class UnitOfMeasureCodeUniquenessPolicyTests
{
    [Fact]
    public void EnsureUnique_WhenDuplicate_Throws()
    {
        var candidate = UnitOfMeasureCode.From("KG");
        IReadOnlyCollection<UnitOfMeasureCode> existing = [UnitOfMeasureCode.From("KG")];

        Assert.Throws<InvalidUnitOfMeasureException>((Action)(() =>
            UnitOfMeasureCodeUniquenessPolicy.EnsureUnique(candidate, existing)));
    }

    [Fact]
    public void EnsureUnique_WhenUnique_DoesNotThrow()
    {
        var candidate = UnitOfMeasureCode.From("G");
        IReadOnlyCollection<UnitOfMeasureCode> existing = [UnitOfMeasureCode.From("KG")];

        UnitOfMeasureCodeUniquenessPolicy.EnsureUnique(candidate, existing);
    }
}
