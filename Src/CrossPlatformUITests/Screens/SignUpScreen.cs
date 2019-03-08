using System;
using CrossPlatformUITests.Support;
using Xamarin.UITest;
using UIElement = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;
namespace CrossPlatformUITests.Screens
{
    public class SignUpScreen : XamarinUITestWrapper
    {
        public SignUpScreen(IApp app, Platform platform)
        : base(app, platform)
        {
            WaitForScreenToload();
        }

        private UIElement _UsernameTextField => x => x.Marked("NewUserSignUpPage_NewUserNameEntry");
        private UIElement _PasswordTextField => x => x.Marked("NewUserSignUpPage_NewPasswordEntry");
        private UIElement _SaverUserNameButton => x => x.Marked("NewUserSignUpPage_SaveUsernameButton");
        private UIElement _CancelButton => x => x.Marked("Cancel");

        public void EnterNewUsername(string userName)
        {

            TypeText(_UsernameTextField, userName);
     
        }

        public void TapNewUsernameField()
        {
            TapOn(_UsernameTextField);   
        }

        public void EnterNewPassword(string password)
        {
           
            TypeText(_PasswordTextField, password);
            DismissDeviceKeyboard();
        }

        public void TapSaveUserNameButton()
        {
            TapOn(_SaverUserNameButton);
        }
        public LoginScreen TapCancelButton()
        {
            TapOn(_CancelButton);
            return new LoginScreen(app, platform);
        }

        public LoginScreen PerformSignUp(string userName, string password)
        {
            EnterNewUsername(userName);
            EnterNewPassword(password);
            DismissDeviceKeyboard();
            TapSaveUserNameButton();
            return new LoginScreen(app,platform);
        }

        public void WaitForScreenToload()
        {
            WaitForUIElement(_UsernameTextField, "SingUp Screen Not Displayed",60);
        }
    }
}
