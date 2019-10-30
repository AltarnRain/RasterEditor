// <copyright file="ShapeModelExtentionsTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.Tests.Extentions
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RasterEditor.Models.Drawing;
    using RasterEditor.Models.Enumerators;
    using RasterEditor.Providers;
    using RasterEditor.R42Extentions;
    using RasterEditor.Tests;

    /// <summary>
    /// Tests the <see cref="ShapeModel"/> extentions/>
    /// </summary>
    [TestClass]
    public class ShapeModelExtentionsTests : TestBase
    {
        /// <summary>
        /// Tests the AddRow extention method
        /// </summary>
        [TestMethod]
        public void AddRowTop()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            this.MakeRowRed(shape, 10);

            // Act
            shape.AddRowTop();

            // Assert
            var numberOfBlocks = shape.Blocks.Count();
            Assert.AreEqual(55, numberOfBlocks);

            var newRow = shape.GetRow(rows + 1);
            Assert.AreEqual(5, newRow.Count());

            for (var col = 0; col < columns; col++)
            {
                var foundBlock = shape.Blocks.Any(b => b.Column == col + 1 && b.Row == rows + 1);
                Assert.IsTrue(foundBlock);
            }

            var expectedRowIsRed = shape.GetRow(11).All(b => b.Color == CGA16Colors.Red.GetColor());
            Assert.IsTrue(expectedRowIsRed);
        }

        /// <summary>
        /// Tests the AddRow extention method
        /// </summary>
        [TestMethod]
        public void AddRowBottom()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            this.MakeRowRed(shape, 10);

            // Act
            shape.AddRowBottom();

            // Assert
            var numberOfBlocks = shape.Blocks.Count();
            Assert.AreEqual(55, numberOfBlocks);

            var newRow = shape.GetRow(rows + 1);
            Assert.AreEqual(5, newRow.Count());

            for (var col = 0; col < columns; col++)
            {
                var foundBlock = shape.Blocks.Any(b => b.Column == col + 1 && b.Row == rows + 1);
                Assert.IsTrue(foundBlock);
            }

            var expectedRowIsRed = shape.GetRow(10).All(b => b.Color == CGA16Colors.Red.GetColor());
            Assert.IsTrue(expectedRowIsRed);

            var bottomRowIsBlack = shape.GetRow(11).All(b => b.Color == CGA16Colors.Black.GetColor());
            Assert.IsTrue(bottomRowIsBlack);
        }

        /// <summary>
        /// Tests the AddRow extention method
        /// </summary>
        [TestMethod]
        public void RemoveRowTop()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            this.MakeRowRed(shape, 10);

            // Act
            shape.RemoveRowTop();

            // Assert
            var numberOfBlocks = shape.Blocks.Count();
            Assert.AreEqual(45, numberOfBlocks);

            var expectedRowIsRed = shape.GetRow(9).All(b => b.Color == CGA16Colors.Red.GetColor());
            Assert.IsTrue(expectedRowIsRed);
            Assert.AreEqual(9, shape.LastRow());
        }

        /// <summary>
        /// Tests the AddRow extention method
        /// </summary>
        [TestMethod]
        public void RemoveRowBottom()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            this.MakeRowRed(shape, 9);

            // Act
            shape.RemoveRowBottom();

            // Assert
            var numberOfBlocks = shape.Blocks.Count();
            Assert.AreEqual(45, numberOfBlocks);

            var expectedRowIsRed = shape.GetRow(9).All(b => b.Color == CGA16Colors.Red.GetColor());
            Assert.IsTrue(expectedRowIsRed);
            Assert.AreEqual(9, shape.LastRow());
        }

        /// <summary>
        /// Tests the AddColumn extention method.
        /// </summary>
        [TestMethod]
        public void AddColumnLeft()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            this.MakeColumnRed(shape, 5);

            // Act
            shape.AddColumnLeft();

            // Assert
            var numberOfBlocks = shape.Blocks.Count();
            Assert.AreEqual(60, numberOfBlocks);

            var newColumn = shape.GetColumn(columns + 1);
            Assert.AreEqual(rows, newColumn.Count());

            for (var row = 0; row < rows; row++)
            {
                var foundBlock = shape.Blocks.Any(b => b.Row == row + 1 && b.Column == columns + 1);
                Assert.IsTrue(foundBlock);
            }

            var expectedColumnIsRed = shape.GetColumn(6).All(b => b.Color == CGA16Colors.Red.GetColor());
            Assert.IsTrue(expectedColumnIsRed);
        }

        /// <summary>
        /// Tests the AddColumn extention method.
        /// </summary>
        [TestMethod]
        public void AddColumnRight()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            this.MakeColumnRed(shape, 5);

            // Act
            shape.AddColumnRight();

            // Assert
            var numberOfBlocks = shape.Blocks.Count();
            Assert.AreEqual(60, numberOfBlocks);

            var newColumn = shape.GetColumn(columns + 1);
            Assert.AreEqual(rows, newColumn.Count());

            for (var row = 0; row < rows; row++)
            {
                var foundBlock = shape.Blocks.Any(b => b.Row == row + 1 && b.Column == columns + 1);
                Assert.IsTrue(foundBlock);
            }

            var expectedColumnIsRed = shape.GetColumn(5).All(b => b.Color == CGA16Colors.Red.GetColor());
            Assert.IsTrue(expectedColumnIsRed);
        }

        /// <summary>
        /// Tests the AddColumn extention method.
        /// </summary>
        [TestMethod]
        public void RemoveColumnLeft()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            this.MakeColumnRed(shape, 5);

            // Act
            shape.RemoveColumnLeft();

            // Assert
            var numberOfBlocks = shape.Blocks.Count();
            Assert.AreEqual(40, numberOfBlocks);

            var expectedColumnIsRed = shape.GetColumn(4).All(b => b.Color == CGA16Colors.Red.GetColor());
            Assert.IsTrue(expectedColumnIsRed);
            Assert.AreEqual(4, shape.LastColumn());
        }

        /// <summary>
        /// Tests the AddColumn extention method.
        /// </summary>
        [TestMethod]
        public void RemoveColumnRight()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            this.MakeColumnRed(shape, 4);

            // Act
            shape.RemoveColumnRight();

            // Assert
            var numberOfBlocks = shape.Blocks.Count();
            Assert.AreEqual(40, numberOfBlocks);

            var expectedColumnIsRed = shape.GetColumn(4).All(b => b.Color == CGA16Colors.Red.GetColor());
            Assert.IsTrue(expectedColumnIsRed);
            Assert.AreEqual(4, shape.LastColumn());
        }

        /// <summary>
        /// Tests the AddColumn extention method.
        /// </summary>
        [TestMethod]
        public void CropImage()
        {
            // Arrange
            const int columns = 6;
            const int rows = 6;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            shape.Blocks.Where(b => b.Row > 3 && b.Column > 3).ToList().ForEach(b => b.Color = CGA16Colors.Red.GetColor());

            // Act
            shape.CropImage();

            // Assert
            var numberOfRedBlocks = shape.Blocks.Count(b => b.Color == CGA16Colors.Red.GetColor());
            Assert.AreEqual(9, numberOfRedBlocks);
            Assert.AreEqual(9, shape.Blocks.Count());
        }

        /// <summary>
        /// Tests the AddColumn extention method.
        /// </summary>
        [TestMethod]
        public void CropImageWithInnerBlackSpace()
        {
            // Arrange
            const int columns = 6;
            const int rows = 6;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            // Create a red square
            shape.Blocks.Where(b => b.Row > 3 && b.Column > 3).ToList().ForEach(b => b.Color = CGA16Colors.Red.GetColor());

            // Create black line, this means there's two red lines split by a black line.
            shape.Blocks.Where(b => b.Row == 5 && b.Column > 3).ToList().ForEach(b => b.Color = CGA16Colors.Black.GetColor());

            // Act
            shape.CropImage();

            // Assert
            var numberOfRedBlocks = shape.Blocks.Count(b => b.Color == CGA16Colors.Red.GetColor());
            Assert.AreEqual(6, numberOfRedBlocks);
            Assert.AreEqual(9, shape.Blocks.Count());
        }

        /// <summary>
        /// move up test.
        /// </summary>
        [TestMethod]
        public void MoveUp()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            shape.Blocks.ForEach((b) =>
            {
                if (b.Row == 2)
                {
                    b.Color = CGA16Colors.Red.GetColor();
                }
            });

            // Act
            shape.MoveUp();

            // Assert
            var firstRowIsRed = shape.GetRow(1).All(b => b.Color == CGA16Colors.Red.GetColor());
            Assert.IsTrue(firstRowIsRed);
        }

        /// <summary>
        /// move down test.
        /// </summary>
        [TestMethod]
        public void MoveDown()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            shape.Blocks.ForEach((b) =>
            {
                if (b.Row == 2)
                {
                    b.Color = CGA16Colors.Red.GetColor();
                }
            });

            // Act
            shape.MoveDown();

            // Assert
            var thirdRowIsRed = shape.GetRow(3).All(b => b.Color == CGA16Colors.Red.GetColor());
            Assert.IsTrue(thirdRowIsRed);
        }

        /// <summary>
        /// move down test.
        /// </summary>
        [TestMethod]
        public void MoveRight()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            shape.Blocks.ForEach((b) =>
            {
                if (b.Column == 2)
                {
                    b.Color = CGA16Colors.Red.GetColor();
                }
            });

            // Act
            shape.MoveRight();

            // Assert
            var isRed = shape.GetColumn(3).All(b => b.Color == CGA16Colors.Red.GetColor());
            Assert.IsTrue(isRed);
        }

        /// <summary>
        /// move left test.
        /// </summary>
        [TestMethod]
        public void MoveLeft()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            shape.Blocks.ForEach((b) =>
            {
                if (b.Column == 2)
                {
                    b.Color = CGA16Colors.Red.GetColor();
                }
            });

            // Act
            shape.MoveLeft();

            // Assert
            var isRed = shape.GetColumn(1).All(b => b.Color == CGA16Colors.Red.GetColor());
            Assert.IsTrue(isRed);
        }

        /// <summary>
        /// Tests if the anchor is removed from a block.
        /// </summary>
        [TestMethod]
        public void SetAnchors()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            shape.GetBlock(4, 4).Anchor = true;
            shape.ResetAnchor();

            // Act
            shape.SetAnchor(5, 5);

            // Assert.
            Assert.IsFalse(shape.GetBlock(4, 4).Anchor);
            Assert.IsTrue(shape.GetBlock(5, 5).Anchor);
        }

        /// <summary>
        /// Tests if the anchor is removed from a block.
        /// </summary>
        [TestMethod]
        public void RetrieveAcnhor()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);
            shape.SetAnchor(5, 6);

            // Act
            var block = shape.GetAnchorBlock();

            // Assert.
            Assert.AreEqual(block.Column, 5);
            Assert.AreEqual(block.Row, 6);
        }

        /// <summary>
        /// Tests if the anchor is removed from a block.
        /// </summary>
        [TestMethod]
        public void RemoveAnchors()
        {
            // Arrange
            const int columns = 5;
            const int rows = 10;
            var shapeProvider = this.Get<ShapeProvider>();
            var shape = shapeProvider.Create(columns, rows);

            shape.GetBlock(5, 5).Anchor = true;

            // Act
            shape.ResetAnchor();

            // Assert.
            Assert.IsFalse(shape.GetBlock(5, 5).Anchor);
        }

        /// <summary>
        /// Makes the column red.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <param name="column">The column.</param>
        private void MakeColumnRed(ShapeModel shapeModel, int column)
        {
            shapeModel.Blocks.Where(b => b.Column == column).ToList().ForEach(b => b.Color = CGA16Colors.Red.GetColor());
        }

        /// <summary>
        /// Makes the row red.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <param name="row">The row.</param>
        private void MakeRowRed(ShapeModel shapeModel, int row)
        {
            shapeModel.Blocks.Where(b => b.Row == row).ToList().ForEach(b => b.Color = CGA16Colors.Red.GetColor());
        }
    }
}
