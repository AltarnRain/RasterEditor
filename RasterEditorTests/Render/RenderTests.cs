// <copyright file="RenderTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.Tests.Render
{
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using global::Render;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RasterEditor.Factories;
    using RasterEditor.Providers;
    using RasterEditor.Tests;

    /// <summary>
    /// Tests the Render class
    /// </summary>
    /// <seealso cref="RasterEditor.Tests.TestBase" />
    [TestClass]
    public class RenderTests : TestBase
    {
        /// <summary>
        /// Tests the render.
        /// </summary>
        [TestMethod]
        public void TestRender()
        {
            // Arrange
            var shapeProvider = this.Get<ShapeProvider>();

            var shape = shapeProvider.Create(5, 5);

            shape.Blocks.Where(b => b.Column == 3).ToList().ForEach(b => b.Color = Color.Red);
            shape.Blocks.Where(b => b.Row == 3).ToList().ForEach(b => b.Color = Color.Red);

            // Act
            var bitmap = ImageGenerator.RenderShapeToBitmap(shape);

            // Assert.
            Assert.IsNotNull(bitmap);
        }
    }
}
