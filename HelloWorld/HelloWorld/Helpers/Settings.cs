using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static string UserName
        {
            get => AppSettings.GetValueOrDefault("UserName", "");
            set => AppSettings.AddOrUpdateValue("UserName", value);
        }

        public static string Password
        {
            get => AppSettings.GetValueOrDefault("Password", "");
            set => AppSettings.AddOrUpdateValue("Password", value);
        }

        public static string AccessToken
        {
            get => AppSettings.GetValueOrDefault("AccessToken", "");
            set => AppSettings.AddOrUpdateValue("AccessToken", value);
        }
    }
}
