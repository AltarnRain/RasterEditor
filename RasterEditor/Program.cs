// <copyright file="Program.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace AssetEditor
{
    using System;
    using System.Windows.Forms;
    using Ninject;
    using RasterEditor.AssetEditor.Forms;
    using RasterEditor.Factories;

    /// <summary>
    /// Main program for editor
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var kernel = new StandardKernel())
            {
                var form = kernel.Get<ViewFactory>().Get<AssetEditor>();

                Application.Run(form);
            }
        }
    }
}
