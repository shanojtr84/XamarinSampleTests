﻿using Android.App;
using Android.Bluetooth;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;

using Java.Interop;

using Plugin.CurrentActivity;

namespace UITestSampleApp.Droid
{
    [Activity(Theme = "@style/MyTheme", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {


        #region Methods
        #region Xamarin Test Cloud Back Door Methods
#if DEBUG
        [Preserve, Export(nameof(BypassLoginScreen))]
        public void BypassLoginScreen() => BackdoorMethodHelpers.BypassLoginScreen();

        [Preserve, Export(nameof(OpenListViewPage))]
        public void OpenListViewPage() => BackdoorMethodHelpers.OpenListViewPage();

        [Preserve, Export(nameof(GetSerializedListViewPageData))]
        public string GetSerializedListViewPageData() => BackdoorMethodHelpers.GetSerializedListViewPageData();

        [Export("ChangeBTStateTo")]
        public void ChangeBTStateTo(string state)
        {
            Android.Bluetooth.BluetoothAdapter bluetootAdapter = BluetoothAdapter.DefaultAdapter;

            if (state == "ON")
            {
                if (bluetootAdapter.IsEnabled == false)
                {
                    bluetootAdapter.Enable();
                }
            }
            else
            {
                if (bluetootAdapter.IsEnabled == true)
                {
                    bluetootAdapter.Disable();
                }
            }
        }
#endif
        #endregion

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {


            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            TabLayoutResource = Resource.Layout.tabs;
            ToolbarResource = Resource.Layout.toolbar;

            CrossCurrentActivity.Current.Init(this, savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.SetFlags("FastRenderers_Experimental");
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Xamarin.Forms.Platform.Android.AppLinks.AndroidAppLinks.Init(this);

            Firebase.FirebaseApp.InitializeApp(this);

            Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

            LoadApplication(new App());
        }
        #endregion
    }
}

