using System.Diagnostics.CodeAnalysis;

namespace DotNetCampus.LatestCSharpFeatures.Tests;

public class NullableTest
{
    public void CanBeCompiled()
    {
        MemberNotNull();
        TryDo("");
    }

    public string? Foo { get; set; }

    private bool TryDo([NotNullWhen(true)] string? text)
    {
        return false;
    }

    [MemberNotNull(nameof(Foo))]
    private void MemberNotNull()
    {
        Foo = "";
    }
}
