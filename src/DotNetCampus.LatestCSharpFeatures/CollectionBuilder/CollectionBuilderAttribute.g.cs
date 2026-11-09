// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable enable
#if NET8_0_OR_GREATER
#else
namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Specifies that a type is a collection builder and points to the method that constructs the collection.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, Inherited = false)]
#if USE_PUBLIC_LATEST_CSHARP_FEATURES
    public
#else
    internal
#endif
    sealed class CollectionBuilderAttribute : Attribute
    {
        /// <summary>
        /// Initialize the attribute to point at the indicated builder method.
        /// </summary>
        /// <param name="builderType">The type that contains the builder method.</param>
        /// <param name="methodName">The name of the builder method.</param>
        public CollectionBuilderAttribute(Type builderType, string methodName)
        {
            BuilderType = builderType;
            MethodName = methodName;
        }

        /// <summary>
        /// Gets the type that contains the builder method.
        /// </summary>
        public Type BuilderType { get; }

        /// <summary>
        /// Gets the name of the builder method.
        /// </summary>
        public string MethodName { get; }
    }
}
#endif
