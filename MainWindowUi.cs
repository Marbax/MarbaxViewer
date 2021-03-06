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
using System.Drawing.Imaging;

namespace MarbaxViewer
{
    public partial class MainWindowUi : UserControl
    {
        private AppSettings _appS;

        List<string> _foundItems = new List<string>();

        private int _treeInher = 2;

        public ushort SliderSize { get; set; } = 20;

        public ushort MoveSpeed { get; set; } = 10;

        public ushort ScreenCoef { get; set; } = 4;

        public bool LSlideOpened { get; set; } = false;
        public bool BSlideOpened { get; set; } = false;

        private bool _moveFiles = false;
        public MainWindowUi(ref AppSettings appS)
        {
            InitializeComponent();
            _appS = appS;
            SetUpItemsVisuals();
            progressBarLoading.Visible = false;

            //TODO
            mCheckBoxOnlyImages.Visible = false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////__METHODS__//////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        private void SetUpItemsVisuals()
        {
            _appS.CurrentSchema = _appS.CurrentSchema;
            _appS.CurrentTheme = _appS.CurrentTheme;
            msMenu.ForeColor = Color.White;

            tvDirBrowser.ForeColor = lvFileBrowser.ForeColor = mSingleLineFieldPath.ForeColor = _appS.GetFontColor();

            panelFilesControlsLeftM.BackColor = panelFilesControlsRightM.BackColor = tvDirBrowser.BackColor =
                lvFileBrowser.BackColor = panelFileBrowser.BackColor = panelSlideBarControls.BackColor = this.BackColor = _appS.GetBackgroundColor();

            panelSlideBar.ForeColor = panelSlideBarControls.ForeColor = msMenu.BackColor = panelSlideBtn.BackColor = panelFileBSlider.BackColor =
                panelFolderPath.BackColor = panelDirTreeBotM.BackColor =
                panelMarginInsideLeft.BackColor = panelMarginInsideRight.BackColor = _appS.GetMainColor();

            picBUpdateTree.Image = picBoxUpdateFileBrowser.Image = _appS.GetUpdateImage();


            tvDirBrowser.Font = lvFileBrowser.Font = mSingleLineFieldPath.Font = mCheckBoxOnlyImages.Font = msMenu.Font = _appS.GetFont();

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
            progressBarLoading.Visible = false;
            timerExtract.Stop();
            imgLCurrentDir.Images.Clear();
            lvFileBrowser.Items.Clear();
            try
            {
                if (Directory.GetFiles(path).Count() > 0)
                {
                    lvFileBrowser.Tag = path;
                    try
                    {
                        foreach (string item in Directory.GetFiles(path))
                        {
                            if (_appS.AllowedImageFormats.Contains(Path.GetExtension(item).ToLower()))
                            {
                                imgLCurrentDir.Images.Add(item, Image.FromFile(item));
                                ListViewItem lviItem = new ListViewItem(Path.GetFileName(item), item);
                                lviItem.ForeColor = _appS.GetFontColor();
                                lviItem.Font = _appS.GetFont();
                                lvFileBrowser.Items.Add(lviItem);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"File check error : {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Directory check error : {ex.Message}");
            }
        }

        private void UpdateListViewFilesAfterSearchWithTimer()
        {
            imgLCurrentDir.Images.Clear();
            lvFileBrowser.Items.Clear();
            timerExtract.Start();
        }

        private void SelectAllItemsInListView()
        {
            if (lvFileBrowser.Items.Count > 1)
                for (int i = 0; i < lvFileBrowser.Items.Count; i++)
                    lvFileBrowser.Items[i].Selected = true;
        }
        //TODO
        private void CopyFilesFromListView(bool moveFiles = false)
        {
            if (moveFiles == true)
                _moveFiles = true;
            else
                _moveFiles = false;

            System.Collections.Specialized.StringCollection files = new System.Collections.Specialized.StringCollection();
            foreach (ListViewItem lvItem in lvFileBrowser.SelectedItems)
                files.Add(lvItem.ImageKey);
            Clipboard.SetFileDropList(files);
        }

        private void PasteImagesToListView()
        {
            if (Clipboard.ContainsFileDropList())
            {
                System.Collections.Specialized.StringCollection files = Clipboard.GetFileDropList();
                Clipboard.Clear();
                foreach (var file in files)
                {
                    if (_appS.AllowedImageFormats.Contains(Path.GetExtension(file)))
                    {
                        try
                        {
                            if (_moveFiles == false)
                                File.Copy(file, Path.Combine(lvFileBrowser.Tag as string, Path.GetFileName(file)));
                            if (_moveFiles == true)
                                File.Move(file, Path.Combine(lvFileBrowser.Tag as string, Path.GetFileName(file)));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                _moveFiles = false;
                UpdateListViewFiles(lvFileBrowser.Tag as string);
            }
        }

        //TODO
        private void DeleteFilesFromListView()
        {
            if (lvFileBrowser.SelectedItems.Count > 0)
            {
                Clipboard.Clear();
                List<string> paths = new List<string>();
                foreach (ListViewItem lvItem in lvFileBrowser.SelectedItems)
                    paths.Add(lvItem.ImageKey);

                imgLCurrentDir.Images.Clear();
                lvFileBrowser.Items.Clear();
                foreach (string path in paths)
                {
                    if (File.Exists(path))
                    {
                        try
                        {
                            File.Delete(path);
                        }
                        catch (IOException e)
                        {
                            MessageBox.Show(e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                UpdateListViewFiles(lvFileBrowser.Tag as string);
            }
        }
        private void SearchByFileName(string startPath, string fileName)
        {
            try
            {
                if (Directory.Exists(startPath))
                {
                    if (Directory.GetFiles(startPath).Count() > 0)
                        foreach (string file in Directory.GetFiles(startPath))
                            if (_appS.AllowedImageFormats.Contains(Path.GetExtension(file).ToLower()) && Path.GetFileNameWithoutExtension(file).Contains(fileName))
                                _foundItems.Add(file);

                    if (Directory.GetDirectories(startPath).Count() > 0)
                        foreach (string dir in Directory.GetDirectories(startPath))
                            SearchByFileName(dir, fileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SearchByFileExtension(string startPath, string fileExtension)
        {
            try
            {
                if (Directory.Exists(startPath))
                {
                    if (Directory.GetFiles(startPath).Count() > 0)
                        foreach (string file in Directory.GetFiles(startPath))
                            if (Path.GetExtension(file).ToLower() == fileExtension.ToLower())
                                _foundItems.Add(file);

                    if (Directory.GetDirectories(startPath).Count() > 0)
                        foreach (string dir in Directory.GetDirectories(startPath))
                            SearchByFileExtension(dir, fileExtension);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SearchByFileSize(string startPath, float min, float max)
        {
            try
            {
                if (Directory.Exists(startPath))
                {
                    if (Directory.GetFiles(startPath).Count() > 0)
                        foreach (string file in Directory.GetFiles(startPath))
                        {
                            FileInfo fi = new FileInfo(file);
                            float fSize = fi.Length / 1000;
                            if (_appS.AllowedImageFormats.Contains(fi.Extension.ToLower()) && fSize >= min && fSize <= max)
                                _foundItems.Add(file);
                        }

                    if (Directory.GetDirectories(startPath).Count() > 0)
                        foreach (string dir in Directory.GetDirectories(startPath))
                            SearchByFileSize(dir, min, max);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SearchByFileCreationDate(string startPath, DateTime min, DateTime max)
        {
            try
            {
                if (Directory.Exists(startPath))
                {
                    if (Directory.GetFiles(startPath).Count() > 0)
                        foreach (string file in Directory.GetFiles(startPath))
                        {
                            FileInfo fi = new FileInfo(file);
                            if (_appS.AllowedImageFormats.Contains(fi.Extension.ToLower()) && fi.CreationTime >= min && fi.CreationTime <= max)
                                _foundItems.Add(file);
                        }

                    if (Directory.GetDirectories(startPath).Count() > 0)
                        foreach (string dir in Directory.GetDirectories(startPath))
                            SearchByFileCreationDate(dir, min, max);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SearchByFileTag(string startPath, string fTag)
        {
            try
            {
                if (Directory.Exists(startPath))
                {
                    if (Directory.GetFiles(startPath).Count() > 0)
                        foreach (string file in Directory.GetFiles(startPath))
                        {
                            FileInfo fi = new FileInfo(file);
                            if (_appS.AllowedImageFormats.Contains(fi.Extension.ToLower()) && _appS.Tags.Exists(item => item.Key == fi.FullName && item.Value.Contains(fTag)))
                                _foundItems.Add(file);
                        }

                    if (Directory.GetDirectories(startPath).Count() > 0)
                        foreach (string dir in Directory.GetDirectories(startPath))
                            SearchByFileTag(dir, fTag);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void AddTag(params string[] tagedItems)
        {
            frmSearchByInput frm = new frmSearchByInput(ref _appS, frmSearchByInput.Mode.AddTag, tagedItems.Aggregate((f, s) => f + " " + s));

            if (frm.ShowDialog() == DialogResult.OK)
            {
                string newTags = frm.ToFindText;
                foreach (string item in tagedItems)
                {
                    if (_appS.Tags.Count > 0 && _appS.Tags.Exists(t => t.Key == item))
                    {
                        int index = _appS.Tags.FindIndex(k => k.Key == item);
                        string oldTags = _appS.Tags[index].Value;
                        _appS.Tags.RemoveAt(index);
                        _appS.Tags.Add(new KeyValuePair<string, string>(item, oldTags + newTags));
                    }
                    else
                        _appS.Tags.Add(new KeyValuePair<string, string>(item, newTags));
                }
            }
        }

        private void EditTag(string fPath)
        {
            if (_appS.Tags.Exists(t => t.Key == fPath))
            {
                var tag = _appS.Tags.Find(i => i.Key == fPath);
                frmSearchByInput frm = new frmSearchByInput(ref _appS, frmSearchByInput.Mode.EditTag, fPath, tag.Value);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _appS.Tags.Add(new KeyValuePair<string, string>(tag.Key, frm.ToFindText));
                    _appS.Tags.Remove(tag);
                }
            }
            else
                MessageBox.Show($"{fPath} doesn't have Tags", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ConvertImageTo(AppSettings.ConvertableFormat format, List<string> files)
        {
            foreach (string file in files)
            {
                try
                {
                    string newFile = $"{Path.GetDirectoryName(file)}/{Path.GetFileNameWithoutExtension(file)}";
                    using (Image img = Image.FromFile(file))
                    {
                        switch (format)
                        {
                            case AppSettings.ConvertableFormat.Png:
                                img.Save($"{newFile}.png", ImageFormat.Png);
                                break;
                            case AppSettings.ConvertableFormat.Bmp:
                                img.Save($"{newFile}.bmp", ImageFormat.Bmp);
                                break;
                            case AppSettings.ConvertableFormat.Gif:
                                img.Save($"{newFile}.gif", ImageFormat.Gif);
                                break;
                            case AppSettings.ConvertableFormat.Icon:
                                img.Save($"{newFile}.ico", ImageFormat.Icon);
                                break;
                            case AppSettings.ConvertableFormat.Jpeg:
                                img.Save($"{newFile}.jepg", ImageFormat.Jpeg);
                                break;
                            case AppSettings.ConvertableFormat.Tiff:
                                img.Save($"{newFile}.tiff", ImageFormat.Tiff);
                                break;
                        }
                    }
                    imgLCurrentDir.Images.Add(newFile, Image.FromFile(newFile));
                    lvFileBrowser.Items.Add(Path.GetFileName(newFile), newFile);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Image convert exception : {ex.Message}");
                }
            }

        }

        private List<string> GetSelectedFilesPathesLV()
        {
            List<string> sFiles = new List<string>();
            foreach (ListViewItem lvItem in lvFileBrowser.SelectedItems)
                sFiles.Add(lvItem.ImageKey);
            return sFiles;
        }

        // isn't working with large files amount
        /*
        private void UpdateListViewFilesAfterSearch()
        {
            imgLCurrentDir.Images.Clear();
            lvFileBrowser.Items.Clear();

            foreach (string item in _foundItems)
            {
                try
                {
                    imgLCurrentDir.Images.Add(item, Image.FromFile(item));
                    ListViewItem lviItem = new ListViewItem(Path.GetFileName(item), item);
                    lviItem.ForeColor = _appS.GetFontColor();
                    lviItem.Font = _appS.Font;
                    lvFileBrowser.Items.Add(lviItem);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"File check Exception : {ex.Message}");
                }
            }

        }
        */
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////__TREE_VIEW_METHODS__////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //TODO
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

        //TODO
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

        //TODO
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
                    volume.NodeFont = _appS.GetFont();
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
                    if (Directory.GetDirectories(node.Name).Count() > 0)
                    {
                        foreach (string dirPath in Directory.GetDirectories(node.Name))
                        {
                            try
                            {
                                TreeNode dir = new TreeNode(Path.GetFileName(dirPath), 1, 1);
                                dir.Name = dirPath;
                                dir.NodeFont = _appS.GetFont();
                                DefaultNodeUpdate(dir, subTreesLeft);
                                node.Nodes.Add(dir);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Inner Directory check exception : {ex.Message}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Outer Directory check exception : {ex.Message}");
                }
            }
        }

        //TODO
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
                            try
                            {
                                TreeNode dir = new TreeNode(Path.GetFileName(dirPath), 1, 1);
                                dir.Name = dirPath;
                                dir.NodeFont = _appS.GetFont();
                                UpdateNodeOnlyImageContainers(dir, subTreesLeft);
                                node.Nodes.Add(dir);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Outer Directory check exception : {ex.Message}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Outer Directory check exception : {ex.Message}");
                }
            }
        }

        private bool ImageExstsInDirectory(string path)
        {
            try
            {
                if (Directory.GetFiles(path).Count() > 0)
                {
                    try
                    {
                        foreach (string file in Directory.GetFiles(path))
                            if (_appS.AllowedImageFormats.Contains(Path.GetExtension(file)))
                                return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"File check exception : {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Directory check exception : {ex.Message}");
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
                {
                    try
                    {
                        if (Directory.GetDirectories(path).Count() > 0)
                        {
                            foreach (string dirPath in Directory.GetDirectories(path))
                                try
                                {
                                    ImageExistsDeeper(dirPath);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Directory check exception : {ex.Message}");
                                }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Directory check exception : {ex.Message}");
                    }
                }
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
            _appS.CurrentTheme = AppSettings.Theme.Dark;
            SetUpItemsVisuals();
        }

        private void lightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _appS.CurrentTheme = AppSettings.Theme.Light;
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

        private void timerExtract_Tick(object sender, EventArgs e)
        {
            if (_foundItems.Count > 0)
            {
                string item = _foundItems[0];
                try
                {
                    imgLCurrentDir.Images.Add(item, Image.FromFile(item));
                    ListViewItem lviItem = new ListViewItem(Path.GetFileName(item), item);
                    lviItem.ForeColor = _appS.GetFontColor();
                    lviItem.Font = _appS.GetFont();
                    lvFileBrowser.Items.Add(lviItem);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Add item exception with {item} : {ex.Message}");
                }
                finally
                {
                    _foundItems.RemoveAt(0);
                }
            }
            else
            {
                progressBarLoading.Visible = false;
                timerExtract.Stop();
            }
        }

        private void tvDirBrowser_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UpdateNodes(e.Node);
            UpdateListViewFiles(e.Node.Name);
            mSingleLineFieldPath.Text = e.Node.Name;
        }

        private void tvDirBrowser_AfterExpand(object sender, TreeViewEventArgs e)
        {
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
                UpdateListViewFiles(tvDirBrowser.SelectedNode.Name);
            else if (lvFileBrowser.Tag as string != null)
                UpdateListViewFiles(lvFileBrowser.Tag as string);
            else if (Directory.Exists(mSingleLineFieldPath.Text))
                UpdateListViewFiles(mSingleLineFieldPath.Text);
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
                frm.ShowDialog(this);
            }
        }

        private void mSingleLineFieldPath_Click(object sender, EventArgs e)
        {
            mSingleLineFieldPath.Text.Trim(' ');
            try
            {
                if (Directory.Exists(mSingleLineFieldPath.Text))
                {
                    UpdateListViewFiles(mSingleLineFieldPath.Text);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wrong path : {ex.Message}");
            }
        }
        private void lvFileBrowser_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void byFileNameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (tvDirBrowser.SelectedNode != null)
            {
                progressBarLoading.Visible = false;
                timerExtract.Stop();
                _foundItems.Clear();
                frmSearchByInput searchForm = new frmSearchByInput(ref _appS, frmSearchByInput.Mode.Name, tvDirBrowser.SelectedNode.Name);
                if (searchForm.ShowDialog() == DialogResult.OK)
                {
                    progressBarLoading.Visible = true;
                    Cursor.Current = Cursors.WaitCursor;
                    SearchByFileName(tvDirBrowser.SelectedNode.Name, searchForm.ToFindText);
                    if (_foundItems.Count > 0)
                    {
                        mLabelItemsFound.Text = $"Items Found : {_foundItems.Count}";
                        UpdateListViewFilesAfterSearchWithTimer();
                    }
                    else
                    {
                        MessageBox.Show("Nothing found but we tried", "Such a pity", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        progressBarLoading.Visible = false;
                    }
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void byFileExtensionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvDirBrowser.SelectedNode != null)
            {
                progressBarLoading.Visible = false;
                timerExtract.Stop();
                _foundItems.Clear();
                frmSearchByInput searchForm = new frmSearchByInput(ref _appS, frmSearchByInput.Mode.Extension, tvDirBrowser.SelectedNode.Name);
                if (searchForm.ShowDialog() == DialogResult.OK)
                {
                    progressBarLoading.Visible = true;
                    Cursor.Current = Cursors.WaitCursor;
                    SearchByFileExtension(tvDirBrowser.SelectedNode.Name, searchForm.ToFindExtension);
                    if (_foundItems.Count > 0)
                    {
                        mLabelItemsFound.Text = $"Items Found : {_foundItems.Count}";
                        UpdateListViewFilesAfterSearchWithTimer();
                    }
                    else
                    {
                        MessageBox.Show("Nothing found but we tried", "Such a pity", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        progressBarLoading.Visible = false;
                    }
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void byFileSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvDirBrowser.SelectedNode != null)
            {
                progressBarLoading.Visible = false;
                timerExtract.Stop();
                _foundItems.Clear();
                frmSearchByInput searchForm = new frmSearchByInput(ref _appS, frmSearchByInput.Mode.Size, tvDirBrowser.SelectedNode.Name);
                if (searchForm.ShowDialog() == DialogResult.OK)
                {
                    progressBarLoading.Visible = true;
                    Cursor.Current = Cursors.WaitCursor;
                    SearchByFileSize(tvDirBrowser.SelectedNode.Name, searchForm.ToFindMinSize, searchForm.ToFindMaxSize);
                    if (_foundItems.Count > 0)
                    {
                        mLabelItemsFound.Text = $"Items Found : {_foundItems.Count}";
                        UpdateListViewFilesAfterSearchWithTimer();
                    }
                    else
                    {
                        MessageBox.Show("Nothing found but we tried", "Such a pity", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        progressBarLoading.Visible = false;
                    }
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void byFileCreationDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvDirBrowser.SelectedNode != null)
            {
                timerExtract.Stop();
                _foundItems.Clear();
                progressBarLoading.Visible = false;
                frmSearchByInput searchForm = new frmSearchByInput(ref _appS, frmSearchByInput.Mode.Date, tvDirBrowser.SelectedNode.Name);
                if (searchForm.ShowDialog() == DialogResult.OK)
                {
                    progressBarLoading.Visible = true;
                    Cursor.Current = Cursors.WaitCursor;
                    SearchByFileCreationDate(tvDirBrowser.SelectedNode.Name, searchForm.ToFindMinDate, searchForm.ToFindMaxDate);
                    if (_foundItems.Count > 0)
                    {
                        mLabelItemsFound.Text = $"Items Found : {_foundItems.Count}";
                        UpdateListViewFilesAfterSearchWithTimer();
                    }
                    else
                    {
                        MessageBox.Show("Nothing found but we tried", "Such a pity", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        progressBarLoading.Visible = false;
                    }
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void byFileTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvDirBrowser.SelectedNode != null)
            {
                timerExtract.Stop();
                _foundItems.Clear();
                progressBarLoading.Visible = false;
                frmSearchByInput searchForm = new frmSearchByInput(ref _appS, frmSearchByInput.Mode.Tag, tvDirBrowser.SelectedNode.Name);
                if (searchForm.ShowDialog() == DialogResult.OK)
                {
                    progressBarLoading.Visible = true;
                    Cursor.Current = Cursors.WaitCursor;
                    SearchByFileTag(tvDirBrowser.SelectedNode.Name, searchForm.ToFindText);
                    if (_foundItems.Count > 0)
                    {
                        mLabelItemsFound.Text = $"Items Found : {_foundItems.Count}";
                        UpdateListViewFilesAfterSearchWithTimer();
                    }
                    else
                    {
                        MessageBox.Show("Nothing found but we tried", "Such a pity", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        progressBarLoading.Visible = false;
                    }
                    Cursor.Current = Cursors.Default;

                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTag(tvDirBrowser.SelectedNode.Name);
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (lvFileBrowser.SelectedItems.Count > 0)
            {
                List<string> selectedItems = new List<string>();
                foreach (ListViewItem lvItem in lvFileBrowser.SelectedItems)
                    selectedItems.Add(lvItem.ImageKey);

                AddTag(selectedItems.ToArray());
            }
            else
                AddTag(lvFileBrowser.Tag as string);
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (lvFileBrowser.SelectedItems.Count > 0)
                EditTag(lvFileBrowser.SelectedItems[0].ImageKey);
            else
                EditTag(lvFileBrowser.Tag as string);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditTag(tvDirBrowser.SelectedNode.Name);
        }

        private void pngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvFileBrowser.SelectedItems.Count > 0)
            {
                ConvertImageTo(AppSettings.ConvertableFormat.Png, GetSelectedFilesPathesLV());
            }
        }

        private void jpegToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvFileBrowser.SelectedItems.Count > 0)
            {
                ConvertImageTo(AppSettings.ConvertableFormat.Jpeg, GetSelectedFilesPathesLV());
            }
        }

        private void bmpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvFileBrowser.SelectedItems.Count > 0)
            {
                ConvertImageTo(AppSettings.ConvertableFormat.Bmp, GetSelectedFilesPathesLV());
            }

        }

        private void gifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvFileBrowser.SelectedItems.Count > 0)
            {
                ConvertImageTo(AppSettings.ConvertableFormat.Gif, GetSelectedFilesPathesLV());
            }

        }

        private void iconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvFileBrowser.SelectedItems.Count > 0)
            {
                ConvertImageTo(AppSettings.ConvertableFormat.Icon, GetSelectedFilesPathesLV());
            }

        }

        private void tiffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvFileBrowser.SelectedItems.Count > 0)
            {
                ConvertImageTo(AppSettings.ConvertableFormat.Tiff, GetSelectedFilesPathesLV());
            }

        }

        private void mSingleLineFieldPath_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (Directory.Exists(mSingleLineFieldPath.Text.Trim(' ')))
                    UpdateListViewFiles(mSingleLineFieldPath.Text.Trim(' '));
        }

        private void lvFileBrowser_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (lvFileBrowser.SelectedItems.Count > 0)
            {
                DoDragDrop(GetSelectedFilesPathesLV(), DragDropEffects.Move);

                //lvFileBrowser.DoDragDrop(lvFileBrowser.SelectedItems, DragDropEffects.Move);
            }
        }

        private void lvFileBrowser_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                System.Collections.Specialized.StringCollection filePath = new System.Collections.Specialized.StringCollection();
                if (lvFileBrowser.SelectedItems.Count > 0)
                {
                    try
                    {
                        filePath.AddRange(GetSelectedFilesPathesLV().ToArray());
                        DataObject dataObject = new DataObject();

                        dataObject.SetFileDropList(filePath);
                        lvFileBrowser.DoDragDrop(dataObject, DragDropEffects.Copy);
                        DoDragDrop(lvFileBrowser.SelectedItems, DragDropEffects.Copy);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Drag mouse down pack exception : {ex.Message}");
                    }
                }
            }
        }

        private void lvFileBrowser_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);
                bool imgExist = false;
                if (paths != null && paths.Count() > 0)
                {
                    foreach (string path in paths)
                    {
                        if (imgExist)
                            break;
                        if (_appS.AllowedImageFormats.Contains(Path.GetExtension(path).ToLower()))
                            imgExist = true;
                    }
                    if (imgExist)
                        e.Effect = DragDropEffects.Move;
                }
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void lvFileBrowser_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (paths != null && paths.Count() > 0)
            {
                foreach (string file in paths)
                {
                    if (_appS.AllowedImageFormats.Contains(Path.GetExtension(file).ToLower()))
                    {
                        try
                        {
                            FileInfo fi = new FileInfo(file);
                            string newPath = $"{Path.GetDirectoryName(lvFileBrowser.Tag as string)}/{fi.Name}";
                            fi.MoveTo(newPath);
                            imgLCurrentDir.Images.Add(newPath, Image.FromFile(newPath));
                            lvFileBrowser.Items.Add(Path.GetFileName(newPath), newPath);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Drag and drop exception : {ex.Message}");
                        }
                    }
                }
            }

        }

        private void sourceLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (System.Diagnostics.Process proc = new System.Diagnostics.Process())
            {
                proc.StartInfo.FileName = "https://github.com/Marbax/MarbaxViewer";
                proc.Start();
            }
        }
    }
}
