using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;

namespace TestBase
{
    public static class DriverConnections
    {
        public static WebDriverWait _webDriverWait;
        public static IWebDriver _driver;

        public static IWebDriver Browser
        {
            get
            {
                if (_driver == null)
                {
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method Start.");
                }
                return _driver;
            }
            private set => _driver = value;
        }

        public static void StopBrowser()
        {
            if (_driver!= null)
            {
                _driver.Quit();
                _driver.Dispose();
                _driver = null;
                _webDriverWait = null;
            }
        }

        public static WebDriverWait BrowserWait
        {
            get
            {
                if (_webDriverWait == null)
                {
                    throw new NullReferenceException("The WebDriver browser wait instance was not initialized. You should first call the method Start.");
                }
                return _webDriverWait;
            }
            private set => _webDriverWait = value;
        }

        public static void StartBrowser(string browserType, int defaultTimeOut = 30)
        {
            Console.WriteLine("**************Browser getting started and Test initiation prosess get started***************");
            if (browserType.Equals("Chrome"))
            {
                _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            }
            if (browserType.Equals("Firefox"))
            {
                _driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            }
            if (browserType.Equals("IE"))
            {
                InternetExplorerOptions options = new InternetExplorerOptions { IntroduceInstabilityByIgnoringProtectedModeSettings = true };
                _driver = new InternetExplorerDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
            }
            if (browserType.Equals("Edge"))
            {
                _driver = new EdgeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            }
            if (browserType.Equals("Headless"))
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--headless");
                _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
            }
            Console.WriteLine("*******   " + browserType.ToString() + "  ******** Getting opened to continue the testing process");
        }

        public static void GotoURL(string url)
        {
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Constants._defaultTimeout);
            _driver.Manage().Window.Maximize();
            _driver.Manage().Window.Size = new Size(1360, 768);
        }

        public static string GetBrowserStatus()
        {
            try
            {
                return _driver.Url;
            }
            catch (Exception)
            {
                return "Driver not loaded";
            }
        }
    }
}
