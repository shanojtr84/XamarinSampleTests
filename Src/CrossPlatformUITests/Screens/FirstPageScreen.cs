using System;
using CrossPlatformUITests.Support;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using UIElement = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;
namespace CrossPlatformUITests.Screens
{
    public class FirstPageScreen : XamarinUITestWrapper
    {
        public FirstPageScreen(IApp app, Platform platform)
          : base(app, platform)
        {
            WaitForScreenToload();
        }

        private UIElement _GoButton => x => x.Marked("Go");
        private UIElement _GoToListPageButton => x => x.Marked("Go to List Page");
        private UIElement _TextEntryField => x => x.Marked("FirstPage_TextEntry");
        private UIElement _TextLabel => x => x.Marked("FirstPage_TextLabel");
        private UIElement _LoadingSpinner => x => x.Marked("FirstPage_BusyActivityIndicator");

        public FirstPageScreen TapGoButton()
        {
            TapOn(_GoButton);
            return this;
        }

        public void TapGoToListPageButton()
        {
            TapOn(_GoToListPageButton);
        }

        public ListScreen NavigateToListScreen()
        {
            TapOn(_GoToListPageButton);
            return new ListScreen(app, platform);
        }

        public FirstPageScreen EnterYourText(string text)
        {
            TypeText(_TextEntryField,text);
            return this;
        }

        public void WaitForScreenToload()
        {
            WaitForUIElement(_GoButton, "First page is not displayed");
        }

        public void WaitForLoadingSpinnerToDisappear()
        {
            WaitForUIElementToDisappear(_LoadingSpinner, "Loading spinner is still displayed");
        }

        public AppResult[] QueryGoButton()
        {
            return UIElementQuery(_GoButton);
        }

        public string GetTextLabel()
        {
            return GetUIElementText(_TextLabel);
        }

    }
}
