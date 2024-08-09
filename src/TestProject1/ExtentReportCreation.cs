using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class ExtentReportCreation
    {
        private static ExtentReports _report;
        private static ExtentTest _test;

        private static ExtentReports StartReporting()
        {
            var path = "D:\\C++ Selenium project\\TestProject1\\Reports";
            if(_report == null)
            {
                Directory.CreateDirectory(path);

                _report = new ExtentReports();
                var htmlReporter = new ExtentSparkReporter(path);

                _report.AttachReporter(htmlReporter);
            }
            return _report;
        }

        public static void CreateTest(string testName) => _test = StartReporting().CreateTest(testName);

        public static void EndReporting() => StartReporting().Flush();

        public static void LogInfo(string info) => _test.Info(info);

        public static void LogPass(string info) => _test.Pass(info);

        public static void LogFail(string info) => _test.Fail(info);

        public static void LogScreenShot(string info, string image) =>
            _test.Info(info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());

    }
}
