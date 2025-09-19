namespace TestSpreadsheet
{
    public static class FormBoundsHelper
    {
        public static string APP_NAME { get; set; } = Application.ProductName ?? "Falcon Matrix";
        public static void AddFormBoundsRegistryStorage(this Form form)
        {
            form.Load += (s, e) => form.LoadFormValuesFromRegistry();
            form.FormClosed += (s, e) => form.SaveFormValuesToRegistry();
        }

        public static void LoadFormValuesFromRegistry(this Form form)
        {
            var state = Win32RegistryHelper.GetIntValue(APP_NAME, "WindowState", 0) ?? 0;
            var locationx = Win32RegistryHelper.GetIntValue(APP_NAME, "Location.X");
            var locationy = Win32RegistryHelper.GetIntValue(APP_NAME, "Location.Y");
            var location = new Point(locationx ?? 0, locationy ?? 0);
            if (!location.IsEmpty)
            {
                form.StartPosition = FormStartPosition.Manual;
                form.Location = location;
            }
            var sizewidth = Win32RegistryHelper.GetIntValue(APP_NAME, "Size.Width");
            var sizeheight = Win32RegistryHelper.GetIntValue(APP_NAME, "Size.Height");
            if (Screen.PrimaryScreen is not null)
            {
                var size = new Size(sizewidth ??
                    (int)(Screen.PrimaryScreen.WorkingArea.Width * 0.35), sizeheight ??
                    (int)(Screen.PrimaryScreen.WorkingArea.Height * 0.35));
                form.Size = size;
            }
            form.WindowState = (FormWindowState)state;
        }

        public static void SaveFormValuesToRegistry(this Form form)
        {
            if (form.WindowState != FormWindowState.Minimized)
                Win32RegistryHelper.SaveValue(APP_NAME, "WindowState", (int)form.WindowState);
            if (form.WindowState == FormWindowState.Normal)
            {
                Win32RegistryHelper.SaveValue(APP_NAME, "Location.X", form.Location.X);
                Win32RegistryHelper.SaveValue(APP_NAME, "Location.Y", form.Location.Y);
                Win32RegistryHelper.SaveValue(APP_NAME, "Size.Width", form.Size.Width);
                Win32RegistryHelper.SaveValue(APP_NAME, "Size.Height", form.Size.Height);
            }
        }

    }
}