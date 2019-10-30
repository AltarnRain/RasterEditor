// <copyright file="EnumHandler.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.Providers
{
    using System;
    using System.Collections.Generic;
    using RasterEditor.Models;

    /// <summary>
    /// Provides the names of the AssetType enum
    /// </summary>
    public static class EnumHandler
    {
        /// <summary>
        /// Gets the asset type list.
        /// </summary>
        /// <param name="anEnum">An enum.</param>
        /// <returns>
        /// List of AssetType Names
        /// </returns>
        public static string[] GetNamesAsList(Type anEnum)
        {
            var returnValue = new List<string>();

            foreach (var name in Enum.GetNames(anEnum))
            {
                returnValue.Add(name);
            }

            return returnValue.ToArray();
        }
    }
}
