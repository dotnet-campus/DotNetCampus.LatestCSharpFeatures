# Latest CSharp Features - 最新 C# 语言特性

| [English][en] | [简体中文][zh-hans] | [繁體中文][zh-hant] |
| ------------- | ------------------- | ------------------- |

[en]: /README.md
[zh-hans]: /docs/README.zh-hans.md
[zh-hant]: /docs/README.zh-hant.md

[![NuGet](https://img.shields.io/nuget/v/dotnetCampus.LatestCSharpFeatures.svg)](https://www.nuget.org/packages/dotnetCampus.LatestCSharpFeatures)

此开源项目提供一个 NuGet 包 dotnetCampus.LatestCSharpFeatures，让您可以在旧版本的 .NET（包括旧的 .NET Framework、.NET Standard，以及旧的 .NET Core App、.NET）中，使用最新的 C# 语言特性。

## 使用方法

直接安装 dotnetCampus.LatestCSharpFeatures NuGet 包即可。

```xml
<!-- 由于 dotnetCampus.LatestCSharpFeatures 只含源生成器，因此不会引入任何运行时依赖项。
     我们可以将其设置为 PrivateAssets="all"，以避免将其传递给其他项目。 -->
<PackageReference Include="dotnetCampus.LatestCSharpFeatures" Version="12.0.0" PrivateAssets="all" />
```

如果你希望这些新语言特性对其他引用了此项目的项目也生效，可以在 csproj 文件中增加一个条件编译符：

```xml
<!-- 默认情况下，dotnetCampus.LatestCSharpFeatures 会将大多数 C# 新特性以 internal 修饰符引入当前项目。
     使用此条件编译符，可以将这些类型设为 public，使得引用此项目的其他项目也能使用这些新特性。
     注意：Index/Range 类型始终是 internal 的，不受此设置影响，详见下方说明。 -->
<DefineConstants>$(DefineConstants);USE_PUBLIC_LATEST_CSHARP_FEATURES</DefineConstants>
```

如果你的项目已经引用了其他提供 Index/Range 实现的库，可能会发生类型冲突。在这种情况下，你可以禁用我们提供的 Index/Range 实现：

```xml
<!-- 如果你的项目中已经有了其他的 Index/Range 实现（例如通过官方的 System.Runtime.CompilerServices.IndexRange 或其他第三方库），
     使用此条件编译符可以禁用我们提供的 Index/Range 实现，以避免类型冲突。 -->
<DefineConstants>$(DefineConstants);DISABLE_LATEST_CSHARP_FEATURES_INDEX_RANGE</DefineConstants>
```

> **特别说明**：与其他特性不同，Index/Range 类型始终保持为 internal 访问级别，不会因为 `USE_PUBLIC_LATEST_CSHARP_FEATURES` 设置而变为 public。这是因为 Index/Range 会被用在公开的 API 中，如果设为 public 可能会与使用官方 Index/Range 实现的其他库产生不兼容问题。其他特性通常是自用类型，不会导致此类兼容性问题。

## 反馈与贡献

我们欢迎所有用户的反馈和贡献。如果你在使用过程中发现任何问题，或者有任何改进建议，都可以通过 GitHub Issues 提交。

如果你希望参与到项目的开发中，也非常欢迎！你可以 Fork 本仓库，然后提交 Pull Request。

感谢你对 dotnetCampus.LatestCSharpFeatures 的支持和帮助！
