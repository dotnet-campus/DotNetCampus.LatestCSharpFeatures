# Latest CSharp Features 最新的 C# 特性

| [English][en] | [简体中文][zh-hans] | [繁體中文][zh-hant] |
| ------------- | ------------------- | ------------------- |

[en]: /README.md
[zh-hans]: /docs/README.zh-hans.md
[zh-hant]: /docs/README.zh-hant.md

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
<!-- 預設情況下，dotnetCampus.LatestCSharpFeatures 會將大多數 C# 新特性以 internal 修飾符引入當前項目。
     使用此條件編譯符，可以將這些類型設為 public，使得引用此項目的其他項目也能使用這些新特性。
     注意：Index/Range 類型始終是 internal 的，不受此設置影響，詳見下方說明。 -->
<DefineConstants>$(DefineConstants);USE_PUBLIC_LATEST_CSHARP_FEATURES</DefineConstants>
```

如果您的項目已經引用了其他提供 Index/Range 實現的庫，可能會發生類型衝突。在這種情況下，您可以禁用我們提供的 Index/Range 實現：

```xml
<!-- 如果您的項目中已經有了其他的 Index/Range 實現（例如通過官方的 System.Runtime.CompilerServices.IndexRange 或其他第三方庫），
     使用此條件編譯符可以禁用我們提供的 Index/Range 實現，以避免類型衝突。 -->
<DefineConstants>$(DefineConstants);DISABLE_LATEST_CSHARP_FEATURES_INDEX_RANGE</DefineConstants>
```

> **特別說明**：與其他特性不同，Index/Range 類型始終保持為 internal 訪問級別，不會因為 `USE_PUBLIC_LATEST_CSHARP_FEATURES` 設置而變為 public。這是因為 Index/Range 會被用在公開的 API 中，如果設為 public 可能會與使用官方 Index/Range 實現的其他庫產生不兼容問題。其他特性通常是自用類型，不會導致此類兼容性問題。

## 反饋與貢獻

我們歡迎所有用戶的反饋和貢獻。如果您在使用過程中發現任何問題，或者有任何改進建議，都可以通過 GitHub Issues 提交。

如果您希望參與到項目的開發中，也非常歡迎！您可以 Fork 本倉庫，然後提交 Pull Request。

感謝您對 dotnetCampus.LatestCSharpFeatures 的支持和幫助！
