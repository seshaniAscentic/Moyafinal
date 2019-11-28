using System;
using System.Collections.Generic;
using System.Text;

namespace MoyaUITest.DataObjects
{
    public class Rootobject
    {
        public Applicationsettings ApplicationSettings { get; set; }
        public Testsettings TestSettings { get; set; }
        public Caregiver Caregiver { get; set; }
        public Techperson TechPerson { get; set; }
        public Invaliduser InvalidUser { get; set; }
    }

    public class Applicationsettings
    {
        public string ApplicationName { get; set; }
        public string Version { get; set; }
        public string Environment { get; set; }
    }

    public class Testsettings
    {
        public string TestCatagory { get; set; }
        public string RunTime { get; set; }
    }

    public class Caregiver
    {
        public string Role { get; set; }
        public string Profile { get; set; }
    }

    public class Techperson
    {
        public string Role { get; set; }
        public string Profile { get; set; }
    }

    public class Invaliduser
    {
        public string Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
