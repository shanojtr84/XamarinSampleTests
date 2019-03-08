using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using Xamarin.UITest;

namespace CrossPlatformUITests.Support
{
    public class ReportUtill
    {
        public static ExtentReports ReportManager;
        public static ExtentTest extentTest;
        AutoUtills utills = new AutoUtills();
        public ExtentReports GetExtentReportInstance(Platform platform)
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

        public void LogExtentTestStatusToReport(TestStatus status, string testName,IApp app,Platform platform)
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

        }

        public ExtentTest CreateExtentTest(string testName){
            extentTest = ReportManager.CreateTest(testName);
            return extentTest;
        }
    }
}
