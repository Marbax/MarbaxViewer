namespace MarbaxViewer
{
    partial class MainWindowUi
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purpleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueGreyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSlideBar = new System.Windows.Forms.Panel();
            this.treeViewExplorer = new System.Windows.Forms.TreeView();
            this.mfBtnSlide = new MaterialSkin.Controls.MaterialFlatButton();
            this.timerOpen = new System.Windows.Forms.Timer(this.components);
            this.timerClose = new System.Windows.Forms.Timer(this.components);
            this.picBUpdate = new System.Windows.Forms.PictureBox();
            this.panelSlideBtn = new System.Windows.Forms.Panel();
            this.panelSlideBarControls = new System.Windows.Forms.Panel();
            this.panelTree = new System.Windows.Forms.Panel();
            this.msMenu.SuspendLayout();
            this.panelSlideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBUpdate)).BeginInit();
            this.panelSlideBtn.SuspendLayout();
            this.panelSlideBarControls.SuspendLayout();
            this.panelTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMenu
            // 
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.msMenu.Size = new System.Drawing.Size(763, 24);
            this.msMenu.TabIndex = 0;
            this.msMenu.Text = "msMenu";
            this.msMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToolStripMenuItem,
            this.themeToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.testToolStripMenuItem.Text = "&Preferences";
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purpleToolStripMenuItem,
            this.blueGreyToolStripMenuItem});
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.colorToolStripMenuItem.Text = "Color";
            // 
            // purpleToolStripMenuItem
            // 
            this.purpleToolStripMenuItem.Name = "purpleToolStripMenuItem";
            this.purpleToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.purpleToolStripMenuItem.Text = "Purple";
            this.purpleToolStripMenuItem.Click += new System.EventHandler(this.purpleToolStripMenuItem_Click);
            // 
            // blueGreyToolStripMenuItem
            // 
            this.blueGreyToolStripMenuItem.Name = "blueGreyToolStripMenuItem";
            this.blueGreyToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.blueGreyToolStripMenuItem.Text = "Blue Grey";
            this.blueGreyToolStripMenuItem.Click += new System.EventHandler(this.blueGreyToolStripMenuItem_Click);
            // 
            // themeToolStripMenuItem
            // 
            this.themeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.darkToolStripMenuItem,
            this.lightToolStripMenuItem});
            this.themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            this.themeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.themeToolStripMenuItem.Text = "Theme";
            // 
            // darkToolStripMenuItem
            // 
            this.darkToolStripMenuItem.Name = "darkToolStripMenuItem";
            this.darkToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.darkToolStripMenuItem.Text = "Dark";
            this.darkToolStripMenuItem.Click += new System.EventHandler(this.darkToolStripMenuItem_Click);
            // 
            // lightToolStripMenuItem
            // 
            this.lightToolStripMenuItem.Name = "lightToolStripMenuItem";
            this.lightToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.lightToolStripMenuItem.Text = "Light";
            this.lightToolStripMenuItem.Click += new System.EventHandler(this.lightToolStripMenuItem_Click);
            // 
            // panelSlideBar
            // 
            this.panelSlideBar.Controls.Add(this.panelTree);
            this.panelSlideBar.Controls.Add(this.panelSlideBarControls);
            this.panelSlideBar.Controls.Add(this.panelSlideBtn);
            this.panelSlideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSlideBar.Location = new System.Drawing.Point(0, 24);
            this.panelSlideBar.Name = "panelSlideBar";
            this.panelSlideBar.Size = new System.Drawing.Size(200, 387);
            this.panelSlideBar.TabIndex = 1;
            // 
            // treeViewExplorer
            // 
            this.treeViewExplorer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewExplorer.Location = new System.Drawing.Point(0, 0);
            this.treeViewExplorer.Name = "treeViewExplorer";
            this.treeViewExplorer.Size = new System.Drawing.Size(179, 351);
            this.treeViewExplorer.TabIndex = 0;
            // 
            // mfBtnSlide
            // 
            this.mfBtnSlide.AutoSize = true;
            this.mfBtnSlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mfBtnSlide.Depth = 0;
            this.mfBtnSlide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mfBtnSlide.Location = new System.Drawing.Point(0, 0);
            this.mfBtnSlide.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mfBtnSlide.MouseState = MaterialSkin.MouseState.HOVER;
            this.mfBtnSlide.Name = "mfBtnSlide";
            this.mfBtnSlide.Primary = false;
            this.mfBtnSlide.Size = new System.Drawing.Size(21, 387);
            this.mfBtnSlide.TabIndex = 2;
            this.mfBtnSlide.Text = "<";
            this.mfBtnSlide.UseVisualStyleBackColor = true;
            this.mfBtnSlide.Click += new System.EventHandler(this.mfBtnSlide_Click);
            // 
            // timerOpen
            // 
            this.timerOpen.Interval = 30;
            this.timerOpen.Tick += new System.EventHandler(this.timerOpen_Tick);
            // 
            // timerClose
            // 
            this.timerClose.Interval = 30;
            this.timerClose.Tick += new System.EventHandler(this.timerClose_Tick);
            // 
            // picBUpdate
            // 
            this.picBUpdate.Dock = System.Windows.Forms.DockStyle.Left;
            this.picBUpdate.Image = global::MarbaxViewer.Properties.Resources.Update;
            this.picBUpdate.Location = new System.Drawing.Point(0, 0);
            this.picBUpdate.Name = "picBUpdate";
            this.picBUpdate.Size = new System.Drawing.Size(51, 36);
            this.picBUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBUpdate.TabIndex = 3;
            this.picBUpdate.TabStop = false;
            this.picBUpdate.Click += new System.EventHandler(this.picBUpdate_Click);
            // 
            // panelSlideBtn
            // 
            this.panelSlideBtn.Controls.Add(this.mfBtnSlide);
            this.panelSlideBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSlideBtn.Location = new System.Drawing.Point(179, 0);
            this.panelSlideBtn.Name = "panelSlideBtn";
            this.panelSlideBtn.Size = new System.Drawing.Size(21, 387);
            this.panelSlideBtn.TabIndex = 3;
            // 
            // panelSlideBarControls
            // 
            this.panelSlideBarControls.Controls.Add(this.picBUpdate);
            this.panelSlideBarControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSlideBarControls.Location = new System.Drawing.Point(0, 0);
            this.panelSlideBarControls.Name = "panelSlideBarControls";
            this.panelSlideBarControls.Size = new System.Drawing.Size(179, 36);
            this.panelSlideBarControls.TabIndex = 4;
            // 
            // panelTree
            // 
            this.panelTree.Controls.Add(this.treeViewExplorer);
            this.panelTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTree.Location = new System.Drawing.Point(0, 36);
            this.panelTree.Name = "panelTree";
            this.panelTree.Size = new System.Drawing.Size(179, 351);
            this.panelTree.TabIndex = 5;
            // 
            // MainWindowUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelSlideBar);
            this.Controls.Add(this.msMenu);
            this.Name = "MainWindowUi";
            this.Size = new System.Drawing.Size(763, 411);
            this.Load += new System.EventHandler(this.MainWindowUi_Load);
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.panelSlideBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBUpdate)).EndInit();
            this.panelSlideBtn.ResumeLayout(false);
            this.panelSlideBtn.PerformLayout();
            this.panelSlideBarControls.ResumeLayout(false);
            this.panelTree.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.Panel panelSlideBar;
        private MaterialSkin.Controls.MaterialFlatButton mfBtnSlide;
        private System.Windows.Forms.Timer timerOpen;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purpleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueGreyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightToolStripMenuItem;
        public System.Windows.Forms.Timer timerClose;
        private System.Windows.Forms.TreeView treeViewExplorer;
        private System.Windows.Forms.PictureBox picBUpdate;
        private System.Windows.Forms.Panel panelTree;
        private System.Windows.Forms.Panel panelSlideBarControls;
        private System.Windows.Forms.Panel panelSlideBtn;
    }
}
