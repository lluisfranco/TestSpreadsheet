using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraEditors;

namespace TestSpreadsheet
{
    public class ThemeHelper
    {
        public static void RestoreSavedTheme(string appname)
        {
            var skinname = Win32RegistryHelper.ReadValueFromRegistry(appname, "Skin");
            var skinpalettename = Win32RegistryHelper.ReadValueFromRegistry(appname, "Palette");
            if (!string.IsNullOrWhiteSpace(skinname))
            {
                var category = SkinCollectionHelper.GetSkinCategory(skinname);
                if (category != SkinCategory.SVG && category != SkinCategory.Custom) skinname = "The Bezier";
                WindowsFormsSettings.DefaultLookAndFeel.SkinName = skinname;
            }
            if (!string.IsNullOrWhiteSpace(skinpalettename))
            {
                var skin = CommonSkins.GetSkin(UserLookAndFeel.Default);
                DevExpress.Utils.Svg.SvgPalette palette = skin.CustomSvgPalettes[skinpalettename];
                skin.SvgPalettes[Skin.DefaultSkinPaletteName].SetCustomPalette(palette);
                LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
                //UserLookAndFeel.Default.StyleChanged += Default_StyleChanged;
            }
        }

        public static void SaveCurrentTheme(string appname)
        {
            Win32RegistryHelper.SaveValueToRegistry(appname, "Skin", WindowsFormsSettings.DefaultLookAndFeel.SkinName);
            Win32RegistryHelper.SaveValueToRegistry(appname, "Palette", WindowsFormsSettings.DefaultLookAndFeel.ActiveSvgPaletteName);
        }
    }
}