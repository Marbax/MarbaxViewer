using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarbaxViewer
{
    public partial class frmFullScreen : MaterialSkin.Controls.MaterialForm
    {
        AppSettings _appS;
        public ushort SliderSize { get; set; } = 20;

        public ushort MoveSpeed { get; set; } = 10;

        public ushort ScreenCoef { get; set; } = 6;

        public bool BSlideOpened { get; set; } = false;

        public frmFullScreen(ref AppSettings appS, ref ListView listView)
        {
            InitializeComponent();
            _appS = appS;
            _appS.AddFormToManage(this);
            listViewImgPreview.BackColor = _appS.GetBackgroundColor();
            mfBtnSwipeLeft.Text = _appS.GetArrow(AppSettings.ArrowDirection.Left);
            mfBtnSwipeRight.Text = _appS.GetArrow(AppSettings.ArrowDirection.Right);
            panelBSlider.Height = SliderSize;
            panelBSlider.BackColor = _appS.GetMainColor();

            FillListView(ref listView);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////__METHODS__//////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FillListView(ref ListView listView)
        {
            listViewImgPreview.LargeImageList = listView.LargeImageList;
            foreach (ListViewItem lvItem in listView.Items)
            {
                listViewImgPreview.Items.Add(lvItem.Clone() as ListViewItem);
            }
        }

        private void UpdatePanelSize()
        {
            ushort margin = 0;
            ushort topMargin = 60;
            panelMain.Left = margin;
            panelMain.Width = this.Width - margin;
            panelMain.Top = topMargin;
            panelMain.Height = this.Height - topMargin - margin;
        }

        private void SetupArrowsStyle()
        {
            if (BSlideOpened)
                mfBtnSlider.Text = _appS.GetArrow(AppSettings.ArrowDirection.Down);
            else
                mfBtnSlider.Text = _appS.GetArrow(AppSettings.ArrowDirection.Top);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////__EVENTS__//////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        private void frmFullScreen_Load(object sender, EventArgs e)
        {
            UpdatePanelSize();
            panelBottomMenu.Height = this.Height / ScreenCoef;
            SetupArrowsStyle();

        }

        private void mfBtnSlider_Click(object sender, EventArgs e)
        {
            if (panelBottomMenu.Height <= this.Height / (ScreenCoef * 2))
                timerBOpen.Start();
            else if (panelBottomMenu.Height >= this.Height / (ScreenCoef * 2))
                timerBClose.Start();
        }

        private void frmFullScreen_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void listViewImgPreview_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void timerBOpen_Tick(object sender, EventArgs e)
        {
            if (panelBottomMenu.Height >= this.Height / ScreenCoef)
            {
                timerBOpen.Stop();
                BSlideOpened = true;
                SetupArrowsStyle();
            }
            else
                panelBottomMenu.Height += MoveSpeed;
        }

        private void timerBClose_Tick(object sender, EventArgs e)
        {
            if (panelBottomMenu.Height <= SliderSize)
            {
                timerBClose.Stop();
                BSlideOpened = false;
                SetupArrowsStyle();
            }
            else
                panelBottomMenu.Height -= MoveSpeed;
        }

        private void listViewImgPreview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewImgPreview.SelectedIndices.Count > 0)
                if (System.IO.File.Exists(listViewImgPreview.SelectedItems[0].ImageKey))
                    pictureBox.Image = Image.FromFile(listViewImgPreview.SelectedItems[0].ImageKey);
                else
                    pictureBox.Image = pictureBox.ErrorImage;
        }

        private void mfBtnSwipeLeft_Click(object sender, EventArgs e)
        {
            if (listViewImgPreview.Items.Count > 1)
                if (listViewImgPreview.SelectedIndices.Count > 0)
                    if (listViewImgPreview.SelectedItems[0].Index > 0)
                        listViewImgPreview.Items[listViewImgPreview.SelectedItems[0].Index - 1].Selected = true;
                    else
                        listViewImgPreview.Items[listViewImgPreview.Items.Count - 1].Selected = true;
                else
                    listViewImgPreview.Items[listViewImgPreview.Items.Count - 1].Selected = true;
        }

        private void mfBtnSwipeRight_Click(object sender, EventArgs e)
        {
            if (listViewImgPreview.Items.Count > 1)
                if (listViewImgPreview.SelectedIndices.Count > 0)
                    if (listViewImgPreview.SelectedItems[0].Index < listViewImgPreview.Items.Count - 1)
                        listViewImgPreview.Items[listViewImgPreview.SelectedItems[0].Index + 1].Selected = true;
                    else
                        listViewImgPreview.Items[0].Selected = true;
                else
                    listViewImgPreview.Items[0].Selected = true;
        }
    }
}
