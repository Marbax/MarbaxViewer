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
        public string ToFindText { get => mslTextFiedFileName.Text.Trim(' '); private set => mslTextFiedFileName.Text = value; }

        public string ToFindExtension { get => cbExtension.SelectedItem.ToString(); }

        public float ToFindMinSize { get => (float)Math.Round(nUpDownMin.Value, 3); }
        public float ToFindMaxSize { get => (float)Math.Round(nUpDownMax.Value, 3); }
        public frmSearchByInput(ref AppSettings appS, Mode searchMode, string startPath)
        {
            InitializeComponent();
            _apps = appS;
            _apps.AddFormToManage(this);
            _currentMode = searchMode;
            mslTextFiedFileName.Visible = cbExtension.Visible = mLabelTopSize.Visible = mLabelBotSize.Visible = nUpDownMax.Visible = nUpDownMin.Visible = false;
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
                        this.Text = "Search By File Extensions";
                        this.cbExtension.Visible = true;
                        cbExtension.Items.AddRange(_apps.AllowedImageFormats.ToArray());
                        cbExtension.SelectedIndex = 0;
                    }
                    break;
                case Mode.Size:
                    {
                        this.Text = "Search By File Size";
                        mLabelTopSize.Visible = mLabelBotSize.Visible = nUpDownMax.Visible = nUpDownMin.Visible = true;
                        nUpDownMin.Maximum = nUpDownMax.Maximum = decimal.MaxValue;
                    }
                    break;
                case Mode.Date:
                    {
                        this.Text = "Search By File Creation Date";
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
                        if (!string.IsNullOrEmpty(ToFindText) || ToFindText.Contains(" "))
                        {
                            _apps.SearchHistory.Add($"{this.Text} under {mLabelStartPath.Text} for {ToFindText} at {DateTime.Now}");
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                            mslTextFiedFileName.BackColor = System.Drawing.Color.OrangeRed;
                    }
                    break;
                case Mode.Extension:
                    {
                        if (cbExtension.SelectedIndex != -1)
                        {
                            _apps.SearchHistory.Add($"{this.Text} under {mLabelStartPath.Text} for filse with extension {ToFindExtension} at {DateTime.Now}");
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    break;
                case Mode.Size:
                    {
                        if (nUpDownMax.Value >= nUpDownMin.Value)
                        {
                            _apps.SearchHistory.Add($"{this.Text} under {mLabelStartPath.Text} for filse with size between {ToFindMinSize.ToString()} and {ToFindMaxSize.ToString()} at {DateTime.Now}");
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                            nUpDownMin.BackColor = nUpDownMax.BackColor = System.Drawing.Color.OrangeRed;
                    }
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
