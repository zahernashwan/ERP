using ERP.Domain;

namespace ERP.Application;

public static class AssemblyMarker
{
    // This reference ensures ERP.Domain appears in GetReferencedAssemblies
    private static readonly Type DomainRef = typeof(ERP.Domain.AssemblyMarker);
}
