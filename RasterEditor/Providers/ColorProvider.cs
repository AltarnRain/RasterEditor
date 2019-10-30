// <copyright file="ColorProvider.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using RasterEditor.Models.Enumerators;
    using RasterEditor.R42Extentions;

    /// <summary>
    /// Providers Color
    /// </summary>
    public class ColorProvider
    {
        /// <summary>
        /// The colors
        /// </summary>
        private static IEnumerable<Color> colors = null;

        /// <summary>
        /// Gets the colors of the CGA 16 palet.
        /// </summary>
        /// <returns>An array of colors</returns>
        public IEnumerable<Color> GetColors()
        {
            if (ColorProvider.colors == null)
            {
                var colorIndexes = Enum.GetValues(typeof(CGA16Colors));

                var colors = new List<Color>();
                foreach (var index in colorIndexes)
                {
                    var cgaColor = (CGA16Colors)index;
                    colors.Add(cgaColor.GetColor());
                }

                ColorProvider.colors = colors;
            }

            return ColorProvider.colors;
        }
    }
}