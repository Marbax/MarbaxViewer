using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace MarbaxViewer
{
    public partial class frmMain : MaterialForm
    {
        DataManager _dm;
        private AppSettings _appS;
        MainWindowUi _mwUI;
        public frmMain()
        {
            InitializeComponent();
            _dm = new DataManager(); ;
            _dm.LoadData();
            _dm.AppSettings.AddFormToManage(this);
            _appS = _dm.AppSettings;
            _mwUI = new MainWindowUi(ref _dm.AppSettings);
            SetVisuals();
        }

        private void SetVisuals()
        {
            rTextBoxHistory.BackColor = _appS.GetBackgroundColor();
            rTextBoxHistory.ForeColor = _appS.GetFontColor();
            //mDividerTop.BackColor = _appS.GetMainColor();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            _mwUI.Dock = DockStyle.Fill;
            tpMain.Controls.Add(_mwUI);
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            UpdatePanelSize();
            _mwUI.CloseSliders();
        }

        private void UpdatePanelSize()
        {
            ushort margin = 2;
            ushort topMargin = 60;
            panelMain.Left = margin;
            panelMain.Width = this.Width - margin;
            panelMain.Top = topMargin;
            panelMain.Height = this.Height - topMargin - margin;
        }

        private void mRaisedButtonUpdateHistory_Click(object sender, EventArgs e)
        {
            SetVisuals();
            try
            {
                rTextBoxHistory.Clear();
                _appS.SearchHistory.ForEach(h => rTextBoxHistory.Text += $"[{h}]\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Updating history exception : {ex.Message}");
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _dm.SaveData();
        }
    }
}
