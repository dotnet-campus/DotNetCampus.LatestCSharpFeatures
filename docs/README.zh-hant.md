# Latest CSharp Features 最新的 C# 特性

| Language                            |
| ----------------------------------- |
| [简体中文](/docs/README.zh-hans.md) |
| [繁體中文](/docs/README.zh-hant.md) |
| [English](/README.md)               |

[![NuGet](https://img.shields.io/nuget/v/dotnetCampus.LatestCSharpFeatures.svg)](https://www.nuget.org/packages/dotnetCampus.LatestCSharpFeatures)

此開源項目提供一個 NuGet 包 dotnetCampus.LatestCSharpFeatures，讓您可以在舊版本的 .NET（包括舊的 .NET Framework、.NET Standard，以及舊的 .NET Core App、.NET）中，使用最新的 C# 語言特性。

## 使用方法

直接安裝 dotnetCampus.LatestCSharpFeatures NuGet 包即可。

```xml
<!-- 由於 dotnetCampus.LatestCSharpFeatures 只含源生成器，因此不會引入任何運行時依賴項。
     我們可以將其設置為 PrivateAssets="all"，以避免將其傳遞給其他項目。 -->
<PackageReference Include="dotnetCampus.LatestCSharpFeatures" Version="12.0.0" PrivateAssets="all" />
```

如果您希望這些新語言特性對其他引用了此項目的項目也生效，可以在 csproj 文件中增加一個條件編譯符：

```xml
<!-- 預設情況下，dotnetCampus.LatestCSharpFeatures 會將 C# 新特性以 internal 修飾符引入當前項目。
     使用此條件編譯符，可以將這些類型設為 public，使得引用此項目的其他項目也能使用這些新特性。 -->
<DefineConstants>$(DefineConstants);USE_PUBLIC_LATEST_CSHARP_FEATURES</DefineConstants>
```

## 反饋與貢獻

我們歡迎所有用戶的反饋和貢獻。如果您在使用過程中發現任何問題，或者有任何改進建議，都可以通過 GitHub Issues 提交。

如果您希望參與到項目的開發中，也非常歡迎！您可以 Fork 本倉庫，然後提交 Pull Request。

感謝您對 dotnetCampus.LatestCSharpFeatures 的支持和幫助！
