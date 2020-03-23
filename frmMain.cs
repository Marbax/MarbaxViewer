using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace MarbaxViewer
{
    public partial class frmMain : MaterialForm
    {
        AppSettings _appS;

        MainWindowUi _mwUI;
        public frmMain()
        {
            InitializeComponent();
            _appS = new AppSettings(MaterialSkinManager.Themes.DARK, this, AppSettings.ColorSchemes.BlueGrey);
            _mwUI = new MainWindowUi(ref _appS);
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
    }
}
