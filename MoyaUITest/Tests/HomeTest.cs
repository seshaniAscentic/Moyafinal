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
    public class HomeTest
    {
        [SetUp]
        public void BrowserLaunch()
        {
            DriverConnections.StartBrowser(Data.BrowserType);
            DriverConnections.GotoURL(Data.BaseURL);
        }
        [Test]
        public void TC003_Create_New_Game()
        {
          
            new LoginPage()
                    .Enter_Windows_Credentials(Data.Username, Data.Password)
                    .Switched_to_ContoleCenter_Window()
                    .Verify_the_login_user_profileNot_Visible(Data.Profile);

            new HomePage()
                    .Verify_Create_New_Game_Button()
                    .Verify_Game_Name(Data.GameName)
                    .Verifiy_click_Start_Date()
                    .Verify_Click_End_Date()
                    .Verify_Submit_New_Game();
        }
        [Test]
        public void TC004_Cancel_before_submit_New_game()
        {
            new LoginPage()
                   .Enter_Windows_Credentials(Data.Username, Data.Password)
                   .Switched_to_ContoleCenter_Window()
                   .Verify_the_login_user_profileNot_Visible(Data.Profile);

            new HomePage()
                    .Verify_Create_New_Game_Button()
                    .Verify_Game_Name(Data.GameName)
                    .Verifiy_click_Start_Date()
                    .Verify_Click_End_Date()
                    .Verify_Click_Cancel_button();
        }
        [Test]
         public void TC005_Select_Showing_Game()
        {
            new LoginPage()
                      .Enter_Windows_Credentials(Data.Username, Data.Password)
                      .Switched_to_ContoleCenter_Window()
                      .Verify_the_login_user_profileNot_Visible(Data.Profile);
            new HomePage()
                     .Verify_Select_Showing_Game(Data.selectgame);
        }

        [Test]
        public void TC006_Create_New_Team()
        {
            new LoginPage()
                   .Enter_Windows_Credentials(Data.Username, Data.Password)
                   .Switched_to_ContoleCenter_Window()
                   .Verify_the_login_user_profileNot_Visible(Data.Profile);
            new HomePage()
                    .Verify_Create_New_Team();
        }
    }
}
