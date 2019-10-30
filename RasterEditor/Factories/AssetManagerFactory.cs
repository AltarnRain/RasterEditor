// <copyright file="AssetManagerFactory.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.Factories
{
    using Ninject;
    using Ninject.Parameters;
    using RasterEditor.Managers;

    /// <summary>
    /// Created an asset manager.
    /// </summary>
    public class AssetManagerFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssetManagerFactory"/> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public AssetManagerFactory(IKernel kernel)
        {
            this.Kernel = kernel;
        }

        /// <summary>
        /// Gets the kernel.
        /// </summary>
        /// <value>
        /// The kernel.
        /// </value>
        public IKernel Kernel { get; }

        /// <summary>
        /// Gets the specified asset file.
        /// </summary>
        /// <param name="assetFile">The asset file.</param>
        /// <param name="loadOnCreate">if set to <c>true</c> [load on create].</param>
        /// <returns>
        /// An asset manager
        /// </returns>
        public AssetManager Get(string assetFile, bool loadOnCreate = true)
        {
            return this.Kernel.Get<AssetManager>(new ConstructorArgument("assetFile", assetFile), new ConstructorArgument("loadOnCreate", loadOnCreate));
        }
    }
}
