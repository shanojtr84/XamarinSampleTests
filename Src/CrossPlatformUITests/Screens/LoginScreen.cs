using System;
using CrossPlatformUITests.Support;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using UIElement = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;
namespace CrossPlatformUITests.Screens
{
    public class LoginScreen : XamarinUITestWrapper
    {
        public LoginScreen(IApp app, Platform platform)
          : base(app, platform)
        {
            WaitForScreenToload();
        }
        private UIElement _UsernameTextField => x => x.Marked("LoginPage_UsernameEntry");
        private UIElement _PasswordTextField => x => x.Marked("LoginPage_PasswordEntry");
        private UIElement _LoginButton => x => x.Marked("Login");
        private UIElement _SignUpButton => x => x.Marked("Sign-up");
        private UIElement _TryAgainButton => x => x.Marked("Try again");

        public void EnterUsername(string userName)
        {
            TypeText(_UsernameTextField, userName);

        }

        public void EnterPassword(string password)
        {
            TypeText(_PasswordTextField, password);
        }

        public void TapLoginButton()
        {
            TapOn(_LoginButton);
        }
        public void TapTryAgainButton()
        {
            TapOn(_TryAgainButton);
        }

        public SignUpScreen TapSignUpButton()
        {
            WaitForUIElement(_SignUpButton, "Sign UP Button not found",5);
            TapOn(_SignUpButton);
            return new SignUpScreen(app,platform);
        }

        public FirstPageScreen PerformLogin(string userName, string password)
        {
            WaitForUIElement(_UsernameTextField, "Sign UP Button not found", 5);
            EnterUsername(userName);
            EnterPassword(password);
            TapLoginButton();
            return new FirstPageScreen(app,platform);
        }

        public void WaitForScreenToload()
        {
            WaitForUIElement(_UsernameTextField, "Login Screen Not Displayed",60);
        }

        public AppResult[] VerifyErrorText(string text)
        {

            return QueryByText(text);
        }

        public AppResult[] QueryUsernameTextField()
        {
            return UIElementQuery(_UsernameTextField);
        }

        public AppResult[] QueryLoginButton()
        {
            return UIElementQuery(_LoginButton);
        }

        public void WaitForLoginError()
        {
            WaitForUIElement(_TryAgainButton, "Login Error Not Displayed");

        }
    }
}
