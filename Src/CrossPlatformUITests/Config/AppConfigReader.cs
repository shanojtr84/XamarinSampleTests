using System;
using System.Configuration;
using Xamarin.UITest;

namespace CrossPlatformUITests.Config
{
    public class AppConfigReader
    {
        public Platform GetPlatform()
        {
            return (Platform)Enum.Parse(typeof(Platform), ConfigurationManager.AppSettings.Get(AppConfigKeys.platform));
        }

        public string GetAppPackage()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.appPackage);
        }

        public string GetAppPath()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.appPath);
        }
    }
}
