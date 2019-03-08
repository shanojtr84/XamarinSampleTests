using System;
using Xamarin.UITest;

namespace CrossPlatformUITests.Base
{
    public class BaseScreen
    {
        protected readonly IApp app;
        protected readonly Platform platform;

        protected BaseScreen(IApp app, Platform platform)
        {
            this.app = app;

            this.platform = platform;

        }
    }
}
