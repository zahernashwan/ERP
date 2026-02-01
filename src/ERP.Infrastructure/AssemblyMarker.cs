using ERP.Application;
using ERP.Domain;

namespace ERP.Infrastructure;

public static class AssemblyMarker
{
    // These references ensure dependencies appear in GetReferencedAssemblies
    private static readonly Type ApplicationRef = typeof(ERP.Application.AssemblyMarker);
    private static readonly Type DomainRef = typeof(ERP.Domain.AssemblyMarker);
}
