// <copyright file="Palet.cs" company="OI">
// Copyright (c) OI. All rights reserved.
// </copyright>

namespace RasterEditor.CustomComponents
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using RasterEditor.Providers;
    using static System.Windows.Forms.Control;

    /// <summary>
    /// Created buttons for setting color
    /// </summary>
    public class Palet
    {
        private readonly ColorProvider colorProvider;

        /// <summary>
        /// The button height
        /// </summary>
        private readonly int buttonHeight;

        /// <summary>
        /// The panel
        /// </summary>
        private readonly Panel panel;

        /// <summary>
        /// Initializes a new instance of the <see cref="Palet" /> class.
        /// </summary>
        /// <param name="colorProvider">The color provider.</param>
        /// <param name="buttonHeight">The button height</param>
        /// <param name="panel">The panel.</param>
        public Palet(ColorProvider colorProvider, int buttonHeight, Panel panel)
            : base()
        {
            this.colorProvider = colorProvider;
            this.buttonHeight = buttonHeight;
            this.panel = panel;
            this.DrawButtons();
        }

        /// <summary>
        /// Called when a button changes the active color.
        /// </summary>
        /// <param name="color">The color.</param>
        public delegate void ColorSelected(Color color);

        /// <summary>
        /// Occurs when [on color selected].
        /// </summary>
        public event ColorSelected OnColorSelected;

        /// <summary>
        /// Gets the controls.
        /// </summary>
        /// <value>
        /// The controls.
        /// </value>
        public ControlCollection Controls
        {
            get
            {
                return this.panel.Controls;
            }
        }

        /// <summary>
        /// Gets the color buttons.
        /// </summary>
        /// <value>
        /// The color buttons.
        /// </value>
        public IEnumerable<Button> ColorButtons
        {
            get
            {
                return this.panel.Controls.Cast<Button>();
            }
        }

        /// <summary>
        /// Draws the buttons.
        /// </summary>
        public void DrawButtons()
        {
            foreach (var color in this.colorProvider.GetColors())
            {
                var button = new Button();
                button.ForeColor = button.BackColor = color;
                button.Dock = DockStyle.Left;
                button.Width = 30;
                button.Click += this.ButtonClick;

                this.panel.Controls.Add(button);
            }
        }

        /// <summary>
        /// Clicks the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            var color = button.ForeColor;
            this.OnColorSelected?.Invoke(color);
        }
    }
}
