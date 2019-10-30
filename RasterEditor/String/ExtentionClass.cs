// <copyright file="ExtentionClass.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.Extentions
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// Extention class
    /// </summary>
    public static partial class ExtentionClass
    {
        /// <summary>
        /// Deserializes the specified XML string.
        /// </summary>
        /// <typeparam name="T">An class</typeparam>
        /// <param name="xmlString">The XML string.</param>
        /// <returns>Object of type T</returns>
        /// <exception cref="InvalidCastException">Invalid model cast</exception>
        /// <exception cref="Exception">An error occurred</exception>
        public static T Deserialize<T>(this string xmlString)
                  where T : class
        {
            if (xmlString == null)
            {
                return null;
            }

            try
            {
                var xmlserializer = new XmlSerializer(typeof(T));
                var stringReader = new StringReader(xmlString);

                using (var reader = XmlReader.Create(stringReader))
                {
                    var returnValue = xmlserializer.Deserialize(reader) as T;

                    if (returnValue == null)
                    {
                        throw new InvalidCastException("Invalid model cast");
                    }
                    else
                    {
                        return returnValue;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }

        /// <summary>
        /// Deserializes the specified XML string.
        /// </summary>
        /// <typeparam name="T">An class</typeparam>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>
        /// Object of type T
        /// </returns>
        /// <exception cref="FileNotFoundException">File '{0}' was not found".FormatString(fileName)</exception>
        public static T DeserializeFile<T>(this string fileName)
                  where T : class
        {
            if (File.Exists(fileName) == false)
            {
                throw new FileNotFoundException("File '{0}' was not found".FormatString(fileName), fileName);
            }

            var xmlString = File.ReadAllText(fileName);
            return xmlString.Deserialize<T>();
        }

        /// <summary>
        /// Formats the specified strings.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="objects">The objects.</param>
        /// <returns>
        /// A formatted string
        /// </returns>
        public static string FormatString(this string str, params object[] objects)
        {
            var stringList = objects.Select(o => o.ToString());
            return string.Format(str, stringList.ToArray());
        }

        /// <summary>
        /// Saves to file.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <param name="fileName">Name of the file.</param>
        public static void SaveToFile(this string src, string fileName)
        {
            File.WriteAllText(fileName, src);
        }
    }
}
