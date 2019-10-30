// <copyright file="PaletFactory.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.Factories
{
    using System.Windows.Forms;
    using Ninject;
    using Ninject.Parameters;
    using RasterEditor.CustomComponents;
    using RasterEditor.Providers;

    /// <summary>
    /// Constructs a palet with coloured buttons,
    /// </summary>
    public class PaletFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaletFactory" /> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        /// <param name="colorProvider">The color provider.</param>
        public PaletFactory(IKernel kernel, ColorProvider colorProvider)
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
        /// <param name="panel">The panel.</param>
        /// <param name="buttonHeight">Height of the button.</param>
        /// <returns>
        /// A palet control
        /// </returns>
        public Palet Get(Panel panel, int buttonHeight = 20)
        {
            return this.Kernel.Get<Palet>(new ConstructorArgument("panel", panel), new ConstructorArgument("buttonHeight", buttonHeight));
        }
    }
}
