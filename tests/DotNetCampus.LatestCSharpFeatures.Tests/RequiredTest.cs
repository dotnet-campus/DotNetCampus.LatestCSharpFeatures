namespace DotNetCampus.LatestCSharpFeatures.Tests;

public class RequiredTest
{
    public void CanBeCompiled()
    {
    }

    public record Foo(string Bar)
    {
        public required string R { get; init; }
    }
}
