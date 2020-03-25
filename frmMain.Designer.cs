namespace MarbaxViewer
{
    partial class frmMain
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.mTabCon = new MaterialSkin.Controls.MaterialTabControl();
            this.tpMain = new System.Windows.Forms.TabPage();
            this.TPSecond = new System.Windows.Forms.TabPage();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.panelMain.SuspendLayout();
            this.mTabCon.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.mTabCon);
            this.panelMain.Controls.Add(this.materialTabSelector1);
            this.panelMain.Location = new System.Drawing.Point(0, 64);
            this.panelMain.Margin = new System.Windows.Forms.Padding(16, 3, 16, 16);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(800, 538);
            this.panelMain.TabIndex = 0;
            // 
            // mTabCon
            // 
            this.mTabCon.Controls.Add(this.tpMain);
            this.mTabCon.Controls.Add(this.TPSecond);
            this.mTabCon.Depth = 0;
            this.mTabCon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTabCon.Location = new System.Drawing.Point(0, 23);
            this.mTabCon.MouseState = MaterialSkin.MouseState.HOVER;
            this.mTabCon.Name = "mTabCon";
            this.mTabCon.SelectedIndex = 0;
            this.mTabCon.Size = new System.Drawing.Size(800, 515);
            this.mTabCon.TabIndex = 1;
            // 
            // tpMain
            // 
            this.tpMain.Location = new System.Drawing.Point(4, 22);
            this.tpMain.Name = "tpMain";
            this.tpMain.Padding = new System.Windows.Forms.Padding(3);
            this.tpMain.Size = new System.Drawing.Size(792, 489);
            this.tpMain.TabIndex = 0;
            this.tpMain.Text = "Main";
            this.tpMain.UseVisualStyleBackColor = true;
            // 
            // TPSecond
            // 
            this.TPSecond.Location = new System.Drawing.Point(4, 22);
            this.TPSecond.Name = "TPSecond";
            this.TPSecond.Padding = new System.Windows.Forms.Padding(3);
            this.TPSecond.Size = new System.Drawing.Size(792, 489);
            this.TPSecond.TabIndex = 1;
            this.TPSecond.Text = "Second";
            this.TPSecond.UseVisualStyleBackColor = true;
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.mTabCon;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialTabSelector1.Location = new System.Drawing.Point(0, 0);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(800, 23);
            this.materialTabSelector1.TabIndex = 0;
            this.materialTabSelector1.Text = "mTabSel";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panelMain);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Marbax Viewer";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.panelMain.ResumeLayout(false);
            this.mTabCon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private MaterialSkin.Controls.MaterialTabControl mTabCon;
        private System.Windows.Forms.TabPage tpMain;
        private System.Windows.Forms.TabPage TPSecond;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
    }
}

