using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using CrossPlatformUITests.Support;
using NUnit.Framework;
using Xamarin.UITest;

namespace CrossPlatformUITests.Base
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public abstract class BaseTest
    {
        public IApp app;
        public Platform platform;

        AutoUtills utills = new AutoUtills();
        // ReportUtill reportutills = new ReportUtill();

        protected BaseTest(Platform platform)
        {
            this.platform = platform;

        }

        [SetUp]
        public virtual void BeforeEachTest()
        {
            //reportutills.GetExtentReportInstance(platform);
            // extentTest = ReportManager.CreateTest(TestContext.CurrentContext.Test.Name);
            // reportutills.CreateExtentTest(TestContext.CurrentContext.Test.Name);
            app = AppInitializer.StartApp(platform);
        }

        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Status;
            string testName = TestContext.CurrentContext.Test.Name;
            //reportutills.LogExtentTestStatusToReport(status, testName, app, platform);
            // reportutills.SaveExtentReport();
        }

        /*  public ExtentReports GetExtentReportInstance()
          {

              if (ReportManager == null)
              {
                  string Platform = platform.ToString();
                  //To create report directory and add HTML report into it
                  string HtmlReportFullPath = utills.GetProjectPath() + "Reports/" + platform.ToString() + "_Test_Report.html";

                  ReportManager = new ExtentReports();
                  var htmlReporter = new ExtentHtmlReporter(HtmlReportFullPath);
                  htmlReporter.Configuration().DocumentTitle = platform.ToString() + " Automation Report";
                  htmlReporter.Configuration().Encoding = "UTF-8";
                  htmlReporter.Configuration().Theme = Theme.Dark;
                  ReportManager.AddSystemInfo("Environment", "QA");
                  ReportManager.AddSystemInfo("Tester", "Shanoj");
                  ReportManager.AddSystemInfo("Team", "SDL");
                  ReportManager.AddSystemInfo("Platform", platform.ToString());
                  ReportManager.AttachReporter(htmlReporter);
              }
              return ReportManager;

          }

          public void SaveExtentReport()
          {

              ReportManager.Flush();
          }
  */
        /* public void LogExtentTestStatusToReport(TestStatus status, string testName)
         {
             Status logstatus;
             switch (status)
             {
                 case TestStatus.Failed:
                     logstatus = Status.Fail;
                     extentTest.Log(logstatus, "Test " + logstatus + "ed");
                     string screenShotPath = utills.TakeScreenShot(testName, app, platform);
                     extentTest.Log(logstatus, "Refer to below Snapshot: " + AttachScreenShotToReport(screenShotPath));
                     break;
                 case TestStatus.Skipped:
                     logstatus = Status.Skip;
                     extentTest.Log(logstatus, "Test " + logstatus + "ed");
                     break;
                 default:
                     logstatus = Status.Pass;
                     extentTest.Log(logstatus, "Test " + logstatus + "ed");
                     break;
             }

         }


         public ExtentTest AttachScreenShotToReport(string screenShotPath)
         {
             return extentTest.AddScreenCaptureFromPath(new Uri(screenShotPath).LocalPath);

         }*/
    }
}
