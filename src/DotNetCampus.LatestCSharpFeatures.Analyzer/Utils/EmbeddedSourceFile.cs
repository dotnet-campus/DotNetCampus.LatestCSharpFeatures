namespace DotNetCampus.LatestCSharpFeatures.Utils;

/// <summary>
/// 嵌入的文本资源的数据。
/// </summary>
/// <param name="FileName">文件的名称（含扩展名）。</param>
/// <param name="TypeName">文件的名称（不含扩展名），或者也很可能是类型名称。</param>
/// <param name="Namespace">文件的命名空间。</param>
/// <param name="Content">文件的文本内容。</param>
internal readonly record struct EmbeddedSourceFile(
    string FileName,
    string TypeName,
    string Namespace,
    string Content)
{
    /// <summary>
    /// 寻找 <paramref name="relativePath"/> 路径下的源代码名称和内容。
    /// </summary>
    /// <param name="relativePath">资源文件的相对路径。请以“/”或“\”分隔文件夹。</param>
    /// <returns></returns>
    internal static EmbeddedSourceFile Get(string relativePath)
    {
        var directory = Path.GetDirectoryName(relativePath)!;
        var fileName = Path.GetFileName(relativePath);
        return EmbeddedSourceFiles.Enumerate(directory)
            .Single(x => x.FileName == fileName);
    }
}
