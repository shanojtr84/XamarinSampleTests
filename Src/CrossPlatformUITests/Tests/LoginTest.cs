using System;
using System.Linq;
using CrossPlatformUITests.Base;
using CrossPlatformUITests.Screens;
using CrossPlatformUITests.Support;
using CrossPlatformUITests.Constants;
using NUnit.Framework;
using Xamarin.UITest;
using AventStack.ExtentReports;

namespace CrossPlatformUITests.Tests
{

    public class LoginTest : BaseTest
    {
        public LoginTest(Platform platform)
           : base(platform)
        {
            this.platform = platform;
        }

        AutoUtills Utills = new AutoUtills();
        [Test]
        public void SignUpAndLoginTest()
        {
            // app.Repl();
            string username = Utills.ReadTestData("validCredentials", "userName");
            string password = Utills.ReadTestData("validCredentials", "password");

            //  ReportUtill.extentTest.Log(Status.Info, "Given I Launch the App and Navigate to Sigup Screen");
            LoginScreen loginScreen = new LoginScreen(app, platform);
            SignUpScreen signUpScreen = loginScreen.TapSignUpButton();
            //  ReportUtill.extentTest.Log(Status.Info, "And  I Sign Up for a new account");
            signUpScreen.PerformSignUp(username, password);
            //  ReportUtill.extentTest.Log(Status.Info, "When  I login to the App");
            FirstPageScreen firstPageScreen = loginScreen.PerformLogin(username, password);
            //  ReportUtill.extentTest.Log(Status.Info, "Then   I confirm ,successful login");
            Assert.IsTrue(firstPageScreen.QueryGoButton().Any(), "Not loged in.");
        }

        //  [Test]
        public void InValidLoginTest()
        {
            // app.Repl();
            string username = Utills.ReadTestData("inValidCredentials", "userName");
            string password = Utills.ReadTestData("inValidCredentials", "password");

            // ReportUtill.extentTest.Log(Status.Info, "Given I Launch the App");
            LoginScreen loginScreen = new LoginScreen(app, platform);
            // ReportUtill.extentTest.Log(Status.Info, "When I enter username");
            loginScreen.EnterUsername(username);
            // ReportUtill.extentTest.Log(Status.Info, "And I enter password");
            loginScreen.EnterPassword(password);
            //  ReportUtill.extentTest.Log(Status.Info, "When I tap on login button");
            loginScreen.TapLoginButton();
            loginScreen.WaitForLoginError();
            //  ReportUtill.extentTest.Log(Status.Info, "Then I confirm login error message is displayed");
            Assert.IsTrue(loginScreen.VerifyErrorText(Copy.LOGIN_ERROR_TITLE).Any());
            Assert.IsTrue(loginScreen.VerifyErrorText(Copy.LOGIN_ERROR_MESSAGE).Any());
            loginScreen.TapTryAgainButton();
        }

        //  [Test]
        public void CancelSignUpTest()
        {
            //app.Repl();
            string username = Utills.ReadTestData("validCredentials", "userName");
            string password = Utills.ReadTestData("validCredentials", "password");
            //  ReportUtill.extentTest.Log(Status.Info, "Given I Launch the App");
            LoginScreen loginScreen = new LoginScreen(app, platform);
            // ReportUtill.extentTest.Log(Status.Info, "When I tap on sign up button");
            SignUpScreen signUpScreen = loginScreen.TapSignUpButton();
            // ReportUtill.extentTest.Log(Status.Info, "When I enter a new username");
            signUpScreen.EnterNewUsername(username);
            // ReportUtill.extentTest.Log(Status.Info, "And I enter a new password");
            signUpScreen.EnterNewPassword(password);
            // ReportUtill.extentTest.Log(Status.Info, "When I tap on cancel button");
            signUpScreen.TapCancelButton();
            // ReportUtill.extentTest.Log(Status.Info, "Then I confirm sign up is cancelled");
            Assert.IsTrue(loginScreen.QueryLoginButton().Any(), "Signup cancel unsuccessful.");
        }

    }
}
