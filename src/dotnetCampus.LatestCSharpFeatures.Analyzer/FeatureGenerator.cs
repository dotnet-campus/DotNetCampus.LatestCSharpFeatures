using dotnetCampus.LatestCSharpFeatures.Analyzer;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Text;

using System.Text;

/// <summary>
/// 生成 C# 新特性所需的类。
/// </summary>
[Generator(LanguageNames.CSharp)]
public class FeatureGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterSourceOutput(context.AnalyzerConfigOptionsProvider, OnExecute);
    }

    private void OnExecute(SourceProductionContext context, AnalyzerConfigOptionsProvider provider)
    {
        // .NET Core 3.0 / .NET Standard 2.1 才开始支持 Nullable；.NET 5.0 开始支持更多。
        GenerateFeatureSource(context, provider, "Nullable");

        // .NET 5.0 才开始支持 ExternalInit
        GenerateFeatureSource(context, provider, "ExternalInit");

        // .NET 6.0 才开始支持 DynamicallyAccessed
        // 为低版本 .NET 生成对应代码，主要是简化编译多目标框架时的繁琐。
        GenerateFeatureSource(context, provider, "DynamicallyAccessed");

        // .NET 7.0 才开始支持 SetsRequiredMembersAttribute
        GenerateFeatureSource(context, provider, "Required");
    }

    private void GenerateFeatureSource(SourceProductionContext context, AnalyzerConfigOptionsProvider provider, string featureName)
    {
        //if (provider.GlobalOptions.TryGetValue($"build_property._dotnetCampusUse{featureName}", out var useFeature)
        //    && useFeature.Equals(featureName, StringComparison.OrdinalIgnoreCase))
        {
            foreach (var source in EmbededSourceFiles.Enumerate($"Features.{featureName}"))
            {
                var name = source.GuessFileNameWithoutExtension().ToString();
                context.AddSource($"{name}.g.cs", SourceText.From(source.Content, Encoding.UTF8));
            }
        }
    }
}
