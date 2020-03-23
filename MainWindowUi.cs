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

        public ushort SliderSize { get; set; } = 20;

        public ushort MoveSpeed { get; set; } = 10;

        public ushort ScreenCoef { get; set; } = 4;

        private bool LSlideOpened = false;
        private bool BSlideOpened = false;
        public MainWindowUi(ref AppSettings appS)
        {
            InitializeComponent();
            _appS = appS;
            SetUpItemsVisuals();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////__METHODS__//////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SetUpItemsVisuals()
        {
            msMenu.ForeColor = Color.White;

            tvDirBrowser.ForeColor = _appS.GetBackgroundColor();
            tvDirBrowser.BackColor = panelFileBrowser.BackColor = _appS.GetBackgroundColor();
            picBUpdate.Image = _appS.GetUpdateImage();
            panelSlideBar.ForeColor = panelSlideBarControls.ForeColor = msMenu.BackColor = panelSlideBtn.BackColor = panelFileBSlider.BackColor = _appS.GetMainColor();

        }

        public void CloseSliders()
        {
            timerLeftClose.Start();
            timerBotClose.Start();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////__EVENTS__//////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void MainWindowUi_Load(object sender, EventArgs e)
        {
            if (!LSlideOpened)
            {
                panelSlideBar.Width = panelFileBSlider.Height = SliderSize;
                mfBtnSlide.Text = ">";
            }
            else
            {
                panelSlideBar.Width = panelFileBSlider.Height = this.Width / ScreenCoef;
                mfBtnSlide.Text = "<";
            }
        }

        private void mfBtnSlide_Click(object sender, EventArgs e)
        {
            if (panelSlideBar.Width <= this.Width / (ScreenCoef * 2))
            {
                timerLeftOpen.Start();
                mfBtnSlide.Text = "<";
            }
            else if (panelSlideBar.Width >= this.Width / (ScreenCoef * 2))
            {
                timerLeftClose.Start();
                mfBtnSlide.Text = ">";
            }
        }


        private void purpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _appS.CurrentSchema = AppSettings.ColorSchemes.Purple;
            SetUpItemsVisuals();
        }

        private void blueGreyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _appS.CurrentSchema = AppSettings.ColorSchemes.BlueGrey;
            SetUpItemsVisuals();
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
            tvDirBrowser.Nodes.Clear();
        }

        private void mfButtonFileSlider_Click(object sender, EventArgs e)
        {
            if (panelFileBOps.Height <= this.Height / (ScreenCoef * 2))
            {
                timerBotOpen.Start();
                mfButtonFileSlider.Text = "v";
            }
            else if (panelFileBOps.Height >= this.Height / (ScreenCoef * 2))
            {
                timerBotClose.Start();
                mfButtonFileSlider.Text = "^";
            }

        }

        private void timerLeftOpen_Tick(object sender, EventArgs e)
        {
            if (panelSlideBar.Width >= this.Width / ScreenCoef)
                timerLeftOpen.Stop();
            else
                panelSlideBar.Width += MoveSpeed;
        }

        private void timerLeftClose_Tick(object sender, EventArgs e)
        {
            if (panelSlideBar.Width <= SliderSize)
                timerLeftClose.Stop();
            else
                panelSlideBar.Width -= MoveSpeed;
        }

        private void timerBotOpen_Tick(object sender, EventArgs e)
        {
            if (panelFileBOps.Height >= this.Height / ScreenCoef)
                timerBotOpen.Stop();
            else
                panelFileBOps.Height += MoveSpeed;
        }

        private void timerBotClose_Tick(object sender, EventArgs e)
        {
            if (panelFileBOps.Height <= SliderSize)
                timerBotClose.Stop();
            else
                panelFileBOps.Height -= MoveSpeed;

        }
    }
}
