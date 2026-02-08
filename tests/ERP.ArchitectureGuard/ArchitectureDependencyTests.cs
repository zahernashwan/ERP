using System.Reflection;
using System.Text.RegularExpressions;
using ERP.Application;
using ERP.Domain;
using ERP.Infrastructure;
using Xunit;

namespace ERP.ArchitectureGuard;

public class ArchitectureDependencyTests
{
    private const string PresentationAssemblyName = "ERP.Presentation.WinForms";

    [Fact]
    public void Domain_Should_Not_Depend_On_Any_Other_Solution_Project()
    {
        var references = GetReferencedProjectNames(typeof(ERP.Domain.AssemblyMarker).Assembly);

        Assert.DoesNotContain("ERP.Application", references);
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
    public void Application_Should_Not_Depend_On_Presentation()
    {
        var references = GetReferencedProjectNames(typeof(ERP.Application.AssemblyMarker).Assembly);
        Assert.DoesNotContain("ERP.Presentation.WinForms", references);
    }

    [Fact]
    public void Infrastructure_Should_Not_Depend_On_Presentation()
    {
        var references = GetReferencedProjectNames(typeof(ERP.Infrastructure.AssemblyMarker).Assembly);
        Assert.DoesNotContain("ERP.Presentation.WinForms", references);
    }

    #if WINDOWS
    [Fact]
    #else
    [Fact(Skip = "Presentation layer dependency checks require Windows desktop targeting.")]
    #endif
    public void Presentation_Should_Not_Depend_On_Infrastructure()
    {
        var references = GetPresentationReferencedProjectNames();
        Assert.DoesNotContain("ERP.Infrastructure", references);
    }

    private static string[] GetPresentationReferencedProjectNames()
    {
        var reference = typeof(ArchitectureDependencyTests).Assembly
            .GetReferencedAssemblies()
            .FirstOrDefault(assembly => assembly.Name == PresentationAssemblyName);

        if (reference == null)
        {
            return [];
        }

        return GetReferencedProjectNames(Assembly.Load(reference));
    }

    private static string[] GetReferencedProjectNames(Assembly assembly)
    {
        return assembly
            .GetReferencedAssemblies()
            .Select(reference => reference.Name)
            .Where(name => !string.IsNullOrWhiteSpace(name))
            .ToArray()!;
    }

    private static void AssertNoForbiddenTokensInDirectory(string directory, IReadOnlyList<string> forbiddenTokens)
    {
        Assert.True(Directory.Exists(directory), $"Expected directory not found: '{directory}'.");

        var violations = new List<string>();

        foreach (var file in Directory.EnumerateFiles(directory, "*.cs", SearchOption.AllDirectories))
        {
            if (file.Contains(Path.DirectorySeparatorChar + "obj" + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase))
                continue;

            if (file.EndsWith(".Designer.cs", StringComparison.OrdinalIgnoreCase))
                continue;

            var content = File.ReadAllText(file);
            var contentWithoutComments = StripComments(content);

            foreach (var token in forbiddenTokens)
            {
                if (contentWithoutComments.Contains(token, StringComparison.Ordinal))
                {
                    violations.Add($"{Path.GetRelativePath(GetSolutionRoot(), file)} contains forbidden token '{token}'.");
                }
            }
        }

        Assert.True(violations.Count == 0, string.Join(Environment.NewLine, violations));
    }

    private static string StripComments(string content)
    {
        // Best-effort removal of comments to avoid false positives in docs.
        // Removes: // line comments and /* block comments */.
        content = Regex.Replace(content, @"//.*?$", string.Empty, RegexOptions.Multiline);
        content = Regex.Replace(content, @"/\*.*?\*/", string.Empty, RegexOptions.Singleline);
        return content;
    }

    private static string GetSolutionRoot()
    {
        var dir = AppContext.BaseDirectory;

        while (!string.IsNullOrWhiteSpace(dir))
        {
            if (File.Exists(Path.Combine(dir, "ERP.sln")))
                return dir;

            dir = Directory.GetParent(dir)?.FullName;
        }

        throw new InvalidOperationException("Could not locate solution root containing 'ERP.sln'.");
    }
}
