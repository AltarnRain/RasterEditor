// <copyright file="ColorExtentions.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.R42Extentions
{
    using System.Drawing;
    using System.IO;
    using RasterEditor.Models.Enumerators;
    using RasterEditor.R42Extentions.Constants;

    /// <summary>
    /// Extention class for the CGA16Colors enum
    /// </summary>
    public static partial class ExtentionsClass
    {
        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <param name="cgaColor">Color of the cga.</param>
        /// <returns> a <see cref="Color"/></returns>
        /// <exception cref="InvalidDataException">Thrown when an invalid value for <see cref="CGA16Colors"/> is used</exception>
        public static Color GetColor(this CGA16Colors cgaColor)
        {
            switch (cgaColor)
            {
                case CGA16Colors.Black:
                    return TranslateColor(ColorHexadecimals.Black);
                case CGA16Colors.Blue:
                    return TranslateColor(ColorHexadecimals.Blue);
                case CGA16Colors.Brown:
                    return TranslateColor(ColorHexadecimals.Brown);
                case CGA16Colors.Cyan:
                    return TranslateColor(ColorHexadecimals.Cyan);
                case CGA16Colors.Red:
                    return TranslateColor(ColorHexadecimals.Red);
                case CGA16Colors.Magenta:
                    return TranslateColor(ColorHexadecimals.Magenta);
                case CGA16Colors.Gray:
                    return TranslateColor(ColorHexadecimals.Gray);
                case CGA16Colors.Green:
                    return TranslateColor(ColorHexadecimals.Green);
                case CGA16Colors.LightBlue:
                    return TranslateColor(ColorHexadecimals.LightBlue);
                case CGA16Colors.LightCyan:
                    return TranslateColor(ColorHexadecimals.LightCyan);
                case CGA16Colors.LightGray:
                    return TranslateColor(ColorHexadecimals.LightGray);
                case CGA16Colors.LightGreen:
                    return TranslateColor(ColorHexadecimals.LightGreen);
                case CGA16Colors.LightMagenta:
                    return TranslateColor(ColorHexadecimals.LightMagenta);
                case CGA16Colors.LightRed:
                    return TranslateColor(ColorHexadecimals.LightRed);
                case CGA16Colors.Yellow:
                    return TranslateColor(ColorHexadecimals.Yellow);
                case CGA16Colors.White:
                    return TranslateColor(ColorHexadecimals.White);
                default:
                    throw new InvalidDataException($"Could not translate {cgaColor.ToString()}");
            }

            Color TranslateColor(string colorHex)
            {
                return ColorTranslator.FromHtml(colorHex);
            }
        }
    }
}
