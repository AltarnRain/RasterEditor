// <copyright file="TestBase.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Ninject;

    /// <summary>
    /// Base class for testing.
    /// </summary>
    public abstract class TestBase
    {
        /// <summary>
        /// The test context instance
        /// </summary>
        private TestContext testContextInstance;

        /// <summary>
        /// The kernel
        /// </summary>
        private IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestBase"/> class.
        /// </summary>
        protected TestBase()
        {
            this.kernel = new StandardKernel();
        }

        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext
        {
            get
            {
                return this.testContextInstance;
            }

            set
            {
                this.testContextInstance = value;
            }
        }

        /// <summary>
        /// Gets the out folder in the deploy folder.
        /// </summary>
        /// <returns>Full path to the out folder.</returns>
        public string GetOutFolder()
        {
            return this.TestContext.TestDeploymentDir.EndsWith(@"\") ? this.testContextInstance.TestDeploymentDir : this.TestContext.TestDeploymentDir + @"\";
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T">Any class</typeparam>
        /// <returns>Instacne of <typeparamref name="T"/></returns>
        public T Get<T>()
            where T : class
        {
            return this.kernel.Get<T>();
        }
    }
}