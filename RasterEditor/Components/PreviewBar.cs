// <copyright file="PreviewBar.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.CustomComponents.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using RasterEditor.Models.Drawing;
    using RasterEditor.Models.Enumerators;
    using RasterEditor.R42Extentions;
    using Render;

    /// <summary>
    /// Shows a preview of each image.
    /// </summary>
    public class PreviewBar
    {
        /// <summary>
        /// The panel
        /// </summary>
        private readonly Panel panel;

        /// <summary>
        /// Initializes a new instance of the <see cref="PreviewBar"/> class.
        /// </summary>
        /// <param name="panel">The panel.</param>
        public PreviewBar(Panel panel)
        {
            this.panel = panel;

            this.panel.AutoScroll = true;
        }

        /// <summary>
        /// Gets or sets the on select image.
        /// </summary>
        /// <value>
        /// The on select image.
        /// </value>
        public Action<int> OnSelectImage { get; set; }

        /// <summary>
        /// Gets or sets the on move image left.
        /// </summary>
        /// <value>
        /// The on move image left.
        /// </value>
        public Action<int> OnMoveImageLeft { get; set; }

        /// <summary>
        /// Gets or sets the on move image right.
        /// </summary>
        /// <value>
        /// The on move image right.
        /// </value>
        public Action<int> OnMoveImageRight { get; set; }

        /// <summary>
        /// Draws the specified shapes.
        /// </summary>
        /// <param name="shapes">The shapes.</param>
        public void Draw(IEnumerable<ShapeModel> shapes)
        {
            this.panel.Controls.Clear();
            this.panel.SuspendLayout();

            var index = shapes.Count() - 1;

            this.panel.Height = 20 + (shapes.Max(s => s.LastRow()) * 20);

            foreach (var shape in shapes.Reverse())
            {
                var mainPanel = new Panel();
                var image = new Panel();

                var bitmap = ImageGenerator.RenderShapeToBitmap(shape);
                image.Width = bitmap.Width;
                image.Height = bitmap.Height;
                image.Top = 0;
                image.Left = 20;
                image.BorderStyle = BorderStyle.Fixed3D;
                image.Tag = index;
                image.Click += this.OnDrawSurfaceClick;
                image.BackColor = CGA16Colors.Black.GetColor();
                image.BackgroundImage = bitmap;

                var moveLeftButton = this.CreateMovebutton("<", this.MoveLeft);
                var moveRightButton = this.CreateMovebutton(">", this.MoveRight);

                moveLeftButton.Dock = DockStyle.Left;
                moveLeftButton.Tag = index;
                moveRightButton.Dock = DockStyle.Right;
                moveRightButton.Tag = index;

                mainPanel.Controls.Add(moveLeftButton);
                mainPanel.Controls.Add(image);
                mainPanel.Controls.Add(moveRightButton);
                mainPanel.Dock = DockStyle.Left;
                mainPanel.Width = image.Width + 40;

                index--;

                this.panel.Controls.Add(mainPanel);
            }

            this.panel.ResumeLayout();
        }

        private Button CreateMovebutton(string text, EventHandler moveMethod)
        {
            var button = new Button();
            button.Height = this.panel.Height;
            button.Width = 20;
            button.Text = text;
            button.Click += moveMethod;

            return button;
        }

        private void MoveLeft(object sender, EventArgs e)
        {
            var index = this.GetButtonIndex(sender);
            this.OnMoveImageLeft?.Invoke(index);
        }

        private int GetButtonIndex(object sender)
        {
            var button = sender as Button;
            return (int)button.Tag;
        }

        private void MoveRight(object sender, EventArgs e)
        {
            var index = this.GetButtonIndex(sender);
            this.OnMoveImageRight?.Invoke(index);
        }

        private void OnDrawSurfaceClick(object sender, EventArgs e)
        {
            var panel = sender as Panel;
            this.OnSelectImage((int)panel.Tag);
        }
    }
}
