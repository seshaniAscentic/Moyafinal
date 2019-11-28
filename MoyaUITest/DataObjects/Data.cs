using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoyaUITest.DataObjects
{
    public static class Data
    {
        // Enviornment specific test data
        // Getting from AutomatedUITest.runsettings file
        public static string BaseURL = TestContext.Parameters["BaseURL"];
        public static string BrowserType = TestContext.Parameters["BrowserType"];
        //Test Data
        public static string Username = TestContext.Parameters["Username"];
        public static string Password = TestContext.Parameters["Password"];
        public static string Profile = TestContext.Parameters["Profile"];

        // Testing specific test data getting from DataCollection.json file
        // Application Settings
        public static string ApplicationName = ReadJSON._data.ApplicationSettings.ApplicationName.ToString();
        public static string Version = ReadJSON._data.ApplicationSettings.Version.ToString();
        public static string Enviornment = ReadJSON._data.ApplicationSettings.Environment.ToString();
        //Test Settings
        public static string TestCatagory = ReadJSON._data.TestSettings.TestCatagory.ToString();
        public static string RunTime = ReadJSON._data.TestSettings.RunTime.ToString();
        //Caregiver Test Data
        public static string Care_Role = ReadJSON._data.Caregiver.Role.ToString();
        public static string Care_ProfileName = ReadJSON._data.Caregiver.Profile.ToString();
        //TechPerson Test Data
        public static string Tec_Role = ReadJSON._data.TechPerson.Role.ToString();
        public static string Tec_ProfileName = ReadJSON._data.TechPerson.Profile.ToString();
        //Invalid User Data
        public static string Bad_Role = ReadJSON._data.InvalidUser.Role.ToString();
        public static string Bad_Username = ReadJSON._data.InvalidUser.Username.ToString();
        public static string Bad_Password = ReadJSON._data.InvalidUser.Password.ToString();

        //NEW GAME DATA
        public static string GameName = TestContext.Parameters["Gamename"];

        // Select game
        public static string selectgame = TestContext.Parameters["Mac"];
    }
}
