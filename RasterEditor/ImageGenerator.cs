// <copyright file="ImageGenerator.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Render
{
    using System.Drawing;
    using RasterEditor.Models.Drawing;
    using RasterEditor.Models.Enumerators;
    using RasterEditor.R42Extentions;

    /// <summary>
    /// Render class
    /// </summary>
    public class ImageGenerator
    {
        /// <summary>
        /// Renders the shape.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <param name="folder">The folder.</param>
        /// <param name="name">The name.</param>
        /// <param name="count">The count.</param>
        /// <returns>
        /// A filename
        /// </returns>
        public string RenderShapeToBitmapFile(ShapeModel shapeModel, string folder, string name, int count)
        {
            var b = this.RenderShapeToBitmap(shapeModel);

            var paddedCount = count.ToString().PadLeft(2, '0');
            var fileName = folder + $"{name}_{paddedCount}.bmp";

            b.Save(fileName);
            return fileName;
        }

        /// <summary>
        /// Renders the shape to bitmap.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <returns>A bitmap</returns>
        public Bitmap RenderShapeToBitmap(ShapeModel shapeModel)
        {
            var width = 20 * shapeModel.LastColumn();
            var height = 20 * shapeModel.LastRow();

            var bitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            var g = Graphics.FromImage(bitmap);

            var size = 20;
            foreach (var block in shapeModel.Blocks)
            {
                var x = (block.Column - 1) * size;
                var y = (block.Row - 1) * size;

                var rect = new Rectangle(x, y, size, size);

                g.FillRectangle(new SolidBrush(block.Color), rect);
            }

            bitmap.MakeTransparent(CGA16Colors.Black.GetColor());

            return bitmap;
        }
    }
}