using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestBase
{
    public class Elements
    {
        public IWebDriver _driver;

        public Elements()
        {
            _driver = DriverConnections.Browser;
        }

        //this will search for the element until a timeout is reached
        public static IWebElement WaitUntilElementVisible(IWebDriver _driver, By elementLocator)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Constants._defaultTimeout));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found.");
                throw;
            }
        }

        public static void Click(IWebDriver _driver, By by)
        {
            try
            {
                var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, seconds: Constants._defaultTimeout));
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
                element.Click();
            }
            catch (Exception ex)
            {
                if (ex is WebDriverTimeoutException || ex is NoSuchElementException)
                {
                    Assert.Fail("Element identified by " + by.ToString() + " not clickable after " + Constants._defaultTimeout.ToString() + " seconds" + ex);
                };
            }
        }

        public static void SendKeys(IWebDriver _driver, By by, string textToEnter)
        {
            try
            {
                var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, seconds: Constants._defaultTimeout));
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                // To Do after application response stable 
                // wait.Until(  d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
                element.Clear();
                element.SendKeys(textToEnter);
            }
            catch (Exception ex)
            {
                if (ex is NoSuchElementException || ex is WebDriverException)
                {
                    Assert.Fail("Could not perform SendKeys on element identified by " + by.ToString() + " after " + Constants._defaultTimeout.ToString() + " second " + ex);
                }
            }
        }

        public static void SelectDropDown(IWebDriver _driver, By by, string drpValue)
        {
            try
            {
                var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, seconds: Constants._defaultTimeout));
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeSelected(by));
                // To Do after application response stable 
                //new WebDriverWait(_driver, TimeSpan.FromSeconds(Constants.DefaultTimeout)).Until(ExpectedConditions.ElementToBeSelected(by));
                new SelectElement(_driver.FindElement(by)).SelectByText(drpValue);
            }
            catch (Exception ex)
            {
                if (ex is NoSuchElementException || ex is WebDriverException)
                {
                    Assert.Fail("Could not perform SendKeys on element identified by " + by.ToString() + " after " + Constants._defaultTimeout.ToString() + " second " + ex);
                }
            }
        }

        public static void ClickAndWaitForPageToLoad(IWebDriver _driver, By by)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Constants._defaultTimeout));
                var element = _driver.FindElement(by);
                element.Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(element));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Element with locator: '" + by.ToString() + "' was not found in current context page.");
                throw;
            }
        }

        public static void SwitchToLatestWindow(IWebDriver _driver)
        {
            var frame = _driver.WindowHandles.Last();
            try
            {
                // To Do after application response stable 
                //var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Constants._defaultTimeout));
                //var  window = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(frame));
                _driver.SwitchTo().Window(frame);
                WaitForElementOnPageLoad(5);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Element with locator: '" + frame.ToString() + "' was not found in current context page.");
                throw;
            }
        }
        public bool IsAvailable(IWebDriver _driver, By by)
        {
            return _driver.FindElement(by).Displayed;
        }

        public static string GetPageTitle(IWebDriver _driver)
        {
            return _driver.Title;
        }

        public static void WaitForElementOnPageLoad(int time)
        {
            Thread.Sleep(TimeSpan.FromSeconds(time));
        }

        public static void PressEnter(IWebDriver _driver, By by, string key)
        {
            _driver.FindElement(by).SendKeys(Keys.Enter);
        }

        public static string GetText(IWebDriver _driver, string text)
        {
            return _driver.FindElement(By.XPath("//*[contains(text(),'" + text + "')]")).Text;
        }

        public static bool IsElementVisible(IWebDriver _driver, By by)
        {
            return _driver.FindElements(by).Count > 0
                && _driver.FindElement(by).Displayed;
        }

        public static bool IsElementNotVisible(IWebDriver _driver, By by)
        {
            return !IsElementVisible(_driver, by);
        }

        public static string GetElementText(IWebDriver _driver, By by)
        {
            try
            {
                var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, seconds: Constants._defaultTimeout));
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return element.Text;
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Element with locator: '" + by.ToString() + "' was not found in current context page.");
                throw;
            }
        }

        public static string GetElementClass(IWebDriver _driver, By by)
        {
            return _driver.FindElement(by).GetAttribute("class").ToString();
        }

        public static bool SelectCheckBox(IWebDriver _driver, By by)
        {
            return _driver.FindElement(by).Selected;
        }

        public static void KeyPress(IWebDriver _driver, By by, string key)
        {
            try
            {
                var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, seconds: Constants._defaultTimeout));
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                switch (key.ToString())
                {
                    case "Delete":
                        _driver.FindElement(by).SendKeys(Keys.Control + 'a');
                        _driver.FindElement(by).SendKeys(Keys.Backspace);
                        break;
                    case "Enter":
                        _driver.FindElement(by).SendKeys(Keys.Enter);
                        break;
                    case "Back":
                        _driver.FindElement(by).SendKeys(Keys.Backspace);
                        break;
                    case "PageDown":
                        _driver.FindElement(by).SendKeys(Keys.PageDown);
                        break;
                    case "Tab":
                        _driver.FindElement(by).SendKeys(Keys.Tab);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                if (ex is NoSuchElementException || ex is WebDriverException)
                {
                    Assert.Fail("Could not perform KeyPress event on element identified by " + by.ToString() + " after " + Constants._defaultTimeout.ToString() + " second " + ex);
                }
            }
        }

        public static void SelectItemList(IWebDriver _driver, By by, string item)
        {
            var option = _driver.FindElement(by);
            var selectElement = new SelectElement(option);
            selectElement.SelectByText(item);
        }

        public static IList<IWebElement> GetList(IWebDriver _drive, By by)
        {
            IList<IWebElement> list = _drive.FindElements(by);
            var size = list.Count;
            return list;
        }

        public static void SelectItemListFromElement(IWebDriver _driver, IWebElement element, string item)
        {
            var option = element;
            var selectElement = new SelectElement(option);
            selectElement.SelectByText(item);
        }

        public static string GetElementTextFromElement(IWebDriver _driver, IWebElement element, string text)
        {
            // To Do after application response stable 
            //var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, seconds: Constants._defaultTimeout));
            //var b = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(element,text));
            return element.Text;
        }

        public static void ExecuteScript(IWebDriver _driver, string message)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("tinyMCE.activeEditor.selection.setContent('" + message + " changed! ')");
        }

        public static void WindowScroll(IWebDriver _driver, string direction)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
        }

        public static void WindowScrollToElement(IWebDriver _driver, By by)
        {
            var element = _driver.FindElement(by);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView();", element);
        }
    }
}
