using System.Text;
using DotNetCampus.LatestCSharpFeatures.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace DotNetCampus.LatestCSharpFeatures.Generators;

/// <summary>
/// 生成 C# 新特性所需的类。
/// </summary>
[Generator(LanguageNames.CSharp)]
public class FeatureGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(OnExecute);
    }

    private void OnExecute(IncrementalGeneratorPostInitializationContext context)
    {
        // .NET Core 3.0 / .NET Standard 2.1 才开始支持 Nullable；.NET 5.0 开始支持更多。
        GenerateFeatureSource(context, "Nullable");

        // .NET Core 3.0 / .NET Standard 2.1 才开始支持 Index 和 Range。
        GenerateFeatureSource(context, "IndexRange");

        // .NET 5.0 才开始支持 ExternalInit。
        GenerateFeatureSource(context, "ExternalInit");

        // .NET 6.0 才开始支持 DynamicallyAccessed
        // 为低版本 .NET 生成对应代码，主要是简化编译多目标框架时的繁琐。
        GenerateFeatureSource(context, "DynamicallyAccessed");

        // .NET 7.0 才开始支持 SetsRequiredMembersAttribute。
        GenerateFeatureSource(context, "Required");
    }

    private void GenerateFeatureSource(IncrementalGeneratorPostInitializationContext context, string featureName)
    {
        foreach (var source in EmbeddedSourceFiles.Enumerate($"Features.{featureName}"))
        {
            context.AddSource(source.FileName, SourceText.From(source.Content, Encoding.UTF8));
        }
    }
}
