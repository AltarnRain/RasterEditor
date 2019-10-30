// <copyright file="BlockButton.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.CustomComponents
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using RasterEditor.Models.Drawing;
    using RasterEditor.Models.Enumerators;
    using RasterEditor.R42Extentions;

    /// <summary>
    /// The block button,
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public partial class BlockButton : Control
    {
        /// <summary>
        /// Gets the block model
        /// </summary>
        /// <value>
        /// The block model.
        /// </value>
        private BlockModel blockModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockButton" /> class.
        /// </summary>
        /// <param name="blockModel">The block model.</param>
        /// <param name="activeColor">Color of the active.</param>
        public BlockButton(BlockModel blockModel, Color activeColor)
            : base()
        {
            this.blockModel = blockModel;
            this.ActiveColor = activeColor;
        }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        public new string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                if (value != base.Text)
                {
                    base.Text = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the active.
        /// </summary>
        /// <value>
        /// The color of the active.
        /// </value>
        public Color ActiveColor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [become anchor on click].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [become anchor on click]; otherwise, <c>false</c>.
        /// </value>
        public bool BecomeAnchorOnClick { get; set; }

        /// <summary>
        /// Gets or sets the on become anchor action
        /// </summary>
        /// <value>
        /// The on become anchor.
        /// </value>
        public Action<int, int> OnBecomeAnchor { get; set; }

        /// <summary>
        /// Gets or sets the color of the on change.
        /// </summary>
        /// <value>
        /// The color of the on change.
        /// </value>
        public Action OnChangeColor { get; set; }

        /// <summary>
        /// Raises the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs" /> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var gfx = e.Graphics;
            var rc = this.ClientRectangle;
            var setColor = this.blockModel.Color;

            var tonAndBottomBorder = rc.Height * 0.10f;
            var leftAndRightBorder = rc.Width * 0.10f;

            var innerRectangle = new RectangleF(
                rc.Left + leftAndRightBorder,
                rc.Top + tonAndBottomBorder,
                rc.Width - (leftAndRightBorder * 2),
                rc.Height - (tonAndBottomBorder * 2));

            if (setColor == CGA16Colors.Black.GetColor())
            {
                gfx.FillRectangle(new SolidBrush(this.Parent.BackColor), rc);
                gfx.FillRectangle(new SolidBrush(setColor), innerRectangle);
            }
            else
            {
                gfx.FillRectangle(new SolidBrush(setColor), rc);
            }

            if (this.blockModel.Anchor)
            {
                this.Text = "Anchor";
            }

            var sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            gfx.DrawString(this.Text, this.Font, new SolidBrush(Color.Black), new RectangleF((float)rc.Left, (float)rc.Top, (float)rc.Height, (float)rc.Width), sf);
        }

        /// <summary>
        /// Click event that updates the accociated block.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            if (this.BecomeAnchorOnClick)
            {
                this.blockModel.Anchor = this.BecomeAnchorOnClick;
                this.OnBecomeAnchor?.Invoke(this.blockModel.Column, this.blockModel.Row);
            }
            else
            {
                this.blockModel.Color = this.ActiveColor;
                this.OnChangeColor?.Invoke();
            }

            this.Invalidate();
        }
    }
}
