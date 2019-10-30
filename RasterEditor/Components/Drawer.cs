// <copyright file="Drawer.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.CustomComponents
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using RasterEditor.Models.Drawing;
    using RasterEditor.R42Extentions;

    /// <summary>
    /// Daws buttons on a panel to set the color.
    /// </summary>
    public class Drawer
    {
        /// <summary>
        /// The panel
        /// </summary>
        private readonly Panel panel;

        /// <summary>
        /// The current shape
        /// </summary>
        private ShapeModel currentShape;

        /// <summary>
        /// Initializes a new instance of the <see cref="Drawer" /> class.
        /// </summary>
        /// <param name="panel">The panel.</param>
        /// <exception cref="System.ArgumentNullException">shapeModel</exception>
        public Drawer(Panel panel)
            : base()
        {
            this.panel = panel;
        }

        /// <summary>
        /// Gets or sets the on image change.
        /// </summary>
        /// <value>
        /// The on image change.
        /// </value>
        public Action OnImageChange { get; set; }

        /// <summary>
        /// Gets the block buttons.
        /// </summary>
        /// <value>
        /// The block buttons.
        /// </value>
        public IEnumerable<BlockButton> BlockButtons
        {
            get
            {
                return this.panel.Controls.Cast<BlockButton>();
            }
        }

        /// <summary>
        /// Passed down the active color to all the BlockButtons contained in the Drawer
        /// </summary>
        /// <param name="color">The color.</param>
        public void SetAciveColor(Color color)
        {
            foreach (BlockButton b in this.panel.Controls)
            {
                b.ActiveColor = color;
            }
        }

        /// <summary>
        /// Sets the achor.
        /// </summary>
        public void SetAchor()
        {
            this.currentShape.ResetAnchor();
            foreach (BlockButton b in this.panel.Controls)
            {
                b.BecomeAnchorOnClick = true;
                b.Text = "Click to set Anchor";
            }
        }

        /// <summary>
        /// Draws the buttons.
        /// </summary>
        /// <param name="shapeModel">The shape model.</param>
        /// <param name="buttonSize">Size of the button.</param>
        public void DrawButtons(ShapeModel shapeModel, int buttonSize)
        {
            this.currentShape = shapeModel;
            this.panel.Controls.Clear();

            var bbList = new List<BlockButton>();
            foreach (var block in shapeModel.Blocks)
            {
                var blockButton = new BlockButton(block, Color.Black)
                {
                    Left = (block.Column - 1) * buttonSize,
                    Top = (block.Row - 1) * buttonSize,
                    Width = buttonSize,
                    Height = buttonSize,
                    OnBecomeAnchor = this.SetAnchor,
                    OnChangeColor = this.OnImageChange
                };

                bbList.Add(blockButton);
            }

            this.panel.Controls.AddRange(bbList.ToArray());
        }

        /// <summary>
        /// Redraws the buttons.
        /// </summary>
        /// <param name="buttonSize">Size of the button.</param>
        public void RedrawButtons(int buttonSize)
        {
            if (this.currentShape != null)
            {
                this.DrawButtons(this.currentShape, buttonSize);
            }
        }

        /// <summary>
        /// Sets the anchor.
        /// </summary>
        /// <param name="column">The column.</param>
        /// <param name="row">The row.</param>
        private void SetAnchor(int column, int row)
        {
            foreach (BlockButton b in this.panel.Controls)
            {
                b.BecomeAnchorOnClick = false;
                b.Text = string.Empty;
            }

            this.currentShape.SetAnchor(column, row);
        }
    }
}
