// <copyright file="ShapeModel.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.Models.Drawing
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    /// <summary>
    /// A basic shape.
    /// </summary>
    public class ShapeModel : BaseModel
    {
        /// <summary>
        /// Gets or sets the blocks.
        /// </summary>
        /// <value>
        /// The blocks.
        /// </value>
        public List<BlockModel> Blocks { get; set; }
    }
}
