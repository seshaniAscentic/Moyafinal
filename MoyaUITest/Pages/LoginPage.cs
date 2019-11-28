using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestBase;

namespace MoyaUITest.Pages
{
    public class LoginPage
    {
        readonly IWebDriver _driver;
        // Login page UI element locators
        readonly By _btnLogin = By.Id("login-btn");
        readonly By _txtUsername = By.Id("i0116");
        //readonly By _errormessageUsernameerror = By.Id("usernameError");
        readonly By _btnNext = By.Id("idSIButton9");
        readonly By _txtPassword = By.Id("i0118");
        readonly By _btnSignin = By.Id("idSIButton9");
        readonly By _lblLoginError = By.XPath("//*[@id='passwordError']");
        readonly By _btnProfile = By.XPath("//*[@id='root']/section/header/ul/li[8]");
        readonly By _btnLogOut = By.XPath("//*[@id='item_3$Menu']/li/ul/li[2]");
        readonly By _btnConfirmLogout = By.XPath("//*[@id='tilesHolder']/div/div/div/div");
        readonly By _lblProfile = By.XPath("//*[@id='root']/section/header/ul/li[8]/div/span");
        readonly By _lblHeader = By.Id("login_workload_logo_text");
        readonly By _Newgamebtn = By.XPath("//*[@id='root']/section/main/div[1]/div/div[4]/button[3]");
        readonly By _GameName = By.Id("gameName");
        readonly By _StarDate = By.ClassName("ant-calendar-picker-input ant-input");
        readonly By _Enddate = By.ClassName("ant-calendar-picker-input ant-input");
        readonly By _Submitbtn = By.XPath("//*[contains(@type,'sub')] ");
        readonly By _Cancelbtn = By.ClassName("ant-btn ant-btn-primary");
        readonly By _selectgame = By.ClassName("ant-select-search__field");
        readonly By _NewTeam = By.XPath("//*[@id='root']/section/main/div[2]/div/div[4]/h3/button");

        // Login page initialization 
        public LoginPage()
        {
            _driver = DriverConnections.Browser;
        }

        // Pressing the login button on login page
        public LoginPage Step_ClickOn_Login_button()
        {
            Elements.Click(_driver, _btnLogin);
            return this;
        }

        // Verifying the title of the page
        public LoginPage Verify_the_Page_Title(string expected)
        {
            Assert.AreEqual(expected, Elements.GetPageTitle(_driver));
            return this;
        }

        // Entering windows credentials 
        public LoginPage Enter_Windows_Credentials(string Username, string password)
        {
            Elements.WaitForElementOnPageLoad(3);
            //Elements.IsElementVisible(_driver, _errormessageUsernameerror);
            if (Elements.IsElementVisible(_driver, _txtUsername))
            {
                Elements.SendKeys(_driver, _txtUsername, Username);
            }
            Elements.Click(_driver, _btnNext);
            Elements.WaitForElementOnPageLoad(3);
            if (Elements.IsElementVisible(_driver, _txtPassword)) 
            {
                Elements.SendKeys(_driver, _txtPassword, password);
            }
            Elements.Click(_driver, _btnSignin);
            Elements.WaitForElementOnPageLoad(2);
            // To Do after login function stable 
            if (Elements.IsElementVisible(_driver, _btnSignin))
            {
                Elements.Click(_driver, _btnSignin);
            }
            Elements.WaitForElementOnPageLoad(2);
            return this;
        }

        // Enter the Usernam and Password without signin button click
        public LoginPage Enter_Username_and_Password(string username, string password)
        {
            Elements.SendKeys(_driver, _txtUsername, username);
            Elements.Click(_driver, _btnNext);
            Elements.SendKeys(_driver, _txtPassword, password);
            return this;
        }

        // Stepps for login to the system 
        public LoginPage Login_to_the_system(string username, string password)
        {
            Step_ClickOn_Login_button();
            Switched_to_Authentication_Window();
            Enter_Windows_Credentials(username, password);
            Switched_to_ContoleCenter_Window();
            Elements.WaitForElementOnPageLoad(2);
            return this;
        }

        // Click on the signin button 
        public LoginPage Enter_SignIn_button()
        {
            //The authentication window gets more time to load
            Elements.Click(_driver, _btnSignin);
            Elements.WaitForElementOnPageLoad(2);
            return this;
        }

        public LoginPage Press_SignIn_Confirm_button()
        {
            // To Do after login function stable The authentication window gets more time to load
            //New Login confirmation 
            if (Elements.IsElementVisible(_driver, _btnSignin))
            {
                Elements.Click(_driver, _btnSignin);
            }
            Elements.WaitForElementOnPageLoad(2);
            return this;
        }

        public void Verify_the_User_Navigates_to_the_LoginPage()
        {
            Assert.IsTrue(Elements.IsElementVisible(_driver, _btnLogin));
        }

        // Verify the login user profile is correct as expected
        public LoginPage Verify_the_login_user_profile(string expected)
        {
            Assert.IsNotEmpty(Elements.GetElementText(_driver, _lblProfile));
            return this;
        }

        // Switching the windows
        public LoginPage Switched_to_Authentication_Window()
        {
            Elements.SwitchToLatestWindow(_driver);
            return this;
        }

        // Switching the windows
        public LoginPage Switched_to_ContoleCenter_Window()
        {
            Elements.SwitchToLatestWindow(_driver);
            return this;
        }

        // Verifying the title of the page
        public LoginPage Verify_the_Password_Error_MessageIs_Available()
        {
            Elements.IsElementVisible(_driver, _lblLoginError);
            return this;
        }

        public LoginPage Verify_the_Password_Error_Message(string expected)
        {
            Elements.IsElementVisible(_driver, _lblLoginError);
            Assert.AreEqual(expected, Elements.GetElementText(_driver, _lblLoginError));
            return this;
        }

        // Pressing the logout button on home page
        public LoginPage Step_ClickOn_LogOut_button()
        {
            Elements.Click(_driver, _btnProfile);
            Elements.WaitForElementOnPageLoad(2);
            Elements.Click(_driver, _btnLogOut);
            return this;
        }

        // Pressing the logout confirm button on home page
        public LoginPage Step_ClickOn_LogOut_Confirm_button()
        {
            Elements.Click(_driver, _btnConfirmLogout);
            return this;
        }

        // Verify the login user profile is correct as expected
        public LoginPage Verify_the_login_user_profileNot_Visible(string expected)
        {
            Assert.True(Elements.IsElementNotVisible(_driver, _btnLogOut));
            return this;
        }

        public LoginPage Verify_the_login_page_header(string expected)
        {
            Assert.AreEqual(expected, Elements.GetElementText(_driver, _lblHeader));
            return this;
        }
    }
}
