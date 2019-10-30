// <copyright file="BaseGameObject.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.Models.GameModels
{
    using System.Collections.Generic;
    using RasterEditor.Models.Drawing;

    /// <summary>
    /// Base class for all actors.
    /// </summary>
    public abstract class BaseGameObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseGameObject"/> class.
        /// </summary>
        /// <param name="asset">The asset.</param>
        public BaseGameObject(AssetModel asset)
        {
            this.Asset = asset;
        }

        /// <summary>
        /// Gets or sets the x.
        /// </summary>
        /// <value>
        /// The x.
        /// </value>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the y.
        /// </summary>
        /// <value>
        /// The y.
        /// </value>
        public double Y { get; set; }

        /// <summary>
        /// Gets or sets the current frame.
        /// </summary>
        /// <value>
        /// The current frame.
        /// </value>
        protected int CurrentFrame { get; set; }

        /// <summary>
        /// Gets or sets the asset.
        /// </summary>
        /// <value>
        /// The asset.
        /// </value>
        protected AssetModel Asset { get; set; }

        /// <summary>
        /// Gets the blocks.
        /// </summary>
        /// <returns>The block models of the current frame</returns>
        public IEnumerable<BlockModel> GetBlocks()
        {
            return null;
        }
    }
}
