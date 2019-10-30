// <copyright file="ExtentionClass.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace Extentions
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    using RasterEditor.Extentions;

    /// <summary>
    /// Extention class
    /// </summary>
    public static partial class ExtentionClass
    {
        /// <summary>
        /// Casts an object to Type T.
        /// </summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <param name="obj">Any class </param>
        /// <returns>Class cast to T</returns>
        public static T As<T>(this object obj)
            where T : class
        {
            var castedObject = obj as T;
            if (castedObject == null)
            {
                throw new InvalidCastException("Cannot perform cast");
            }

            return castedObject;
        }

        /// <summary>
        /// Generates the XML.
        /// </summary>
        /// <typeparam name="T">A model of type T</typeparam>
        /// <param name="obj">The model.</param>
        /// <returns>
        /// XML string
        /// </returns>
        /// <exception cref="System.Exception">An error occurred</exception>
        public static string Serialize<T>(this object obj)
            where T : class
        {
            if (obj == null)
            {
                return string.Empty;
            }

            try
            {
                var xmlserializer = new XmlSerializer(typeof(T));
                var stringWriter = new StringWriter();

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "\t";

                using (var writer = XmlWriter.Create(stringWriter, settings))
                {
                    xmlserializer.Serialize(writer, obj);
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }

        /// <summary>
        /// Clones the specified object.
        /// </summary>
        /// <typeparam name="T">An object of type t</typeparam>
        /// <param name="obj">The object.</param>
        /// <returns>A cloned object using XML serialization</returns>
        public static T Clone<T>(this object obj)
            where T : class
        {
            var str = obj.Serialize<T>();
            return str.Deserialize<T>();
        }
    }
}
