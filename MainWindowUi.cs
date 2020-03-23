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
using System.Security.Principal;
using System.Security.AccessControl;
using System.IO;

namespace MarbaxViewer
{
    public partial class MainWindowUi : UserControl
    {
        private AppSettings _appS;

        public ushort SliderSize { get; set; } = 20;

        public ushort MoveSpeed { get; set; } = 10;

        public ushort ScreenCoef { get; set; } = 4;

        public bool LSlideOpened { get; set; } = false;
        public bool BSlideOpened { get; set; } = false;

        public List<string> ImageFormats { get; set; }
        public MainWindowUi(ref AppSettings appS)
        {
            InitializeComponent();
            _appS = appS;
            SetUpItemsVisuals();
            InitDefaultImageFormats();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////__METHODS__//////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void InitDefaultImageFormats()
        {
            if (ImageFormats == null)
            {
                ImageFormats = new List<string>();
                ImageFormats.Add(".jpeg");
                ImageFormats.Add(".jpg");
                ImageFormats.Add(".png");
                ImageFormats.Add(".ico");
                ImageFormats.Add(".gif");
                ImageFormats.Add(".bmp");
                ImageFormats.Add(".tif");
            }
        }

        private void SetUpItemsVisuals()
        {
            msMenu.ForeColor = Color.White;
            tvDirBrowser.ForeColor = lvFileBrowser.ForeColor = _appS.GetFontColor();
            lvFileBrowser.ForeColor = panelFilesControlsLeftM.BackColor = panelFilesControlsRightM.BackColor = _appS.GetBackgroundColor();

            tvDirBrowser.BackColor = lvFileBrowser.BackColor = panelFileBrowser.BackColor = _appS.GetBackgroundColor();

            panelSlideBar.ForeColor = panelSlideBarControls.ForeColor = msMenu.BackColor = panelSlideBtn.BackColor = panelFileBSlider.BackColor =
                panelFolderPath.BackColor = panelDirTreeBotM.BackColor =
                panelMarginInsideLeft.BackColor = panelMarginInsideRight.BackColor = _appS.GetMainColor();

            picBUpdateTree.Image = picBoxUpdateFileBrowser.Image = _appS.GetUpdateImage();

        }

        public void CloseSliders()
        {
            timerLeftClose.Start();
            timerBotClose.Start();
        }

        private void UpdateListViewFiles(string path)
        {
            imgLCurrentDir.Images.Clear();
            lvFileBrowser.Items.Clear();
            if (AccessIsAllowed(path, FileSystemRights.Modify) && Directory.GetFiles(path).Count() > 0)
            {
                foreach (string item in Directory.GetFiles(path))
                {
                    if (ImageFormats.Contains(Path.GetExtension(item)))
                    {
                        imgLCurrentDir.Images.Add(item, Image.FromFile(item));
                        ListViewItem lviItem = new ListViewItem(Path.GetFileName(item), item);
                        lviItem.ForeColor = _appS.GetFontColor();
                        lvFileBrowser.Items.Add(lviItem);
                    }
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////__TREE_VIEW_METHODS__////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void UpdateTreeViewCatalogs()
        {
            this.tvDirBrowser.Nodes.Clear();
            foreach (string item in Directory.GetLogicalDrives())
            {
                TreeNode volume = new TreeNode(item, 0, 0);
                volume.Name = item;
                UpdateChildeNodes(volume, 2);
                tvDirBrowser.Nodes.Add(volume);
            }
        }

        private void UpdateChildeNodes(TreeNode node, int subTrees)
        {
            int subTreesLeft = subTrees;
            if (subTreesLeft > 0)
            {
                subTreesLeft--;
                node.Nodes.Clear();
                if (AccessIsAllowed(node.Name, FileSystemRights.Modify))
                    foreach (string item in Directory.EnumerateDirectories(node.Name))
                        if (AccessIsAllowed(item, FileSystemRights.Modify))
                        {
                            TreeNode dir = new TreeNode(Path.GetFileName(item), 1, 1);
                            dir.Name = item;
                            UpdateChildeNodes(dir, subTreesLeft);
                            node.Nodes.Add(dir);
                        }
            }
        }

        static bool AccessIsAllowed(string directoryName, FileSystemRights rights)
        {
            bool AllowingRightsIsPresent = false;
            bool ForbiddingRightsIsPresent = false;

            void ProcessACT(AccessControlType type)
            {
                if (type == AccessControlType.Allow)
                    AllowingRightsIsPresent = true;
                else if (type == AccessControlType.Deny)
                    ForbiddingRightsIsPresent = true;
            }

            DirectorySecurity directorySecurity = new DirectorySecurity();
            try
            {
                directorySecurity = Directory.GetAccessControl(directoryName);
            }
            catch (Exception)
            {
                return false;
            }

            WindowsIdentity wi = WindowsIdentity.GetCurrent();
            foreach (FileSystemAccessRule ar in
                directorySecurity.GetAccessRules(true, true, typeof(SecurityIdentifier)))
                if (ar.FileSystemRights.HasFlag(rights))
                {
                    if (ar.IdentityReference.Value == wi.User.Value)
                        ProcessACT(ar.AccessControlType);
                    else
                        foreach (IdentityReference ir in wi.Groups)
                            if (ar.IdentityReference.Value == ir.Value)
                                ProcessACT(ar.AccessControlType);
                }

            if (ForbiddingRightsIsPresent)
                return false;
            else if (AllowingRightsIsPresent)
                return true;
            else
                return false;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////__EVENTS__//////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void MainWindowUi_Load(object sender, EventArgs e)
        {
            if (!LSlideOpened)
            {
                panelSlideBar.Width = SliderSize;
                mfBtnSlide.Text = ">";
            }
            else
            {
                panelSlideBar.Width = this.Width / ScreenCoef;
                mfBtnSlide.Text = "<";
            }
            if (!BSlideOpened)
            {
                panelFileBOps.Height = SliderSize;
                mfButtonFileSlider.Text = "^";
            }
            else
            {
                panelFileBOps.Height = this.Width / ScreenCoef;
                mfButtonFileSlider.Text = "v";
            }
            UpdateTreeViewCatalogs();
        }

        private void mfBtnSlide_Click(object sender, EventArgs e)
        {
            if (panelSlideBar.Width <= this.Width / (ScreenCoef * 2))
            {
                timerLeftOpen.Start();
                mfBtnSlide.Text = "<";
                mfBtnSlide.Image = Properties.Resources.iconfinder_arrow_program_214661;

            }
            else if (panelSlideBar.Width >= this.Width / (ScreenCoef * 2))
            {
                timerLeftClose.Start();
                mfBtnSlide.Text = ">";
                mfBtnSlide.Image = Properties.Resources.iconfinder_arrow_program_214661;

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
            UpdateTreeViewCatalogs();
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

        private void tvDirBrowser_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UpdateChildeNodes(e.Node, 2);
            UpdateListViewFiles(e.Node.Name);
            mSingleLineFieldPath.Text = e.Node.Name;
        }

        private void tvDirBrowser_AfterExpand(object sender, TreeViewEventArgs e)
        {
            UpdateChildeNodes(e.Node, 2);
        }
    }
}
