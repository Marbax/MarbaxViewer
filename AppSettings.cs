using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbaxViewer
{
    public class AppSettings
    {
        public MaterialSkinManager SkinManager { get; set; } = MaterialSkinManager.Instance;

        public MaterialSkinManager.Themes FormTheme { get => SkinManager.Theme; set => SkinManager.Theme = value; }

        public ColorScheme ColorScheme { get => SkinManager.ColorScheme; }

        private ColorSchemes _currentSchema;
        public ColorSchemes CurrentSchema { get => _currentSchema; set => SetColorScheme(value); }
        public enum ColorSchemes
        {
            Purple = 1,
            BlueGrey
        }


        public AppSettings(MaterialSkinManager.Themes theme, MaterialForm frm, ColorSchemes scheme)
        {
            FormTheme = theme;
            AddFormToManage(frm);
            SetColorScheme(scheme);
        }
        public void AddFormToManage(MaterialForm frm)
        {
            SkinManager.AddFormToManage(frm);
        }

        private void SetColorScheme(ColorSchemes scheme)
        {
            switch (scheme)
            {
                case ColorSchemes.Purple:
                    {
                        SkinManager.ColorScheme = new ColorScheme(Primary.DeepPurple600, Primary.DeepPurple800, Primary.DeepPurple700, Accent.Purple400, TextShade.WHITE);
                        _currentSchema = ColorSchemes.Purple;
                    }
                    break;
                case ColorSchemes.BlueGrey:
                    {
                        SkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
                        _currentSchema = ColorSchemes.BlueGrey;
                    }
                    break;
            }
        }

        public Color GetMainColor()
        {
            switch (_currentSchema)
            {
                case ColorSchemes.Purple:
                    return Color.FromArgb(94, 53, 177);
                case ColorSchemes.BlueGrey:
                    return Color.FromArgb(55, 71, 79);
                default:
                    return Color.FromArgb(94, 53, 177);
            }
        }
        public Color GetBackgroundColor()
        {
            switch (FormTheme)
            {
                case MaterialSkinManager.Themes.LIGHT:
                    return Color.FromArgb(255, 255, 255);
                case MaterialSkinManager.Themes.DARK:
                    return Color.FromArgb(51, 51, 51);
                default:
                    return Color.FromArgb(51, 51, 51);
            }
        }
        public Color GetFontColor()
        {
            switch (FormTheme)
            {
                case MaterialSkinManager.Themes.DARK:
                    return Color.FromArgb(255, 255, 255);
                case MaterialSkinManager.Themes.LIGHT:
                    return Color.FromArgb(51, 51, 51);
                default:
                    return Color.FromArgb(255, 255, 255);
            }
        }
        public Image GetUpdateImage()
        {
            switch (FormTheme)
            {
                case MaterialSkinManager.Themes.DARK:
                    return MarbaxViewer.Properties.Resources.UpdateWhite;
                case MaterialSkinManager.Themes.LIGHT:
                    return MarbaxViewer.Properties.Resources.Update;
                default:
                    return MarbaxViewer.Properties.Resources.Update;
            }
        }

    }
}
