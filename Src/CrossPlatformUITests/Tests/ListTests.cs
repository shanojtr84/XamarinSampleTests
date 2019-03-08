/*using System;
using System.Linq;
using AventStack.ExtentReports;
using CrossPlatformUITests.Base;
using CrossPlatformUITests.Screens;
using CrossPlatformUITests.Support;
using NUnit.Framework;
using Xamarin.UITest;

namespace CrossPlatformUITests.Tests
{
    public class ListTests : BaseTest
    {
        public ListTests(Platform platform)
           : base(platform)
        {
            this.platform = platform;
        }

        AutoUtills Utills = new AutoUtills();

        [Test]
        public void TextDisplayTest()
        {
            // app.Repl();
            string username = Utills.ReadTestData("validCredentials", "userName");
            string password = Utills.ReadTestData("validCredentials", "password");
            string text = "Hola!!";


            ReportUtill.extentTest.Log(Status.Info, "Given I Launch the App");

            LoginScreen loginScreen = new LoginScreen(app, platform);
            SignUpScreen signUpScreen = loginScreen.TapSignUpButton();
            signUpScreen.PerformSignUp(username, password);
            ReportUtill.extentTest.Log(Status.Info, "When I login into the App");
            FirstPageScreen firstPageScreen = loginScreen.PerformLogin(username, password);
            ReportUtill.extentTest.Log(Status.Info, "And I enter the text and tap on go button");
            firstPageScreen.EnterYourText(text)
                           .TapGoButton()
                           .WaitForLoadingSpinnerToDisappear();
            ReportUtill.extentTest.Log(Status.Info, "Then I confirm text is displayed");
            Assert.AreEqual(text, firstPageScreen.GetTextLabel(), "Entered Text is not displayed");
        }

        [Test]
        public void ListTest()
        {
            // app.Repl();
            string username = Utills.ReadTestData("validCredentials", "userName");
            string password = Utills.ReadTestData("validCredentials", "password");
            string listitem = "1";

            ReportUtill.extentTest.Log(Status.Info, "Given I Launch the App");
            LoginScreen loginScreen = new LoginScreen(app, platform);
            SignUpScreen signUpScreen = loginScreen.TapSignUpButton();
            signUpScreen.PerformSignUp(username, password);
            ReportUtill.extentTest.Log(Status.Info, "When I log into the App");
            FirstPageScreen firstPageScreen = loginScreen.PerformLogin(username, password);
            ReportUtill.extentTest.Log(Status.Info, "And I navigate to the list screen");
            ListScreen listScreen = firstPageScreen.NavigateToListScreen();
            ReportUtill.extentTest.Log(Status.Info, "Then I confirm list items are displayed");
            Assert.IsTrue(listScreen.QueryListItemNumber(listitem).Any(), "List item is not displayed");
        }
    }
}
*/