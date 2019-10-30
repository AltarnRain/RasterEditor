// <copyright file="RenderFactoryTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RasterEditor.Factories;

    /// <summary>
    /// Tests fo the <see cref="AssetManagerFactory"/>
    /// </summary>
    /// <seealso cref="RasterEditor.Tests.TestBase" />
    [TestClass]
    public class RenderFactoryTests : TestBase
    {
        /// <summary>
        /// Creates the factory.
        /// </summary>
        [TestMethod]
        public void CreateFactory()
        {
            var factory = this.Get<RenderFactory>();
            Assert.IsNotNull(factory);
        }

        /// <summary>
        /// Creates the asset manager.
        /// </summary>
        [TestMethod]
        public void CreateRender()
        {
            var factory = this.Get<RenderFactory>();

            var render = factory.Get(this.GetOutFolder());
            Assert.IsNotNull(render);
        }
    }
}
