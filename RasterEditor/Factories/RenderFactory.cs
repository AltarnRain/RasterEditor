// <copyright file="RenderFactory.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.Factories
{
    using Ninject;
    using Ninject.Parameters;
    using Render;

    /// <summary>
    /// Constructs a palet with coloured buttons,
    /// </summary>
    public class RenderFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RenderFactory"/> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public RenderFactory(IKernel kernel)
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
        /// Gets the specified button size.
        /// </summary>
        /// <param name="folder">The folder.</param>
        /// <returns>
        /// A palet control
        /// </returns>
        public ImageGenerator Get(string folder)
        {
            return this.Kernel.Get<ImageGenerator>(new ConstructorArgument("folder", folder));
        }
    }
}
