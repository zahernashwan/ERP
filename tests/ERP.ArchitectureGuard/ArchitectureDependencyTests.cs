using System.Reflection;
using ERP.Application;
using ERP.Domain;
using ERP.Infrastructure;
#if WINDOWS
using ERP.Presentation.WinForms;
#endif
using Xunit;

namespace ERP.ArchitectureGuard;

public class ArchitectureDependencyTests
{
    [Fact]
    public void Domain_Should_Not_Depend_On_Outer_Layers()
    {
        var references = GetReferencedProjectNames(typeof(ERP.Domain.AssemblyMarker).Assembly);

        Assert.DoesNotContain("ERP.Application", references);
        Assert.DoesNotContain("ERP.Infrastructure", references);
        Assert.DoesNotContain("ERP.Presentation.WinForms", references);
    }

    [Fact]
    public void Application_Should_Not_Depend_On_Infrastructure_Or_Presentation()
    {
        var references = GetReferencedProjectNames(typeof(ERP.Application.AssemblyMarker).Assembly);

        Assert.Contains("ERP.Domain", references);
        Assert.DoesNotContain("ERP.Infrastructure", references);
        Assert.DoesNotContain("ERP.Presentation.WinForms", references);
    }

    [Fact]
    public void Application_Should_Not_Depend_On_Infrastructure()
    {
        var references = GetReferencedProjectNames(typeof(ERP.Application.AssemblyMarker).Assembly);

        Assert.DoesNotContain("ERP.Infrastructure", references);
    }

    [Fact]
    public void Infrastructure_Should_Not_Depend_On_Presentation()
    {
        var references = GetReferencedProjectNames(typeof(ERP.Infrastructure.AssemblyMarker).Assembly);

        Assert.Contains("ERP.Application", references);
        Assert.Contains("ERP.Domain", references);
        Assert.DoesNotContain("ERP.Presentation.WinForms", references);
    }

#if WINDOWS
    [Fact]
    public void Presentation_Should_Not_Depend_On_Infrastructure()
    {
        var references = GetReferencedProjectNames(typeof(ERP.Presentation.WinForms.AssemblyMarker).Assembly);

        Assert.Contains("ERP.Application", references);
        Assert.DoesNotContain("ERP.Infrastructure", references);
    }
#endif

    [Fact]
    public void Domain_Should_Not_Depend_On_Application_Infrastructure_Or_Presentation()
    {
        var references = GetReferencedProjectNames(typeof(ERP.Domain.AssemblyMarker).Assembly);

        Assert.DoesNotContain("ERP.Application", references);
        Assert.DoesNotContain("ERP.Infrastructure", references);
        Assert.DoesNotContain("ERP.Presentation.WinForms", references);
    }

    private static IReadOnlyCollection<string> GetReferencedProjectNames(Assembly assembly)
    {
        return assembly
            .GetReferencedAssemblies()
            .Select(reference => reference.Name)
            .Where(name => !string.IsNullOrWhiteSpace(name))
            .ToArray()!;
    }
}
