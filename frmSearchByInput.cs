using System;
using System.Windows.Forms;

namespace MarbaxViewer
{
    public partial class frmSearchByInput : MaterialSkin.Controls.MaterialForm
    {
        private Mode _currentMode;
        public enum Mode
        {
            Name = 1,
            Extension,
            Size,
            Date,
            Tag
        }
        private AppSettings _apps;
        public string ToFindPatter { get => mslTextFiedFileName.Text.Trim(' '); private set => mslTextFiedFileName.Text = value; }
        public frmSearchByInput(ref AppSettings appS, Mode searchMode, string startPath)
        {
            InitializeComponent();
            _apps = appS;
            _apps.AddFormToManage(this);
            _currentMode = searchMode;
            InitMode();
            this.mLabelStartPath.Text = startPath;
        }

        private void InitMode()
        {
            switch (_currentMode)
            {
                case Mode.Name:
                    {
                        this.Text = "Search By File Name";
                        this.mslTextFiedFileName.Visible = true;
                    }
                    break;
                case Mode.Extension:
                    {

                    }
                    break;
                case Mode.Size:
                    {

                    }
                    break;
                case Mode.Date:
                    {

                    }
                    break;
                case Mode.Tag:
                    {
                        this.Text = "Search By Tag";
                        this.mslTextFiedFileName.Visible = true;
                    }
                    break;
            }
        }
        private void mFlatButtonOk_Click(object sender, EventArgs e)
        {
            switch (_currentMode)
            {
                case Mode.Name:
                    {
                        if (!string.IsNullOrEmpty(ToFindPatter) || ToFindPatter.Contains(" "))
                            this.DialogResult = DialogResult.OK;
                        else
                            mslTextFiedFileName.BackColor = System.Drawing.Color.OrangeRed;
                    }
                    break;
                case Mode.Extension:
                    break;
                case Mode.Size:
                    break;
                case Mode.Date:
                    break;
                case Mode.Tag:
                    break;
            }

        }

        private void mFlatButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
