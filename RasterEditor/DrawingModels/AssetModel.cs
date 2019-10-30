// <copyright file="AssetModel.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.Models.Drawing
{
    using System.Collections.Generic;

    /// <summary>
    /// A model for game assets.
    /// </summary>
    public class AssetModel
    {
        /// <summary>
        /// Gets or sets the animation.
        /// </summary>
        /// <value>
        /// The animation.
        /// </value>
        public List<ShapeModel> Shapes { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
