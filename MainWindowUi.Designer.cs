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
            this.panelTree = new System.Windows.Forms.Panel();
            this.tvDirBrowser = new System.Windows.Forms.TreeView();
            this.panelSlideBarControls = new System.Windows.Forms.Panel();
            this.picBUpdate = new System.Windows.Forms.PictureBox();
            this.panelSlideBtn = new System.Windows.Forms.Panel();
            this.mfBtnSlide = new MaterialSkin.Controls.MaterialFlatButton();
            this.timerLeftOpen = new System.Windows.Forms.Timer(this.components);
            this.timerLeftClose = new System.Windows.Forms.Timer(this.components);
            this.panelFileBrowser = new System.Windows.Forms.Panel();
            this.panelFileList = new System.Windows.Forms.Panel();
            this.lvFileBrowser = new System.Windows.Forms.ListView();
            this.panelFileBControls = new System.Windows.Forms.Panel();
            this.panelFileBOps = new System.Windows.Forms.Panel();
            this.panelFileBSlider = new System.Windows.Forms.Panel();
            this.mfButtonFileSlider = new MaterialSkin.Controls.MaterialFlatButton();
            this.timerBotOpen = new System.Windows.Forms.Timer(this.components);
            this.timerBotClose = new System.Windows.Forms.Timer(this.components);
            this.msMenu.SuspendLayout();
            this.panelSlideBar.SuspendLayout();
            this.panelTree.SuspendLayout();
            this.panelSlideBarControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBUpdate)).BeginInit();
            this.panelSlideBtn.SuspendLayout();
            this.panelFileBrowser.SuspendLayout();
            this.panelFileList.SuspendLayout();
            this.panelFileBOps.SuspendLayout();
            this.panelFileBSlider.SuspendLayout();
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
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
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
            this.themeToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
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
            // panelTree
            // 
            this.panelTree.Controls.Add(this.tvDirBrowser);
            this.panelTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTree.Location = new System.Drawing.Point(0, 36);
            this.panelTree.Name = "panelTree";
            this.panelTree.Size = new System.Drawing.Size(179, 351);
            this.panelTree.TabIndex = 5;
            // 
            // tvDirBrowser
            // 
            this.tvDirBrowser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvDirBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDirBrowser.Location = new System.Drawing.Point(0, 0);
            this.tvDirBrowser.Name = "tvDirBrowser";
            this.tvDirBrowser.Size = new System.Drawing.Size(179, 351);
            this.tvDirBrowser.TabIndex = 0;
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
            // timerLeftOpen
            // 
            this.timerLeftOpen.Interval = 30;
            this.timerLeftOpen.Tick += new System.EventHandler(this.timerLeftOpen_Tick);
            // 
            // timerLeftClose
            // 
            this.timerLeftClose.Interval = 30;
            this.timerLeftClose.Tick += new System.EventHandler(this.timerLeftClose_Tick);
            // 
            // panelFileBrowser
            // 
            this.panelFileBrowser.Controls.Add(this.panelFileList);
            this.panelFileBrowser.Controls.Add(this.panelFileBControls);
            this.panelFileBrowser.Controls.Add(this.panelFileBOps);
            this.panelFileBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFileBrowser.Location = new System.Drawing.Point(200, 24);
            this.panelFileBrowser.Name = "panelFileBrowser";
            this.panelFileBrowser.Size = new System.Drawing.Size(563, 387);
            this.panelFileBrowser.TabIndex = 2;
            // 
            // panelFileList
            // 
            this.panelFileList.Controls.Add(this.lvFileBrowser);
            this.panelFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFileList.Location = new System.Drawing.Point(0, 36);
            this.panelFileList.Name = "panelFileList";
            this.panelFileList.Size = new System.Drawing.Size(563, 264);
            this.panelFileList.TabIndex = 2;
            // 
            // lvFileBrowser
            // 
            this.lvFileBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFileBrowser.HideSelection = false;
            this.lvFileBrowser.Location = new System.Drawing.Point(0, 0);
            this.lvFileBrowser.Name = "lvFileBrowser";
            this.lvFileBrowser.Size = new System.Drawing.Size(563, 264);
            this.lvFileBrowser.TabIndex = 0;
            this.lvFileBrowser.UseCompatibleStateImageBehavior = false;
            // 
            // panelFileBControls
            // 
            this.panelFileBControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFileBControls.Location = new System.Drawing.Point(0, 0);
            this.panelFileBControls.Name = "panelFileBControls";
            this.panelFileBControls.Size = new System.Drawing.Size(563, 36);
            this.panelFileBControls.TabIndex = 1;
            // 
            // panelFileBOps
            // 
            this.panelFileBOps.Controls.Add(this.panelFileBSlider);
            this.panelFileBOps.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFileBOps.Location = new System.Drawing.Point(0, 300);
            this.panelFileBOps.Name = "panelFileBOps";
            this.panelFileBOps.Size = new System.Drawing.Size(563, 87);
            this.panelFileBOps.TabIndex = 0;
            // 
            // panelFileBSlider
            // 
            this.panelFileBSlider.Controls.Add(this.mfButtonFileSlider);
            this.panelFileBSlider.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFileBSlider.Location = new System.Drawing.Point(0, 0);
            this.panelFileBSlider.Name = "panelFileBSlider";
            this.panelFileBSlider.Size = new System.Drawing.Size(563, 22);
            this.panelFileBSlider.TabIndex = 0;
            // 
            // mfButtonFileSlider
            // 
            this.mfButtonFileSlider.AutoSize = true;
            this.mfButtonFileSlider.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mfButtonFileSlider.Depth = 0;
            this.mfButtonFileSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mfButtonFileSlider.Location = new System.Drawing.Point(0, 0);
            this.mfButtonFileSlider.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mfButtonFileSlider.MouseState = MaterialSkin.MouseState.HOVER;
            this.mfButtonFileSlider.Name = "mfButtonFileSlider";
            this.mfButtonFileSlider.Primary = false;
            this.mfButtonFileSlider.Size = new System.Drawing.Size(563, 22);
            this.mfButtonFileSlider.TabIndex = 0;
            this.mfButtonFileSlider.Text = "^";
            this.mfButtonFileSlider.UseVisualStyleBackColor = true;
            this.mfButtonFileSlider.Click += new System.EventHandler(this.mfButtonFileSlider_Click);
            // 
            // timerBotOpen
            // 
            this.timerBotOpen.Interval = 30;
            this.timerBotOpen.Tick += new System.EventHandler(this.timerBotOpen_Tick);
            // 
            // timerBotClose
            // 
            this.timerBotClose.Interval = 30;
            this.timerBotClose.Tick += new System.EventHandler(this.timerBotClose_Tick);
            // 
            // MainWindowUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelFileBrowser);
            this.Controls.Add(this.panelSlideBar);
            this.Controls.Add(this.msMenu);
            this.Name = "MainWindowUi";
            this.Size = new System.Drawing.Size(763, 411);
            this.Load += new System.EventHandler(this.MainWindowUi_Load);
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.panelSlideBar.ResumeLayout(false);
            this.panelTree.ResumeLayout(false);
            this.panelSlideBarControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBUpdate)).EndInit();
            this.panelSlideBtn.ResumeLayout(false);
            this.panelSlideBtn.PerformLayout();
            this.panelFileBrowser.ResumeLayout(false);
            this.panelFileList.ResumeLayout(false);
            this.panelFileBOps.ResumeLayout(false);
            this.panelFileBSlider.ResumeLayout(false);
            this.panelFileBSlider.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.Panel panelSlideBar;
        private MaterialSkin.Controls.MaterialFlatButton mfBtnSlide;
        private System.Windows.Forms.Timer timerLeftOpen;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purpleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueGreyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightToolStripMenuItem;
        private System.Windows.Forms.TreeView tvDirBrowser;
        private System.Windows.Forms.PictureBox picBUpdate;
        private System.Windows.Forms.Panel panelTree;
        private System.Windows.Forms.Panel panelSlideBarControls;
        private System.Windows.Forms.Panel panelSlideBtn;
        private System.Windows.Forms.Panel panelFileBrowser;
        private System.Windows.Forms.Panel panelFileList;
        private System.Windows.Forms.Panel panelFileBControls;
        private System.Windows.Forms.Panel panelFileBOps;
        private System.Windows.Forms.Panel panelFileBSlider;
        private MaterialSkin.Controls.MaterialFlatButton mfButtonFileSlider;
        private System.Windows.Forms.ListView lvFileBrowser;
        private System.Windows.Forms.Timer timerBotOpen;
        private System.Windows.Forms.Timer timerLeftClose;
        private System.Windows.Forms.Timer timerBotClose;
    }
}
