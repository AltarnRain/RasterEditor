// <copyright file="DrawerTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.Tests
{
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Providers;
    using RasterEditor.Factories;

    /// <summary>
    /// Tests the Drawer component
    /// </summary>
    [TestClass]
    public class DrawerTests : TestBase
    {
        /// <summary>
        /// Tests the creation of the drawer component.
        /// </summary>
        [TestMethod]
        public void CreateTest()
        {
            // Arrange
            var shapeModel = this.Get<ShapeProvider>().Create(3, 5);
            var panel = new Panel();

            // Act
            var drawer = this.Get<DrawerFactory>().Get(panel);
            drawer.DrawButtons(shapeModel, 20);

            // Assert
            var numberOfButtons = drawer.BlockButtons.Count();

            // Each block should have its own button
            Assert.AreEqual(shapeModel.Blocks.Count, numberOfButtons);
        }

        /// <summary>
        /// Tests setting the active components
        /// </summary>
        [TestMethod]
        public void SetAciveColorTest()
        {
            // Arrange
            var shapeModel = this.Get<ShapeProvider>().Create(3, 5);
            var panel = new Panel();

            // Act
            var drawer = this.Get<DrawerFactory>().Get(panel);

            drawer.SetAciveColor(Color.BlueViolet);

            var allButtonsSet = drawer.BlockButtons.All(b => b.ActiveColor == Color.BlueViolet);

            Assert.IsTrue(allButtonsSet);
        }
    }
}