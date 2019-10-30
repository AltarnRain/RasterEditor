// <copyright file="PaletTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.Tests
{
    using System.Linq;
    using System.Windows.Forms;
    using Extentions;
    using global::Extentions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RasterEditor.Factories;
    using RasterEditor.Providers;

    /// <summary>
    /// Tests the palet component
    /// </summary>
    [TestClass]
    public class PaletTests : TestBase
    {
        /// <summary>
        /// Creates the test.
        /// </summary>
        [TestMethod]
        public void PaletCreateTest()
        {
            // Arrange
            var colors = this.Get<ColorProvider>().GetColors();
            var panel = new Panel();

            // Act
            var palet = this.Get<PaletFactory>().Get(panel);

            // Assert
            var numberOfControls = palet.ColorButtons.Count();

            Assert.AreEqual(colors.Count(), numberOfControls);
        }

        /// <summary>
        /// Tests if all the colors were assigned to the buttons.
        /// </summary>
        [TestMethod]
        public void SetColorTest()
        {
            // Arrange
            var colors = this.Get<ColorProvider>().GetColors();
            var panel = new Panel();

            // Act
            var palet = this.Get<PaletFactory>().Get(panel);

            // Act
            foreach (var c in palet.Controls)
            {
                if (c is Button)
                {
                    var b = c as Button;
                    if (colors.Any(color => color == c.As<Button>().ForeColor) == false)
                    {
                        Assert.Fail();
                    }
                }
            }

            // If not fail then test passes.
        }
    }
}