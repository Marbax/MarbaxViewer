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
            Tag,
            AddTag,
            EditTag
        }
        private AppSettings _apps;
        private string _existTags;

        public string ToFindText { get => mslTextFiedFileName.Text.Trim(' '); private set => mslTextFiedFileName.Text = value; }

        public string ToFindExtension { get => cbExtension.SelectedItem.ToString(); }

        public float ToFindMinSize { get => (float)Math.Round(nUpDownMin.Value, 3); }
        public float ToFindMaxSize { get => (float)Math.Round(nUpDownMax.Value, 3); }

        public DateTime ToFindMinDate { get => dateTimePBot.Value; }
        public DateTime ToFindMaxDate { get => dateTimePTop.Value; }
        public frmSearchByInput(ref AppSettings appS, Mode searchMode, string startPath, string existTags = default)
        {
            InitializeComponent();
            _apps = appS;
            _apps.AddFormToManage(this);
            _currentMode = searchMode;
            mslTextFiedFileName.Visible = cbExtension.Visible = mLabelTopSize.Visible = mLabelBotSize.Visible = nUpDownMax.Visible = nUpDownMin.Visible =
               mLabelMinDate.Visible = mLabelMaxDate.Visible = dateTimePBot.Visible = dateTimePTop.Visible = false;
            _existTags = existTags;
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
                        mLabelMinDate.Visible = mLabelMaxDate.Visible = dateTimePBot.Visible = dateTimePTop.Visible = true;
                    }
                    break;
                case Mode.Tag:
                    {
                        this.Text = "Search By Tag";
                        this.mslTextFiedFileName.Visible = true;
                    }
                    break;
                case Mode.AddTag:
                    {
                        mLabelSearchUnder.Visible = mLabelStartPath.Visible = false;
                        mLabelSerchFor.Text = this.Text = "Add Tags";
                        mslTextFiedFileName.Visible = true;
                    }
                    break;
                case Mode.EditTag:
                    {
                        mLabelSearchUnder.Visible = mLabelStartPath.Visible = false;
                        mLabelSerchFor.Text = this.Text = "Edit Tags";
                        mslTextFiedFileName.Visible = true;
                        mslTextFiedFileName.Text = _existTags;
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
                            _apps.SearchHistory.Add($"{this.Text} under {mLabelStartPath.Text} for files with extension {ToFindExtension} at {DateTime.Now}");
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    break;
                case Mode.Size:
                    {
                        if (nUpDownMax.Value >= nUpDownMin.Value)
                        {
                            _apps.SearchHistory.Add($"{this.Text} under {mLabelStartPath.Text} for files with size between {ToFindMinSize.ToString()} and {ToFindMaxSize.ToString()} at {DateTime.Now}");
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                            nUpDownMin.BackColor = nUpDownMax.BackColor = System.Drawing.Color.OrangeRed;
                    }
                    break;
                case Mode.Date:
                    {
                        if (ToFindMaxDate >= ToFindMinDate)
                        {
                            _apps.SearchHistory.Add($"{this.Text} under {mLabelStartPath.Text} for files with creation date between {ToFindMinDate.ToString()} and {ToFindMaxDate.ToString()} at {DateTime.Now}");
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                            dateTimePTop.BackColor = dateTimePBot.BackColor = System.Drawing.Color.OrangeRed;

                    }
                    break;
                case Mode.Tag:
                    {
                        if (!string.IsNullOrEmpty(ToFindText))
                        {
                            _apps.SearchHistory.Add($"{this.Text} under {mLabelStartPath.Text} for {ToFindText} at {DateTime.Now}");
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                            mslTextFiedFileName.BackColor = System.Drawing.Color.OrangeRed;
                    }
                    break;
                case Mode.AddTag:
                    {
                        if (!string.IsNullOrEmpty(ToFindText))
                        {
                            _apps.SearchHistory.Add($"{this.Text} \"{ToFindText}\" for {mLabelStartPath.Text} at {DateTime.Now}");
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                            mslTextFiedFileName.BackColor = System.Drawing.Color.OrangeRed;
                    }
                    break;
                case Mode.EditTag:
                    {
                        if (!string.IsNullOrEmpty(ToFindText))
                        {
                            _apps.SearchHistory.Add($"{this.Text} cnahged from {_existTags} to \"{ToFindText}\" for {mLabelStartPath.Text} at {DateTime.Now}");
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                            mslTextFiedFileName.BackColor = System.Drawing.Color.OrangeRed;
                    }
                    break;
            }

        }

        private void mFlatButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
