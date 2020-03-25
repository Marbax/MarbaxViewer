namespace MarbaxViewer
{
    partial class frmFullScreen
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
            this.components = new System.ComponentModel.Container();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelPic = new System.Windows.Forms.Panel();
            this.mfBtnSwipeLeft = new MaterialSkin.Controls.MaterialFlatButton();
            this.mfBtnSwipeRight = new MaterialSkin.Controls.MaterialFlatButton();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panelBottomMenu = new System.Windows.Forms.Panel();
            this.listViewImgPreview = new System.Windows.Forms.ListView();
            this.panelBSlider = new System.Windows.Forms.Panel();
            this.mfBtnSlider = new MaterialSkin.Controls.MaterialFlatButton();
            this.timerBOpen = new System.Windows.Forms.Timer(this.components);
            this.timerBClose = new System.Windows.Forms.Timer(this.components);
            this.mfLabelPicName = new MaterialSkin.Controls.MaterialLabel();
            this.panelMain.SuspendLayout();
            this.panelPic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panelBottomMenu.SuspendLayout();
            this.panelBSlider.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelPic);
            this.panelMain.Controls.Add(this.panelBottomMenu);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMain.Location = new System.Drawing.Point(0, 63);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(800, 387);
            this.panelMain.TabIndex = 0;
            // 
            // panelPic
            // 
            this.panelPic.Controls.Add(this.mfBtnSwipeLeft);
            this.panelPic.Controls.Add(this.mfBtnSwipeRight);
            this.panelPic.Controls.Add(this.pictureBox);
            this.panelPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPic.Location = new System.Drawing.Point(0, 0);
            this.panelPic.Name = "panelPic";
            this.panelPic.Size = new System.Drawing.Size(800, 295);
            this.panelPic.TabIndex = 1;
            // 
            // mfBtnSwipeLeft
            // 
            this.mfBtnSwipeLeft.AutoSize = true;
            this.mfBtnSwipeLeft.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mfBtnSwipeLeft.Depth = 0;
            this.mfBtnSwipeLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.mfBtnSwipeLeft.Location = new System.Drawing.Point(0, 0);
            this.mfBtnSwipeLeft.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mfBtnSwipeLeft.MouseState = MaterialSkin.MouseState.HOVER;
            this.mfBtnSwipeLeft.Name = "mfBtnSwipeLeft";
            this.mfBtnSwipeLeft.Primary = false;
            this.mfBtnSwipeLeft.Size = new System.Drawing.Size(19, 295);
            this.mfBtnSwipeLeft.TabIndex = 2;
            this.mfBtnSwipeLeft.Text = "<";
            this.mfBtnSwipeLeft.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mfBtnSwipeLeft.UseVisualStyleBackColor = true;
            this.mfBtnSwipeLeft.Click += new System.EventHandler(this.mfBtnSwipeLeft_Click);
            // 
            // mfBtnSwipeRight
            // 
            this.mfBtnSwipeRight.AutoSize = true;
            this.mfBtnSwipeRight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mfBtnSwipeRight.Depth = 0;
            this.mfBtnSwipeRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.mfBtnSwipeRight.Location = new System.Drawing.Point(781, 0);
            this.mfBtnSwipeRight.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mfBtnSwipeRight.MouseState = MaterialSkin.MouseState.HOVER;
            this.mfBtnSwipeRight.Name = "mfBtnSwipeRight";
            this.mfBtnSwipeRight.Primary = false;
            this.mfBtnSwipeRight.Size = new System.Drawing.Size(19, 295);
            this.mfBtnSwipeRight.TabIndex = 1;
            this.mfBtnSwipeRight.Text = ">";
            this.mfBtnSwipeRight.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mfBtnSwipeRight.UseVisualStyleBackColor = true;
            this.mfBtnSwipeRight.Click += new System.EventHandler(this.mfBtnSwipeRight_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.ErrorImage = global::MarbaxViewer.Properties.Resources.img_not_found;
            this.pictureBox.Image = global::MarbaxViewer.Properties.Resources.img_not_found;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(800, 295);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // panelBottomMenu
            // 
            this.panelBottomMenu.Controls.Add(this.listViewImgPreview);
            this.panelBottomMenu.Controls.Add(this.panelBSlider);
            this.panelBottomMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomMenu.Location = new System.Drawing.Point(0, 295);
            this.panelBottomMenu.Name = "panelBottomMenu";
            this.panelBottomMenu.Size = new System.Drawing.Size(800, 92);
            this.panelBottomMenu.TabIndex = 0;
            // 
            // listViewImgPreview
            // 
            this.listViewImgPreview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewImgPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewImgPreview.HideSelection = false;
            this.listViewImgPreview.Location = new System.Drawing.Point(0, 20);
            this.listViewImgPreview.MultiSelect = false;
            this.listViewImgPreview.Name = "listViewImgPreview";
            this.listViewImgPreview.Size = new System.Drawing.Size(800, 72);
            this.listViewImgPreview.TabIndex = 1;
            this.listViewImgPreview.UseCompatibleStateImageBehavior = false;
            this.listViewImgPreview.SelectedIndexChanged += new System.EventHandler(this.listViewImgPreview_SelectedIndexChanged);
            this.listViewImgPreview.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listViewImgPreview_KeyUp);
            // 
            // panelBSlider
            // 
            this.panelBSlider.Controls.Add(this.mfBtnSlider);
            this.panelBSlider.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBSlider.Location = new System.Drawing.Point(0, 0);
            this.panelBSlider.Name = "panelBSlider";
            this.panelBSlider.Size = new System.Drawing.Size(800, 20);
            this.panelBSlider.TabIndex = 0;
            // 
            // mfBtnSlider
            // 
            this.mfBtnSlider.AutoSize = true;
            this.mfBtnSlider.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mfBtnSlider.Depth = 0;
            this.mfBtnSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mfBtnSlider.Location = new System.Drawing.Point(0, 0);
            this.mfBtnSlider.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mfBtnSlider.MouseState = MaterialSkin.MouseState.HOVER;
            this.mfBtnSlider.Name = "mfBtnSlider";
            this.mfBtnSlider.Primary = false;
            this.mfBtnSlider.Size = new System.Drawing.Size(800, 20);
            this.mfBtnSlider.TabIndex = 0;
            this.mfBtnSlider.Text = "^";
            this.mfBtnSlider.UseVisualStyleBackColor = true;
            this.mfBtnSlider.Click += new System.EventHandler(this.mfBtnSlider_Click);
            // 
            // timerBOpen
            // 
            this.timerBOpen.Interval = 30;
            this.timerBOpen.Tick += new System.EventHandler(this.timerBOpen_Tick);
            // 
            // timerBClose
            // 
            this.timerBClose.Interval = 30;
            this.timerBClose.Tick += new System.EventHandler(this.timerBClose_Tick);
            // 
            // mfLabelPicName
            // 
            this.mfLabelPicName.AutoSize = true;
            this.mfLabelPicName.Depth = 0;
            this.mfLabelPicName.Font = new System.Drawing.Font("Roboto", 11F);
            this.mfLabelPicName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mfLabelPicName.Location = new System.Drawing.Point(12, 0);
            this.mfLabelPicName.MouseState = MaterialSkin.MouseState.HOVER;
            this.mfLabelPicName.Name = "mfLabelPicName";
            this.mfLabelPicName.Size = new System.Drawing.Size(74, 19);
            this.mfLabelPicName.TabIndex = 1;
            this.mfLabelPicName.Text = "No Image";
            // 
            // frmFullScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mfLabelPicName);
            this.Controls.Add(this.panelMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFullScreen";
            this.Sizable = false;
            this.Text = "Marbax Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmFullScreen_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmFullScreen_KeyUp);
            this.panelMain.ResumeLayout(false);
            this.panelPic.ResumeLayout(false);
            this.panelPic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panelBottomMenu.ResumeLayout(false);
            this.panelBSlider.ResumeLayout(false);
            this.panelBSlider.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelPic;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel panelBottomMenu;
        private MaterialSkin.Controls.MaterialFlatButton mfBtnSwipeLeft;
        private MaterialSkin.Controls.MaterialFlatButton mfBtnSwipeRight;
        private System.Windows.Forms.ListView listViewImgPreview;
        private System.Windows.Forms.Panel panelBSlider;
        private MaterialSkin.Controls.MaterialFlatButton mfBtnSlider;
        private System.Windows.Forms.Timer timerBOpen;
        private System.Windows.Forms.Timer timerBClose;
        private MaterialSkin.Controls.MaterialLabel mfLabelPicName;
    }
}