using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;

namespace MarbaxViewer
{
    public partial class MainWindowUi : UserControl
    {
        private AppSettings _appS;

        public ushort SliderWidth { get; set; } = 20;

        public ushort MoveSpeed { get; set; } = 10;

        public ushort ScreenCoef { get; set; } = 4;

        private bool LSlideOpened = false;
        public MainWindowUi(ref AppSettings appS)
        {
            InitializeComponent();
            _appS = appS;
            SetUpItemsVisuals();
        }

        private void SetUpItemsVisuals()
        {
            msMenu.BackColor = _appS.GetBackgroundColor();
            msMenu.ForeColor = treeViewExplorer.ForeColor = _appS.GetFontdColor();
            treeViewExplorer.BackColor = _appS.GetBackgroundColor();
            picBUpdate.Image = _appS.GetUpdateImage();

        }

        private void timerClose_Tick(object sender, EventArgs e)
        {
            if (panelSlideBar.Width <= SliderWidth)
                timerClose.Stop();
            else
                panelSlideBar.Width -= MoveSpeed;
        }

        private void timerOpen_Tick(object sender, EventArgs e)
        {
            if (panelSlideBar.Width >= this.Width / ScreenCoef)
                timerOpen.Stop();
            else
                panelSlideBar.Width += MoveSpeed;
        }

        private void mfBtnSlide_Click(object sender, EventArgs e)
        {
            if (panelSlideBar.Width <= this.Width / (ScreenCoef * 2))
            {
                timerOpen.Start();
                mfBtnSlide.Text = "<";
            }
            else if (panelSlideBar.Width >= this.Width / (ScreenCoef * 2))
            {
                timerClose.Start();
                mfBtnSlide.Text = ">";
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //
        }

        private void MainWindowUi_Load(object sender, EventArgs e)
        {
            if (!LSlideOpened)
            {
                panelSlideBar.Width = SliderWidth;
                mfBtnSlide.Text = ">";
            }
            else
            {
                panelSlideBar.Width = this.Width / ScreenCoef;
                mfBtnSlide.Text = "<";
            }
        }


        public void OpenLeftSlide()
        {
        }
        public void CloseLeftSlide()
        {
        }

        private void purpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _appS.CurrentSchema = AppSettings.ColorSchemes.Purple;
        }

        private void blueGreyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _appS.CurrentSchema = AppSettings.ColorSchemes.BlueGrey;
        }

        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _appS.FormTheme = MaterialSkinManager.Themes.DARK;
            SetUpItemsVisuals();
        }

        private void lightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _appS.FormTheme = MaterialSkinManager.Themes.LIGHT;
            SetUpItemsVisuals();

        }

        private void picBUpdate_Click(object sender, EventArgs e)
        {
            treeViewExplorer.Nodes.Clear();
        }
    }
}
