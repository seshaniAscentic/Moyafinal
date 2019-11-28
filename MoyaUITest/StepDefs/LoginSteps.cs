using MoyaUITest.DataObjects;
using MoyaUITest.Pages;
using System;
using TechTalk.SpecFlow;
using TestBase;

namespace MoyaUITest.StepDefs
{
    [Binding]
    public class LoginSteps
    {
        [Given(@"That I have launch the ""(.*)"" browser")]
        public void GivenThatIHaveLaunchTheBrowser(string browserType)
        {
            var status = DriverConnections.GetBrowserStatus();
            if (!status.Equals(Data.BaseURL))
            {
                DriverConnections.StartBrowser(Data.BrowserType);
            }
        }
        
        [Given(@"Navigates to the ""(.*)"" Login page")]
        public void GivenNavigatesToTheLoginPage(string title)
        {
            var status = DriverConnections.GetBrowserStatus();
            if (!status.Equals(Data.BaseURL))
            {
                DriverConnections.GotoURL(Data.BaseURL);
                new LoginPage()
                    .Verify_the_Page_Title(title);
            }
        }
        
        [Given(@"I have entered correct value for username and password")]
        public void GivenIHaveEnteredCorrectValueForUsernameAndPassword(Table table)
        {
            new LoginPage()
                .Enter_Username_and_Password(Data.Username, Data.Password);
        }
        
        [Given(@"I have entered invalid value for username and password")]
        public void GivenIHaveEnteredInvalidValueForUsernameAndPassword(Table table)
        {
            new LoginPage()
                 .Enter_Username_and_Password(Data.Username, Data.Bad_Password);
        }
        
        [When(@"I click on the signin button")]
        public void WhenIClickOnTheSigninButton()
        {
            new LoginPage()
               .Enter_SignIn_button();
        }
        
        [When(@"I click on the logout button")]
        public void WhenIClickOnTheLogoutButton()
        {
            new LoginPage()
                 .Step_ClickOn_LogOut_button()
                 .Step_ClickOn_LogOut_Confirm_button();
        }
        
        [Then(@"I should be able to login to the system successfully")]
        public void ThenIShouldBeAbleToLoginToTheSystemSuccessfully()
        {
            new LoginPage()
                .Press_SignIn_Confirm_button()
                .Switched_to_ContoleCenter_Window();
        }
        
        [Then(@"I verify the profile name ""(.*)""")]
        public void ThenIVerifyTheProfileName(string p0)
        {
            new LoginPage()
                  .Verify_the_login_user_profile(Data.Profile);
        }
        
        [Then(@"I verify the login page header ""(.*)""")]
        public void ThenIVerifyTheLoginPageHeader(string header)
        {
            new LoginPage()
                 .Verify_the_login_page_header(header);
        }
        
        [Then(@"I should NOT be able to login successfully")]
        public void ThenIShouldNOTBeAbleToLoginSuccessfully()
        {
            new LoginPage()
             .Verify_the_Password_Error_MessageIs_Available();
        }
        
        [Then(@"I verify the error message ""(.*)""")]
        public void ThenIVerifyTheErrorMessage(string expected)
        {
            new LoginPage()
                .Verify_the_Password_Error_Message(expected);
        }
    }
}
