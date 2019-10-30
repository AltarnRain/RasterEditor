// <copyright file="ImageGenerator.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Render
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using RasterEditor.Models.Drawing;
    using RasterEditor.Models.Enumerators;
    using RasterEditor.R42Extentions;

    /// <summary>
    /// Render class
    /// </summary>
    public class ImageGenerator
    {
        /// <summary>
        /// The image map part size
        /// </summary>
        private const int ImageMapPartSize = 128;

        /// <summary>
        /// Renders the shape to bitmap.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <returns>A bitmap</returns>
        public static Bitmap RenderShapeToBitmap(ShapeModel shapeModel)
        {
            var width = 12 * shapeModel.LastColumn();
            var height = 12 * shapeModel.LastRow();

            var bitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            var g = Graphics.FromImage(bitmap);

            var size = 12;
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

        /// <summary>
        /// Renders to sprite map.
        /// </summary>
        /// <param name="shapes">The shapes.</param>
        /// <returns>A bitmap containing a sprite map</returns>
        public static Bitmap RenderToSpriteMap(List<ShapeModel> shapes)
        {
            var allBitmaps = new List<Bitmap>();
            foreach (var shape in shapes)
            {
                allBitmaps.Add(RenderShapeToBitmap(shape));
            }

            var width = allBitmaps.Count() * ImageMapPartSize;
            var height = allBitmaps.Select(b => b.Height).Max();

            var bitmap = new Bitmap(width, ImageMapPartSize, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

            var g = Graphics.FromImage(bitmap);

            var bitmapCounter = 0;
            foreach (var bm in allBitmaps)
            {
                var x = (ImageMapPartSize * bitmapCounter) + (ImageMapPartSize / 2) - (bm.Width / 2);
                var y = (ImageMapPartSize / 2) - (bm.Height / 2);
                g.DrawImage(bm, x, y, bm.Width, bm.Height);
                bitmapCounter++;
            }

            return bitmap;
        }
    }
}