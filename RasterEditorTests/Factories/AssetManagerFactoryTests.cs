// <copyright file="AssetManagerFactoryTests.cs" company="OI">
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
    public class AssetManagerFactoryTests : TestBase
    {
        /// <summary>
        /// Creates the factory.
        /// </summary>
        [TestMethod]
        public void CreateFactory()
        {
            var factory = this.Get<AssetManagerFactory>();
            Assert.IsNotNull(factory);
        }

        /// <summary>
        /// Creates the asset manager.
        /// </summary>
        [TestMethod]
        public void CreateAssetManager()
        {
            var factory = this.Get<AssetManagerFactory>();

            var assetManager = factory.Get(string.Empty);

            Assert.IsNotNull(assetManager);
        }
    }
}
