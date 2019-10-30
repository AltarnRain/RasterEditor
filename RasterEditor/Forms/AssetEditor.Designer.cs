namespace RasterEditor.AssetEditor.Forms
{
    partial class AssetEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ListPanel = new System.Windows.Forms.Panel();
            this.AssetListBox = new System.Windows.Forms.ListBox();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddAsset = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAssetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cropShapesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.renderAllAssetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.About = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimatorTab = new System.Windows.Forms.TabControl();
            this.AnimationTab = new System.Windows.Forms.TabPage();
            this.DrawerPanel = new System.Windows.Forms.Panel();
            this.PreviewBar = new System.Windows.Forms.Panel();
            this.PaletPanel = new System.Windows.Forms.Panel();
            this.Tools = new System.Windows.Forms.Panel();
            this.AssetType = new System.Windows.Forms.ComboBox();
            this.AnimationStyle = new System.Windows.Forms.ComboBox();
            this.SetAnchorButton = new System.Windows.Forms.Button();
            this.ButtonSize = new System.Windows.Forms.TrackBar();
            this.RemoveTopRowButton = new System.Windows.Forms.Button();
            this.AddRowTopButton = new System.Windows.Forms.Button();
            this.RemoveLeftColumnButton = new System.Windows.Forms.Button();
            this.AddColumnLeftButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MoveDownButton = new System.Windows.Forms.Button();
            this.MoveRightButton = new System.Windows.Forms.Button();
            this.MoveLeftButton = new System.Windows.Forms.Button();
            this.MoveUpButton = new System.Windows.Forms.Button();
            this.RemoveBottomRowButton = new System.Windows.Forms.Button();
            this.RemoveRightColumnButton = new System.Windows.Forms.Button();
            this.AddRowBottomButton = new System.Windows.Forms.Button();
            this.AddColumnRightButton = new System.Windows.Forms.Button();
            this.RemoveFrameButton = new System.Windows.Forms.Button();
            this.AddFrameButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectFrameCombobox = new System.Windows.Forms.ComboBox();
            this.ListPanel.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.AnimatorTab.SuspendLayout();
            this.AnimationTab.SuspendLayout();
            this.Tools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonSize)).BeginInit();
            this.SuspendLayout();
            // 
            // ListPanel
            // 
            this.ListPanel.Controls.Add(this.AssetListBox);
            this.ListPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ListPanel.Location = new System.Drawing.Point(0, 24);
            this.ListPanel.Name = "ListPanel";
            this.ListPanel.Size = new System.Drawing.Size(200, 519);
            this.ListPanel.TabIndex = 0;
            // 
            // AssetListBox
            // 
            this.AssetListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssetListBox.FormattingEnabled = true;
            this.AssetListBox.Location = new System.Drawing.Point(0, 0);
            this.AssetListBox.Name = "AssetListBox";
            this.AssetListBox.Size = new System.Drawing.Size(200, 519);
            this.AssetListBox.TabIndex = 0;
            this.AssetListBox.SelectedIndexChanged += new System.EventHandler(this.AssetListBox_SelectedIndexChanged);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1018, 24);
            this.MainMenu.TabIndex = 2;
            this.MainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddAsset,
            this.removeAssetToolStripMenuItem,
            this.toolStripMenuItem1,
            this.cropShapesToolStripMenuItem,
            this.toolStripMenuItem2,
            this.renderAllAssetsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // AddAsset
            // 
            this.AddAsset.Name = "AddAsset";
            this.AddAsset.Size = new System.Drawing.Size(201, 22);
            this.AddAsset.Text = "Add Asset";
            this.AddAsset.Click += new System.EventHandler(this.AddAsset_Click);
            // 
            // removeAssetToolStripMenuItem
            // 
            this.removeAssetToolStripMenuItem.Name = "removeAssetToolStripMenuItem";
            this.removeAssetToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.removeAssetToolStripMenuItem.Text = "Remove Asset";
            this.removeAssetToolStripMenuItem.Click += new System.EventHandler(this.RemoveAsset_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(198, 6);
            // 
            // cropShapesToolStripMenuItem
            // 
            this.cropShapesToolStripMenuItem.Name = "cropShapesToolStripMenuItem";
            this.cropShapesToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.cropShapesToolStripMenuItem.Text = "Crop and Align Anchors";
            this.cropShapesToolStripMenuItem.Click += new System.EventHandler(this.CropShapesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(198, 6);
            // 
            // renderAllAssetsToolStripMenuItem
            // 
            this.renderAllAssetsToolStripMenuItem.Name = "renderAllAssetsToolStripMenuItem";
            this.renderAllAssetsToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.renderAllAssetsToolStripMenuItem.Text = "Render all assets";
            this.renderAllAssetsToolStripMenuItem.Click += new System.EventHandler(this.RenderAllAssetsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.About});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // About
            // 
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(107, 22);
            this.About.Text = "About";
            // 
            // AnimatorTab
            // 
            this.AnimatorTab.Controls.Add(this.AnimationTab);
            this.AnimatorTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnimatorTab.Location = new System.Drawing.Point(200, 24);
            this.AnimatorTab.Name = "AnimatorTab";
            this.AnimatorTab.SelectedIndex = 0;
            this.AnimatorTab.Size = new System.Drawing.Size(818, 519);
            this.AnimatorTab.TabIndex = 3;
            // 
            // AnimationTab
            // 
            this.AnimationTab.Controls.Add(this.DrawerPanel);
            this.AnimationTab.Controls.Add(this.PreviewBar);
            this.AnimationTab.Controls.Add(this.PaletPanel);
            this.AnimationTab.Controls.Add(this.Tools);
            this.AnimationTab.Location = new System.Drawing.Point(4, 22);
            this.AnimationTab.Name = "AnimationTab";
            this.AnimationTab.Padding = new System.Windows.Forms.Padding(3);
            this.AnimationTab.Size = new System.Drawing.Size(810, 493);
            this.AnimationTab.TabIndex = 1;
            this.AnimationTab.Text = "Animation";
            this.AnimationTab.UseVisualStyleBackColor = true;
            // 
            // DrawerPanel
            // 
            this.DrawerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawerPanel.Location = new System.Drawing.Point(131, 31);
            this.DrawerPanel.Name = "DrawerPanel";
            this.DrawerPanel.Size = new System.Drawing.Size(676, 374);
            this.DrawerPanel.TabIndex = 1;
            // 
            // PreviewBar
            // 
            this.PreviewBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PreviewBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PreviewBar.Location = new System.Drawing.Point(131, 405);
            this.PreviewBar.Name = "PreviewBar";
            this.PreviewBar.Size = new System.Drawing.Size(676, 85);
            this.PreviewBar.TabIndex = 2;
            // 
            // PaletPanel
            // 
            this.PaletPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PaletPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PaletPanel.Location = new System.Drawing.Point(131, 3);
            this.PaletPanel.Name = "PaletPanel";
            this.PaletPanel.Size = new System.Drawing.Size(676, 28);
            this.PaletPanel.TabIndex = 0;
            // 
            // Tools
            // 
            this.Tools.BackColor = System.Drawing.Color.Silver;
            this.Tools.Controls.Add(this.AssetType);
            this.Tools.Controls.Add(this.AnimationStyle);
            this.Tools.Controls.Add(this.SetAnchorButton);
            this.Tools.Controls.Add(this.ButtonSize);
            this.Tools.Controls.Add(this.RemoveTopRowButton);
            this.Tools.Controls.Add(this.AddRowTopButton);
            this.Tools.Controls.Add(this.RemoveLeftColumnButton);
            this.Tools.Controls.Add(this.AddColumnLeftButton);
            this.Tools.Controls.Add(this.label4);
            this.Tools.Controls.Add(this.label3);
            this.Tools.Controls.Add(this.MoveDownButton);
            this.Tools.Controls.Add(this.MoveRightButton);
            this.Tools.Controls.Add(this.MoveLeftButton);
            this.Tools.Controls.Add(this.MoveUpButton);
            this.Tools.Controls.Add(this.RemoveBottomRowButton);
            this.Tools.Controls.Add(this.RemoveRightColumnButton);
            this.Tools.Controls.Add(this.AddRowBottomButton);
            this.Tools.Controls.Add(this.AddColumnRightButton);
            this.Tools.Controls.Add(this.RemoveFrameButton);
            this.Tools.Controls.Add(this.AddFrameButton);
            this.Tools.Controls.Add(this.label1);
            this.Tools.Controls.Add(this.SelectFrameCombobox);
            this.Tools.Dock = System.Windows.Forms.DockStyle.Left;
            this.Tools.Location = new System.Drawing.Point(3, 3);
            this.Tools.Name = "Tools";
            this.Tools.Size = new System.Drawing.Size(128, 487);
            this.Tools.TabIndex = 0;
            // 
            // AssetType
            // 
            this.AssetType.Location = new System.Drawing.Point(0, 0);
            this.AssetType.Name = "AssetType";
            this.AssetType.Size = new System.Drawing.Size(121, 21);
            this.AssetType.TabIndex = 0;
            // 
            // AnimationStyle
            // 
            this.AnimationStyle.Location = new System.Drawing.Point(0, 0);
            this.AnimationStyle.Name = "AnimationStyle";
            this.AnimationStyle.Size = new System.Drawing.Size(121, 21);
            this.AnimationStyle.TabIndex = 25;
            // 
            // SetAnchorButton
            // 
            this.SetAnchorButton.Location = new System.Drawing.Point(8, 280);
            this.SetAnchorButton.Name = "SetAnchorButton";
            this.SetAnchorButton.Size = new System.Drawing.Size(75, 23);
            this.SetAnchorButton.TabIndex = 21;
            this.SetAnchorButton.Text = "Anchor";
            this.SetAnchorButton.UseVisualStyleBackColor = true;
            this.SetAnchorButton.Click += new System.EventHandler(this.SetAnchorButton_Click);
            // 
            // ButtonSize
            // 
            this.ButtonSize.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonSize.Location = new System.Drawing.Point(83, 0);
            this.ButtonSize.Maximum = 100;
            this.ButtonSize.Name = "ButtonSize";
            this.ButtonSize.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ButtonSize.Size = new System.Drawing.Size(45, 487);
            this.ButtonSize.TabIndex = 20;
            this.ButtonSize.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.ButtonSize.Value = 20;
            this.ButtonSize.Scroll += new System.EventHandler(this.ButtonSize_Scroll);
            // 
            // RemoveTopRowButton
            // 
            this.RemoveTopRowButton.BackColor = System.Drawing.Color.Red;
            this.RemoveTopRowButton.Location = new System.Drawing.Point(29, 127);
            this.RemoveTopRowButton.Name = "RemoveTopRowButton";
            this.RemoveTopRowButton.Size = new System.Drawing.Size(31, 23);
            this.RemoveTopRowButton.TabIndex = 19;
            this.RemoveTopRowButton.Text = "/\\";
            this.RemoveTopRowButton.UseVisualStyleBackColor = false;
            this.RemoveTopRowButton.Click += new System.EventHandler(this.RemoveRowTopButton_Click);
            // 
            // AddRowTopButton
            // 
            this.AddRowTopButton.BackColor = System.Drawing.Color.LightGreen;
            this.AddRowTopButton.Location = new System.Drawing.Point(29, 53);
            this.AddRowTopButton.Name = "AddRowTopButton";
            this.AddRowTopButton.Size = new System.Drawing.Size(31, 23);
            this.AddRowTopButton.TabIndex = 18;
            this.AddRowTopButton.Text = "/\\";
            this.AddRowTopButton.UseVisualStyleBackColor = false;
            this.AddRowTopButton.Click += new System.EventHandler(this.AddRowTopButton_Click);
            // 
            // RemoveLeftColumnButton
            // 
            this.RemoveLeftColumnButton.BackColor = System.Drawing.Color.Red;
            this.RemoveLeftColumnButton.Location = new System.Drawing.Point(3, 150);
            this.RemoveLeftColumnButton.Name = "RemoveLeftColumnButton";
            this.RemoveLeftColumnButton.Size = new System.Drawing.Size(31, 23);
            this.RemoveLeftColumnButton.TabIndex = 17;
            this.RemoveLeftColumnButton.Text = "<";
            this.RemoveLeftColumnButton.UseVisualStyleBackColor = false;
            this.RemoveLeftColumnButton.Click += new System.EventHandler(this.RemoveColumnLeftButton_Click);
            // 
            // AddColumnLeftButton
            // 
            this.AddColumnLeftButton.BackColor = System.Drawing.Color.LightGreen;
            this.AddColumnLeftButton.Location = new System.Drawing.Point(5, 75);
            this.AddColumnLeftButton.Name = "AddColumnLeftButton";
            this.AddColumnLeftButton.Size = new System.Drawing.Size(31, 23);
            this.AddColumnLeftButton.TabIndex = 16;
            this.AddColumnLeftButton.Text = "<";
            this.AddColumnLeftButton.UseVisualStyleBackColor = false;
            this.AddColumnLeftButton.Click += new System.EventHandler(this.AddColumnLeftButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "+";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "-";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MoveDownButton
            // 
            this.MoveDownButton.Location = new System.Drawing.Point(34, 248);
            this.MoveDownButton.Name = "MoveDownButton";
            this.MoveDownButton.Size = new System.Drawing.Size(26, 26);
            this.MoveDownButton.TabIndex = 11;
            this.MoveDownButton.Text = "\\/";
            this.MoveDownButton.UseVisualStyleBackColor = true;
            this.MoveDownButton.Click += new System.EventHandler(this.MoveDownButton_Click);
            // 
            // MoveRightButton
            // 
            this.MoveRightButton.Location = new System.Drawing.Point(57, 224);
            this.MoveRightButton.Name = "MoveRightButton";
            this.MoveRightButton.Size = new System.Drawing.Size(26, 26);
            this.MoveRightButton.TabIndex = 10;
            this.MoveRightButton.Text = ">";
            this.MoveRightButton.UseVisualStyleBackColor = true;
            this.MoveRightButton.Click += new System.EventHandler(this.MoveRightButton_Click);
            // 
            // MoveLeftButton
            // 
            this.MoveLeftButton.Location = new System.Drawing.Point(11, 225);
            this.MoveLeftButton.Name = "MoveLeftButton";
            this.MoveLeftButton.Size = new System.Drawing.Size(26, 26);
            this.MoveLeftButton.TabIndex = 9;
            this.MoveLeftButton.Text = "<";
            this.MoveLeftButton.UseVisualStyleBackColor = true;
            this.MoveLeftButton.Click += new System.EventHandler(this.MoveLeftButton_Click);
            // 
            // MoveUpButton
            // 
            this.MoveUpButton.Location = new System.Drawing.Point(34, 201);
            this.MoveUpButton.Name = "MoveUpButton";
            this.MoveUpButton.Size = new System.Drawing.Size(26, 26);
            this.MoveUpButton.TabIndex = 8;
            this.MoveUpButton.Text = "/\\";
            this.MoveUpButton.UseVisualStyleBackColor = true;
            this.MoveUpButton.Click += new System.EventHandler(this.MoveUpButton_Click);
            // 
            // RemoveBottomRowButton
            // 
            this.RemoveBottomRowButton.BackColor = System.Drawing.Color.Red;
            this.RemoveBottomRowButton.Location = new System.Drawing.Point(32, 171);
            this.RemoveBottomRowButton.Name = "RemoveBottomRowButton";
            this.RemoveBottomRowButton.Size = new System.Drawing.Size(28, 24);
            this.RemoveBottomRowButton.TabIndex = 7;
            this.RemoveBottomRowButton.Text = "\\/";
            this.RemoveBottomRowButton.UseVisualStyleBackColor = false;
            this.RemoveBottomRowButton.Click += new System.EventHandler(this.RemoveRowBottomButton_Click);
            // 
            // RemoveRightColumnButton
            // 
            this.RemoveRightColumnButton.BackColor = System.Drawing.Color.Red;
            this.RemoveRightColumnButton.Location = new System.Drawing.Point(57, 150);
            this.RemoveRightColumnButton.Name = "RemoveRightColumnButton";
            this.RemoveRightColumnButton.Size = new System.Drawing.Size(31, 23);
            this.RemoveRightColumnButton.TabIndex = 6;
            this.RemoveRightColumnButton.Text = ">";
            this.RemoveRightColumnButton.UseVisualStyleBackColor = false;
            this.RemoveRightColumnButton.Click += new System.EventHandler(this.RemoveColumnRightButton_Click);
            // 
            // AddRowBottomButton
            // 
            this.AddRowBottomButton.BackColor = System.Drawing.Color.LightGreen;
            this.AddRowBottomButton.Location = new System.Drawing.Point(29, 98);
            this.AddRowBottomButton.Name = "AddRowBottomButton";
            this.AddRowBottomButton.Size = new System.Drawing.Size(31, 23);
            this.AddRowBottomButton.TabIndex = 5;
            this.AddRowBottomButton.Text = "\\/";
            this.AddRowBottomButton.UseVisualStyleBackColor = false;
            this.AddRowBottomButton.Click += new System.EventHandler(this.AddRowBottomButtonButton_Click);
            // 
            // AddColumnRightButton
            // 
            this.AddColumnRightButton.BackColor = System.Drawing.Color.LightGreen;
            this.AddColumnRightButton.Location = new System.Drawing.Point(57, 76);
            this.AddColumnRightButton.Name = "AddColumnRightButton";
            this.AddColumnRightButton.Size = new System.Drawing.Size(31, 23);
            this.AddColumnRightButton.TabIndex = 4;
            this.AddColumnRightButton.Text = ">";
            this.AddColumnRightButton.UseVisualStyleBackColor = false;
            this.AddColumnRightButton.Click += new System.EventHandler(this.AddColumnRightButton_Click);
            // 
            // RemoveFrameButton
            // 
            this.RemoveFrameButton.Location = new System.Drawing.Point(57, 25);
            this.RemoveFrameButton.Name = "RemoveFrameButton";
            this.RemoveFrameButton.Size = new System.Drawing.Size(26, 23);
            this.RemoveFrameButton.TabIndex = 3;
            this.RemoveFrameButton.Text = "-";
            this.RemoveFrameButton.UseVisualStyleBackColor = true;
            this.RemoveFrameButton.Click += new System.EventHandler(this.RemoveFrameButton_Click);
            // 
            // AddFrameButton
            // 
            this.AddFrameButton.Location = new System.Drawing.Point(34, 25);
            this.AddFrameButton.Name = "AddFrameButton";
            this.AddFrameButton.Size = new System.Drawing.Size(30, 23);
            this.AddFrameButton.TabIndex = 2;
            this.AddFrameButton.Text = "+";
            this.AddFrameButton.UseVisualStyleBackColor = true;
            this.AddFrameButton.Click += new System.EventHandler(this.AddFrameButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Frame";
            // 
            // SelectFrameCombobox
            // 
            this.SelectFrameCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectFrameCombobox.FormattingEnabled = true;
            this.SelectFrameCombobox.Location = new System.Drawing.Point(3, 26);
            this.SelectFrameCombobox.Name = "SelectFrameCombobox";
            this.SelectFrameCombobox.Size = new System.Drawing.Size(36, 21);
            this.SelectFrameCombobox.TabIndex = 0;
            this.SelectFrameCombobox.SelectedIndexChanged += new System.EventHandler(this.SelectFrameCombobox_SelectedIndexChanged);
            // 
            // AssetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 543);
            this.Controls.Add(this.AnimatorTab);
            this.Controls.Add(this.ListPanel);
            this.Controls.Add(this.MainMenu);
            this.Name = "AssetEditor";
            this.Text = "Asset Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ListPanel.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.AnimatorTab.ResumeLayout(false);
            this.AnimationTab.ResumeLayout(false);
            this.Tools.ResumeLayout(false);
            this.Tools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ListPanel;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddAsset;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem About;
        private System.Windows.Forms.TabControl AnimatorTab;
        private System.Windows.Forms.TabPage AnimationTab;
        private System.Windows.Forms.ListBox AssetListBox;
        private System.Windows.Forms.Panel DrawerPanel;
        private System.Windows.Forms.Panel PaletPanel;
        private System.Windows.Forms.Panel Tools;
        private System.Windows.Forms.ComboBox SelectFrameCombobox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RemoveFrameButton;
        private System.Windows.Forms.Button AddFrameButton;
        private System.Windows.Forms.Button AddRowBottomButton;
        private System.Windows.Forms.Button AddColumnRightButton;
        private System.Windows.Forms.Button RemoveBottomRowButton;
        private System.Windows.Forms.Button RemoveRightColumnButton;
        private System.Windows.Forms.Button MoveDownButton;
        private System.Windows.Forms.Button MoveRightButton;
        private System.Windows.Forms.Button MoveLeftButton;
        private System.Windows.Forms.Button MoveUpButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button RemoveTopRowButton;
        private System.Windows.Forms.Button AddRowTopButton;
        private System.Windows.Forms.Button RemoveLeftColumnButton;
        private System.Windows.Forms.Button AddColumnLeftButton;
        private System.Windows.Forms.ToolStripMenuItem removeAssetToolStripMenuItem;
        private System.Windows.Forms.TrackBar ButtonSize;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cropShapesToolStripMenuItem;
        private System.Windows.Forms.Button SetAnchorButton;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem renderAllAssetsToolStripMenuItem;
        private System.Windows.Forms.Panel PreviewBar;
        private System.Windows.Forms.ComboBox AnimationStyle;
        private System.Windows.Forms.ComboBox AssetType;
    }
}

