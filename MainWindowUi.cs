﻿using System;
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

        private int _treeInher = 2;

        public ushort SliderSize { get; set; } = 20;

        public ushort MoveSpeed { get; set; } = 10;

        public ushort ScreenCoef { get; set; } = 4;

        public bool LSlideOpened { get; set; } = false;
        public bool BSlideOpened { get; set; } = false;

        public List<string> ImageFormats { get; set; } = null;
        public MainWindowUi(ref AppSettings appS)
        {
            InitializeComponent();
            _appS = appS;
            SetUpItemsVisuals();
            InitDefaultImageFormats();

            //TODO
            mCheckBoxOnlyImages.Visible = false;
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

            panelFilesControlsLeftM.BackColor = panelFilesControlsRightM.BackColor = tvDirBrowser.BackColor =
                lvFileBrowser.BackColor = panelFileBrowser.BackColor = _appS.GetBackgroundColor();

            panelSlideBar.ForeColor = panelSlideBarControls.ForeColor = msMenu.BackColor = panelSlideBtn.BackColor = panelFileBSlider.BackColor =
                panelFolderPath.BackColor = panelDirTreeBotM.BackColor =
                panelMarginInsideLeft.BackColor = panelMarginInsideRight.BackColor = _appS.GetMainColor();

            picBUpdateTree.Image = picBoxUpdateFileBrowser.Image = _appS.GetUpdateImage();


            tvDirBrowser.Font = lvFileBrowser.Font = mSingleLineFieldPath.Font = mCheckBoxOnlyImages.Font = msMenu.Font = _appS.Font;

        }

        private void SetupArrowsStyle()
        {
            if (LSlideOpened)
                mfBtnSlide.Text = _appS.GetArrow(AppSettings.ArrowDirection.Left);
            else
                mfBtnSlide.Text = _appS.GetArrow(AppSettings.ArrowDirection.Right);

            if (BSlideOpened)
                mfButtonFileSlider.Text = _appS.GetArrow(AppSettings.ArrowDirection.Down);
            else
                mfButtonFileSlider.Text = _appS.GetArrow(AppSettings.ArrowDirection.Top);

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
                        lviItem.Font = _appS.Font;
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

        private void SimpleUpdateTreeViewCatalogs()
        {
            this.tvDirBrowser.Nodes.Clear();
            try
            {
                foreach (string volumePath in Directory.GetLogicalDrives())
                {
                    TreeNode volume = new TreeNode(volumePath.Trim(@"\".ToCharArray()), 0, 0);
                    volume.Name = volumePath;
                    volume.NodeFont = _appS.Font;
                    UpdateNodes(volume);
                    tvDirBrowser.Nodes.Add(volume);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void UpdateNodes(TreeNode node)
        {
            if (mCheckBoxOnlyImages.Checked)
                UpdateNodeOnlyImageContainers(node, _treeInher);
            else
                DefaultNodeUpdate(node, _treeInher);
        }

        private void DefaultNodeUpdate(TreeNode node, int subTrees)
        {
            node.Nodes.Clear();
            int subTreesLeft = subTrees;

            if (subTreesLeft > 0)
            {
                subTreesLeft--;
                try
                {
                    foreach (string dirPath in Directory.GetDirectories(node.Name))
                    {
                        TreeNode dir = new TreeNode(Path.GetFileName(dirPath), 1, 1);
                        dir.Name = dirPath;
                        dir.NodeFont = _appS.Font;
                        DefaultNodeUpdate(dir, subTreesLeft);
                        node.Nodes.Add(dir);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Directory check exception : {ex.Message}");
                }
            }
        }

        private void UpdateNodeOnlyImageContainers(TreeNode node, int subTrees)
        {
            node.Nodes.Clear();
            int subTreesLeft = subTrees;

            if (subTreesLeft > 0)
            {
                subTreesLeft--;
                try
                {
                    foreach (string dirPath in Directory.GetDirectories(node.Name))
                    {
                        if (ImageExistsDeeper(dirPath))
                        {
                            TreeNode dir = new TreeNode(Path.GetFileName(dirPath), 1, 1);
                            dir.Name = dirPath;
                            dir.NodeFont = _appS.Font;
                            UpdateNodeOnlyImageContainers(dir, subTreesLeft);
                            node.Nodes.Add(dir);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Directory check exception : {ex.Message}");
                }
            }
        }

        private bool ImageExstsInDirectory(string path)
        {
            try
            {
                foreach (string file in Directory.GetFiles(path))
                    if (ImageFormats.Contains(Path.GetExtension(file)))
                        return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"File check exception : {ex.Message}");
            }
            return false;
        }

        //TODO
        private bool ImageExistsDeeper(string path)
        {
            try
            {
                if (ImageExstsInDirectory(path))
                    return true;
                else
                    foreach (string dirPath in Directory.GetDirectories(path))
                        ImageExistsDeeper(dirPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Directory check exception : {ex.Message}");
            }
            return false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////__EVENTS__//////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void MainWindowUi_Load(object sender, EventArgs e)
        {
            //UpdateTreeViewCatalogs();
            SimpleUpdateTreeViewCatalogs();
        }

        private void mfBtnSlide_Click(object sender, EventArgs e)
        {
            if (panelSlideBar.Width <= this.Width / (ScreenCoef * 2))
                timerLeftOpen.Start();
            else if (panelSlideBar.Width >= this.Width / (ScreenCoef * 2))
                timerLeftClose.Start();
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

        private void mfButtonFileSlider_Click(object sender, EventArgs e)
        {
            if (panelFileBOps.Height <= this.Height / (ScreenCoef * 2))
                timerBotOpen.Start();
            else if (panelFileBOps.Height >= this.Height / (ScreenCoef * 2))
                timerBotClose.Start();

        }

        private void timerLeftOpen_Tick(object sender, EventArgs e)
        {
            if (panelSlideBar.Width >= this.Width / ScreenCoef)
            {
                timerLeftOpen.Stop();
                LSlideOpened = true;
                SetupArrowsStyle();
            }
            else
                panelSlideBar.Width += MoveSpeed;
        }

        private void timerLeftClose_Tick(object sender, EventArgs e)
        {
            if (panelSlideBar.Width <= SliderSize)
            {
                timerLeftClose.Stop();
                LSlideOpened = false;
                SetupArrowsStyle();
            }
            else
                panelSlideBar.Width -= MoveSpeed;
        }

        private void timerBotOpen_Tick(object sender, EventArgs e)
        {
            if (panelFileBOps.Height >= this.Height / ScreenCoef)
            {
                timerBotOpen.Stop();
                BSlideOpened = true;
                SetupArrowsStyle();
            }
            else
                panelFileBOps.Height += MoveSpeed;
        }

        private void timerBotClose_Tick(object sender, EventArgs e)
        {
            if (panelFileBOps.Height <= SliderSize)
            {
                timerBotClose.Stop();
                BSlideOpened = false;
                SetupArrowsStyle();
            }
            else
                panelFileBOps.Height -= MoveSpeed;
        }

        private void tvDirBrowser_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //UpdateChildeNodes(e.Node, _treeInher);
            UpdateNodes(e.Node);
            UpdateListViewFiles(e.Node.Name);
            mSingleLineFieldPath.Text = e.Node.Name;
        }

        private void tvDirBrowser_AfterExpand(object sender, TreeViewEventArgs e)
        {
            //UpdateChildeNodes(e.Node, _treeInher);
            UpdateNodes(e.Node);
        }

        private void dartArrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _appS.CurrentArrowStyle = AppSettings.ArrowStyle.DartArrow;
            SetupArrowsStyle();
        }

        private void quadrupleArrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _appS.CurrentArrowStyle = AppSettings.ArrowStyle.Quadruple;
            SetupArrowsStyle();
        }

        private void picBoxUpdateFileBrowser_Click(object sender, EventArgs e)
        {
            if (tvDirBrowser.SelectedNode != null)
            {
                UpdateListViewFiles(tvDirBrowser.SelectedNode.Name);
            }
            else if (Directory.Exists(mSingleLineFieldPath.Text))
            {
                UpdateListViewFiles(mSingleLineFieldPath.Text);
            }
        }

        private void picBUpdateTree_Click(object sender, EventArgs e)
        {
            SimpleUpdateTreeViewCatalogs();
        }

        private void lvFileBrowser_DoubleClick(object sender, EventArgs e)
        {
            if (lvFileBrowser.SelectedIndices.Count > 0)
            {
                Form frm = new frmFullScreen(ref _appS, ref lvFileBrowser, lvFileBrowser.SelectedIndices[0]);
                frm.ShowDialog();
            }
        }
    }
}
