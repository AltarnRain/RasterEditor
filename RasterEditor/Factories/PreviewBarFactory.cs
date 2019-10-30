// <copyright file="PreviewBarFactory.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.Factories
{
    using System.Windows.Forms;
    using Ninject;
    using Ninject.Parameters;
    using RasterEditor.CustomComponents.Components;

    /// <summary>
    /// Generates a preview bar
    /// </summary>
    public class PreviewBarFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PreviewBarFactory"/> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public PreviewBarFactory(IKernel kernel)
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
        /// Gets the specified panel.
        /// </summary>
        /// <param name="panel">The panel.</param>
        /// <returns>A preview bar</returns>
        public PreviewBar Get(Panel panel)
        {
            return this.Kernel.Get<PreviewBar>(new ConstructorArgument("panel", panel));
        }
    }
}
