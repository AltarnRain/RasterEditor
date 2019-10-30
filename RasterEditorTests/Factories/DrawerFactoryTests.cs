// <copyright file="DrawerFactoryTests.cs" company="OI">
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
    /// <seealso cref="TestBase" />
    [TestClass]
    public class DrawerFactoryTests : TestBase
    {
        /// <summary>
        /// Creates the factory.
        /// </summary>
        [TestMethod]
        public void CreateFactory()
        {
            var factory = this.Get<DrawerFactory>();
            Assert.IsNotNull(factory);
        }

        /// <summary>
        /// Creates the asset manager.
        /// </summary>
        [TestMethod]
        public void CreateAssetManager()
        {
            var factory = this.Get<DrawerFactory>();

            var drawer = factory.Get(new Panel());
            Assert.IsNotNull(drawer);
        }
    }
}
