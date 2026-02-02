using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.Inventory.Policies;
using ERP.Domain.Setup.Inventory.TransferType;
using Xunit;

namespace ERP.Domain.Tests.Setup.Inventory.Policies;

public sealed class TransferTypeCodeUniquenessPolicyTests
{
    [Fact]
    public void EnsureUnique_WhenDuplicate_Throws()
    {
        var candidate = TransferTypeCode.From("TR");
        IReadOnlyCollection<TransferTypeCode> existing = [TransferTypeCode.From("TR")];

        Assert.Throws<InvalidTransferTypeException>((Action)(() =>
            TransferTypeCodeUniquenessPolicy.EnsureUnique(candidate, existing)));
    }

    [Fact]
    public void EnsureUnique_WhenUnique_DoesNotThrow()
    {
        var candidate = TransferTypeCode.From("TR2");
        IReadOnlyCollection<TransferTypeCode> existing = [TransferTypeCode.From("TR")];

        TransferTypeCodeUniquenessPolicy.EnsureUnique(candidate, existing);
    }
}
