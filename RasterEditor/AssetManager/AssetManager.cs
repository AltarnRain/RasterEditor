// <copyright file="AssetManager.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.Managers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Exceptions;
    using Extentions;
    using Providers;
    using RasterEditor.Models.Drawing;
    using RasterEditor.Models.Enumerators;
    using RasterEditor.R42Extentions;

    /// <summary>
    /// Manages assets
    /// </summary>
    public class AssetManager
    {
        /// <summary>
        /// The asset provider
        /// </summary>
        private readonly AssetProvider assetProvider;

        /// <summary>
        /// The shape provider
        /// </summary>
        private readonly ShapeProvider shapeProvider;

        /// <summary>
        /// The asset file
        /// </summary>
        private string assetFile;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetManager" /> class.
        /// </summary>
        /// <param name="assetFile">The asset file.</param>
        /// <param name="assetProvider">The asset provider.</param>
        /// <param name="shapeProvider">The shape provider.</param>
        /// <param name="loadOnCreate">if set to <c>true</c> [load on create].</param>
        public AssetManager(
            string assetFile,
            AssetProvider assetProvider,
            ShapeProvider shapeProvider,
            bool loadOnCreate = false)
        {
            this.assetProvider = assetProvider;
            this.shapeProvider = shapeProvider;

            this.assetFile = assetFile;

            this.SetupAssets(this.assetFile);
        }

        /// <summary>
        /// Raised when the asset collection changes
        /// </summary>
        /// <param name="assets">The assets.</param>
        /// <param name="asset">The asset.</param>
        public delegate void NewAsset(IEnumerable<AssetModel> assets, AssetModel asset);

        /// <summary>
        /// Raised when the current asset changes
        /// </summary>
        /// <param name="asset">The asset.</param>
        public delegate void CurrentAssetChanged(AssetModel asset);

        /// <summary>
        /// Raised when the current asset changes
        /// </summary>
        /// <param name="assets">The assets.</param>
        public delegate void AssetsLoaded(IEnumerable<AssetModel> assets);

        /// <summary>
        /// Raised when a frame is selected.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        public delegate void LoadFrame(ShapeModel shapeModel);

        /// <summary>
        /// Occurs when [on new asset].
        /// </summary>
        public event NewAsset OnNewAsset;

        /// <summary>
        /// Occurs when [on loaded asset].
        /// </summary>
        public event AssetsLoaded OnAssetsLoaded;

        /// <summary>
        /// Occurs when [on loaded asset].
        /// </summary>
        public event CurrentAssetChanged OnCurrentAssetChanged;

        /// <summary>
        /// Occurs when [on load frame].
        /// </summary>
        public event LoadFrame OnLoadFrame;

        /// <summary>
        /// Gets the current asset.
        /// </summary>
        /// <value>
        /// The current asset.
        /// </value>
        public AssetModel CurrentAsset { get; private set; }

        /// <summary>
        /// Gets the current frame.
        /// </summary>
        /// <value>
        /// The current frame.
        /// </value>
        public ShapeModel CurrentFrame { get; private set; }

        /// <summary>
        /// Gets or sets the assets.
        /// </summary>
        /// <value>
        /// The assets.
        /// </value>
        private List<AssetModel> Assets { get; set; }

        /// <summary>
        /// Gets the assets.
        /// </summary>
        /// <returns>
        ///   <see cref="IEnumerable{AssetModel}" />
        /// </returns>
        public IEnumerable<AssetModel> GetAssets()
        {
            return this.Assets.AsEnumerable();
        }

        /// <summary>
        /// Gets the frame.
        /// </summary>
        /// <param name="index">The frame.</param>
        public void LoadFrameByIndex(int index)
        {
            this.CurrentFrame = this.CurrentAsset.Shapes[index];
            this.OnLoadFrame?.Invoke(this.CurrentFrame);
        }

        /// <summary>
        /// Adds the specified width.
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        /// <param name="frames">The number of shapes.</param>
        /// <param name="columns">The width.</param>
        /// <param name="rows">The height.</param>
        /// <exception cref="DuplicateEntryException">Asset {0} already exists".FormatString(assetName)</exception>
        public void Add(string assetName, int frames, int columns, int rows)
        {
            if (this.Assets.Any(a => a.Name == assetName))
            {
                throw new DuplicateEntryException("Asset {0} already exists".FormatString(assetName));
            }

            var newAsset = this.assetProvider.Create(assetName, frames, columns, rows);
            this.Add(newAsset);
            this.Save();
        }

        /// <summary>
        /// Adds the shape.
        /// </summary>
        public void AddShapeToAsset()
        {
            var newShape = this.shapeProvider.Create(this.CurrentAsset.Shapes.First().LastColumn(), this.CurrentAsset.Shapes.First().LastRow());
            this.CurrentAsset.Shapes.Add(newShape);
            this.TriggerOnCurrentAssetChanged();
        }

        /// <summary>
        /// Moves the shape right.
        /// </summary>
        /// <param name="index">The index.</param>
        public void MoveShapeRight(int index)
        {
            if (index == this.CurrentAsset.Shapes.Count() - 1)
            {
                return;
            }

            // Swap shape with the one on the right.
            var shape1 = this.CurrentAsset.Shapes[index];
            var shape2 = this.CurrentAsset.Shapes[index + 1];

            this.CurrentAsset.Shapes[index] = shape2;
            this.CurrentAsset.Shapes[index + 1] = shape1;

            this.TriggerOnCurrentAssetChanged();
        }

        /// <summary>
        /// Moves the shape left.
        /// </summary>
        /// <param name="index">The index.</param>
        public void MoveShapeLeft(int index)
        {
            if (index == 0)
            {
                return;
            }

            // Swap shape with the one on the right.
            var shape1 = this.CurrentAsset.Shapes[index];
            var shape2 = this.CurrentAsset.Shapes[index - 1];

            this.CurrentAsset.Shapes[index] = shape2;
            this.CurrentAsset.Shapes[index - 1] = shape1;

            this.TriggerOnCurrentAssetChanged();
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(this.Assets);
            json.SaveToFile(this.assetFile);
        }

        /// <summary>
        /// Adds the specified new asset.
        /// </summary>
        /// <param name="newAsset">The new asset.</param>
        public void Add(AssetModel newAsset)
        {
            this.Assets.Add(newAsset);
            this.OnNewAsset?.Invoke(this.Assets, newAsset);
        }

        /// <summary>
        /// Removes this instance.
        /// </summary>
        public void Remove()
        {
            if (this.CurrentAsset != null)
            {
                this.Assets.Remove(this.CurrentAsset);
                this.OnAssetsLoaded?.Invoke(this.Assets);
            }
        }

        /// <summary>
        /// Removes the specified current asset.
        /// </summary>
        /// <param name="shapeIndex">Index of the shape.</param>
        public void RemoveShapeFromAsset(int shapeIndex)
        {
            if (this.CurrentAsset.Shapes.Count() > 1)
            {
                this.CurrentAsset.Shapes.RemoveAt(shapeIndex);
                this.OnCurrentAssetChanged?.Invoke(this.CurrentAsset);
            }
        }

        /// <summary>
        /// Adds the shape to asset.
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        public void AddShapeToAsset(string assetName)
        {
            this.SetByName(assetName);
            this.AddShapeToAsset();
        }

        /// <summary>
        /// Adds the column left.
        /// </summary>
        public void AddColumnLeft()
        {
            this.CurrentFrame.AddColumnLeft();
            this.OnLoadFrame?.Invoke(this.CurrentFrame);
        }

        /// <summary>
        /// Adds the column.
        /// </summary>
        public void AddColumnRight()
        {
            this.CurrentFrame.AddColumnRight();
            this.OnLoadFrame?.Invoke(this.CurrentFrame);
        }

        /// <summary>
        /// Adds the row top.
        /// </summary>
        public void AddRowTop()
        {
            this.CurrentFrame.AddRowTop();
            this.OnLoadFrame?.Invoke(this.CurrentFrame);
        }

        /// <summary>
        /// Adds the row.
        /// </summary>
        public void AddRowBottom()
        {
            this.CurrentFrame.AddRowBottom();
            this.OnLoadFrame.Invoke(this.CurrentFrame);
        }

        /// <summary>
        /// Removes the row top.
        /// </summary>
        public void RemoveRowTop()
        {
            if (this.CurrentFrame.LastRow() > 1)
            {
                this.CurrentFrame.RemoveRowTop();
            }

            this.OnLoadFrame.Invoke(this.CurrentFrame);
        }

        /// <summary>
        /// Removes the last row.
        /// </summary>
        public void RemoveRowBottom()
        {
            if (this.CurrentFrame.LastRow() > 1)
            {
                this.CurrentFrame.RemoveRowBottom();
            }

            this.OnLoadFrame.Invoke(this.CurrentFrame);
        }

        /// <summary>
        /// Removes the last column.
        /// </summary>
        public void RemoveColumnLeft()
        {
            if (this.CurrentFrame.LastColumn() > 1)
            {
                this.CurrentFrame.RemoveColumnLeft();
            }

            this.OnLoadFrame.Invoke(this.CurrentFrame);
        }

        /// <summary>
        /// Removes the column right.
        /// </summary>
        public void RemoveColumnRight()
        {
            if (this.CurrentFrame.LastColumn() > 1)
            {
                this.CurrentFrame.RemoveColumnRight();
            }

            this.OnLoadFrame.Invoke(this.CurrentFrame);
        }

        /// <summary>
        /// Crops the images for the shapes in the current asset.
        /// </summary>
        public void CropAndAlignAnchors()
        {
            if (this.CurrentAsset != null)
            {
                var allHaveAnchor = this.CurrentAsset.Shapes.All(s => s.Blocks.Any(b => b.Anchor));

                if (!allHaveAnchor)
                {
                    MessageBox.Show("Not every shape has an anchor");
                    return;
                }

                foreach (var shape in this.CurrentAsset.Shapes)
                {
                    if (shape.Blocks.All(b => b.Color == CGA16Colors.Black.GetColor()) == false)
                    {
                        shape.CropImage();
                    }
                }

                var anchorBlocks = this.CurrentAsset.Shapes.SelectMany(s => s.Blocks).Where(b => b.Anchor);
                var maxColumn = anchorBlocks.Max(b => b.Column);
                var maxRow = anchorBlocks.Max(b => b.Row);
                this.AlignAnchors(maxColumn, maxRow);

                // Make images same size
                maxColumn = this.CurrentAsset.Shapes.Max(s => s.LastColumn());
                maxRow = this.CurrentAsset.Shapes.Max(s => s.LastRow());
                this.MakeShapesSameSize(maxColumn, maxRow);
            }

            this.TriggerOnCurrentAssetChanged();
        }

        /// <summary>
        /// Loads the name of the by.
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        public void LoadByName(string assetName)
        {
            this.SetByName(assetName);
            this.OnCurrentAssetChanged?.Invoke(this.CurrentAsset);
        }

        /// <summary>
        /// Loads this instance.
        /// </summary>
        public void LoadAssets()
        {
            this.SetupAssets(this.assetFile);
        }

        /// <summary>
        /// Move blocks in frame to the left.
        /// </summary>
        public void MoveLeft()
        {
            this.CurrentFrame.MoveLeft();
            this.OnLoadFrame.Invoke(this.CurrentFrame);
        }

        /// <summary>
        /// Move blocks in frame up
        /// </summary>
        public void MoveUp()
        {
            this.CurrentFrame.MoveUp();
            this.OnLoadFrame.Invoke(this.CurrentFrame);
        }

        /// <summary>
        /// Move blocks in frame right.
        /// </summary>
        public void MoveRight()
        {
            this.CurrentFrame.MoveRight();
            this.OnLoadFrame.Invoke(this.CurrentFrame);
        }

        /// <summary>
        /// Move blocks in frame down.
        /// </summary>
        public void MoveDown()
        {
            this.CurrentFrame.MoveDown();
            this.OnLoadFrame.Invoke(this.CurrentFrame);
        }

        /// <summary>
        /// Sets up assets. If there are none, we'll create a new list we can add too.
        /// </summary>
        /// <param name="assetFile">The asset file.</param>
        private void SetupAssets(string assetFile)
        {
            if (File.Exists(assetFile))
            {
                var fileContent = File.ReadAllText(assetFile);
                this.Assets = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AssetModel>>(fileContent);
            }
            else
            {
                this.Assets = new List<AssetModel>();
            }

            this.OnAssetsLoaded?.Invoke(this.Assets);
        }

        /// <summary>
        /// Triggers the change event.
        /// </summary>
        private void TriggerOnCurrentAssetChanged()
        {
            this.OnCurrentAssetChanged?.Invoke(this.CurrentAsset);
        }

        /// <summary>
        /// Loads the name of the by.
        /// </summary>
        /// <param name="assetName">Name of the asset.</param>
        private void SetByName(string assetName)
        {
            if (string.IsNullOrEmpty(assetName))
            {
                return;
            }

            var asset = this.Assets.Single(a => a.Name == assetName);
            this.CurrentAsset = asset;
            this.CurrentFrame = asset.Shapes.First();
        }

        /// <summary>
        /// Makes the size of the shapes same.
        /// </summary>
        /// <param name="maxColumn">The maximum column.</param>
        /// <param name="maxRow">The maximum row.</param>
        private void MakeShapesSameSize(int maxColumn, int maxRow)
        {
            foreach (var shape in this.CurrentAsset.Shapes)
            {
                var colDiff = maxColumn - shape.LastColumn();
                var rowDiff = maxRow - shape.LastRow();

                for (int col = 0; col < colDiff; col++)
                {
                    shape.AddColumnRight();
                }

                for (int row = 0; row < rowDiff; row++)
                {
                    shape.AddRowBottom();
                }
            }
        }

        /// <summary>
        /// Aligns the anchors.
        /// </summary>
        /// <param name="maxColumn">The maximum column.</param>
        /// <param name="maxRow">The maximum row.</param>
        private void AlignAnchors(int maxColumn, int maxRow)
        {
            foreach (var shape in this.CurrentAsset.Shapes)
            {
                var anchorBlock = shape.GetAnchorBlock();
                if (anchorBlock != null)
                {
                    var colDiff = maxColumn - anchorBlock.Column;
                    var rowDiff = maxRow - anchorBlock.Row;

                    for (int col = 0; col < colDiff; col++)
                    {
                        shape.AddColumnLeft();
                    }

                    for (int row = 0; row < rowDiff; row++)
                    {
                        shape.AddRowTop();
                    }
                }
            }
        }
    }
}
