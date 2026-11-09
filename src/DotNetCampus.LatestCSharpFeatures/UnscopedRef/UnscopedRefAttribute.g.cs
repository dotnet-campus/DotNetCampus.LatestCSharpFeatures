// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable enable
#if NET7_0_OR_GREATER
#else
namespace System.Diagnostics.CodeAnalysis
{
    /// <summary>
    /// Used to indicate a byref escapes and is not scoped.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Parameter, Inherited = false)]
#if USE_PUBLIC_LATEST_CSHARP_FEATURES
    public
#else
    internal
#endif
    sealed class UnscopedRefAttribute : Attribute
    {
    }
}
#endif
