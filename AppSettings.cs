using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace MarbaxViewer
{
    [Serializable]
    public class AppSettings
    {
        private AppFont _currentFont = AppFont.Gothic;
        public AppFont CurrentFont { get => _currentFont; set => _currentFont = value; }

        private ColorSchemes _currentSchema = ColorSchemes.BlueGrey;
        public ColorSchemes CurrentSchema { get => _currentSchema; set => SetColorScheme(value); }


        private Theme _currentTheme = Theme.Dark;
        public Theme CurrentTheme { get => _currentTheme; set => SetTheme(value); }

        private ArrowStyle _CurrentArrowStyle = ArrowStyle.DartArrow;
        public ArrowStyle CurrentArrowStyle { get => _CurrentArrowStyle; set => _CurrentArrowStyle = value; }


        public List<string> AllowedImageFormats;
        public List<string> SearchHistory { get; set; }
        public List<KeyValuePair<string, string>> Tags;

        [NonSerialized]
        private MaterialSkinManager _skinManager = MaterialSkinManager.Instance;
        public MaterialSkinManager SkinManager { get => _skinManager; set => _skinManager = value; }

        public enum ColorSchemes
        {
            Purple = 1,
            BlueGrey
        }

        public enum ArrowStyle
        {
            DartArrow = 1,
            Quadruple
        }

        public enum ArrowDirection
        {
            Left = 1,
            Top,
            Right,
            Down
        }
        public enum AppFont
        {
            Gothic = 1,
            Jokerman,
            Kristen
        }

        public enum Theme
        {
            Dark = 1,
            Light
        }

        public enum ConvertableFormat
        {
            Png = 1,
            Bmp,
            Gif,
            Icon,
            Jpeg,
            Tiff
        }

        public AppSettings(MaterialSkinManager.Themes theme = MaterialSkinManager.Themes.DARK, ColorSchemes scheme = ColorSchemes.BlueGrey)
        {
            SkinManager = MaterialSkinManager.Instance;
            SkinManager.Theme = theme;
            SetColorScheme(scheme);
            InitDefaultImageFormats();
            SearchHistory = new List<string>();
            Tags = new List<KeyValuePair<string, string>>();
        }
        public void InitDefaultImageFormats()
        {
            if (AllowedImageFormats == null)
            {
                AllowedImageFormats = new List<string>();
                AllowedImageFormats.Add(".jpeg");
                AllowedImageFormats.Add(".jpg");
                AllowedImageFormats.Add(".png");
                AllowedImageFormats.Add(".ico");
                AllowedImageFormats.Add(".gif");
                AllowedImageFormats.Add(".bmp");
                AllowedImageFormats.Add(".tif");
            }
        }


        public void AddFormToManage(MaterialForm frm)
        {
            if (SkinManager == null)
                SkinManager = MaterialSkinManager.Instance;
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

        private void SetTheme(Theme value)
        {
            switch (value)
            {
                case Theme.Dark:
                    {
                        SkinManager.Theme = MaterialSkinManager.Themes.DARK;
                        _currentTheme = Theme.Dark;
                    }
                    break;
                case Theme.Light:
                    {
                        SkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                        _currentTheme = Theme.Light;
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
            switch (_currentTheme)
            {
                case Theme.Light:
                    return Color.FromArgb(255, 255, 255);
                case Theme.Dark:
                    return Color.FromArgb(51, 51, 51);
                default:
                    return Color.FromArgb(51, 51, 51);
            }
        }
        public Color GetFontColor()
        {
            switch (_currentTheme)
            {
                case Theme.Dark:
                    return Color.FromArgb(255, 255, 255);
                case Theme.Light:
                    return Color.FromArgb(51, 51, 51);
                default:
                    return Color.FromArgb(255, 255, 255);
            }
        }
        public Image GetUpdateImage()
        {
            switch (_currentTheme)
            {
                case Theme.Dark:
                    return MarbaxViewer.Properties.Resources.UpdateWhite;
                case Theme.Light:
                    return MarbaxViewer.Properties.Resources.Update;
                default:
                    return MarbaxViewer.Properties.Resources.Update;
            }
        }

        public Font GetFont()
        {
            switch (_currentFont)
            {
                case AppFont.Gothic:
                    return new Font("Yu Gothic UI", 11, FontStyle.Regular);
                case AppFont.Jokerman:
                    return new Font("Jokerman", 10, FontStyle.Regular);
                case AppFont.Kristen:
                    return new Font("Kristen ITC", 10, FontStyle.Regular);
                default:
                    return new Font("Yu Gothic UI", 11, FontStyle.Regular);
            }
        }

        public string GetArrow(ArrowDirection arrowDirection)
        {
            switch (_CurrentArrowStyle)
            {
                case ArrowStyle.DartArrow:
                    {
                        switch (arrowDirection)
                        {
                            case ArrowDirection.Left:
                                return char.ConvertFromUtf32(11164);
                            case ArrowDirection.Top:
                                return char.ConvertFromUtf32(11165);
                            case ArrowDirection.Right:
                                return char.ConvertFromUtf32(11166);
                            case ArrowDirection.Down:
                                return char.ConvertFromUtf32(11167);
                            default:
                                return char.ConvertFromUtf32(11165);
                        }
                    }
                case ArrowStyle.Quadruple:
                    {
                        switch (arrowDirection)
                        {
                            case ArrowDirection.Left:
                                return char.ConvertFromUtf32(11077);
                            case ArrowDirection.Top:
                                return char.ConvertFromUtf32(10224);
                            case ArrowDirection.Right:
                                return char.ConvertFromUtf32(11078);
                            case ArrowDirection.Down:
                                return char.ConvertFromUtf32(10225);
                            default:
                                return char.ConvertFromUtf32(10224);
                        }
                    }
                default:
                    return char.ConvertFromUtf32(11165);
            }
        }

    }
}
