// <copyright file="FileLocationProvider.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.Providers
{
    /// <summary>
    /// Providers the location of core game files.
    /// </summary>
    public class FileLocationProvider
    {
        /// <summary>
        /// Gets the asset file.
        /// </summary>
        /// <value>
        /// The asset file.
        /// </value>
        public string AssetFile
        {
            get
            {
                return @"D:\Reps\RasterEditor\Data\Assets.json";
            }
        }
    }
}
