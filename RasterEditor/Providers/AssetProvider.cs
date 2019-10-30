// <copyright file="AssetProvider.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.Providers
{
    using System.Collections.Generic;
    using RasterEditor.Models.Drawing;
    using RasterEditor.Models.Enumerators;

    /// <summary>
    /// Provides an Asset.
    /// </summary>
    public class AssetProvider
    {
        /// <summary>
        /// The shape provider
        /// </summary>
        private readonly ShapeProvider shapeProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetProvider"/> class.
        /// </summary>
        /// <param name="shapeProvider">The shape provider.</param>
        public AssetProvider(ShapeProvider shapeProvider)
        {
            this.shapeProvider = shapeProvider;
        }

        /// <summary>
        /// Creates an AssetModel.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="numberOfShapes">The number of shapes.</param>
        /// <param name="columns">The number of blocks on x axis.</param>
        /// <param name="rows">The number of blocks on y axis.</param>
        /// <returns>
        /// An AssetModel
        /// </returns>
        public AssetModel Create(string name, int numberOfShapes, int columns, int rows)
        {
            var returnValue = new AssetModel
            {
                Name = name
            };

            returnValue.Shapes = new List<ShapeModel>();

            for (var i = 0; i < numberOfShapes; i++)
            {
                var shape = this.shapeProvider.Create(columns, rows);
                returnValue.Shapes.Add(shape);
            }

            return returnValue;
        }
    }
}
