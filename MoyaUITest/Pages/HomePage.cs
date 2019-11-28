using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestBase;
namespace MoyaUITest.Pages
{
    public class HomePage
    {
        readonly IWebDriver _driver;
        //Home page element locators 
        readonly By _Newgamebtn = By.XPath("//*[@id='root']/section/main/div[1]/div/div[4]/button[3]");
        readonly By _GameName = By.Id("gameName");
        readonly By _StarDate = By.XPath("//*[@id='gameStart']/div/input");
        readonly By _SelectStartdate = By.XPath("/html/body/div[3]/div/div/div/div/div[2]/div[2]/table/tbody/tr[3]/td[5]/div");
        readonly By _Enddate = By.XPath("//*[@id='gameEnd']/div/input");
        readonly By _SelectEnddate = By.XPath("/html/body/div[4]/div/div/div/div/div[2]/div[2]/table/tbody/tr[5]/td[7]/div");
        readonly By _Submitbtn = By.XPath("//*[contains(@type,'sub')] ");
        readonly By _Cancelbtn = By.XPath("/html/body/div[2]/div/div[2]/div/div/div[2]/form/p/button[1]");
        readonly By _selectgame = By.Name("Ascentic Game");
        readonly By _NewTeam = By.XPath("//*[@id='root']/section/main/div[2]/div/div[4]/h3/button");

        // Home page initialization 
        public HomePage()
        {
            _driver = DriverConnections.Browser;
        }

        // create new game button
        public HomePage Verify_Create_New_Game_Button()
        {
            Elements.Click(_driver, _Newgamebtn);
            return this;
        }
        public HomePage Verify_Game_Name(string gamaname)
        {
            Elements.SendKeys(_driver, _GameName, gamaname);
            return this;
        }

        public HomePage Verifiy_click_Start_Date()
        {
            Elements.Click(_driver, _StarDate);
            Elements.WaitUntilElementVisible(_driver, _StarDate);
            Elements.IsElementNotVisible(_driver, _StarDate);
            Elements.WaitUntilElementVisible(_driver, _SelectStartdate);
            Elements.Click(_driver, _SelectStartdate);
            return this;
        }                                                                  
        public HomePage Verify_Click_End_Date()
        {
            Elements.Click(_driver, _Enddate);
            Elements.WaitUntilElementVisible(_driver, _Enddate);
            Elements.WaitUntilElementVisible(_driver, _SelectEnddate);
            Elements.IsElementNotVisible(_driver, _Enddate);
            Elements.Click(_driver, _SelectEnddate);
            return this;
        }
        public HomePage Verify_Submit_New_Game()
        {
            Elements.WaitUntilElementVisible(_driver, _Submitbtn);
            if (Elements.IsElementVisible(_driver, _Submitbtn))
            {
                Elements.Click(_driver, _Submitbtn);
            }
            return this;
        }
        public HomePage Verify_Click_Cancel_button()
        {
            Elements.Click(_driver, _Cancelbtn);
            return this;
        }
        public HomePage Verify_Select_Showing_Game(string Mac)
        {
            Elements.Click(_driver, _selectgame);
            Elements.SendKeys(_driver, _selectgame, Mac);
            return this;
        }
        public HomePage Verify_Create_New_Team()
        {
            Elements.Click(_driver, _NewTeam);
            return this;
        }
    }

}

