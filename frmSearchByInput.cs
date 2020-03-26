using System;
using System.Windows.Forms;

namespace MarbaxViewer
{
    public partial class frmSearchByInput : MaterialSkin.Controls.MaterialForm
    {
        private AppSettings _apps;
        public string ToFindPatter { get => mslTextFiedFileName.Text.Trim(' '); private set => mslTextFiedFileName.Text = value; }
        public frmSearchByInput(ref AppSettings appS, string header, string startPath)
        {
            InitializeComponent();
            _apps = appS;
            _apps.AddFormToManage(this);
            this.Text = header;
            this.mLabelStartPath.Text = startPath;
        }

        private void mFlatButtonOk_Click(object sender, EventArgs e)
        {
            if (!ToFindPatter.Contains(" "))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
                mslTextFiedFileName.BackColor = System.Drawing.Color.OrangeRed;
        }

        private void mFlatButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
