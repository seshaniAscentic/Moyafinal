using MoyaUITest.DataObjects;
using MoyaUITest.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestBase;

namespace MoyaUITest.Tests
{
    [TestFixture]
    public class LoginTest
    {
        [SetUp]
        public void BrowserLaunch()
        {
            DriverConnections.StartBrowser(Data.BrowserType);
            DriverConnections.GotoURL(Data.BaseURL);
        }
        [Test]
        public void TC001_Login_to_the_application_using_valid_credentials()
        {
            new LoginPage()
                .Enter_Windows_Credentials(Data.Username, Data.Password)
                .Switched_to_ContoleCenter_Window()
                .Verify_the_login_user_profile(Data.Profile);
        }
        [Test]
        public void TC002_LogOut_from_the_application_using_valid_credentials()
        {
            new LoginPage()
                   .Enter_Windows_Credentials(Data.Username, Data.Password)
                   .Switched_to_ContoleCenter_Window()
                   .Verify_the_login_user_profile(Data.Profile)
                   .Step_ClickOn_LogOut_button()
                   .Step_ClickOn_LogOut_Confirm_button()
                   .Verify_the_login_user_profileNot_Visible(Data.Profile);
        }
        [TearDown]
        public void BrowserTearDown()
        {
            DriverConnections.StopBrowser();
        }
    }
}
