// <copyright file="ViewFactory.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.Factories
{
    using System.Windows.Forms;
    using Ninject;

    /// <summary>
    /// Factory for (forms) views.
    /// </summary>
    public class ViewFactory
    {
        /// <summary>
        /// The kernel
        /// </summary>
        private readonly IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewFactory"/> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public ViewFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T">A form of type T</typeparam>
        /// <returns>Instance of T</returns>
        public T Get<T>()
            where T : Form
        {
            return this.kernel.Get<T>();
        }
    }
}