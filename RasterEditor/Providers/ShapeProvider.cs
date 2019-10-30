// <copyright file="ShapeProvider.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.Providers
{
    using System.Collections.Generic;
    using RasterEditor.Models.Drawing;

    /// <summary>
    /// The ShapeProvider. A shape is a collection of blocks.
    /// </summary>
    public class ShapeProvider
    {
        /// <summary>
        /// News the specified height.
        /// </summary>
        /// <param name="numberOfColumns">The width.</param>
        /// <param name="numberOfRows">The height.</param>
        /// <returns>
        /// Empty Shape
        /// </returns>
        public ShapeModel Create(int numberOfColumns, int numberOfRows)
        {
            var returnValue = new ShapeModel()
            {
                Blocks = new List<BlockModel>()
            };

            for (var row = 0; row < numberOfRows; row++)
            {
                for (var column = 0; column < numberOfColumns; column++)
                {
                    // Columns and rows are 1 base
                    var block = BlockModel.Create(column + 1, row + 1);
                    returnValue.Blocks.Add(block);
                }
            }

            return returnValue;
        }
    }
}
