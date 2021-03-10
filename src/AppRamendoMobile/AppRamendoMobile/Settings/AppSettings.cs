using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppRammendoMobile.Settings
{
    public class AppSettings
    {

        private static ISettings Settings =>
         CrossSettings.Current;

        public static string Pin
        {
            get => Settings.GetValueOrDefault(nameof(Pin), default(string));
            set => Settings.AddOrUpdateValue(nameof(Pin), value);
        }
        public static int TotalQty
        {
            get => Settings.GetValueOrDefault(nameof(TotalQty), default(int));
            set => Settings.AddOrUpdateValue(nameof(TotalQty), value);
        }

        public static DateTime CurrentDay
            {
            get => Settings.GetValueOrDefault(nameof(CurrentDay), default(DateTime));
            set => Settings.AddOrUpdateValue(nameof(CurrentDay), value);
        }
}
}
