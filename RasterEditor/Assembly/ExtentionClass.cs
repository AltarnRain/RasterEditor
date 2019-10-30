// <copyright file="ExtentionClass.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Extentions
{
    using System;
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// Extentions for <see cref="Assembly" />
    /// </summary>
    public static partial class ExtentionClass
    {
        /// <summary>
        /// Gets the directory path.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>a string</returns>
        public static string GetDirectoryPath(this Assembly assembly)
        {
            var filePath = new Uri(assembly.CodeBase).LocalPath;

            if (filePath.EndsWith(@"\") == false)
            {
                filePath += @"\";
            }

            return Path.GetDirectoryName(filePath);
        }
    }
}
