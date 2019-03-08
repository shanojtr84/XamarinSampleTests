using System;
using System.IO;
using System.Linq;
using CrossPlatformUITests.Config;
using Xamarin.UITest;
using Xamarin.UITest.Configuration;
using Xamarin.UITest.Queries;

namespace CrossPlatformUITests.Base
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            // TODO: If the iOS or Android app being tested is included in the solution 
            // then open the Unit Tests window, right click Test Apps, select Add App Project
            // and select the app projects that should be tested.
            //
            // The iOS project should have the Xamarin.TestCloud.Agent NuGet package
            // installed. To start the Test Cloud Agent the following code should be
            // added to the FinishedLaunching method of the AppDelegate:
            //
            //    #if ENABLE_TEST_CLOUD
            //    Xamarin.Calabash.Start();
            //    #endif

            AppConfigReader config = new AppConfigReader();
            string appBundle = config.GetAppPackage();

            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .InstalledApp(appBundle)
                    // .EnableLocalScreenshots()
                    // TODO: Update this path to point to your Android app and uncomment the
                    // code if the app is not included in the solution.
                    //.ApkFile ("../../../Droid/bin/Debug/xamarinforms.apk")
                    //.ApkFile("/Users/shanoj/Desktop/app.apk")
                    .StartApp();
                //Xamarin.UITest.Configuration.AppDataMode.Clear
            }

            return ConfigureApp
                .iOS

                // TODO: Update this path to point to your iOS app and uncomment the
                // code if the app is not included in the solution.
                // .AppBundle ("../../../iOS/bin/iPhoneSimulator/Debug/XamarinForms.iOS.app")
                // .AppBundle("/Users/shanoj/Desktop/xamarinUITest/UITestSampleApp-master/Src/UITestSampleApp.iOS/bin/iPhone/Debug/UITestSampleApp.iOS.app")
                // .InstalledApp(appBundle)
                .EnableLocalScreenshots()
                // .DeviceIdentifier("4b07dfc8a642d8f9df1085139409668fde3244d5")
                // .DeviceIdentifier("50CD274F-2B3C-465B-ABB5-D9CC334521A2")
                .StartApp();
        }
    }
}
