using Xamarin.UITest;

namespace UITestSampleApp.UITests
{
    static class AppInitializer
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
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    // TODO: Update this path to point to your Android app and uncomment the
                    // code if the app is not included in the solution.
                    //.ApkFile ("../../../Droid/bin/Debug/xamarinforms.apk")
                    .InstalledApp("com.minnick.uitestsampleapp")
                    .StartApp();
            }

            return ConfigureApp
                .iOS
                // TODO: Update this path to point to your iOS app and uncomment the
                // code if the app is not included in the solution.
                //.AppBundle ("../../../iOS/bin/iPhoneSimulator/Debug/XamarinForms.iOS.app")
               .DeviceIdentifier("4b07dfc8a642d8f9df1085139409668fde3244d5")
               // .AppBundle("../../../EAXamarinApp/EAXamarinApp.iOS/bin/iPhoneSimulator/Debug/device-builds/iphone9.1-12.1/EAXamarinApp.iOS.app")
                .InstalledApp("com.minnick.uitestsampleapp")
                .StartApp();
        }
    }
}

