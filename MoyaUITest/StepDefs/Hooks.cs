using MoyaUITest.DataObjects;
using MoyaUITest.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TestBase;

namespace MoyaUITest.StepDefs
{
    [Binding]
    public sealed class Hooks
    {
        [AfterFeature]
        public static void AfterAuthenticationFeatuer()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var screenshot = ((ITakesScreenshot)DriverConnections.Browser).GetScreenshot();
                var filename = TestContext.CurrentContext.Test.Name + "_screenshot_" + DateTime.Now.Ticks + ".Png";
                var path = Path.Combine(TestContext.CurrentContext.WorkDirectory, filename);
                screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
                TestContext.AddTestAttachment(path);
            }
            DriverConnections.StopBrowser();
        }

        // Login scenarios need to close the browser session each and every scenario end
        // therefor use the @Login tag in the feature file which need to end browser seperatly
        [AfterScenario("Login")]
        public static void AfterAuthenticationScenario()
        {
            DriverConnections.StopBrowser();
        }

        [BeforeFeature("authentication")]
        public static void BeforeAuthenticationScenario()
        {
            DriverConnections.StartBrowser(Data.BrowserType);
            DriverConnections.GotoURL(Data.BaseURL);
            new LoginPage()
                .Login_to_the_system(Data.Username, Data.Password);
        }
    }
}
