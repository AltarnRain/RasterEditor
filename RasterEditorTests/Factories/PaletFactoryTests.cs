// <copyright file="PaletFactoryTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.Tests
{
    using System.Windows.Forms;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RasterEditor.Factories;

    /// <summary>
    /// Tests fo the <see cref="AssetManagerFactory"/>
    /// </summary>
    /// <seealso cref="RasterEditor.Tests.TestBase" />
    [TestClass]
    public class PaletFactoryTests : TestBase
    {
        /// <summary>
        /// Creates the factory.
        /// </summary>
        [TestMethod]
        public void CreateFactory()
        {
            var factory = this.Get<PaletFactory>();
            Assert.IsNotNull(factory);
        }

        /// <summary>
        /// Creates the asset manager.
        /// </summary>
        [TestMethod]
        public void CreateAssetManager()
        {
            var factory = this.Get<PaletFactory>();

            var palet = factory.Get(new Panel(), 20);
            Assert.IsNotNull(palet);
        }
    }
}
