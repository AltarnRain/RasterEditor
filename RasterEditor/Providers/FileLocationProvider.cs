// <copyright file="FileLocationProvider.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.Providers
{
    using System.IO;
    using System.Reflection;

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
        public string MainFolder
        {
            get
            {
                return Path.GetDirectoryName(Path.Combine(Assembly.GetExecutingAssembly().Location));
            }
        }

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
                var path = Path.Combine(this.MainFolder, "Data");
                var filePath = Path.Combine(path, "Assets.json");
                this.EnsureDirectory(path);
                return filePath;
            }
        }

        /// <summary>
        /// Gets the image folder.
        /// </summary>
        /// <value>
        /// The image folder.
        /// </value>
        public string ImageFolder
        {
            get
            {
                var path = Path.Combine(this.MainFolder, "Images");
                this.EnsureDirectory(path);
                return path;
            }
        }

        /// <summary>
        /// Ensures the directory.
        /// </summary>
        /// <param name="directory">The directory.</param>
        private void EnsureDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}
