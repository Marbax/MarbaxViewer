namespace MarbaxViewer
{
    partial class frmSearchByInput
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
            this.mLabelSearchUnder = new MaterialSkin.Controls.MaterialLabel();
            this.mFlatButtonOk = new MaterialSkin.Controls.MaterialFlatButton();
            this.mFlatButtonCancel = new MaterialSkin.Controls.MaterialFlatButton();
            this.mLabelStartPath = new MaterialSkin.Controls.MaterialLabel();
            this.mslTextFiedFileName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.mLabelSerchFor = new MaterialSkin.Controls.MaterialLabel();
            this.panelBtns = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelBtns.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mLabelSearchUnder
            // 
            this.mLabelSearchUnder.AutoSize = true;
            this.mLabelSearchUnder.Depth = 0;
            this.mLabelSearchUnder.Font = new System.Drawing.Font("Roboto", 11F);
            this.mLabelSearchUnder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLabelSearchUnder.Location = new System.Drawing.Point(12, 81);
            this.mLabelSearchUnder.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLabelSearchUnder.Name = "mLabelSearchUnder";
            this.mLabelSearchUnder.Size = new System.Drawing.Size(106, 19);
            this.mLabelSearchUnder.TabIndex = 2;
            this.mLabelSearchUnder.Text = "Search Under :";
            // 
            // mFlatButtonOk
            // 
            this.mFlatButtonOk.AutoSize = true;
            this.mFlatButtonOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mFlatButtonOk.Depth = 0;
            this.mFlatButtonOk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mFlatButtonOk.Location = new System.Drawing.Point(0, 0);
            this.mFlatButtonOk.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mFlatButtonOk.MouseState = MaterialSkin.MouseState.HOVER;
            this.mFlatButtonOk.Name = "mFlatButtonOk";
            this.mFlatButtonOk.Primary = false;
            this.mFlatButtonOk.Size = new System.Drawing.Size(182, 37);
            this.mFlatButtonOk.TabIndex = 4;
            this.mFlatButtonOk.Text = "OK";
            this.mFlatButtonOk.UseVisualStyleBackColor = true;
            this.mFlatButtonOk.Click += new System.EventHandler(this.mFlatButtonOk_Click);
            // 
            // mFlatButtonCancel
            // 
            this.mFlatButtonCancel.AutoSize = true;
            this.mFlatButtonCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mFlatButtonCancel.Depth = 0;
            this.mFlatButtonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mFlatButtonCancel.Location = new System.Drawing.Point(0, 0);
            this.mFlatButtonCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mFlatButtonCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.mFlatButtonCancel.Name = "mFlatButtonCancel";
            this.mFlatButtonCancel.Primary = false;
            this.mFlatButtonCancel.Size = new System.Drawing.Size(182, 37);
            this.mFlatButtonCancel.TabIndex = 5;
            this.mFlatButtonCancel.Text = "Cancel";
            this.mFlatButtonCancel.UseVisualStyleBackColor = true;
            this.mFlatButtonCancel.Click += new System.EventHandler(this.mFlatButtonCancel_Click);
            // 
            // mLabelStartPath
            // 
            this.mLabelStartPath.AutoSize = true;
            this.mLabelStartPath.Depth = 0;
            this.mLabelStartPath.Font = new System.Drawing.Font("Roboto", 11F);
            this.mLabelStartPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLabelStartPath.Location = new System.Drawing.Point(124, 81);
            this.mLabelStartPath.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLabelStartPath.Name = "mLabelStartPath";
            this.mLabelStartPath.Size = new System.Drawing.Size(38, 19);
            this.mLabelStartPath.TabIndex = 6;
            this.mLabelStartPath.Text = "path";
            // 
            // mslTextFiedFileName
            // 
            this.mslTextFiedFileName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.mslTextFiedFileName.Depth = 0;
            this.mslTextFiedFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mslTextFiedFileName.Hint = "";
            this.mslTextFiedFileName.Location = new System.Drawing.Point(46, 172);
            this.mslTextFiedFileName.MouseState = MaterialSkin.MouseState.HOVER;
            this.mslTextFiedFileName.Name = "mslTextFiedFileName";
            this.mslTextFiedFileName.PasswordChar = '\0';
            this.mslTextFiedFileName.SelectedText = "";
            this.mslTextFiedFileName.SelectionLength = 0;
            this.mslTextFiedFileName.SelectionStart = 0;
            this.mslTextFiedFileName.Size = new System.Drawing.Size(300, 23);
            this.mslTextFiedFileName.TabIndex = 7;
            this.mslTextFiedFileName.Text = "Enter_Here";
            this.mslTextFiedFileName.UseSystemPasswordChar = false;
            // 
            // mLabelSerchFor
            // 
            this.mLabelSerchFor.AutoSize = true;
            this.mLabelSerchFor.Depth = 0;
            this.mLabelSerchFor.Font = new System.Drawing.Font("Roboto", 11F);
            this.mLabelSerchFor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLabelSerchFor.Location = new System.Drawing.Point(16, 119);
            this.mLabelSerchFor.MouseState = MaterialSkin.MouseState.HOVER;
            this.mLabelSerchFor.Name = "mLabelSerchFor";
            this.mLabelSerchFor.Size = new System.Drawing.Size(89, 19);
            this.mLabelSerchFor.TabIndex = 8;
            this.mLabelSerchFor.Text = "Search For :";
            // 
            // panelBtns
            // 
            this.panelBtns.Controls.Add(this.mFlatButtonOk);
            this.panelBtns.Location = new System.Drawing.Point(6, 227);
            this.panelBtns.Name = "panelBtns";
            this.panelBtns.Size = new System.Drawing.Size(182, 37);
            this.panelBtns.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mFlatButtonCancel);
            this.panel1.Location = new System.Drawing.Point(202, 227);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(182, 37);
            this.panel1.TabIndex = 9;
            // 
            // frmSearchByInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 268);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelBtns);
            this.Controls.Add(this.mLabelSerchFor);
            this.Controls.Add(this.mslTextFiedFileName);
            this.Controls.Add(this.mLabelStartPath);
            this.Controls.Add(this.mLabelSearchUnder);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchByInput";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Serch By Input";
            this.panelBtns.ResumeLayout(false);
            this.panelBtns.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel mLabelSearchUnder;
        private MaterialSkin.Controls.MaterialFlatButton mFlatButtonOk;
        private MaterialSkin.Controls.MaterialFlatButton mFlatButtonCancel;
        private MaterialSkin.Controls.MaterialLabel mLabelStartPath;
        private MaterialSkin.Controls.MaterialSingleLineTextField mslTextFiedFileName;
        private MaterialSkin.Controls.MaterialLabel mLabelSerchFor;
        private System.Windows.Forms.Panel panelBtns;
        private System.Windows.Forms.Panel panel1;
    }
}