// <copyright file="AssetManagerTests.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Exceptions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RasterEditor.Factories;
    using RasterEditor.Models.Drawing;
    using RasterEditor.Models.Enumerators;
    using RasterEditor.R42Extentions;

    /// <summary>
    /// Tests for the asset manager
    /// </summary>
    [TestClass]
    public class AssetManagerTests : TestBase
    {
        /// <summary>
        /// Assets the manager create test.
        /// </summary>
        [TestMethod]
        public void CreateTest()
        {
            // Arrange / Act
            this.DeleteAssetFile();
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());

            // Assert
            Assert.IsNotNull(assetManager);
        }

        /// <summary>
        /// Assets the manager add.
        /// </summary>
        [TestMethod]
        public void Add()
        {
            // Arrange
            this.DeleteAssetFile();
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());

            // Act
            assetManager.Add("Test", 10, 15, 2);

            // Assert
            var asset = assetManager.GetAssets().SingleOrDefault(a => a.Name == "Test");
            Assert.IsNotNull(asset);
        }

        /// <summary>
        /// Duplicate assets are not allowed
        /// </summary>
        [TestMethod]
        public void AddDuplicate()
        {
            // Act
            this.DeleteAssetFile();
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());
            assetManager.Add("Test", 10, 15, 2);

            try
            {
                assetManager.Add("Test", 10, 15, 2);
            }
            catch (DuplicateEntryException ex)
            {
                Assert.IsNotNull(ex.Message);
            }
        }

        /// <summary>
        /// Check if exception is only thrown when duplicates are added not multiple assets
        /// </summary>
        [TestMethod]
        public void AddTwoAssets()
        {
            // Arrange
            this.DeleteAssetFile();
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());

            // Act
            try
            {
                assetManager.Add("Test", 10, 15, 2);
                assetManager.Add("Test2", 10, 15, 2);
            }
            catch (DuplicateEntryException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Assets the manager on new test event.
        /// </summary>
        [TestMethod]
        public void OnNewTest()
        {
            // Arrange
            this.DeleteAssetFile();
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());

            // Act
            assetManager.Add("Test", 10, 15, 2);

            assetManager.OnNewAsset += (IEnumerable<AssetModel> assets, AssetModel assetModel) =>
            {
                Assert.IsNotNull(assetModel);
                Assert.AreEqual("Test", assetModel.Name);
            };
        }

        /// <summary>
        /// Tests saving and loading.
        /// </summary>
        [TestMethod]
        public void SaveAndLoad()
        {
            // Arrange
            this.DeleteAssetFile();
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());
            assetManager.Add("Test", 10, 15, 2);

            // Act
            assetManager.Save();

            // Assert
            Assert.IsTrue(File.Exists(this.GetAssetFile()));

            // Act
            var assetManager2 = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());

            // Assert
            Assert.AreEqual(1, assetManager2.GetAssets().Count());
            Assert.AreEqual(10, assetManager2.GetAssets().First().Shapes.Count());
            Assert.AreEqual(30, assetManager2.GetAssets().First().Shapes.First().Blocks.Count());
        }

        /// <summary>
        /// Tests adding a shape
        /// </summary>
        [TestMethod]
        public void AddShape()
        {
            // Arrange
            this.DeleteAssetFile();
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());
            assetManager.Add("Test", 10, 15, 2);
            assetManager.LoadByName("Test");

            var numberOfColumns = 0;
            var numberOfRows = 0;

            assetManager.OnCurrentAssetChanged += (AssetModel assets) =>
            {
                // Assert
                Assert.AreEqual(11, assets.Shapes.Count());

                var addedShape = assets.Shapes.Last();
                numberOfColumns = addedShape.LastColumn();
                numberOfRows = addedShape.LastRow();
            };

            // Act
            assetManager.AddShapeToAsset();
            Assert.AreEqual(15, numberOfColumns);
            Assert.AreEqual(2, numberOfRows);
        }

        /// <summary>
        /// Tests removing a shape.
        /// </summary>
        [TestMethod]
        public void RemoveShape()
        {
            // Arrange
            this.DeleteAssetFile();
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());
            assetManager.Add("Test", 10, 15, 2);
            assetManager.LoadByName("Test");

            var numberOfShapes = 0;
            assetManager.OnCurrentAssetChanged += (AssetModel asset) =>
            {
                // Assert
                numberOfShapes = asset.Shapes.Count();
            };

            // Act
            assetManager.RemoveShapeFromAsset(0);
            Assert.AreEqual(9, numberOfShapes);
        }

        /// <summary>
        /// Tests the add column.
        /// </summary>
        [TestMethod]
        public void AddColumnLeft()
        {
            // Arrange
            this.DeleteAssetFile();
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());
            assetManager.Add("Test", 1, 15, 2);
            assetManager.LoadByName("Test");

            var numberOfColumns = 0;
            assetManager.OnLoadFrame += (ShapeModel shapeModel) =>
            {
                // Assert
                numberOfColumns = shapeModel.LastColumn();
            };

            // Act
            assetManager.AddColumnLeft();
            Assert.AreEqual(16, numberOfColumns);
        }

        /// <summary>
        /// Assets the manager add column right.
        /// </summary>
        [TestMethod]
        public void AddColumnRight()
        {
            // Arrange
            this.DeleteAssetFile();
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());
            assetManager.Add("Test", 1, 15, 2);
            assetManager.LoadByName("Test");

            var numberOfColumns = 0;
            assetManager.OnLoadFrame += (ShapeModel shapeModel) =>
            {
                // Assert
                numberOfColumns = shapeModel.LastColumn();
            };

            // Act
            assetManager.AddColumnLeft();
            Assert.AreEqual(16, numberOfColumns);
        }

        /// <summary>
        /// Assets the manager remove column left.
        /// </summary>
        [TestMethod]
        public void RemoveColumnLeft()
        {
            // Arrange
            this.DeleteAssetFile();
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());
            assetManager.Add("Test", 1, 2, 2);
            assetManager.LoadByName("Test");

            var lastColumn = 0;
            assetManager.OnLoadFrame += (ShapeModel shape) =>
            {
                lastColumn = shape.LastColumn();
            };

            assetManager.RemoveColumnLeft();
            Assert.AreEqual(1, lastColumn);
            assetManager.RemoveColumnLeft();
            Assert.AreEqual(1, lastColumn);
        }

        /// <summary>
        /// Tests the add column.
        /// </summary>
        [TestMethod]
        public void RemoveColumnRight()
        {
            // Arrange
            this.DeleteAssetFile();
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());
            assetManager.Add("Test", 10, 2, 2);
            assetManager.LoadByName("Test");

            var lastColumn = 0;
            assetManager.OnLoadFrame += (ShapeModel shape) =>
            {
                lastColumn = shape.LastColumn();
            };

            assetManager.RemoveColumnLeft();
            Assert.AreEqual(1, lastColumn);
            assetManager.RemoveColumnLeft();
            Assert.AreEqual(1, lastColumn);
        }

        /// <summary>
        /// Tests the add column.
        /// </summary>
        [TestMethod]
        public void RemoveTopRow()
        {
            // Arrange
            this.DeleteAssetFile();
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());
            assetManager.Add("Test", 10, 15, 2);
            assetManager.LoadByName("Test");

            var lastRow = 0;
            assetManager.OnLoadFrame += (ShapeModel shape) =>
            {
                lastRow = shape.LastRow();
            };

            assetManager.RemoveRowBottom();
            Assert.AreEqual(1, lastRow);
            assetManager.RemoveRowBottom();
            Assert.AreEqual(1, lastRow);
        }

        /// <summary>
        /// Assets the manager remove bottom row.
        /// </summary>
        [TestMethod]
        public void RemoveBottomRow()
        {
            // Arrange
            this.DeleteAssetFile();
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());
            assetManager.Add("Test", 10, 15, 2);
            assetManager.LoadByName("Test");

            var lastRow = 0;
            assetManager.OnLoadFrame += (ShapeModel shape) =>
            {
                lastRow = shape.LastRow();
            };

            assetManager.RemoveRowBottom();
            Assert.AreEqual(1, lastRow);
            assetManager.RemoveRowBottom();
            Assert.AreEqual(1, lastRow);
        }

        /// <summary>
        /// Moves the shape left.
        /// </summary>
        [TestMethod]
        public void MoveShapeLeft()
        {
            // Arrange
            this.DeleteAssetFile();
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());
            assetManager.Add("Test", 3, 1, 1);
            assetManager.LoadByName("Test");

            assetManager.CurrentAsset.Shapes[0].Blocks[0].Color = CGA16Colors.Green.GetColor();
            assetManager.CurrentAsset.Shapes[1].Blocks[0].Color = CGA16Colors.Red.GetColor();
            assetManager.CurrentAsset.Shapes[2].Blocks[0].Color = CGA16Colors.Blue.GetColor();

            // Act
            assetManager.MoveShapeLeft(1);

            // Assert
            Assert.AreEqual(assetManager.CurrentAsset.Shapes[0].Blocks[0].Color, CGA16Colors.Red.GetColor());
            Assert.AreEqual(assetManager.CurrentAsset.Shapes[1].Blocks[0].Color, CGA16Colors.Green.GetColor());
            Assert.AreEqual(assetManager.CurrentAsset.Shapes[2].Blocks[0].Color, CGA16Colors.Blue.GetColor());

            // Act
            assetManager.MoveShapeLeft(0);

            // Assert
            Assert.AreEqual(assetManager.CurrentAsset.Shapes[0].Blocks[0].Color, CGA16Colors.Red.GetColor());
            Assert.AreEqual(assetManager.CurrentAsset.Shapes[1].Blocks[0].Color, CGA16Colors.Green.GetColor());
            Assert.AreEqual(assetManager.CurrentAsset.Shapes[2].Blocks[0].Color, CGA16Colors.Blue.GetColor());
        }

        /// <summary>
        /// Moves the shape right.
        /// </summary>
        [TestMethod]
        public void MoveShapeRight()
        {
            // Arrange
            this.DeleteAssetFile();
            var assetManager = this.Get<AssetManagerFactory>().Get(this.GetAssetFile());
            assetManager.Add("Test", 3, 1, 1);
            assetManager.LoadByName("Test");

            assetManager.CurrentAsset.Shapes[0].Blocks[0].Color = CGA16Colors.Green.GetColor();
            assetManager.CurrentAsset.Shapes[1].Blocks[0].Color = CGA16Colors.Red.GetColor();
            assetManager.CurrentAsset.Shapes[2].Blocks[0].Color = CGA16Colors.Blue.GetColor();

            // Act
            assetManager.MoveShapeRight(1);

            // Assert
            Assert.AreEqual(assetManager.CurrentAsset.Shapes[0].Blocks[0].Color, CGA16Colors.Green.GetColor());
            Assert.AreEqual(assetManager.CurrentAsset.Shapes[1].Blocks[0].Color, CGA16Colors.Blue.GetColor());
            Assert.AreEqual(assetManager.CurrentAsset.Shapes[2].Blocks[0].Color, CGA16Colors.Red.GetColor());

            // Act 2
            assetManager.MoveShapeRight(2);

            // Assert 2
            Assert.AreEqual(assetManager.CurrentAsset.Shapes[0].Blocks[0].Color, CGA16Colors.Green.GetColor());
            Assert.AreEqual(assetManager.CurrentAsset.Shapes[1].Blocks[0].Color, CGA16Colors.Blue.GetColor());
            Assert.AreEqual(assetManager.CurrentAsset.Shapes[2].Blocks[0].Color, CGA16Colors.Red.GetColor());
        }

        /// <summary>
        /// Gets the asset file.
        /// </summary>
        /// <returns>A string with a temporary asset file</returns>
        private string GetAssetFile()
        {
            // Arrange
            return this.GetOutFolder() + "Assets.json";
        }

        private void DeleteAssetFile()
        {
            File.Delete(this.GetAssetFile());
        }
    }
}